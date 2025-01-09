namespace Diff.Net
{
	#region Using Directives

	using System;
	using System.ComponentModel;
	using System.Diagnostics.CodeAnalysis;
	using System.Drawing;
	using System.IO;
	using System.IO.Compression;
	using System.Linq;
	using System.Reflection;
	using System.Threading;
	using System.Windows.Forms;
	using Menees;
	using Menees.Diffs.Windows.Forms;
	using Menees.Windows.Forms;

	#endregion

	internal sealed partial class MainForm : ExtendedForm
	{
		#region Private Data Members

		private IDifferenceDialog? currentDifferenceDlg;

		#endregion

		#region Constructors

		public MainForm()
		{
			this.InitializeComponent();
			this.Text = ApplicationInfo.ApplicationName;

			// Turn off the 3D border for the MDI client area, so the app looks more modern.
			WindowsUtility.SetMdiClientBorderStyle(this, BorderStyle.None);

			Application.Idle += this.UpdateUIOnIdle;
			Options.OptionsChanged += this.Options_OptionsChanged;
		}

		#endregion

		#region Private Properties

		private bool NewChildShouldBeMaximized
		{
			get
			{
				bool result = true;

				Form child = this.ActiveMdiChild;
				if (child != null)
				{
					result = child.WindowState == FormWindowState.Maximized;
				}

				return result;
			}
		}

		#endregion

		#region Public Methods

		public static void HandleDragEnter(DragEventArgs e)
		{
			if (e.Data?.GetDataPresent(DataFormats.FileDrop) ?? false)
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		public void HandleDragDrop(DragEventArgs e)
		{
			if (e.Data?.GetDataPresent(DataFormats.FileDrop) ?? false)
			{
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

				// Post a message back to ourselves to process these files.
				// It isn't safe to pop up a modal during an OLE/shell drop.
				this.PostFiles(files, false);
			}
		}

		public void ShowFileDifferences(string fileNameA, string fileNameB, DialogDisplay display)
		{
			using (FileDiffDialog dialog = new())
			{
				dialog.NameA = fileNameA;
				dialog.NameB = fileNameB;
				if (this.GetDialogResult(dialog, display) == DialogResult.OK)
				{
					Options.LastFileA = dialog.NameA;
					Options.LastFileB = dialog.NameB;
					int lastIndexA = dialog.NameA.LastIndexOf('\\');
					int lastIndexB = dialog.NameB.LastIndexOf('\\');
					if (
						Options.CompareType == CompareType.Zip
						&& Path.GetExtension(dialog.NameA).Equals(".zip", StringComparison.OrdinalIgnoreCase)
						&& Path.GetExtension(dialog.NameB).Equals(".zip", StringComparison.OrdinalIgnoreCase))
					{
						string dirA = dialog.NameA.Substring(0, lastIndexA);
						string dirB = dialog.NameB.Substring(0, lastIndexB);
						string fileA = Path.GetFileNameWithoutExtension(dialog.NameA);
						string fileB = Path.GetFileNameWithoutExtension(dialog.NameB);
						string extractFileA = dirA + '\\' + fileA;
						string extractFileB = dirB + '\\' + fileB;
						if (Directory.Exists(extractFileA))
						{
							Directory.Delete(extractFileA, recursive: true);
							Directory.CreateDirectory(extractFileA);
						}

						if (Directory.Exists(extractFileB))
						{
							Directory.Delete(extractFileB, recursive: true);
							Directory.CreateDirectory(extractFileB);
						}

						ZipFile.ExtractToDirectory(dialog.NameA, extractFileA);
						ZipFile.ExtractToDirectory(dialog.NameB, extractFileB);

						// get all fileZip in subfolder and extract them
						string[] zipFilesA = Directory.GetFiles(extractFileA, "*.zip", SearchOption.AllDirectories);
						string[] zipFilesB = Directory.GetFiles(extractFileB, "*.zip", SearchOption.AllDirectories);
						if (zipFilesA.Length > 0)
							{
								foreach (string zipFile in zipFilesA)
								{
								int lastIndex = zipFile.LastIndexOf('\\');
								string? dir = zipFile.Substring(0, lastIndex);
								string extractFile = Path.Combine(dir, Path.GetFileNameWithoutExtension(zipFile));
								if (Directory.Exists(extractFile))
										{
											Directory.Delete(extractFile);
											Directory.CreateDirectory(extractFile);
										}

								ZipFile.ExtractToDirectory(zipFile, extractFile);
								File.Delete(zipFile);
								}
							}

						if (zipFilesB.Length > 0)
						{
								foreach (string zipFile in zipFilesB)
								{
								int lastIndex = zipFile.LastIndexOf('\\');
								string? dir = zipFile.Substring(0, lastIndex);
								string extractFile = Path.Combine(dir, Path.GetFileNameWithoutExtension(zipFile));
								if (Directory.Exists(extractFile))
									{
									Directory.Delete(extractFile);
									Directory.CreateDirectory(extractFile);
									}

								ZipFile.ExtractToDirectory(zipFile, extractFile);
								File.Delete(zipFile);
								}
						}

						string[] directoriesA = Directory.GetDirectories(extractFileA, "*", SearchOption.AllDirectories);
						string[] directoriesB = Directory.GetDirectories(extractFileB, "*", SearchOption.AllDirectories);
						var leafDirectoriesA = directoriesA.Where(dir => Directory.GetDirectories(dir).Length == 0);
						var leafDirectoriesB = directoriesB.Where(dir => Directory.GetDirectories(dir).Length == 0);
						foreach (string dirLeft in leafDirectoriesA)
						{
							foreach (string dirRight in leafDirectoriesB)
							{
								this.ShowDifferences(dirLeft, dirRight, DiffType.Directory);
							}
						}

						this.ShowDifferences(extractFileA + '\\' + fileA, extractFileB + '\\' + fileB, DiffType.Directory);
					}
					else
					{
						this.ShowDifferences(dialog.NameA, dialog.NameB, DiffType.File);
					}
				}
			}
		}

		public void ShowTextDifferences(string textA, string textB)
		{
			Options.LastTextA = textA;
			Options.LastTextB = textB;
			if (Path.GetExtension(textA).Equals(".zip", StringComparison.OrdinalIgnoreCase)
			&& Path.GetExtension(textB).Equals(".zip", StringComparison.OrdinalIgnoreCase))
			{
				this.ShowDifferences(textA, textB, DiffType.Directory);
			}
			else
			{
				this.ShowDifferences(textA, textB, DiffType.Text);
			}
		}

		// show difference when clicking filename without showing difffiledialog
		public void ShowDirectDifferences(string fileNameA, string fileNameB)
		{
			this.ShowDifferences(fileNameA, fileNameB, DiffType.File);
		}
		#endregion

		#region Private Methods
		private static string BuildRecentItemMenuString(string itemA, string itemB) => itemA + "\n      " + itemB;

		private void FormSave_LoadSettings(object sender, SettingsEventArgs e)
		{
			Options.Load(e.SettingsNode.GetSubNode(nameof(Options)));
			DiffOptions.Load(e.SettingsNode.GetSubNode("DiffOptions"));

			this.ApplyOptions();

			// Handle command-line options
			string[] names = CommandLineProcessor.Names;
			if (names != null)
			{
				// Post a message to ourselves to process the command-line
				// arguments after the form finishes displaying.
				this.PostFiles(names, true);
			}
		}

#pragma warning disable CC0091 // Use static method. Designer likes instance-level event handlers.
		private void FormSave_SaveSettings(object sender, SettingsEventArgs e)
#pragma warning restore CC0091 // Use static method
		{
			Options.Save(e.SettingsNode.GetSubNode(nameof(Options)));
			DiffOptions.Save(e.SettingsNode.GetSubNode("DiffOptions"));
		}

		private DialogResult GetDialogResult(IDifferenceDialog dialog, DialogDisplay display)
		{
			DialogResult result = DialogResult.OK;

			bool showDialog = false;
			if (display == DialogDisplay.Always || dialog.RequiresInput)
			{
				showDialog = true;
			}
			else if (display == DialogDisplay.UseOption)
			{
				showDialog = !dialog.OnlyShowIfShiftPressed || Options.IsShiftPressed;
			}

			if (showDialog)
			{
				dialog.ShowShiftCheck = display != DialogDisplay.Always;

				this.currentDifferenceDlg = dialog;
				try
				{
					result = dialog.ShowDialog(this);
				}
				finally
				{
					this.currentDifferenceDlg = null;
				}
			}

			return result;
		}

		private void HandlePostedFiles(string[] files, bool commandLine)
		{
			int numFiles = files.Length;
			if (numFiles == 1 || numFiles == 2)
			{
				string fileNameA = files[0];
				string fileNameB = string.Empty;
				if (numFiles == 2)
				{
					fileNameB = files[1];
				}

				// See if the first arg is a file.  I'm using the File.Exists
				// method here instead of Options.FileExists because I really
				// always need to know what type of argument was passed in.
				bool fileExists = File.Exists(fileNameA);

				DialogDisplay display = DialogDisplay.UseOption;
				if (commandLine)
				{
					if (fileExists)
					{
						display = CommandLineProcessor.DisplayFileDialog;
					}
					else
					{
						display = CommandLineProcessor.DisplayDirDialog;
					}
				}

				// See if a diff dialog is currently displayed.  If so,
				// then we need to route the args to it instead of popping
				// up a new dialog.
				if (this.currentDifferenceDlg != null)
				{
					if (numFiles == 1)
					{
						if (this.currentDifferenceDlg.NameA.Length == 0)
						{
							this.currentDifferenceDlg.NameA = fileNameA;
						}
						else
						{
							this.currentDifferenceDlg.NameB = fileNameA;
						}
					}
					else
					{
						this.currentDifferenceDlg.NameA = fileNameA;
						this.currentDifferenceDlg.NameB = fileNameB;
					}
				}
				else if (fileExists)
				{
					this.ShowFileDifferences(fileNameA, fileNameB, display);
				}
				else
				{
					this.ShowDirDifferences(fileNameA, fileNameB, display);
				}
			}
		}

		private void MainForm_DragDrop(object sender, DragEventArgs e)
		{
			this.HandleDragDrop(e);
		}

#pragma warning disable CC0091 // Use static method. Designer likes instance-level event handlers.
		private void MainForm_DragEnter(object sender, DragEventArgs e)
#pragma warning restore CC0091 // Use static method
		{
			HandleDragEnter(e);
		}

		private void About_Click(object? sender, EventArgs e)
		{
			WindowsUtility.ShowAboutBox(this, Assembly.GetExecutingAssembly());
		}

		private void Cascade_Click(object? sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.Cascade);
		}

		private void CloseAll_Click(object? sender, EventArgs e)
		{
			foreach (Form child in this.MdiChildren)
			{
				child.Close();
			}
		}

		private void CompareDirectories_Click(object? sender, EventArgs e)
		{
			this.ShowDirDifferences(Options.LastDirA, Options.LastDirB, DialogDisplay.Always);
		}

		private void CompareFiles_Click(object? sender, EventArgs e)
		{
			this.ShowFileDifferences(Options.LastFileA, Options.LastFileB, DialogDisplay.Always);
		}

		private void CompareText_Click(object? sender, EventArgs e)
		{
			TextDiffForm textDiff = new();
			if (this.NewChildShouldBeMaximized)
			{
				textDiff.WindowState = FormWindowState.Maximized;
			}

			textDiff.MdiParent = this;
			textDiff.Show();
		}

		private void Exit_Click(object? sender, EventArgs e)
		{
			this.Close();
		}

		private void Options_Click(object? sender, EventArgs e)
		{
			using (OptionsDialog dialog = new())
			{
				dialog.ShowDialog(this);
			}
		}

		private void TileHorizontally_Click(object? sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void TileVertically_Click(object? sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileVertical);
		}

		private void PostFiles(string[] files, bool commandLine)
		{
			// Post a message back to ourselves to process these files.
			this.BeginInvoke(new Action<string[], bool>(this.HandlePostedFiles), new object[] { files, commandLine });
		}

		private void RecentDirs_ItemClick(object sender, RecentItemClickEventArgs e)
		{
			if (e.Values != null)
			{
				this.ShowDirDifferences(e.Values.ElementAt(0), e.Values.ElementAt(1), DialogDisplay.UseOption);
			}
		}

		private void RecentFiles_ItemClick(object sender, RecentItemClickEventArgs e)
		{
			if (e.Values != null)
			{
				this.ShowFileDifferences(e.Values.ElementAt(0), e.Values.ElementAt(1), DialogDisplay.UseOption);
			}
		}

		private void ReportError(string message)
		{
			Cursor.Current = Cursors.Default;
			WindowsUtility.ShowError(this, message);
		}

		[SuppressMessage(
			"Microsoft.Design",
			"CA1031:DoNotCatchGeneralExceptionTypes",
			Justification = "Top-level method for showing differences.")]
		private void ShowDifferences(string itemA, string itemB, DiffType diffType)
		{
			using (WaitCursor wc = new(this))
			{
				try
				{
					Form frmNew;
					if (diffType == DiffType.Directory)
					{
						frmNew = new DirDiffForm();
						this.RecentDirs.Add(BuildRecentItemMenuString(itemA, itemB), new string[] { itemA, itemB });
					}
					else
					{
						// Use a FileDiffForm for file or text diffs.
						frmNew = new FileDiffForm();

						if (diffType == DiffType.File)
						{
							this.RecentFiles.Add(BuildRecentItemMenuString(itemA, itemB), new string[] { itemA, itemB });
						}
					}

					if (this.NewChildShouldBeMaximized)
					{
						frmNew.WindowState = FormWindowState.Maximized;
					}

					frmNew.MdiParent = this;

					IDifferenceForm frmDiff = (IDifferenceForm)frmNew;
					frmDiff.ShowDifferences(new ShowDiffArgs(itemA, itemB, diffType));

					MdiTab? tab = this.mdiTabStrip.FindTab(frmNew);
					if (tab != null)
					{
						tab.ToolTipText = frmDiff.ToolTipText;
					}
				}
				catch (Exception ex)
				{
					this.ReportError(ex.Message);
				}
			}
		}

		private void ShowDirDifferences(string directoryA, string directoryB, DialogDisplay display)
		{
			using (DirDiffDialog dialog = new())
			{
				dialog.NameA = directoryA;
				dialog.NameB = directoryB;

				if (this.GetDialogResult(dialog, display) == DialogResult.OK)
				{
					Options.LastDirA = dialog.NameA;
					Options.LastDirB = dialog.NameB;

					this.ShowDifferences(dialog.NameA, dialog.NameB, DiffType.Directory);
				}
			}
		}

		[SuppressMessage(
			"Microsoft.Design",
			"CA1031:DoNotCatchGeneralExceptionTypes",
			Justification = "Application.Idle handlers must catch all exceptions.")]
		private void UpdateUIOnIdle(object? sender, EventArgs e)
		{
			try
			{
				Form child = this.ActiveMdiChild;
				if (child is IDifferenceForm frmChild)
				{
					frmChild.UpdateUI();
				}

				// There can be MDI children that are not IDifferenceForms (e.g., TextDiffForm).
				bool hasMdiChildren = child != null;
				this.mnuTileVertically.Enabled = hasMdiChildren;
				this.mnuTileHorizontally.Enabled = hasMdiChildren;
				this.mnuCascade.Enabled = hasMdiChildren;
				this.mnuCloseAll.Enabled = hasMdiChildren;
			}
			catch (Exception ex)
			{
				// We must explicitly call this because Application.Idle
				// doesn't run inside the normal ThreadException protection
				// that the Application provides for the main message pump.
				Application.OnThreadException(ex);
			}
		}

		private void Options_OptionsChanged(object? sender, EventArgs e)
		{
			this.ApplyOptions();
		}

		private void ApplyOptions()
		{
			// The MdiTabStrip manages its own visiblity by hiding when no tabs exist.  However,
			// it respects the control's Enabled property when deciding whether to add or remove
			// tabs and toggle the visibility.
			this.mdiTabStrip.Enabled = Options.ShowMdiTabs;

			if (!Options.ShowMdiTabs)
			{
				// The strip is disabled, so we have to force visibility off since the strip
				// won't do any checking of tab existence now.
				this.mdiTabStrip.Visible = false;
			}
			else
			{
				// The strip is enabled, so we need to let the strip decide whether
				// it should be visible based on whether any tabs exist.
				this.mdiTabStrip.BeginUpdate();
				this.mdiTabStrip.EndUpdate();

				// Make sure all the tab tooltips are up-to-date since windows may have
				// been opened while the tab strip was disabled.
				foreach (Form child in this.MdiChildren)
				{
					// Not all MDI children implement IDifferenceForm (e.g., TextDiffForm doesn't).
					if (child is IDifferenceForm form)
					{
						MdiTab? tab = this.mdiTabStrip.FindTab(child);
						if (tab != null && !string.IsNullOrEmpty(tab.ToolTipText))
						{
							tab.ToolTipText = form.ToolTipText;
						}
					}
				}
			}
		}

		private void CloseTab_Click(object? sender, EventArgs e)
		{
			this.mdiTabStrip.CloseActiveTab();
		}

		private void CloseAllButThisTab_Click(object? sender, EventArgs e)
		{
			this.mdiTabStrip.CloseAllButActiveTab();
		}

		private void MdiTabContext_Opening(object sender, CancelEventArgs e)
		{
			MdiTab? mouseOverTab = this.mdiTabStrip.FindTabAtScreenPoint(Cursor.Position);
			e.Cancel = mouseOverTab == null;
		}

		#endregion
	}
}
