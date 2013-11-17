namespace EasyPdfSigning
{
	partial class CustomizeDialog
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
			this.DoCancelButton = new System.Windows.Forms.Button();
			this.OKButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.NameCheck = new System.Windows.Forms.CheckBox();
			this.LocationCheck = new System.Windows.Forms.CheckBox();
			this.ReasonCheck = new System.Windows.Forms.CheckBox();
			this.DateCheck = new System.Windows.Forms.CheckBox();
			this.LabelsCheck = new System.Windows.Forms.CheckBox();
			this.ImageCheck = new System.Windows.Forms.CheckBox();
			this.NameLabel = new System.Windows.Forms.Label();
			this.LocationLabel = new System.Windows.Forms.Label();
			this.ReasonLabel = new System.Windows.Forms.Label();
			this.DateLabel = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.ChoosePictureButton = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.line1 = new Unclassified.UI.Line();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// DoCancelButton
			// 
			this.DoCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.DoCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.DoCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.DoCancelButton.Location = new System.Drawing.Point(260, 10);
			this.DoCancelButton.Name = "DoCancelButton";
			this.DoCancelButton.Size = new System.Drawing.Size(85, 25);
			this.DoCancelButton.TabIndex = 1;
			this.DoCancelButton.Text = "Abbrechen";
			this.DoCancelButton.UseVisualStyleBackColor = true;
			this.DoCancelButton.Click += new System.EventHandler(this.DoCancelButton_Click);
			// 
			// OKButton
			// 
			this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.OKButton.Location = new System.Drawing.Point(169, 10);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(85, 25);
			this.OKButton.TabIndex = 0;
			this.OKButton.Text = "OK";
			this.OKButton.UseVisualStyleBackColor = true;
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(260, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Angaben, die in der Signatur dargestellt werden:";
			// 
			// NameCheck
			// 
			this.NameCheck.AutoSize = true;
			this.NameCheck.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.NameCheck.Location = new System.Drawing.Point(12, 29);
			this.NameCheck.Name = "NameCheck";
			this.NameCheck.Size = new System.Drawing.Size(64, 20);
			this.NameCheck.TabIndex = 1;
			this.NameCheck.Text = "Name";
			this.NameCheck.UseVisualStyleBackColor = true;
			// 
			// LocationCheck
			// 
			this.LocationCheck.AutoSize = true;
			this.LocationCheck.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.LocationCheck.Location = new System.Drawing.Point(12, 50);
			this.LocationCheck.Name = "LocationCheck";
			this.LocationCheck.Size = new System.Drawing.Size(49, 20);
			this.LocationCheck.TabIndex = 3;
			this.LocationCheck.Text = "Ort";
			this.LocationCheck.UseVisualStyleBackColor = true;
			// 
			// ReasonCheck
			// 
			this.ReasonCheck.AutoSize = true;
			this.ReasonCheck.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ReasonCheck.Location = new System.Drawing.Point(12, 71);
			this.ReasonCheck.Name = "ReasonCheck";
			this.ReasonCheck.Size = new System.Drawing.Size(65, 20);
			this.ReasonCheck.TabIndex = 5;
			this.ReasonCheck.Text = "Grund";
			this.ReasonCheck.UseVisualStyleBackColor = true;
			// 
			// DateCheck
			// 
			this.DateCheck.AutoSize = true;
			this.DateCheck.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.DateCheck.Location = new System.Drawing.Point(12, 92);
			this.DateCheck.Name = "DateCheck";
			this.DateCheck.Size = new System.Drawing.Size(68, 20);
			this.DateCheck.TabIndex = 7;
			this.DateCheck.Text = "Datum";
			this.DateCheck.UseVisualStyleBackColor = true;
			// 
			// LabelsCheck
			// 
			this.LabelsCheck.AutoSize = true;
			this.LabelsCheck.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.LabelsCheck.Location = new System.Drawing.Point(12, 113);
			this.LabelsCheck.Name = "LabelsCheck";
			this.LabelsCheck.Size = new System.Drawing.Size(112, 20);
			this.LabelsCheck.TabIndex = 9;
			this.LabelsCheck.Text = "Beschriftungen";
			this.LabelsCheck.UseVisualStyleBackColor = true;
			// 
			// ImageCheck
			// 
			this.ImageCheck.AutoSize = true;
			this.ImageCheck.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ImageCheck.Location = new System.Drawing.Point(12, 134);
			this.ImageCheck.Name = "ImageCheck";
			this.ImageCheck.Size = new System.Drawing.Size(52, 20);
			this.ImageCheck.TabIndex = 10;
			this.ImageCheck.Text = "Bild";
			this.ImageCheck.UseVisualStyleBackColor = true;
			// 
			// NameLabel
			// 
			this.NameLabel.AutoSize = true;
			this.NameLabel.Location = new System.Drawing.Point(124, 31);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(39, 15);
			this.NameLabel.TabIndex = 2;
			this.NameLabel.Text = "Name";
			this.NameLabel.UseMnemonic = false;
			// 
			// LocationLabel
			// 
			this.LocationLabel.AutoSize = true;
			this.LocationLabel.Location = new System.Drawing.Point(124, 52);
			this.LocationLabel.Name = "LocationLabel";
			this.LocationLabel.Size = new System.Drawing.Size(24, 15);
			this.LocationLabel.TabIndex = 4;
			this.LocationLabel.Text = "Ort";
			this.LocationLabel.UseMnemonic = false;
			// 
			// ReasonLabel
			// 
			this.ReasonLabel.AutoSize = true;
			this.ReasonLabel.Location = new System.Drawing.Point(124, 73);
			this.ReasonLabel.Name = "ReasonLabel";
			this.ReasonLabel.Size = new System.Drawing.Size(40, 15);
			this.ReasonLabel.TabIndex = 6;
			this.ReasonLabel.Text = "Grund";
			this.ReasonLabel.UseMnemonic = false;
			// 
			// DateLabel
			// 
			this.DateLabel.AutoSize = true;
			this.DateLabel.Location = new System.Drawing.Point(124, 94);
			this.DateLabel.Name = "DateLabel";
			this.DateLabel.Size = new System.Drawing.Size(43, 15);
			this.DateLabel.TabIndex = 8;
			this.DateLabel.Text = "Datum";
			this.DateLabel.UseMnemonic = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(31, 186);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(312, 97);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 9;
			this.pictureBox1.TabStop = false;
			// 
			// ChoosePictureButton
			// 
			this.ChoosePictureButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ChoosePictureButton.Location = new System.Drawing.Point(30, 155);
			this.ChoosePictureButton.Name = "ChoosePictureButton";
			this.ChoosePictureButton.Size = new System.Drawing.Size(91, 25);
			this.ChoosePictureButton.TabIndex = 11;
			this.ChoosePictureButton.Text = "Auswählen...";
			this.ChoosePictureButton.UseVisualStyleBackColor = true;
			this.ChoosePictureButton.Click += new System.EventHandler(this.ChoosePictureButton_Click);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.Controls.Add(this.DoCancelButton);
			this.panel1.Controls.Add(this.OKButton);
			this.panel1.Location = new System.Drawing.Point(0, 295);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(355, 45);
			this.panel1.TabIndex = 12;
			// 
			// line1
			// 
			this.line1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.line1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this.line1.Location = new System.Drawing.Point(0, 294);
			this.line1.Name = "line1";
			this.line1.Size = new System.Drawing.Size(355, 1);
			this.line1.TabIndex = 12;
			this.line1.TabStop = false;
			// 
			// CustomizeDialog
			// 
			this.AcceptButton = this.OKButton;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.CancelButton = this.DoCancelButton;
			this.ClientSize = new System.Drawing.Size(355, 340);
			this.Controls.Add(this.line1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.ChoosePictureButton);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.DateLabel);
			this.Controls.Add(this.ReasonLabel);
			this.Controls.Add(this.LocationLabel);
			this.Controls.Add(this.NameLabel);
			this.Controls.Add(this.ImageCheck);
			this.Controls.Add(this.LabelsCheck);
			this.Controls.Add(this.DateCheck);
			this.Controls.Add(this.ReasonCheck);
			this.Controls.Add(this.LocationCheck);
			this.Controls.Add(this.NameCheck);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CustomizeDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Signaturdarstellung anpassen";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button DoCancelButton;
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.CheckBox NameCheck;
		internal System.Windows.Forms.CheckBox LocationCheck;
		internal System.Windows.Forms.CheckBox ReasonCheck;
		internal System.Windows.Forms.CheckBox DateCheck;
		internal System.Windows.Forms.CheckBox LabelsCheck;
		internal System.Windows.Forms.CheckBox ImageCheck;
		internal System.Windows.Forms.Label NameLabel;
		internal System.Windows.Forms.Label LocationLabel;
		internal System.Windows.Forms.Label ReasonLabel;
		internal System.Windows.Forms.Label DateLabel;
		private System.Windows.Forms.Button ChoosePictureButton;
		private System.Windows.Forms.Panel panel1;
		private Unclassified.UI.Line line1;
		internal System.Windows.Forms.PictureBox pictureBox1;
	}
}