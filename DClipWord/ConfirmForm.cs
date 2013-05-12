using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DClipWord.Properties;

namespace DClipWord
{
	public partial class ConfirmForm : Form
	{
		int Cont = 0;

		public ConfirmForm()
		{
			InitializeComponent();

			this.Left = Screen.PrimaryScreen.WorkingArea.Width - (this.Width + 5);
			this.Top = Screen.PrimaryScreen.WorkingArea.Height - (this.Height + 5);
		}

		private void ConfirmForm_Load(object sender, EventArgs e)
		{
			this.Cont = 0;
			timer1.Enabled = true;
			timer1.Interval = 1000;
		}

		private void ConfirmForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			timer1.Enabled = false;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			Cont++;

			this.btnSim.Text = string.Format("{0} ({1})", Resources.ConfirmMessage, Cont);

			if (Cont == 5)
				this.Close();
		}
	}
}
