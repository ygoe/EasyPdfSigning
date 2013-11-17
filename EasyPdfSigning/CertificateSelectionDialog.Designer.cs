namespace EasyPdfSigning
{
	partial class CertificateSelectionDialog
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
			this.label1 = new System.Windows.Forms.Label();
			this.CertificateList = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panel1 = new System.Windows.Forms.Panel();
			this.DoCancelButton = new System.Windows.Forms.Button();
			this.OKButton = new System.Windows.Forms.Button();
			this.line1 = new Unclassified.UI.Line();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(359, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Wählen Sie das Zertifikat aus, mit dem das Dokument signiert wird:";
			// 
			// CertificateList
			// 
			this.CertificateList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CertificateList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
			this.CertificateList.FullRowSelect = true;
			this.CertificateList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.CertificateList.HideSelection = false;
			this.CertificateList.Location = new System.Drawing.Point(12, 31);
			this.CertificateList.MultiSelect = false;
			this.CertificateList.Name = "CertificateList";
			this.CertificateList.Size = new System.Drawing.Size(870, 162);
			this.CertificateList.TabIndex = 1;
			this.CertificateList.UseCompatibleStateImageBehavior = false;
			this.CertificateList.View = System.Windows.Forms.View.Details;
			this.CertificateList.SelectedIndexChanged += new System.EventHandler(this.CertificateList_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 180;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "E-Mail-Adresse";
			this.columnHeader2.Width = 180;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Organisation";
			this.columnHeader3.Width = 140;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Aussteller";
			this.columnHeader4.Width = 140;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Gültig bis";
			this.columnHeader5.Width = 100;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Hash";
			this.columnHeader6.Width = 100;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.Controls.Add(this.DoCancelButton);
			this.panel1.Controls.Add(this.OKButton);
			this.panel1.Location = new System.Drawing.Point(0, 204);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(894, 45);
			this.panel1.TabIndex = 2;
			// 
			// DoCancelButton
			// 
			this.DoCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.DoCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.DoCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.DoCancelButton.Location = new System.Drawing.Point(799, 10);
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
			this.OKButton.Location = new System.Drawing.Point(708, 10);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(85, 25);
			this.OKButton.TabIndex = 0;
			this.OKButton.Text = "OK";
			this.OKButton.UseVisualStyleBackColor = true;
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// line1
			// 
			this.line1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.line1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this.line1.Location = new System.Drawing.Point(0, 203);
			this.line1.Name = "line1";
			this.line1.Size = new System.Drawing.Size(894, 1);
			this.line1.TabIndex = 14;
			this.line1.TabStop = false;
			// 
			// CertificateSelectionDialog
			// 
			this.AcceptButton = this.OKButton;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.CancelButton = this.DoCancelButton;
			this.ClientSize = new System.Drawing.Size(894, 249);
			this.Controls.Add(this.line1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.CertificateList);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CertificateSelectionDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Zertifikat auswählen";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		internal System.Windows.Forms.ListView CertificateList;
		private Unclassified.UI.Line line1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button DoCancelButton;
		private System.Windows.Forms.Button OKButton;
	}
}