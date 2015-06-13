namespace MyEditor
{
	partial class AnimationViewer
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
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// AnimationViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(284, 263);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "AnimationViewer";
			this.Text = "AnimationViewer";
			this.toolTip1.SetToolTip(this, "クリックするとウィンドウを閉じます");
			this.TransparencyKey = System.Drawing.Color.Black;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnimationViewer_FormClosing);
			this.Load += new System.EventHandler(this.AnimationViewer_Load);
			this.Click += new System.EventHandler(this.AnimationViewer_Click);
			this.Resize += new System.EventHandler(this.AnimationViewer_Resize);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ToolTip toolTip1;
	}
}