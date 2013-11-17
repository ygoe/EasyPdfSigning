using System.IO;
using iTextSharp.text.pdf;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pkcs;

namespace EasyPdfSigning
{
	/// <summary>
	/// This class hold the certificate and extract private key needed for e-signature 
	/// </summary>
	class Cert
	{
		#region Attributes

		private string path = null;
		private byte[] rawData = null;
		private string password = "";
		private AsymmetricKeyParameter akp;
		private Org.BouncyCastle.X509.X509Certificate[] chain;

		private ITSAClient tsc;

		public ITSAClient Tsc
		{
			get { return tsc; }
			set { tsc = value; }
		}
		#endregion

		#region Accessors
		public Org.BouncyCastle.X509.X509Certificate[] Chain
		{
			get { return chain; }
		}
		public AsymmetricKeyParameter Akp
		{
			get { return akp; }
		}

		public string Path
		{
			get { return path; }
		}

		public string Password
		{
			get { return password; }
			set { password = value; }
		}
		#endregion

		#region Helpers

		private void processCert()
		{
			string alias = null;
			Pkcs12Store pk12;

			//First we'll read the certificate file
			Stream fs;

			if (this.path != null) fs = new FileStream(this.Path, FileMode.Open, FileAccess.Read);
			else fs = new MemoryStream(this.rawData);
			pk12 = new Pkcs12Store(fs, this.password.ToCharArray());

			//then Iterate throught certificate entries to find the private key entry
			foreach (string al in pk12.Aliases)
			{
				if (pk12.IsKeyEntry(al) && pk12.GetKey(al).Key.IsPrivate)
				{
					alias = al;
					break;
				}
			}

			//IEnumerator i = pk12.Aliases.GetEnumerator();
			//while (i.MoveNext())
			//{
			//    alias = ((string)i.Current);
			//    if (pk12.IsKeyEntry(alias))
			//        break;
			//}
			fs.Close();

			this.akp = pk12.GetKey(alias).Key;
			X509CertificateEntry[] ce = pk12.GetCertificateChain(alias);
			this.chain = new Org.BouncyCastle.X509.X509Certificate[ce.Length];
			for (int k = 0; k < ce.Length; ++k)
				chain[k] = ce[k].Certificate;

			//this.tsc = new TSAClientBouncyCastle("http://www.ca-soft.com/request.aspx", TSA_ACCNT, TSA_PASSW);
			//this.tsc = new TSAClientBouncyCastle("http://www.ca-soft.com/request.aspx");
		}
		#endregion

		#region Constructors
		public Cert()
		{ }
		public Cert(string cpath)
		{
			this.path = cpath;
			this.processCert();
		}
		public Cert(string cpath, string cpassword, string tsaURL, string tsaLogin, string tsaPwd)
		{
			this.path = cpath;
			this.Password = cpassword;
			this.processCert();

			if (tsaURL == null) this.tsc = null;
			else this.tsc = new TSAClientBouncyCastle(tsaURL, tsaLogin, tsaPwd);
		}

		public Cert(byte[] rawData)
		{
			this.rawData = rawData;
			this.processCert();
		}
		public Cert(byte[] rawData, string cpassword, string tsaURL, string tsaLogin, string tsaPwd)
		{
			this.rawData = rawData;
			this.Password = cpassword;
			this.processCert();

			if (tsaURL == null) this.tsc = null;
			else this.tsc = new TSAClientBouncyCastle(tsaURL, tsaLogin, tsaPwd);
		}
		#endregion
	}
}
