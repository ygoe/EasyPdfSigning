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
	public partial class CertificateSelectionDialog : Form
	{
		public CertificateSelectionDialog()
		{
			InitializeComponent();
		}

		private void CertificateList_SelectedIndexChanged(object sender, EventArgs e)
		{
			OKButton.Enabled = CertificateList.SelectedIndices.Count == 1;
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
	}
}
