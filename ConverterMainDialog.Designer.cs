namespace Blender_Converter
{
    partial class frmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dlgOpenObjectFile = new System.Windows.Forms.OpenFileDialog();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblObjectFileLabel = new System.Windows.Forms.Label();
            this.lblObjectFileName = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grpOutputType = new System.Windows.Forms.GroupBox();
            this.lnkJavaOptions = new System.Windows.Forms.LinkLabel();
            this.chkJava = new System.Windows.Forms.CheckBox();
            this.lblBaseFilename = new System.Windows.Forms.Label();
            this.txtBaseFilename = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnChooseOutput = new System.Windows.Forms.Button();
            this.txtOuputFolder = new System.Windows.Forms.TextBox();
            this.lstData = new System.Windows.Forms.ListBox();
            this.grpModelInfo = new System.Windows.Forms.GroupBox();
            this.lblVertices = new System.Windows.Forms.Label();
            this.lblVerticesLabel = new System.Windows.Forms.Label();
            this.lblFaces = new System.Windows.Forms.Label();
            this.lblFacesLabel = new System.Windows.Forms.Label();
            this.lblNormals = new System.Windows.Forms.Label();
            this.lblNormalsLabel = new System.Windows.Forms.Label();
            this.lblTexels = new System.Windows.Forms.Label();
            this.lblTexelsLabel = new System.Windows.Forms.Label();
            this.lblPositions = new System.Windows.Forms.Label();
            this.lblPostionLabel = new System.Windows.Forms.Label();
            this.dlgOutputFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.mnuMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.grpOutputType.SuspendLayout();
            this.grpModelInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dlgOpenObjectFile
            // 
            this.dlgOpenObjectFile.Filter = "Object Files (*.obj)|*.obj";
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(579, 24);
            this.mnuMain.TabIndex = 3;
            this.mnuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // lblObjectFileLabel
            // 
            this.lblObjectFileLabel.AutoSize = true;
            this.lblObjectFileLabel.Location = new System.Drawing.Point(3, 9);
            this.lblObjectFileLabel.Name = "lblObjectFileLabel";
            this.lblObjectFileLabel.Size = new System.Drawing.Size(60, 13);
            this.lblObjectFileLabel.TabIndex = 4;
            this.lblObjectFileLabel.Text = "Object File:";
            // 
            // lblObjectFileName
            // 
            this.lblObjectFileName.AutoSize = true;
            this.lblObjectFileName.Location = new System.Drawing.Point(69, 9);
            this.lblObjectFileName.Name = "lblObjectFileName";
            this.lblObjectFileName.Size = new System.Drawing.Size(57, 13);
            this.lblObjectFileName.TabIndex = 5;
            this.lblObjectFileName.Text = "Object File";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpOutputType);
            this.pnlMain.Controls.Add(this.lblBaseFilename);
            this.pnlMain.Controls.Add(this.txtBaseFilename);
            this.pnlMain.Controls.Add(this.btnGenerate);
            this.pnlMain.Controls.Add(this.btnChooseOutput);
            this.pnlMain.Controls.Add(this.txtOuputFolder);
            this.pnlMain.Controls.Add(this.lstData);
            this.pnlMain.Controls.Add(this.grpModelInfo);
            this.pnlMain.Controls.Add(this.lblObjectFileLabel);
            this.pnlMain.Controls.Add(this.lblObjectFileName);
            this.pnlMain.Enabled = false;
            this.pnlMain.Location = new System.Drawing.Point(13, 27);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(554, 395);
            this.pnlMain.TabIndex = 6;
            // 
            // grpOutputType
            // 
            this.grpOutputType.Controls.Add(this.lnkJavaOptions);
            this.grpOutputType.Controls.Add(this.chkJava);
            this.grpOutputType.Location = new System.Drawing.Point(15, 241);
            this.grpOutputType.Name = "grpOutputType";
            this.grpOutputType.Size = new System.Drawing.Size(523, 67);
            this.grpOutputType.TabIndex = 14;
            this.grpOutputType.TabStop = false;
            this.grpOutputType.Text = "Output";
            // 
            // lnkJavaOptions
            // 
            this.lnkJavaOptions.AutoSize = true;
            this.lnkJavaOptions.Location = new System.Drawing.Point(21, 39);
            this.lnkJavaOptions.Name = "lnkJavaOptions";
            this.lnkJavaOptions.Size = new System.Drawing.Size(69, 13);
            this.lnkJavaOptions.TabIndex = 11;
            this.lnkJavaOptions.TabStop = true;
            this.lnkJavaOptions.Text = "Java Options";
            this.lnkJavaOptions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkJavaOptions_LinkClicked);
            // 
            // chkJava
            // 
            this.chkJava.AutoSize = true;
            this.chkJava.Checked = true;
            this.chkJava.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkJava.Location = new System.Drawing.Point(27, 19);
            this.chkJava.Name = "chkJava";
            this.chkJava.Size = new System.Drawing.Size(49, 17);
            this.chkJava.TabIndex = 10;
            this.chkJava.Text = "Java";
            this.chkJava.UseVisualStyleBackColor = true;
            this.chkJava.CheckedChanged += new System.EventHandler(this.EnableGenerateCommand);
            this.chkJava.CheckStateChanged += new System.EventHandler(this.EnableGenerateCommand);
            // 
            // lblBaseFilename
            // 
            this.lblBaseFilename.AutoSize = true;
            this.lblBaseFilename.Location = new System.Drawing.Point(12, 199);
            this.lblBaseFilename.Name = "lblBaseFilename";
            this.lblBaseFilename.Size = new System.Drawing.Size(79, 13);
            this.lblBaseFilename.TabIndex = 13;
            this.lblBaseFilename.Text = "Base Filename:";
            // 
            // txtBaseFilename
            // 
            this.txtBaseFilename.Location = new System.Drawing.Point(97, 196);
            this.txtBaseFilename.Name = "txtBaseFilename";
            this.txtBaseFilename.Size = new System.Drawing.Size(159, 20);
            this.txtBaseFilename.TabIndex = 12;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Enabled = false;
            this.btnGenerate.Location = new System.Drawing.Point(15, 336);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(126, 23);
            this.btnGenerate.TabIndex = 11;
            this.btnGenerate.Text = "Generate Code";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnChooseOutput
            // 
            this.btnChooseOutput.Location = new System.Drawing.Point(407, 155);
            this.btnChooseOutput.Name = "btnChooseOutput";
            this.btnChooseOutput.Size = new System.Drawing.Size(131, 23);
            this.btnChooseOutput.TabIndex = 9;
            this.btnChooseOutput.Text = "Choose Output Folder";
            this.btnChooseOutput.UseVisualStyleBackColor = true;
            this.btnChooseOutput.Click += new System.EventHandler(this.btnChooseOutput_Click);
            // 
            // txtOuputFolder
            // 
            this.txtOuputFolder.Location = new System.Drawing.Point(6, 157);
            this.txtOuputFolder.Name = "txtOuputFolder";
            this.txtOuputFolder.Size = new System.Drawing.Size(395, 20);
            this.txtOuputFolder.TabIndex = 8;
            // 
            // lstData
            // 
            this.lstData.FormattingEnabled = true;
            this.lstData.Location = new System.Drawing.Point(355, 43);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(183, 69);
            this.lstData.TabIndex = 7;
            // 
            // grpModelInfo
            // 
            this.grpModelInfo.Controls.Add(this.lblVertices);
            this.grpModelInfo.Controls.Add(this.lblVerticesLabel);
            this.grpModelInfo.Controls.Add(this.lblFaces);
            this.grpModelInfo.Controls.Add(this.lblFacesLabel);
            this.grpModelInfo.Controls.Add(this.lblNormals);
            this.grpModelInfo.Controls.Add(this.lblNormalsLabel);
            this.grpModelInfo.Controls.Add(this.lblTexels);
            this.grpModelInfo.Controls.Add(this.lblTexelsLabel);
            this.grpModelInfo.Controls.Add(this.lblPositions);
            this.grpModelInfo.Controls.Add(this.lblPostionLabel);
            this.grpModelInfo.Location = new System.Drawing.Point(6, 40);
            this.grpModelInfo.Name = "grpModelInfo";
            this.grpModelInfo.Size = new System.Drawing.Size(343, 72);
            this.grpModelInfo.TabIndex = 6;
            this.grpModelInfo.TabStop = false;
            this.grpModelInfo.Text = "Model Info";
            // 
            // lblVertices
            // 
            this.lblVertices.AutoSize = true;
            this.lblVertices.Location = new System.Drawing.Point(61, 25);
            this.lblVertices.Name = "lblVertices";
            this.lblVertices.Size = new System.Drawing.Size(35, 13);
            this.lblVertices.TabIndex = 9;
            this.lblVertices.Text = "label1";
            // 
            // lblVerticesLabel
            // 
            this.lblVerticesLabel.AutoSize = true;
            this.lblVerticesLabel.Location = new System.Drawing.Point(6, 25);
            this.lblVerticesLabel.Name = "lblVerticesLabel";
            this.lblVerticesLabel.Size = new System.Drawing.Size(48, 13);
            this.lblVerticesLabel.TabIndex = 8;
            this.lblVerticesLabel.Text = "Vertices:";
            this.lblVerticesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFaces
            // 
            this.lblFaces.AutoSize = true;
            this.lblFaces.Location = new System.Drawing.Point(285, 42);
            this.lblFaces.Name = "lblFaces";
            this.lblFaces.Size = new System.Drawing.Size(35, 13);
            this.lblFaces.TabIndex = 7;
            this.lblFaces.Text = "label1";
            this.lblFaces.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFacesLabel
            // 
            this.lblFacesLabel.AutoSize = true;
            this.lblFacesLabel.Location = new System.Drawing.Point(241, 42);
            this.lblFacesLabel.Name = "lblFacesLabel";
            this.lblFacesLabel.Size = new System.Drawing.Size(39, 13);
            this.lblFacesLabel.TabIndex = 6;
            this.lblFacesLabel.Text = "Faces:";
            this.lblFacesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNormals
            // 
            this.lblNormals.AutoSize = true;
            this.lblNormals.Location = new System.Drawing.Point(174, 42);
            this.lblNormals.Name = "lblNormals";
            this.lblNormals.Size = new System.Drawing.Size(35, 13);
            this.lblNormals.TabIndex = 5;
            this.lblNormals.Text = "label2";
            // 
            // lblNormalsLabel
            // 
            this.lblNormalsLabel.AutoSize = true;
            this.lblNormalsLabel.Location = new System.Drawing.Point(120, 42);
            this.lblNormalsLabel.Name = "lblNormalsLabel";
            this.lblNormalsLabel.Size = new System.Drawing.Size(48, 13);
            this.lblNormalsLabel.TabIndex = 4;
            this.lblNormalsLabel.Text = "Normals:";
            this.lblNormalsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTexels
            // 
            this.lblTexels.AutoSize = true;
            this.lblTexels.Location = new System.Drawing.Point(286, 25);
            this.lblTexels.Name = "lblTexels";
            this.lblTexels.Size = new System.Drawing.Size(35, 13);
            this.lblTexels.TabIndex = 3;
            this.lblTexels.Text = "label1";
            // 
            // lblTexelsLabel
            // 
            this.lblTexelsLabel.AutoSize = true;
            this.lblTexelsLabel.Location = new System.Drawing.Point(239, 25);
            this.lblTexelsLabel.Name = "lblTexelsLabel";
            this.lblTexelsLabel.Size = new System.Drawing.Size(41, 13);
            this.lblTexelsLabel.TabIndex = 2;
            this.lblTexelsLabel.Text = "Texels:";
            this.lblTexelsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPositions
            // 
            this.lblPositions.AutoSize = true;
            this.lblPositions.Location = new System.Drawing.Point(174, 25);
            this.lblPositions.Name = "lblPositions";
            this.lblPositions.Size = new System.Drawing.Size(35, 13);
            this.lblPositions.TabIndex = 1;
            this.lblPositions.Text = "label1";
            // 
            // lblPostionLabel
            // 
            this.lblPostionLabel.AutoSize = true;
            this.lblPostionLabel.Location = new System.Drawing.Point(116, 25);
            this.lblPostionLabel.Name = "lblPostionLabel";
            this.lblPostionLabel.Size = new System.Drawing.Size(52, 13);
            this.lblPostionLabel.TabIndex = 0;
            this.lblPostionLabel.Text = "Positions:";
            this.lblPostionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 434);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blender Converter";
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.grpOutputType.ResumeLayout(false);
            this.grpOutputType.PerformLayout();
            this.grpModelInfo.ResumeLayout(false);
            this.grpModelInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog dlgOpenObjectFile;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Label lblObjectFileLabel;
        private System.Windows.Forms.Label lblObjectFileName;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpModelInfo;
        private System.Windows.Forms.Label lblVertices;
        private System.Windows.Forms.Label lblVerticesLabel;
        private System.Windows.Forms.Label lblFaces;
        private System.Windows.Forms.Label lblFacesLabel;
        private System.Windows.Forms.Label lblNormals;
        private System.Windows.Forms.Label lblNormalsLabel;
        private System.Windows.Forms.Label lblTexels;
        private System.Windows.Forms.Label lblTexelsLabel;
        private System.Windows.Forms.Label lblPositions;
        private System.Windows.Forms.Label lblPostionLabel;
        private System.Windows.Forms.ListBox lstData;
        private System.Windows.Forms.Button btnChooseOutput;
        private System.Windows.Forms.TextBox txtOuputFolder;
        private System.Windows.Forms.FolderBrowserDialog dlgOutputFolder;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.CheckBox chkJava;
        private System.Windows.Forms.GroupBox grpOutputType;
        private System.Windows.Forms.Label lblBaseFilename;
        private System.Windows.Forms.TextBox txtBaseFilename;
        private System.Windows.Forms.LinkLabel lnkJavaOptions;
    }
}

