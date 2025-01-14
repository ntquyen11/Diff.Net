using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Menees;
using Menees.Diffs;
using Menees.Windows.Forms;
namespace Diff.Net
{
	partial class DirDiffDialog
	{
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnLeft;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnRight;
		private System.Windows.Forms.Button btnSwap;
		private System.Windows.Forms.ComboBox cbFilters;
		private System.Windows.Forms.CheckBox chkIgnoreDirectoryComparison;
		private System.Windows.Forms.CheckBox chkOnlyIfShift;
		private System.Windows.Forms.CheckBox chkRecursive;
            private System.Windows.Forms.CheckBox chkLineByLine;
		private System.Windows.Forms.CheckBox chkShowDifferent;
		private System.Windows.Forms.CheckBox chkShowOnlyInA;
		private System.Windows.Forms.CheckBox chkShowOnlyInB;
		private System.Windows.Forms.CheckBox chkShowSame;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox edtLeft;
		private System.Windows.Forms.TextBox edtRight;
		private System.Windows.Forms.GroupBox grpFileFilters;
		private System.Windows.Forms.GroupBox grpGeneral;
		private System.Windows.Forms.GroupBox grpMatched;
		private System.Windows.Forms.GroupBox grpMismatched;
		private System.Windows.Forms.Label lblLeft;
		private System.Windows.Forms.Label lblRight;
		private System.Windows.Forms.RadioButton rbExclude;
		private System.Windows.Forms.RadioButton rbInclude;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkIgnoreDirectoryComparison = new System.Windows.Forms.CheckBox();
            this.chkRecursive = new System.Windows.Forms.CheckBox();
            this.chkShowSame = new System.Windows.Forms.CheckBox();
            this.chkShowDifferent = new System.Windows.Forms.CheckBox();
            this.chkShowOnlyInB = new System.Windows.Forms.CheckBox();
            this.chkShowOnlyInA = new System.Windows.Forms.CheckBox();
            this.edtLeft = new System.Windows.Forms.TextBox();
            this.edtRight = new System.Windows.Forms.TextBox();
            this.grpMismatched = new System.Windows.Forms.GroupBox();
            this.lblRight = new System.Windows.Forms.Label();
            this.lblLeft = new System.Windows.Forms.Label();
            this.grpMatched = new System.Windows.Forms.GroupBox();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.chkLineByLine = new System.Windows.Forms.CheckBox();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.grpFileFilters = new System.Windows.Forms.GroupBox();
            this.rbExclude = new System.Windows.Forms.RadioButton();
            this.rbInclude = new System.Windows.Forms.RadioButton();
            this.cbFilters = new System.Windows.Forms.ComboBox();
            this.btnSwap = new System.Windows.Forms.Button();
            this.chkOnlyIfShift = new System.Windows.Forms.CheckBox();
            this.grpMismatched.SuspendLayout();
            this.grpMatched.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            this.grpFileFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(378, 513);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 37);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(263, 513);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(103, 37);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.OK_Click);
            // 
            // chkIgnoreDirectoryComparison
            // 
            this.chkIgnoreDirectoryComparison.AutoSize = true;
            this.chkIgnoreDirectoryComparison.Checked = true;
            this.chkIgnoreDirectoryComparison.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIgnoreDirectoryComparison.Location = new System.Drawing.Point(16, 99);
            this.chkIgnoreDirectoryComparison.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkIgnoreDirectoryComparison.Name = "chkIgnoreDirectoryComparison";
            this.chkIgnoreDirectoryComparison.Size = new System.Drawing.Size(186, 24);
            this.chkIgnoreDirectoryComparison.TabIndex = 2;
            this.chkIgnoreDirectoryComparison.Text = "Show If Same Directory";
            // 
            // chkRecursive
            // 
            this.chkRecursive.AutoSize = true;
            this.chkRecursive.Checked = true;
            this.chkRecursive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecursive.Location = new System.Drawing.Point(16, 33);
            this.chkRecursive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkRecursive.Name = "chkRecursive";
            this.chkRecursive.Size = new System.Drawing.Size(93, 24);
            this.chkRecursive.TabIndex = 0;
            this.chkRecursive.Text = "Recursive";
            // 
            // chkShowSame
            // 
            this.chkShowSame.AutoSize = true;
            this.chkShowSame.Checked = true;
            this.chkShowSame.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowSame.Location = new System.Drawing.Point(16, 65);
            this.chkShowSame.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkShowSame.Name = "chkShowSame";
            this.chkShowSame.Size = new System.Drawing.Size(148, 24);
            this.chkShowSame.TabIndex = 1;
            this.chkShowSame.Text = "Show If Same File";
            // 
            // chkShowDifferent
            // 
            this.chkShowDifferent.AutoSize = true;
            this.chkShowDifferent.Checked = true;
            this.chkShowDifferent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowDifferent.Location = new System.Drawing.Point(16, 33);
            this.chkShowDifferent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkShowDifferent.Name = "chkShowDifferent";
            this.chkShowDifferent.Size = new System.Drawing.Size(143, 24);
            this.chkShowDifferent.TabIndex = 0;
            this.chkShowDifferent.Text = "Show If Different";
            // 
            // chkShowOnlyInB
            // 
            this.chkShowOnlyInB.AutoSize = true;
            this.chkShowOnlyInB.Checked = true;
            this.chkShowOnlyInB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowOnlyInB.Location = new System.Drawing.Point(16, 65);
            this.chkShowOnlyInB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkShowOnlyInB.Name = "chkShowOnlyInB";
            this.chkShowOnlyInB.Size = new System.Drawing.Size(176, 24);
            this.chkShowOnlyInB.TabIndex = 1;
            this.chkShowOnlyInB.Text = "Show If Only On Right";
            // 
            // chkShowOnlyInA
            // 
            this.chkShowOnlyInA.AutoSize = true;
            this.chkShowOnlyInA.Checked = true;
            this.chkShowOnlyInA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowOnlyInA.Location = new System.Drawing.Point(16, 33);
            this.chkShowOnlyInA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkShowOnlyInA.Name = "chkShowOnlyInA";
            this.chkShowOnlyInA.Size = new System.Drawing.Size(166, 24);
            this.chkShowOnlyInA.TabIndex = 0;
            this.chkShowOnlyInA.Text = "Show If Only On Left";
            // 
            // edtLeft
            // 
            this.edtLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtLeft.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.edtLeft.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.edtLeft.Location = new System.Drawing.Point(66, 20);
            this.edtLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.edtLeft.Name = "edtLeft";
            this.edtLeft.Size = new System.Drawing.Size(369, 27);
            this.edtLeft.TabIndex = 1;
            this.edtLeft.TextChanged += new System.EventHandler(this.Edit_TextChanged);
            // 
            // edtRight
            // 
            this.edtRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtRight.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.edtRight.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.edtRight.Location = new System.Drawing.Point(66, 65);
            this.edtRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.edtRight.Name = "edtRight";
            this.edtRight.Size = new System.Drawing.Size(369, 27);
            this.edtRight.TabIndex = 4;
            this.edtRight.TextChanged += new System.EventHandler(this.Edit_TextChanged);
            // 
            // grpMismatched
            // 
            this.grpMismatched.Controls.Add(this.chkShowOnlyInA);
            this.grpMismatched.Controls.Add(this.chkShowOnlyInB);
            this.grpMismatched.Location = new System.Drawing.Point(16, 256);
            this.grpMismatched.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpMismatched.Name = "grpMismatched";
            this.grpMismatched.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpMismatched.Size = new System.Drawing.Size(225, 112);
            this.grpMismatched.TabIndex = 7;
            this.grpMismatched.TabStop = false;
            this.grpMismatched.Text = "Mismatched Items";
            // 
            // lblRight
            // 
            this.lblRight.AutoSize = true;
            this.lblRight.Location = new System.Drawing.Point(11, 69);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(47, 20);
            this.lblRight.TabIndex = 3;
            this.lblRight.Text = "Right:";
            // 
            // lblLeft
            // 
            this.lblLeft.AutoSize = true;
            this.lblLeft.Location = new System.Drawing.Point(11, 23);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(37, 20);
            this.lblLeft.TabIndex = 0;
            this.lblLeft.Text = "Left:";
            // 
            // grpMatched
            // 
            this.grpMatched.Controls.Add(this.chkShowSame);
            this.grpMatched.Controls.Add(this.chkIgnoreDirectoryComparison);
            this.grpMatched.Controls.Add(this.chkShowDifferent);
            this.grpMatched.Location = new System.Drawing.Point(253, 256);
            this.grpMatched.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpMatched.Name = "grpMatched";
            this.grpMatched.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpMatched.Size = new System.Drawing.Size(225, 197);
            this.grpMatched.TabIndex = 9;
            this.grpMatched.TabStop = false;
            this.grpMatched.Text = "Matched Items";
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.chkRecursive);
            this.grpGeneral.Controls.Add(this.chkLineByLine);
            this.grpGeneral.Location = new System.Drawing.Point(16, 375);
            this.grpGeneral.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpGeneral.Size = new System.Drawing.Size(225, 97);
            this.grpGeneral.TabIndex = 8;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            // 
            // chkLineByLine
            // 
            this.chkLineByLine.AutoSize = true;
            this.chkLineByLine.Location = new System.Drawing.Point(16, 66);
            this.chkLineByLine.Name = "chkLineByLine";
            this.chkLineByLine.Size = new System.Drawing.Size(176, 24);
            this.chkLineByLine.TabIndex = 1;
            this.chkLineByLine.Text = "Compare Folder Loop";
            this.chkLineByLine.UseVisualStyleBackColor = true;
            // 
            // btnRight
            // 
            this.btnRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRight.Location = new System.Drawing.Point(447, 65);
            this.btnRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(33, 33);
            this.btnRight.TabIndex = 5;
            this.btnRight.Text = "...";
            this.btnRight.Click += new System.EventHandler(this.Right_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLeft.Location = new System.Drawing.Point(447, 20);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(33, 32);
            this.btnLeft.TabIndex = 2;
            this.btnLeft.Text = "...";
            this.btnLeft.Click += new System.EventHandler(this.Left_Click);
            // 
            // grpFileFilters
            // 
            this.grpFileFilters.Controls.Add(this.rbExclude);
            this.grpFileFilters.Controls.Add(this.rbInclude);
            this.grpFileFilters.Controls.Add(this.cbFilters);
            this.grpFileFilters.Location = new System.Drawing.Point(16, 112);
            this.grpFileFilters.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpFileFilters.Name = "grpFileFilters";
            this.grpFileFilters.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpFileFilters.Size = new System.Drawing.Size(462, 131);
            this.grpFileFilters.TabIndex = 6;
            this.grpFileFilters.TabStop = false;
            this.grpFileFilters.Text = "File Filters";
            // 
            // rbExclude
            // 
            this.rbExclude.AutoSize = true;
            this.rbExclude.Location = new System.Drawing.Point(274, 85);
            this.rbExclude.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbExclude.Name = "rbExclude";
            this.rbExclude.Size = new System.Drawing.Size(81, 24);
            this.rbExclude.TabIndex = 2;
            this.rbExclude.Text = "Exclude";
            // 
            // rbInclude
            // 
            this.rbInclude.AutoSize = true;
            this.rbInclude.Checked = true;
            this.rbInclude.Location = new System.Drawing.Point(98, 85);
            this.rbInclude.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbInclude.Name = "rbInclude";
            this.rbInclude.Size = new System.Drawing.Size(78, 24);
            this.rbInclude.TabIndex = 1;
            this.rbInclude.TabStop = true;
            this.rbInclude.Text = "Include";
            // 
            // cbFilters
            // 
            this.cbFilters.Location = new System.Drawing.Point(16, 33);
            this.cbFilters.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbFilters.MaxDropDownItems = 10;
            this.cbFilters.Name = "cbFilters";
            this.cbFilters.Size = new System.Drawing.Size(428, 28);
            this.cbFilters.TabIndex = 0;
            this.cbFilters.TextChanged += new System.EventHandler(this.Filters_TextChanged);
            // 
            // btnSwap
            // 
            this.btnSwap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSwap.Location = new System.Drawing.Point(147, 513);
            this.btnSwap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.Size = new System.Drawing.Size(103, 37);
            this.btnSwap.TabIndex = 11;
            this.btnSwap.Text = "&Swap";
            this.btnSwap.Click += new System.EventHandler(this.Swap_Click);
            // 
            // chkOnlyIfShift
            // 
            this.chkOnlyIfShift.AutoSize = true;
            this.chkOnlyIfShift.Location = new System.Drawing.Point(16, 472);
            this.chkOnlyIfShift.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkOnlyIfShift.Name = "chkOnlyIfShift";
            this.chkOnlyIfShift.Size = new System.Drawing.Size(245, 24);
            this.chkOnlyIfShift.TabIndex = 10;
            this.chkOnlyIfShift.Text = "Only Show When Shift Is Pressed";
            // 
            // DirDiffDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(494, 567);
            this.Controls.Add(this.chkOnlyIfShift);
            this.Controls.Add(this.btnSwap);
            this.Controls.Add(this.grpFileFilters);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.grpGeneral);
            this.Controls.Add(this.grpMatched);
            this.Controls.Add(this.lblRight);
            this.Controls.Add(this.lblLeft);
            this.Controls.Add(this.edtLeft);
            this.Controls.Add(this.edtRight);
            this.Controls.Add(this.grpMismatched);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DirDiffDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Compare Directories";
            this.Load += new System.EventHandler(this.DirDiffDlg_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.DirDiffDlg_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.DirDiffDlg_DragEnter);
            this.grpMismatched.ResumeLayout(false);
            this.grpMismatched.PerformLayout();
            this.grpMatched.ResumeLayout(false);
            this.grpMatched.PerformLayout();
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.grpFileFilters.ResumeLayout(false);
            this.grpFileFilters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		// private CheckBox chkLineByLine;
	}
}

