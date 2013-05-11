using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using Microsoft.Office.Core;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DClipWord.Properties;
using Microsoft.Office.Interop.Word;

namespace DClipWord
{
	public partial class ThisAddIn
	{
		CommandBarButton menuCommand;
		System.Media.SoundPlayer soundPlayer;
		bool Enabled = false;
		ClipboardManager manager;

		private void ThisAddIn_Startup(object sender, System.EventArgs e)
		{
			CheckIfMenuBarExists();
			AddMenuBar();

			soundPlayer = new System.Media.SoundPlayer();
			soundPlayer.Stream = Properties.Resources.camera_click;
			
			manager = new ClipboardManager();
		}

		private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
		{
			if (Enabled)
			{
				Enabled = false;
				manager.OnNewClipboard -= manager_OnNewClipboard;
				manager.Stop();
			}
		}

		private void CheckIfMenuBarExists()
		{
			try
			{
				Office.CommandBarButton foundMenu = (Office.CommandBarButton)
						this.Application.CommandBars.ActiveMenuBar.FindControl(
						Office.MsoControlType.msoControlButton, System.Type.Missing, 200, true, true);

				if (foundMenu != null)
				{
					foundMenu.Delete(true);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void AddMenuBar()
		{
			try
			{
				Office.CommandBar menubar = (Office.CommandBar)Application.CommandBars.ActiveMenuBar;
				int controlCount = menubar.Controls.Count;

				// Add the menu.
				menuCommand = (Office.CommandBarButton)menubar.Controls.Add(
							Office.MsoControlType.msoControlButton, missing, missing, missing, true);
				menuCommand.Style = MsoButtonStyle.msoButtonIconAndCaptionBelow;
				menuCommand.Caption = Resources.ItemMenu;
				menuCommand.Tag = "200";
				menuCommand.FaceId = 65;
				menuCommand.Click += new Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler(
							menuCommand_Click);

				this.Enabled = false;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void menuCommand_Click(Microsoft.Office.Core.CommandBarButton Ctrl, ref bool CancelDefault)
		{
			if (Enabled)
			{
				Enabled = false;
				manager.OnNewClipboard -= manager_OnNewClipboard;
				manager.Stop();				

				MessageBox.Show(Resources.MessageDisabled, 
					Resources.ApplicationName,
					MessageBoxButtons.OK, 
					MessageBoxIcon.Information);
			}
			else
			{
				Enabled = true;
				manager.Start();
				manager.OnNewClipboard += manager_OnNewClipboard;

				MessageBox.Show(Resources.MessageEnabled,
					Resources.ApplicationName,
					MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		void manager_OnNewClipboard(object sender, ClipboardArgs e)
		{
			Application.ActiveDocument.Content.Paragraphs.Add(Globals.ThisAddIn.Application.Selection.Range);

			Globals.ThisAddIn.Application.Selection.Paste();		

			Application.ActiveDocument.Content.Paragraphs.Add(Globals.ThisAddIn.Application.Selection.Range);

			Globals.ThisAddIn.Application.Selection.MoveDown(WdUnits.wdParagraph, 2, Type.Missing);

			soundPlayer.Play();

		}

		#region VSTO generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InternalStartup()
		{
			this.Startup += new System.EventHandler(ThisAddIn_Startup);
			this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);			
		}

		#endregion
	}
}
