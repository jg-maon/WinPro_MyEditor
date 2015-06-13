namespace MyEditor
{
	partial class LayerInfoDialog
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(23, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "レイヤー名";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(23, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(12, 12);
			this.label2.TabIndex = 1;
			this.label2.Text = "X";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(171, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(12, 12);
			this.label3.TabIndex = 1;
			this.label3.Text = "Y";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(23, 108);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(14, 12);
			this.label4.TabIndex = 1;
			this.label4.Text = "W";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(171, 108);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(13, 12);
			this.label5.TabIndex = 1;
			this.label5.Text = "H";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(84, 19);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(206, 19);
			this.textBox1.TabIndex = 2;
			this.textBox1.Enter += new System.EventHandler(this.textBox_Enter);
			this.textBox1.MouseEnter += new System.EventHandler(this.textBox_MouseEnter);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(41, 61);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(100, 19);
			this.textBox2.TabIndex = 3;
			this.textBox2.Enter += new System.EventHandler(this.textBox_Enter);
			this.textBox2.MouseEnter += new System.EventHandler(this.textBox_MouseEnter);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(190, 61);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(100, 19);
			this.textBox3.TabIndex = 4;
			this.textBox3.Enter += new System.EventHandler(this.textBox_Enter);
			this.textBox3.MouseEnter += new System.EventHandler(this.textBox_MouseEnter);
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(41, 105);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(100, 19);
			this.textBox4.TabIndex = 5;
			this.textBox4.Enter += new System.EventHandler(this.textBox_Enter);
			this.textBox4.MouseEnter += new System.EventHandler(this.textBox_MouseEnter);
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(190, 105);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(100, 19);
			this.textBox5.TabIndex = 6;
			this.textBox5.Enter += new System.EventHandler(this.textBox_Enter);
			this.textBox5.MouseEnter += new System.EventHandler(this.textBox_MouseEnter);
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(297, 17);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "変　更";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(297, 46);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 8;
			this.button2.Text = "キャンセル";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// LayerInfoDialog
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(384, 163);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "LayerInfoDialog";
			this.ShowInTaskbar = false;
			this.Text = "LayerInfoDialog";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LayerInfoDialog_FormClosing);
			this.Load += new System.EventHandler(this.LayerInfoDialog_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}