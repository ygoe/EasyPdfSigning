using System;
using System.Threading;
using System.Windows.Forms;

namespace EasyPdfSigning
{
	static class Program
	{
		#region Setup detection mutex

		private static Mutex appMutex = new Mutex(false, "Unclassified.EasyPdfSigning");

		#endregion Setup detection mutex

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
			Application.Run(new EasyForm());
		}

		private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			MessageBox.Show(e.Exception.ToString(), "EasyPdfSigning - An error occured", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}
}