using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DClipWord
{
	public partial class ClipboardManager : Form
	{
		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

		private const int WM_DRAWCLIPBOARD = 0x0308;        // WM_DRAWCLIPBOARD message
		private IntPtr _clipboardViewerNext;
				
		public event Action OnNewClipboard;

		public ClipboardManager()
		{
			InitializeComponent();
		}

		public void Start()
		{
			_clipboardViewerNext = SetClipboardViewer(this.Handle);
		}

		public void Stop()
		{
			ChangeClipboardChain(this.Handle, _clipboardViewerNext);
		}

		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);    

			if (m.Msg == WM_DRAWCLIPBOARD)
			{
				IDataObject iData = Clipboard.GetDataObject();      

				if ((iData.GetDataPresent(DataFormats.Bitmap, false)) &&
						(iData.GetDataPresent(DataFormats.Text, false) == false))
				{
					var image = iData.GetData(DataFormats.Bitmap);
										
					if ((image != null) && (OnNewClipboard != null))
					{						
						OnNewClipboard();
					}
				}
			}
		}
	}	
}
