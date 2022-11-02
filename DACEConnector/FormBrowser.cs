using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DACEConnector
{
	public partial class FormBrowser : Form
	{
		public string url;
		public string redirectUrl;
		public string code;
		public FormBrowser()
		{
			InitializeComponent();
		}

		private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
		{
			string res = e.Url.AbsoluteUri;
			if (res.IndexOf(redirectUrl) > -1)
			{
				// get code
				// end
				code = res.Substring(res.IndexOf("code=" + 5));
				this.Close();
			}
		}

		private void FormBrowser_Shown(object sender, EventArgs e)
		{
			webBrowser1.Navigate(url);
		}
	}
}
