using System;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text.xml.xmp;

namespace EasyPdfSigning
{
	/// <summary>
	/// This is a holder class for PDF metadata
	/// </summary>
	class MetaData
	{
		private Dictionary<string, string> info = new Dictionary<string, string>();

		public Dictionary<string, string> Info
		{
			get { return info; }
			set { info = value; }
		}

		public string Author
		{
			get
			{
				if (!info.ContainsKey("Author")) return String.Empty;

				return info["Author"];
			}
			set { info.Add("Author", value); }
		}
		public string Title
		{
			get
			{
				if (!info.ContainsKey("Title")) return String.Empty;

				return info["Title"];
			}
			set { info.Add("Title", value); }
		}
		public string Subject
		{
			get
			{
				if (!info.ContainsKey("Subject")) return String.Empty;
				return info["Subject"];
			}
			set { info.Add("Subject", value); }
		}
		public string Keywords
		{
			get
			{
				if (!info.ContainsKey("Keywords")) return String.Empty;

				return info["Keywords"];
			}
			set { info.Add("Keywords", value); }
		}
		public string Producer
		{
			get
			{
				if (!info.ContainsKey("Producer")) return String.Empty;
				return info["Producer"];
			}
			set { info.Add("Producer", value); }
		}

		public string Creator
		{
			get
			{
				if (!info.ContainsKey("Creator")) return String.Empty;

				return info["Creator"];
			}
			set { info.Add("Creator", value); }
		}

		public Dictionary<string, string> getMetaData()
		{
			return this.info;
		}
		public byte[] getStreamedMetaData()
		{
			MemoryStream os = new System.IO.MemoryStream();
			XmpWriter xmp = new XmpWriter(os, this.info);
			xmp.Close();
			return os.ToArray();
		}
	}
}
