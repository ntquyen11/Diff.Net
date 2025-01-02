namespace Diff.Net
{
    partial class CompareOptionsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.GroupBox typeGroup;
            System.Windows.Forms.GroupBox optionsGroup;
            this.compareZip = new System.Windows.Forms.RadioButton();
            this.compareBinary = new System.Windows.Forms.RadioButton();
            this.compareXml = new System.Windows.Forms.RadioButton();
            this.compareText = new System.Windows.Forms.RadioButton();
            this.compareAuto = new System.Windows.Forms.RadioButton();
            this.binaryFootprintLength = new System.Windows.Forms.NumericUpDown();
            this.binaryLabel = new System.Windows.Forms.Label();
            this.ignoreXmlWhitespace = new System.Windows.Forms.CheckBox();
            this.ignoreTextWhitespace = new System.Windows.Forms.CheckBox();
            this.ignoreCase = new System.Windows.Forms.CheckBox();
            typeGroup = new System.Windows.Forms.GroupBox();
            optionsGroup = new System.Windows.Forms.GroupBox();
            typeGroup.SuspendLayout();
            optionsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binaryFootprintLength)).BeginInit();
            this.SuspendLayout();
            // 
            // typeGroup
            // 
            typeGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            typeGroup.Controls.Add(this.compareZip);
            typeGroup.Controls.Add(this.compareBinary);
            typeGroup.Controls.Add(this.compareXml);
            typeGroup.Controls.Add(this.compareText);
            typeGroup.Controls.Add(this.compareAuto);
            typeGroup.Location = new System.Drawing.Point(5, 0);
            typeGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            typeGroup.Name = "typeGroup";
            typeGroup.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            typeGroup.Size = new System.Drawing.Size(107, 226);
            typeGroup.TabIndex = 0;
            typeGroup.TabStop = false;
            typeGroup.Text = "Compare";
            // 
            // compareZip
            // 
            this.compareZip.AutoSize = true;
            this.compareZip.Location = new System.Drawing.Point(16, 180);
            this.compareZip.Name = "compareZip";
            this.compareZip.Size = new System.Drawing.Size(51, 24);
            this.compareZip.TabIndex = 4;
            this.compareZip.TabStop = true;
            this.compareZip.Text = "ZIP";
            this.compareZip.UseVisualStyleBackColor = true;
            // 
            // compareBinary
            // 
            this.compareBinary.AutoSize = true;
            this.compareBinary.Location = new System.Drawing.Point(16, 148);
            this.compareBinary.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.compareBinary.Name = "compareBinary";
            this.compareBinary.Size = new System.Drawing.Size(71, 24);
            this.compareBinary.TabIndex = 3;
            this.compareBinary.TabStop = true;
            this.compareBinary.Text = "Binary";
            this.compareBinary.UseVisualStyleBackColor = true;
            // 
            // compareXml
            // 
            this.compareXml.AutoSize = true;
            this.compareXml.Location = new System.Drawing.Point(16, 111);
            this.compareXml.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.compareXml.Name = "compareXml";
            this.compareXml.Size = new System.Drawing.Size(59, 24);
            this.compareXml.TabIndex = 2;
            this.compareXml.TabStop = true;
            this.compareXml.Text = "XML";
            this.compareXml.UseVisualStyleBackColor = true;
            // 
            // compareText
            // 
            this.compareText.AutoSize = true;
            this.compareText.Location = new System.Drawing.Point(16, 74);
            this.compareText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.compareText.Name = "compareText";
            this.compareText.Size = new System.Drawing.Size(57, 24);
            this.compareText.TabIndex = 1;
            this.compareText.TabStop = true;
            this.compareText.Text = "Text";
            this.compareText.UseVisualStyleBackColor = true;
            // 
            // compareAuto
            // 
            this.compareAuto.AutoSize = true;
            this.compareAuto.Location = new System.Drawing.Point(16, 37);
            this.compareAuto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.compareAuto.Name = "compareAuto";
            this.compareAuto.Size = new System.Drawing.Size(62, 24);
            this.compareAuto.TabIndex = 0;
            this.compareAuto.TabStop = true;
            this.compareAuto.Text = "Auto";
            this.compareAuto.UseVisualStyleBackColor = true;
            // 
            // optionsGroup
            // 
            optionsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            optionsGroup.Controls.Add(this.binaryFootprintLength);
            optionsGroup.Controls.Add(this.binaryLabel);
            optionsGroup.Controls.Add(this.ignoreXmlWhitespace);
            optionsGroup.Controls.Add(this.ignoreTextWhitespace);
            optionsGroup.Controls.Add(this.ignoreCase);
            optionsGroup.Location = new System.Drawing.Point(123, 0);
            optionsGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            optionsGroup.Name = "optionsGroup";
            optionsGroup.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            optionsGroup.Size = new System.Drawing.Size(372, 226);
            optionsGroup.TabIndex = 1;
            optionsGroup.TabStop = false;
            optionsGroup.Text = "Options";
            // 
            // binaryFootprintLength
            // 
            this.binaryFootprintLength.Location = new System.Drawing.Point(187, 148);
            this.binaryFootprintLength.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.binaryFootprintLength.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.binaryFootprintLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.binaryFootprintLength.Name = "binaryFootprintLength";
            this.binaryFootprintLength.Size = new System.Drawing.Size(64, 27);
            this.binaryFootprintLength.TabIndex = 4;
            this.binaryFootprintLength.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // binaryLabel
            // 
            this.binaryLabel.AutoSize = true;
            this.binaryLabel.Location = new System.Drawing.Point(13, 151);
            this.binaryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.binaryLabel.Name = "binaryLabel";
            this.binaryLabel.Size = new System.Drawing.Size(167, 20);
            this.binaryLabel.TabIndex = 3;
            this.binaryLabel.Text = "Binary Footprint Length:";
            // 
            // ignoreXmlWhitespace
            // 
            this.ignoreXmlWhitespace.AutoSize = true;
            this.ignoreXmlWhitespace.Location = new System.Drawing.Point(16, 111);
            this.ignoreXmlWhitespace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ignoreXmlWhitespace.Name = "ignoreXmlWhitespace";
            this.ignoreXmlWhitespace.Size = new System.Drawing.Size(335, 24);
            this.ignoreXmlWhitespace.TabIndex = 2;
            this.ignoreXmlWhitespace.Text = "Ignore Insignificant Whitespace Nodes In XML";
            this.ignoreXmlWhitespace.UseVisualStyleBackColor = true;
            // 
            // ignoreTextWhitespace
            // 
            this.ignoreTextWhitespace.AutoSize = true;
            this.ignoreTextWhitespace.Location = new System.Drawing.Point(16, 74);
            this.ignoreTextWhitespace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ignoreTextWhitespace.Name = "ignoreTextWhitespace";
            this.ignoreTextWhitespace.Size = new System.Drawing.Size(343, 24);
            this.ignoreTextWhitespace.TabIndex = 1;
            this.ignoreTextWhitespace.Text = "Ignore Leading And Trailing Whitespace In Text";
            this.ignoreTextWhitespace.UseVisualStyleBackColor = true;
            // 
            // ignoreCase
            // 
            this.ignoreCase.AutoSize = true;
            this.ignoreCase.Location = new System.Drawing.Point(16, 37);
            this.ignoreCase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ignoreCase.Name = "ignoreCase";
            this.ignoreCase.Size = new System.Drawing.Size(156, 24);
            this.ignoreCase.TabIndex = 0;
            this.ignoreCase.Text = "Ignore Case In Text";
            this.ignoreCase.UseVisualStyleBackColor = true;
            // 
            // CompareOptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(optionsGroup);
            this.Controls.Add(typeGroup);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CompareOptionsControl";
            this.Size = new System.Drawing.Size(501, 234);
            this.Load += new System.EventHandler(this.CompareOptionsControl_Load);
            typeGroup.ResumeLayout(false);
            typeGroup.PerformLayout();
            optionsGroup.ResumeLayout(false);
            optionsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binaryFootprintLength)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton compareBinary;
        private System.Windows.Forms.RadioButton compareXml;
        private System.Windows.Forms.RadioButton compareText;
        private System.Windows.Forms.RadioButton compareAuto;
        private System.Windows.Forms.NumericUpDown binaryFootprintLength;
        private System.Windows.Forms.CheckBox ignoreXmlWhitespace;
        private System.Windows.Forms.CheckBox ignoreTextWhitespace;
        private System.Windows.Forms.CheckBox ignoreCase;
        private System.Windows.Forms.Label binaryLabel;
		private System.Windows.Forms.RadioButton compareZip;
	}
}
