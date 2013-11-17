using System.Security.Cryptography.X509Certificates;

namespace EasyPdfSigning
{
	public class PDFSignatureAP
	{
		public string SigReason {get;set;}
		public string SigContact {get;set;}
		public string SigLocation {get;set;}
		public string CustomText { get; set; }
		public bool Visible  {get;set;}
		public bool Multi { get; set; }

		public float SigX { get; set; }
		public float SigY { get; set; }
		public float SigW { get; set; }
		public float SigH { get; set; }

		public int Page { get; set; }
		public byte[] RawData { get; set; }


		public X509Certificate2 Certificate { get; set; }
	}
}
