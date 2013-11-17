namespace EasyPdfSigning
{
	partial class EasyForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EasyForm));
			this.label1 = new System.Windows.Forms.Label();
			this.InputFileText = new System.Windows.Forms.TextBox();
			this.BrowseInputButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.PageNum = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.LeftNum = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.BottomNum = new System.Windows.Forms.NumericUpDown();
			this.label10 = new System.Windows.Forms.Label();
			this.WidthNum = new System.Windows.Forms.NumericUpDown();
			this.label12 = new System.Windows.Forms.Label();
			this.HeightNum = new System.Windows.Forms.NumericUpDown();
			this.SignButton = new System.Windows.Forms.Button();
			this.ReasonCombo = new System.Windows.Forms.ComboBox();
			this.PagePreviewPanel = new System.Windows.Forms.Panel();
			this.SignaturePicture = new System.Windows.Forms.PictureBox();
			this.CertificateCombo = new System.Windows.Forms.ComboBox();
			this.PreviewPanel = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.WebLink = new System.Windows.Forms.LinkLabel();
			this.SelectCertButton = new System.Windows.Forms.Button();
			this.VisibleSignatureCheck = new System.Windows.Forms.CheckBox();
			this.CustomizeSignatureButton = new System.Windows.Forms.Button();
			this.BottomPanel = new System.Windows.Forms.Panel();
			this.renderWorker = new System.ComponentModel.BackgroundWorker();
			this.signWorker = new System.ComponentModel.BackgroundWorker();
			this.FileWarningPicture = new System.Windows.Forms.PictureBox();
			this.SignatureAppearancePanel = new System.Windows.Forms.Panel();
			this.line1 = new Unclassified.UI.Line();
			this.signSpinner = new Unclassified.UI.ProgressSpinner();
			this.mouseFilter1 = new Unclassified.MouseFilter(this.components);
			((System.ComponentModel.ISupportInitialize)(this.PageNum)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LeftNum)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BottomNum)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.WidthNum)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.HeightNum)).BeginInit();
			this.PagePreviewPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SignaturePicture)).BeginInit();
			this.PreviewPanel.SuspendLayout();
			this.BottomPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.FileWarningPicture)).BeginInit();
			this.SignatureAppearancePanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(455, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Dateiname des zu signierenden PDF-Dokuments: (oder Datei in dieses Fenster ziehen" +
    ")";
			// 
			// InputFileText
			// 
			this.InputFileText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.InputFileText.Location = new System.Drawing.Point(12, 27);
			this.InputFileText.Name = "InputFileText";
			this.InputFileText.Size = new System.Drawing.Size(352, 23);
			this.InputFileText.TabIndex = 1;
			this.InputFileText.Enter += new System.EventHandler(this.SelectableField_Enter);
			this.InputFileText.Leave += new System.EventHandler(this.InputFileText_Leave);
			// 
			// BrowseInputButton
			// 
			this.BrowseInputButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BrowseInputButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.BrowseInputButton.Location = new System.Drawing.Point(370, 25);
			this.BrowseInputButton.Name = "BrowseInputButton";
			this.BrowseInputButton.Size = new System.Drawing.Size(102, 25);
			this.BrowseInputButton.TabIndex = 2;
			this.BrowseInputButton.Text = "Durchsuchen...";
			this.BrowseInputButton.UseVisualStyleBackColor = true;
			this.BrowseInputButton.Click += new System.EventHandler(this.BrowseInputButton_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(225, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "Zertifikat zum Unterschreiben auswählen:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 119);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 15);
			this.label3.TabIndex = 6;
			this.label3.Text = "Grund der Unterschrift:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(-3, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(196, 15);
			this.label4.TabIndex = 9;
			this.label4.Text = "Position der sichtbaren Unterschrift:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(-3, 20);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(32, 15);
			this.label5.TabIndex = 10;
			this.label5.Text = "Seite";
			// 
			// PageNum
			// 
			this.PageNum.Location = new System.Drawing.Point(38, 18);
			this.PageNum.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.PageNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.PageNum.Name = "PageNum";
			this.PageNum.Size = new System.Drawing.Size(49, 23);
			this.PageNum.TabIndex = 11;
			this.PageNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.PageNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.PageNum.ValueChanged += new System.EventHandler(this.PageNum_ValueChanged);
			this.PageNum.Enter += new System.EventHandler(this.SelectableField_Enter);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(-3, 57);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(34, 15);
			this.label6.TabIndex = 12;
			this.label6.Text = "Links";
			// 
			// LeftNum
			// 
			this.LeftNum.Location = new System.Drawing.Point(38, 55);
			this.LeftNum.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.LeftNum.Name = "LeftNum";
			this.LeftNum.Size = new System.Drawing.Size(49, 23);
			this.LeftNum.TabIndex = 13;
			this.LeftNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.LeftNum.Value = new decimal(new int[] {
            140,
            0,
            0,
            0});
			this.LeftNum.ValueChanged += new System.EventHandler(this.LeftNum_ValueChanged);
			this.LeftNum.Enter += new System.EventHandler(this.SelectableField_Enter);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(-3, 86);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(39, 15);
			this.label8.TabIndex = 15;
			this.label8.Text = "Unten";
			// 
			// BottomNum
			// 
			this.BottomNum.Location = new System.Drawing.Point(38, 84);
			this.BottomNum.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.BottomNum.Name = "BottomNum";
			this.BottomNum.Size = new System.Drawing.Size(49, 23);
			this.BottomNum.TabIndex = 16;
			this.BottomNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.BottomNum.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
			this.BottomNum.ValueChanged += new System.EventHandler(this.BottomNum_ValueChanged);
			this.BottomNum.Enter += new System.EventHandler(this.SelectableField_Enter);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(-3, 123);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(37, 15);
			this.label10.TabIndex = 18;
			this.label10.Text = "Breite";
			// 
			// WidthNum
			// 
			this.WidthNum.Location = new System.Drawing.Point(38, 121);
			this.WidthNum.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.WidthNum.Name = "WidthNum";
			this.WidthNum.Size = new System.Drawing.Size(49, 23);
			this.WidthNum.TabIndex = 19;
			this.WidthNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.WidthNum.Value = new decimal(new int[] {
            52,
            0,
            0,
            0});
			this.WidthNum.ValueChanged += new System.EventHandler(this.WidthNum_ValueChanged);
			this.WidthNum.Enter += new System.EventHandler(this.SelectableField_Enter);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(-3, 152);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(36, 15);
			this.label12.TabIndex = 21;
			this.label12.Text = "Höhe";
			// 
			// HeightNum
			// 
			this.HeightNum.Location = new System.Drawing.Point(38, 150);
			this.HeightNum.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.HeightNum.Name = "HeightNum";
			this.HeightNum.Size = new System.Drawing.Size(49, 23);
			this.HeightNum.TabIndex = 22;
			this.HeightNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.HeightNum.Value = new decimal(new int[] {
            17,
            0,
            0,
            0});
			this.HeightNum.ValueChanged += new System.EventHandler(this.HeightNum_ValueChanged);
			this.HeightNum.Enter += new System.EventHandler(this.SelectableField_Enter);
			// 
			// SignButton
			// 
			this.SignButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SignButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.SignButton.Location = new System.Drawing.Point(340, 10);
			this.SignButton.Name = "SignButton";
			this.SignButton.Size = new System.Drawing.Size(134, 25);
			this.SignButton.TabIndex = 0;
			this.SignButton.Text = "Dokument signieren";
			this.SignButton.UseVisualStyleBackColor = true;
			this.SignButton.Click += new System.EventHandler(this.SignButton_Click);
			// 
			// ReasonCombo
			// 
			this.ReasonCombo.FormattingEnabled = true;
			this.ReasonCombo.Items.AddRange(new object[] {
            "Erstellt",
            "Review",
            "Freigabe"});
			this.ReasonCombo.Location = new System.Drawing.Point(143, 116);
			this.ReasonCombo.Name = "ReasonCombo";
			this.ReasonCombo.Size = new System.Drawing.Size(221, 23);
			this.ReasonCombo.TabIndex = 7;
			this.ReasonCombo.SelectedIndexChanged += new System.EventHandler(this.ReasonCombo_SelectedIndexChanged);
			this.ReasonCombo.TextUpdate += new System.EventHandler(this.ReasonCombo_TextUpdate);
			this.ReasonCombo.Enter += new System.EventHandler(this.SelectableField_Enter);
			// 
			// PagePreviewPanel
			// 
			this.PagePreviewPanel.BackColor = System.Drawing.SystemColors.Window;
			this.PagePreviewPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.PagePreviewPanel.Controls.Add(this.SignaturePicture);
			this.PagePreviewPanel.Location = new System.Drawing.Point(27, 17);
			this.PagePreviewPanel.Name = "PagePreviewPanel";
			this.PagePreviewPanel.Size = new System.Drawing.Size(115, 146);
			this.PagePreviewPanel.TabIndex = 0;
			// 
			// SignaturePicture
			// 
			this.SignaturePicture.BackColor = System.Drawing.SystemColors.WindowText;
			this.SignaturePicture.Location = new System.Drawing.Point(14, 34);
			this.SignaturePicture.Name = "SignaturePicture";
			this.SignaturePicture.Size = new System.Drawing.Size(64, 30);
			this.SignaturePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.SignaturePicture.TabIndex = 0;
			this.SignaturePicture.TabStop = false;
			// 
			// CertificateCombo
			// 
			this.CertificateCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CertificateCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CertificateCombo.FormattingEnabled = true;
			this.CertificateCombo.Location = new System.Drawing.Point(12, 79);
			this.CertificateCombo.Name = "CertificateCombo";
			this.CertificateCombo.Size = new System.Drawing.Size(352, 23);
			this.CertificateCombo.TabIndex = 4;
			this.CertificateCombo.SelectedIndexChanged += new System.EventHandler(this.CertificateCombo_SelectedIndexChanged);
			// 
			// PreviewPanel
			// 
			this.PreviewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.PreviewPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.PreviewPanel.Controls.Add(this.PagePreviewPanel);
			this.PreviewPanel.Location = new System.Drawing.Point(122, 18);
			this.PreviewPanel.Name = "PreviewPanel";
			this.PreviewPanel.Size = new System.Drawing.Size(338, 210);
			this.PreviewPanel.TabIndex = 25;
			this.PreviewPanel.Resize += new System.EventHandler(this.PreviewPanel_Resize);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(87, 57);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(29, 15);
			this.label7.TabIndex = 14;
			this.label7.Text = "mm";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(87, 86);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(29, 15);
			this.label9.TabIndex = 17;
			this.label9.Text = "mm";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(87, 123);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(29, 15);
			this.label11.TabIndex = 20;
			this.label11.Text = "mm";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(87, 152);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(29, 15);
			this.label13.TabIndex = 23;
			this.label13.Text = "mm";
			// 
			// WebLink
			// 
			this.WebLink.AutoSize = true;
			this.WebLink.Location = new System.Drawing.Point(9, 15);
			this.WebLink.Name = "WebLink";
			this.WebLink.Size = new System.Drawing.Size(149, 15);
			this.WebLink.TabIndex = 1;
			this.WebLink.TabStop = true;
			this.WebLink.Text = "Lizenz und Dokumentation";
			this.WebLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.WebLink_LinkClicked);
			// 
			// SelectCertButton
			// 
			this.SelectCertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SelectCertButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.SelectCertButton.Location = new System.Drawing.Point(370, 78);
			this.SelectCertButton.Name = "SelectCertButton";
			this.SelectCertButton.Size = new System.Drawing.Size(102, 25);
			this.SelectCertButton.TabIndex = 5;
			this.SelectCertButton.Text = "Details...";
			this.SelectCertButton.UseVisualStyleBackColor = true;
			this.SelectCertButton.Click += new System.EventHandler(this.SelectCertButton_Click);
			// 
			// VisibleSignatureCheck
			// 
			this.VisibleSignatureCheck.AutoSize = true;
			this.VisibleSignatureCheck.Checked = true;
			this.VisibleSignatureCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.VisibleSignatureCheck.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.VisibleSignatureCheck.Location = new System.Drawing.Point(12, 148);
			this.VisibleSignatureCheck.Name = "VisibleSignatureCheck";
			this.VisibleSignatureCheck.Size = new System.Drawing.Size(206, 20);
			this.VisibleSignatureCheck.TabIndex = 8;
			this.VisibleSignatureCheck.Text = "Signatur im Dokument darstellen";
			this.VisibleSignatureCheck.UseVisualStyleBackColor = true;
			this.VisibleSignatureCheck.CheckedChanged += new System.EventHandler(this.VisibleSignatureCheck_CheckedChanged);
			// 
			// CustomizeSignatureButton
			// 
			this.CustomizeSignatureButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.CustomizeSignatureButton.Location = new System.Drawing.Point(0, 187);
			this.CustomizeSignatureButton.Name = "CustomizeSignatureButton";
			this.CustomizeSignatureButton.Size = new System.Drawing.Size(114, 25);
			this.CustomizeSignatureButton.TabIndex = 24;
			this.CustomizeSignatureButton.Text = "Anpassen...";
			this.CustomizeSignatureButton.UseVisualStyleBackColor = true;
			this.CustomizeSignatureButton.Click += new System.EventHandler(this.CustomizeSignatureButton_Click);
			// 
			// BottomPanel
			// 
			this.BottomPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.BottomPanel.BackColor = System.Drawing.SystemColors.Control;
			this.BottomPanel.Controls.Add(this.signSpinner);
			this.BottomPanel.Controls.Add(this.WebLink);
			this.BottomPanel.Controls.Add(this.SignButton);
			this.BottomPanel.Location = new System.Drawing.Point(0, 417);
			this.BottomPanel.Name = "BottomPanel";
			this.BottomPanel.Size = new System.Drawing.Size(484, 45);
			this.BottomPanel.TabIndex = 27;
			// 
			// renderWorker
			// 
			this.renderWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.renderWorker_DoWork);
			this.renderWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.renderWorker_RunWorkerCompleted);
			// 
			// signWorker
			// 
			this.signWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.signWorker_DoWork);
			this.signWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.signWorker_RunWorkerCompleted);
			// 
			// FileWarningPicture
			// 
			this.FileWarningPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.FileWarningPicture.Image = global::EasyPdfSigning.Properties.Resources.Warning;
			this.FileWarningPicture.Location = new System.Drawing.Point(344, 31);
			this.FileWarningPicture.Name = "FileWarningPicture";
			this.FileWarningPicture.Size = new System.Drawing.Size(16, 16);
			this.FileWarningPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.FileWarningPicture.TabIndex = 30;
			this.FileWarningPicture.TabStop = false;
			this.FileWarningPicture.Visible = false;
			// 
			// SignatureAppearancePanel
			// 
			this.SignatureAppearancePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SignatureAppearancePanel.Controls.Add(this.label4);
			this.SignatureAppearancePanel.Controls.Add(this.label5);
			this.SignatureAppearancePanel.Controls.Add(this.PageNum);
			this.SignatureAppearancePanel.Controls.Add(this.label6);
			this.SignatureAppearancePanel.Controls.Add(this.CustomizeSignatureButton);
			this.SignatureAppearancePanel.Controls.Add(this.label7);
			this.SignatureAppearancePanel.Controls.Add(this.label9);
			this.SignatureAppearancePanel.Controls.Add(this.PreviewPanel);
			this.SignatureAppearancePanel.Controls.Add(this.label11);
			this.SignatureAppearancePanel.Controls.Add(this.HeightNum);
			this.SignatureAppearancePanel.Controls.Add(this.label13);
			this.SignatureAppearancePanel.Controls.Add(this.label12);
			this.SignatureAppearancePanel.Controls.Add(this.LeftNum);
			this.SignatureAppearancePanel.Controls.Add(this.label8);
			this.SignatureAppearancePanel.Controls.Add(this.WidthNum);
			this.SignatureAppearancePanel.Controls.Add(this.label10);
			this.SignatureAppearancePanel.Controls.Add(this.BottomNum);
			this.SignatureAppearancePanel.Location = new System.Drawing.Point(12, 174);
			this.SignatureAppearancePanel.Name = "SignatureAppearancePanel";
			this.SignatureAppearancePanel.Size = new System.Drawing.Size(460, 228);
			this.SignatureAppearancePanel.TabIndex = 31;
			// 
			// line1
			// 
			this.line1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.line1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this.line1.Location = new System.Drawing.Point(0, 416);
			this.line1.Name = "line1";
			this.line1.Size = new System.Drawing.Size(484, 1);
			this.line1.TabIndex = 29;
			this.line1.TabStop = false;
			// 
			// signSpinner
			// 
			this.signSpinner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.signSpinner.ForeColor = System.Drawing.SystemColors.Highlight;
			this.signSpinner.Location = new System.Drawing.Point(318, 15);
			this.signSpinner.Maximum = 100;
			this.signSpinner.Name = "signSpinner";
			this.signSpinner.Size = new System.Drawing.Size(16, 16);
			this.signSpinner.TabIndex = 0;
			this.signSpinner.TabStop = false;
			this.signSpinner.Value = -1;
			// 
			// mouseFilter1
			// 
			this.mouseFilter1.DispatchMouseWheel = true;
			// 
			// EasyForm
			// 
			this.AcceptButton = this.SignButton;
			this.AllowDrop = true;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(484, 462);
			this.Controls.Add(this.SignatureAppearancePanel);
			this.Controls.Add(this.FileWarningPicture);
			this.Controls.Add(this.line1);
			this.Controls.Add(this.BottomPanel);
			this.Controls.Add(this.VisibleSignatureCheck);
			this.Controls.Add(this.CertificateCombo);
			this.Controls.Add(this.ReasonCombo);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.SelectCertButton);
			this.Controls.Add(this.BrowseInputButton);
			this.Controls.Add(this.InputFileText);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(500, 500);
			this.Name = "EasyForm";
			this.Text = "Einfache PDF-Signierung";
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.EasyForm_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.EasyForm_DragEnter);
			((System.ComponentModel.ISupportInitialize)(this.PageNum)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LeftNum)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BottomNum)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.WidthNum)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.HeightNum)).EndInit();
			this.PagePreviewPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.SignaturePicture)).EndInit();
			this.PreviewPanel.ResumeLayout(false);
			this.BottomPanel.ResumeLayout(false);
			this.BottomPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.FileWarningPicture)).EndInit();
			this.SignatureAppearancePanel.ResumeLayout(false);
			this.SignatureAppearancePanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox InputFileText;
		private System.Windows.Forms.Button BrowseInputButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown PageNum;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown LeftNum;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.NumericUpDown BottomNum;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.NumericUpDown WidthNum;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.NumericUpDown HeightNum;
		private System.Windows.Forms.Button SignButton;
		private System.Windows.Forms.ComboBox ReasonCombo;
		private System.Windows.Forms.Panel PagePreviewPanel;
		private System.Windows.Forms.ComboBox CertificateCombo;
		private System.Windows.Forms.PictureBox SignaturePicture;
		private System.Windows.Forms.Panel PreviewPanel;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label13;
		private Unclassified.MouseFilter mouseFilter1;
		private System.Windows.Forms.LinkLabel WebLink;
		private System.Windows.Forms.Button SelectCertButton;
		private System.Windows.Forms.CheckBox VisibleSignatureCheck;
		private System.Windows.Forms.Button CustomizeSignatureButton;
		private Unclassified.UI.Line line1;
		private System.Windows.Forms.Panel BottomPanel;
		private System.ComponentModel.BackgroundWorker renderWorker;
		private System.ComponentModel.BackgroundWorker signWorker;
		private Unclassified.UI.ProgressSpinner signSpinner;
		private System.Windows.Forms.PictureBox FileWarningPicture;
		private System.Windows.Forms.Panel SignatureAppearancePanel;
	}
}