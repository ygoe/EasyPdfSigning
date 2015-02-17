using System;
using System.Threading;
using System.Windows.Forms;
using Unclassified.FieldLog;
using Unclassified.Util;

namespace EasyPdfSigning
{
	static class Program
	{
		/// <summary>
		/// Application entry point.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// Set up FieldLog
			FL.AcceptLogFileBasePath();

			// Keep the setup away
			GlobalMutex.Create("Unclassified.EasyPdfSigning");

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new EasyForm());
		}
	}
}