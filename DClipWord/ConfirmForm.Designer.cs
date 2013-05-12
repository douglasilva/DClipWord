namespace DClipWord
{
	partial class ConfirmForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.btnSim = new System.Windows.Forms.Button();
			this.btnNao = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// btnSim
			// 
			this.btnSim.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.btnSim.Location = new System.Drawing.Point(41, 20);
			this.btnSim.Name = "btnSim";
			this.btnSim.Size = new System.Drawing.Size(85, 47);
			this.btnSim.TabIndex = 0;
			this.btnSim.Text = "&Sim";
			this.btnSim.UseVisualStyleBackColor = true;
			// 
			// btnNao
			// 
			this.btnNao.DialogResult = System.Windows.Forms.DialogResult.No;
			this.btnNao.Location = new System.Drawing.Point(154, 32);
			this.btnNao.Name = "btnNao";
			this.btnNao.Size = new System.Drawing.Size(75, 23);
			this.btnNao.TabIndex = 1;
			this.btnNao.Text = "&Não";
			this.btnNao.UseVisualStyleBackColor = true;
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// ConfirmForm
			// 
			this.AcceptButton = this.btnSim;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnNao;
			this.ClientSize = new System.Drawing.Size(275, 88);
			this.Controls.Add(this.btnNao);
			this.Controls.Add(this.btnSim);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ConfirmForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Deseja registrar a imagem?";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConfirmForm_FormClosed);
			this.Load += new System.EventHandler(this.ConfirmForm_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnSim;
		private System.Windows.Forms.Button btnNao;
		private System.Windows.Forms.Timer timer1;
	}
}