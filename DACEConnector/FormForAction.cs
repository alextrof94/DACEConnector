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
	public partial class FormForAction : Form
	{
		public DonateAction parentAction;

		public FormForAction()
		{
			InitializeComponent();
		}

		public void MyUpdate()
		{
			this.Width = parentAction.ActionWindow.Width;
			this.Height = parentAction.ActionWindow.Height;
			if (parentAction.Enabled)
			{
				label1.Text = parentAction.ActionWindow.LabelActive.Text;
				label1.ForeColor = parentAction.ActionWindow.LabelActive.ColorText;
				this.BackColor = parentAction.ActionWindow.LabelActive.ColorBack;
			} else
			{
				label1.Text = parentAction.ActionWindow.LabelInactive.Text;
				label1.ForeColor = parentAction.ActionWindow.LabelInactive.ColorText;
				this.BackColor = parentAction.ActionWindow.LabelInactive.ColorBack;
			}
		}

		private void FormForAction_Resize(object sender, EventArgs e)
		{
			label1.Top = Height / 2 - label1.Height / 2;
			label1.Left = Width / 2 - label1.Width / 2;
		}

		private void FormForAction_Load(object sender, EventArgs e)
		{

		}

		private void FormForAction_ResizeEnd(object sender, EventArgs e)
		{
			parentAction.ActionWindow.Width = this.Width;
			parentAction.ActionWindow.Height = this.Height;
		}
	}
}
