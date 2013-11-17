using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyPdfSigning
{
	public partial class CustomizeDialog : Form
	{
		public CustomizeDialog()
		{
			InitializeComponent();
		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void DoCancelButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void ChoosePictureButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog fd = new OpenFileDialog();
			fd.Filter = "Bilddateien|*.png;*.gif;*.jpg;*.jpeg;*.bmp;*.tif;*.tiff|Alle Dateien|*.*";
			fd.Title = "Signaturbild auswählen";
			while (true)
			{
				if (fd.ShowDialog() == DialogResult.OK)
				{
					try
					{
						pictureBox1.Image = new Bitmap(fd.FileName);
						ImageCheck.Checked = true;
						break;
					}
					catch (Exception ex)
					{
						if (MessageBox.Show(
							"Die ausgewählte Datei kann nicht als Bild geladen werden. " + ex.Message,
							"Fehler",
							MessageBoxButtons.RetryCancel,
							MessageBoxIcon.Warning) == DialogResult.Cancel)
						{
							break;
						}
					}
				}
				else
				{
					break;
				}
			}
		}
	}
}
