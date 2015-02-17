using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using PdfToImage;
using Unclassified.Util;

namespace EasyPdfSigning
{
	public partial class EasyForm : Form
	{
		private X509Certificate2Collection certificates;
		private PdfReader reader;
		private MetaData metaData;
		private bool existingSignatures;
		private DelayedCall renderPageDc;
		private bool showName = true;
		private bool showLocation;
		private bool showReason = true;
		private bool showDate = true;
		private bool showLabels;
		private bool showImage;
		private Image renderImage;
		private int fixedWindowHeight;

		#region UI data copy for background worker

		private string inputFileTextText;
		private int certificateComboSelectedIndex;
		private string reasonComboText;
		private bool visibleSignatureCheckChecked;
		private int pageNumValue;
		private float leftNumValue;
		private float bottomNumValue;
		private float widthNumValue;
		private float heightNumValue;
		private Image signaturePictureImage;

		#endregion UI data copy for background worker

		public EasyForm()
		{
			renderPageDc = DelayedCall.Create(RenderPdfPage, 200);

			InitializeComponent();
			
			FillCertificatesList();
			ValidateUIState();

			string[] args = Environment.GetCommandLineArgs();
			if (args.Length > 1)
			{
				InputFileText.Text = args[1];
				ValidateInputFile();
			}
		}

		private string ExtractDNField(string dn, string field)
		{
			Match m = Regex.Match(dn, @"(?:^\s*|,\s*)" + field + @"=([^,]*)");
			if (m.Success)
			{
				return m.Groups[1].Value;
			}
			return null;
		}

		private void FillCertificatesList()
		{
			string selectedHash = null;
			int selectedIndex = -1;
			using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Unclassified\EasyPdfSigning"))
			{
				selectedHash = key.GetValue("SelectedCertificate") as string;
			}

			X509Store store = new X509Store(StoreName.My);
			store.Open(OpenFlags.ReadOnly);
			certificates = store.Certificates;
			foreach (X509Certificate2 cert in certificates)
			{
				string cn = ExtractDNField(cert.Subject, "CN");
				if (cn != null)
				{
					cn += " <" + ExtractDNField(cert.Subject, "E") + ">";
				}
				else
				{
					cn = cert.Subject;
				}
				// More details in the separate dialog

				CertificateCombo.Items.Add(cn);

				if (cert.GetCertHashString() == selectedHash)
				{
					selectedIndex = CertificateCombo.Items.Count - 1;
				}
			}
			if (selectedIndex > -1)
			{
				CertificateCombo.SelectedIndex = selectedIndex;
			}
			else if (CertificateCombo.Items.Count == 1)
			{
				CertificateCombo.SelectedIndex = 0;
			}
			else if (CertificateCombo.Items.Count == 0)
			{
				CertificateCombo.Items.Add("Sie verfügen über kein Zertifikat, um ein Dokument zu signieren.");
				CertificateCombo.SelectedIndex = 0;
				CertificateCombo.Enabled = false;
				SelectCertButton.Enabled = false;
			}
		}

		private void EasyForm_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void EasyForm_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] fileNames = e.Data.GetData(DataFormats.FileDrop) as string[];
				if (fileNames != null && fileNames.Length > 0)
				{
					InputFileText.Text = fileNames[0];
					ValidateInputFile();
				}
			}
		}

		private void InputFileText_Leave(object sender, EventArgs e)
		{
			ValidateInputFile();
		}

		private void BrowseInputButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog fd = new OpenFileDialog();
			fd.DefaultExt = ".pdf";
			fd.Filter = "PDF-Dokumente|*.pdf|Alle Dateien|*.*";
			fd.Title = "Zu signierendes PDF-Dokument auswählen";
			if (fd.ShowDialog() == DialogResult.OK)
			{
				InputFileText.Text = fd.FileName;
				ValidateInputFile();
			}
		}

		private void CertificateCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			ValidateUIState();

			if (CertificateCombo.SelectedIndex > -1)
			{
				X509Certificate2 cert = certificates[CertificateCombo.SelectedIndex];
				using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Unclassified\EasyPdfSigning"))
				{
					key.SetValue("SelectedCertificate", cert.GetCertHashString());
				}
			}
		}

		private void SelectCertButton_Click(object sender, EventArgs e)
		{
			CertificateSelectionDialog dlg = new CertificateSelectionDialog();

			X509Certificate2 selectedCert = null;
			if (CertificateCombo.SelectedIndex > -1)
			{
				selectedCert = certificates[CertificateCombo.SelectedIndex];
			}

			foreach (X509Certificate2 cert in certificates)
			{
				string cn = ExtractDNField(cert.Subject, "CN");
				if (cn == null)
				{
					cn = cert.Subject;
				}
				string email = ExtractDNField(cert.Subject, "E");
				string org = ExtractDNField(cert.Subject, "O");
				string issuerCN = ExtractDNField(cert.Issuer, "CN");
				string valid = cert.NotAfter.ToShortDateString();
				string hash = cert.GetCertHashString();

				ListViewItem lvi = new ListViewItem(new string[] { cn, email, org, issuerCN, valid, hash });
				lvi.Selected = cert == selectedCert;
				dlg.CertificateList.Items.Add(lvi);
			}

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				if (dlg.CertificateList.SelectedIndices.Count == 1)
				{
					CertificateCombo.SelectedIndex = dlg.CertificateList.SelectedIndices[0];
				}
			}
		}

		private void ReasonCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			ValidateUIState();
		}

		private void ReasonCombo_TextUpdate(object sender, EventArgs e)
		{
			ValidateUIState();
		}

		private void VisibleSignatureCheck_CheckedChanged(object sender, EventArgs e)
		{
			ValidateUIState();
			if (PageNum.Enabled)
			{
				PageNum_ValueChanged(null, null);
			}
		}

		private void PageNum_ValueChanged(object sender, EventArgs e)
		{
			iTextSharp.text.Rectangle rect = reader.GetPageSize((int) PageNum.Value);

			int width = PreviewPanel.Width - 6;
			int height = (int) ((width * rect.Height) / rect.Width);
			if (height > PreviewPanel.Height - 6)
			{
				height = PreviewPanel.Height - 6;
				width = (int) ((height * rect.Width) / rect.Height);
			}
			int left = (PreviewPanel.Width - width) / 2;
			int top = (PreviewPanel.Height - height) / 2;
			PagePreviewPanel.Bounds = new Rectangle(left, top, width, height);

			LeftNum.Maximum = (decimal) pt2mm(rect.Width);
			BottomNum.Maximum = (decimal) pt2mm(rect.Height);

			WidthNum.Maximum = (decimal) pt2mm(rect.Width);
			HeightNum.Maximum = (decimal) pt2mm(rect.Height);

			LeftNum_ValueChanged(null, null);
			BottomNum_ValueChanged(null, null);
			WidthNum_ValueChanged(null, null);
			HeightNum_ValueChanged(null, null);

			renderPageDc.Reset();
		}

		private void LeftNum_ValueChanged(object sender, EventArgs e)
		{
			iTextSharp.text.Rectangle rect = reader.GetPageSize((int) PageNum.Value);
			float leftPt = mm2pt((float) LeftNum.Value);
			SignaturePicture.Left = (int) Math.Round(leftPt / rect.Width * PagePreviewPanel.Width);
		}

		private void BottomNum_ValueChanged(object sender, EventArgs e)
		{
			iTextSharp.text.Rectangle rect = reader.GetPageSize((int) PageNum.Value);
			float bottomPt = mm2pt((float) BottomNum.Value);
			SignaturePicture.Top = PagePreviewPanel.Height -
				(int) Math.Round(bottomPt / rect.Height * PagePreviewPanel.Height) -
				SignaturePicture.Height;
		}

		private void WidthNum_ValueChanged(object sender, EventArgs e)
		{
			iTextSharp.text.Rectangle rect = reader.GetPageSize((int) PageNum.Value);
			float widthPt = mm2pt((float) WidthNum.Value);
			SignaturePicture.Width = (int) Math.Round(widthPt / rect.Width * PagePreviewPanel.Width);

			LeftNum.Maximum = (decimal) pt2mm(rect.Width) - WidthNum.Value;
		}

		private void HeightNum_ValueChanged(object sender, EventArgs e)
		{
			iTextSharp.text.Rectangle rect = reader.GetPageSize((int) PageNum.Value);
			float heightPt = mm2pt((float) HeightNum.Value);
			SignaturePicture.Height = (int) Math.Round(heightPt / rect.Height * PagePreviewPanel.Height);

			// Also update top position because it's bottom-aligned
			float bottomPt = mm2pt((float) BottomNum.Value);
			SignaturePicture.Top = PagePreviewPanel.Height -
				(int) Math.Round(bottomPt / rect.Height * PagePreviewPanel.Height) -
				SignaturePicture.Height;

			BottomNum.Maximum = (decimal) pt2mm(rect.Height) - HeightNum.Value;
		}

		private void CustomizeSignatureButton_Click(object sender, EventArgs e)
		{
			CustomizeDialog dlg = new CustomizeDialog();

			dlg.NameCheck.Checked = showName;
			dlg.LocationCheck.Checked = showLocation;
			dlg.ReasonCheck.Checked = showReason;
			dlg.DateCheck.Checked = showDate;
			dlg.LabelsCheck.Checked = showLabels;
			dlg.ImageCheck.Checked = showImage;

			dlg.ReasonLabel.Text = ReasonCombo.Text;
			dlg.DateLabel.Text = DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss K");
			if (CertificateCombo.SelectedIndex > -1)
			{
				X509Certificate2 selectedCert = certificates[CertificateCombo.SelectedIndex];

				dlg.NameLabel.Text = ExtractDNField(selectedCert.Subject, "CN");
				string country = ExtractDNField(selectedCert.Subject, "C");
				string locality = ExtractDNField(selectedCert.Subject, "L");
				dlg.LocationLabel.Text = locality +
					(!string.IsNullOrEmpty(locality) && !string.IsNullOrEmpty(country) ? ", " : "") +
					country;
			}

			dlg.pictureBox1.Image = SignaturePicture.Image;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				showName = dlg.NameCheck.Checked;
				showLocation = dlg.LocationCheck.Checked;
				showReason = dlg.ReasonCheck.Checked;
				showDate = dlg.DateCheck.Checked;
				showLabels = dlg.LabelsCheck.Checked;
				showImage = dlg.ImageCheck.Checked;

				SignaturePicture.Image = showImage ? dlg.pictureBox1.Image : null;
			}
		}

		private void PreviewPanel_Resize(object sender, EventArgs e)
		{
			if (VisibleSignatureCheck.Checked && PageNum.Enabled)
			{
				PageNum_ValueChanged(null, null);
			}
		}

		private void SignButton_Click(object sender, EventArgs e)
		{
			inputFileTextText = InputFileText.Text;
			certificateComboSelectedIndex = CertificateCombo.SelectedIndex;
			reasonComboText = ReasonCombo.Text;
			visibleSignatureCheckChecked = VisibleSignatureCheck.Checked;
			pageNumValue = (int) PageNum.Value;
			leftNumValue = (float) LeftNum.Value;
			bottomNumValue = (float) BottomNum.Value;
			widthNumValue = (float) WidthNum.Value;
			heightNumValue = (float) HeightNum.Value;
			signaturePictureImage = SignaturePicture.Image;

			signWorker.RunWorkerAsync();
			ValidateUIState();
		}

		private void signWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			Cert myCert = null;
			string certName = null;
			string tsaUrl = "http://timestamp.globalsign.com/scripts/timestamp.dll";   // null if unused
			X509Certificate2 certificateData = certificates[certificateComboSelectedIndex] as X509Certificate2;
			if (certificateData != null)
			{
				certName = ExtractDNField(certificateData.Subject, "CN");
				if (certName == null)
				{
					certName = certificateData.Subject;   // Use fallback
				}
				byte[] bytes = certificateData.Export(X509ContentType.Pfx, "");
				myCert = new Cert(bytes, "", tsaUrl, "" /* TSA login */, "" /* TSA password */);
			}
			else
			{
				return;
				//myCert = new Cert(certificateTextBox.Text, certificatePwdBox.Text, tsaUrl, tsaLogin.Text, tsaPwd.Text);
			}

			if (reasonComboText == null)
			{
				reasonComboText = "";
			}

			// Copy original to backup file, then sign that back to original file name
			string outputFile;
			bool outputFileIsTemporary = false;
			outputFile = Path.GetFileNameWithoutExtension(inputFileTextText) +
				".unsigned" +
				Path.GetExtension(inputFileTextText);
			outputFile = Path.Combine(Path.GetDirectoryName(inputFileTextText),
				outputFile);
			string inputFile = outputFile;

			// Create a copy if it does not exist yet (keep original unsigned forever)
			if (!File.Exists(outputFile))
			{
				File.Copy(inputFileTextText, outputFile);
				outputFile = inputFileTextText;
			}
			else
			{
				// We need a different temporary file
				inputFile = inputFileTextText;
				outputFile = Path.GetTempFileName();
				outputFileIsTemporary = true;
			}

			// NOTES:
			// * Encryption can only be applied before any signatures exist, otherwise existing signatures are broken.
			// * Encryption requires a non-empty password set, or we'll get problems when opening next time.
			// * Permissions can only be set together with the encryption status.
			// => Permissions cannot be changed once a signature exists.
			// http://stackoverflow.com/q/20008256/143684
			// TODO

			PDFEncryption pdfEnc = new PDFEncryption();
			pdfEnc.UserPwd = "";
			//pdfEnc.OwnerPwd = "1234";
			pdfEnc.OwnerPwd = "";
			pdfEnc.Encryption = true;   // Use 128 bit instead of 40 bit, but still RC4
			// Permissions explanation: http://www.pdflib.com/knowledge-base/pdf-security/permissions/
			pdfEnc.Permissions.Add(permissionType.Copy);
			pdfEnc.Permissions.Add(permissionType.DegradedPrinting);
			pdfEnc.Permissions.Add(permissionType.Printing);
			pdfEnc.Permissions.Add(permissionType.ScreenReaders);

			//pdfEnc.Permissions.Add(permissionType.Assembly);
			pdfEnc.Permissions.Add(permissionType.FillIn);   // Includes signing
			//pdfEnc.Permissions.Add(permissionType.ModifyAnnotation);
			//pdfEnc.Permissions.Add(permissionType.ModifyContent);

			// Sign document
			PDFSigner pdfs = new PDFSigner(inputFile, outputFile, myCert, metaData);
			PDFSignatureAP sigAp = new PDFSignatureAP();
			sigAp.SigReason = reasonComboText;
			sigAp.SigContact = "";
			sigAp.SigLocation = "";
			sigAp.Visible = visibleSignatureCheckChecked;
			sigAp.Multi = existingSignatures;
			sigAp.Page = pageNumValue;

			sigAp.CustomText = "";
			if (visibleSignatureCheckChecked)
			{
				if (showName)
				{
					if (showLabels)
					{
						sigAp.CustomText += "Digital signiert von ";
					}
					sigAp.CustomText += certName + "\n";
				}
				if (showLocation)
				{
					string country = ExtractDNField(certificateData.Subject, "C");
					string locality = ExtractDNField(certificateData.Subject, "L");
					if (!string.IsNullOrEmpty(country) || !string.IsNullOrEmpty(locality))
					{
						if (showLabels)
						{
							sigAp.CustomText += "Ort: ";
						}
						sigAp.CustomText += locality +
							(!string.IsNullOrEmpty(locality) && !string.IsNullOrEmpty(country) ? ", " : "") +
							country + "\n";
					}
				}
				if (showReason)
				{
					if (showLabels)
					{
						sigAp.CustomText += "Grund: ";
					}
					sigAp.CustomText += reasonComboText + "\n";
				}
				if (showDate)
				{
					if (showLabels)
					{
						sigAp.CustomText += "Datum: ";
					}
					sigAp.CustomText += DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss K") + "\n";
				}
				sigAp.CustomText = sigAp.CustomText.TrimEnd();

				if (showImage && signaturePictureImage != null)
				{
					using (MemoryStream ms = new MemoryStream())
					{
						signaturePictureImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
						sigAp.RawData = ms.ToArray();
					}
				}

				sigAp.SigX = mm2pt(leftNumValue);
				sigAp.SigY = mm2pt(bottomNumValue);
				sigAp.SigW = mm2pt(widthNumValue);
				sigAp.SigH = mm2pt(heightNumValue);
			}

			// Encrypt only if no signatures exist. Later it won't work anymore because it'll
			// break the existing signatures.
			pdfs.Sign(sigAp, false /*!existingSignatures*/, pdfEnc);

			if (outputFileIsTemporary)
			{
				// Delete input file and replace with temp output
				File.Delete(inputFile);
				File.Move(outputFile, inputFile);
			}
		}

		private void signWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			ValidateUIState();
			if (e.Error != null)
			{
				MessageBox.Show(this, e.Error.Message + " (" + e.Error.GetType().Name + ")", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				MessageBox.Show(this, "Das Dokument wurde signiert.", "Dokument signiert", MessageBoxButtons.OK);
			}
		}

		private void WebLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://unclassified.software/apps/easypdfsigning?ref=inapp_easypdfsigning");
		}

		private float mm2pt(float mm)
		{
			return mm / 25.4f * 72f;
		}

		private float pt2mm(float pt)
		{
			return pt / 72f * 25.4f;
		}

		private void SelectableField_Enter(object sender, EventArgs e)
		{
			TextBox tb = sender as TextBox;
			if (tb != null)
			{
				tb.SelectAll();
			}
			NumericUpDown num = sender as NumericUpDown;
			if (num != null)
			{
				num.Select(0, num.Text.Length);
			}
		}

		private void ValidateInputFile()
		{
			FileWarningPicture.Hide();

			if (!string.IsNullOrEmpty(InputFileText.Text))
			{
				try
				{
					reader = new PdfReader(InputFileText.Text);
				}
				catch
				{
					reader = null;
					ValidateUIState();
					FileWarningPicture.Show();
					return;
				}
			}
			else
			{
				reader = null;
				ValidateUIState();
				return;
			}

			metaData = new MetaData();
			metaData.Info = reader.Info;

			PageNum.Maximum = reader.NumberOfPages;
			PageNum.Minimum = PageNum.Value = 1;
			PageNum_ValueChanged(null, null);

			existingSignatures = reader.AcroFields.GetSignatureNames().Count > 0;
			ValidateUIState();
		}

		private void RenderPdfPage()
		{
			if (!renderWorker.IsBusy)
			{
				renderWorker.RunWorkerAsync();
			}
			else
			{
				// Retry later
				renderPageDc.Reset();
			}
		}

		private void ValidateUIState()
		{
			bool vis = VisibleSignatureCheck.Checked;

			SignatureAppearancePanel.Visible = vis;
			if (vis)
			{
				fixedWindowHeight = -1;
				MinimumSize = new Size(500, 500);
				MaximumSize = new Size();
			}
			else
			{
				fixedWindowHeight = SignatureAppearancePanel.Top + BottomPanel.Height + (Height - ClientSize.Height) + 4;
				MinimumSize = new Size(500, fixedWindowHeight);
				MaximumSize = new Size(99999, fixedWindowHeight);
			}

			PageNum.Enabled = reader != null && vis;
			LeftNum.Enabled = reader != null && vis;
			BottomNum.Enabled = reader != null && vis;
			WidthNum.Enabled = reader != null && vis;
			HeightNum.Enabled = reader != null && vis;
			PagePreviewPanel.Visible = reader != null && vis;
			CustomizeSignatureButton.Enabled = reader != null && vis;

			signSpinner.Spinning = signSpinner.Visible = signWorker.IsBusy;

			SignButton.Enabled =
				reader != null &&
				CertificateCombo.SelectedIndex > -1 &&
				!string.IsNullOrEmpty(ReasonCombo.Text) &&
				!signWorker.IsBusy;
		}

		private void renderWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			renderImage = null;
			
			PDFConvert converter = new PDFConvert();
			converter.FirstPageToConvert = (int) PageNum.Value;
			converter.LastPageToConvert = (int) PageNum.Value;
			converter.OutputFormat = "png16m";
			converter.TextAlphaBit = 0;
			converter.GraphicsAlphaBit = 0;
			converter.Width = PagePreviewPanel.Width * 4;
			converter.Height = PagePreviewPanel.Height * 4;
			converter.FitPage = true;
			string output = Path.GetTempFileName();
			if (converter.Convert(InputFileText.Text, output))
			{
				MemoryStream ms = new MemoryStream(File.ReadAllBytes(output));
				renderImage = Image.FromStream(ms);
			}
			File.Delete(output);
		}

		private void renderWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			PagePreviewPanel.BackgroundImage = renderImage;
		}
	}
}
