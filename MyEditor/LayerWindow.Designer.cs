namespace MyEditor
{
    partial class LayerWindow
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.textBox4);
			this.panel1.Controls.Add(this.textBox3);
			this.panel1.Controls.Add(this.textBox2);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(200, 100);
			this.panel1.TabIndex = 0;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.RepaintContainer);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(162, 68);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(26, 18);
			this.button1.TabIndex = 8;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(103, 46);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(13, 12);
			this.label4.TabIndex = 7;
			this.label4.Text = "H";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 46);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(14, 12);
			this.label3.TabIndex = 6;
			this.label3.Text = "W";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(103, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(12, 12);
			this.label2.TabIndex = 5;
			this.label2.Text = "Y";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(12, 12);
			this.label1.TabIndex = 4;
			this.label1.Text = "X";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(121, 43);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(55, 19);
			this.textBox4.TabIndex = 3;
			this.textBox4.Enter += new System.EventHandler(this.textBox_Enter);
			this.textBox4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
			this.textBox4.MouseEnter += new System.EventHandler(this.textBox_MouseEnter);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(30, 43);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(55, 19);
			this.textBox3.TabIndex = 2;
			this.textBox3.Enter += new System.EventHandler(this.textBox_Enter);
			this.textBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
			this.textBox3.MouseEnter += new System.EventHandler(this.textBox_MouseEnter);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(121, 18);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(55, 19);
			this.textBox2.TabIndex = 1;
			this.textBox2.Enter += new System.EventHandler(this.textBox_Enter);
			this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
			this.textBox2.MouseEnter += new System.EventHandler(this.textBox_MouseEnter);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(30, 18);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(55, 19);
			this.textBox1.TabIndex = 0;
			this.textBox1.Enter += new System.EventHandler(this.textBox_Enter);
			this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
			this.textBox1.MouseEnter += new System.EventHandler(this.textBox_MouseEnter);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(98, 377);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(26, 20);
			this.button2.TabIndex = 9;
			this.button2.Text = "↑";
			this.button2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(130, 377);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(26, 20);
			this.button3.TabIndex = 10;
			this.button3.Text = "↓";
			this.button3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(162, 377);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(26, 20);
			this.button4.TabIndex = 11;
			this.button4.Text = "☒";
			this.button4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoScroll = true;
			this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 100);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 271);
			this.flowLayoutPanel1.TabIndex = 12;
			this.flowLayoutPanel1.WrapContents = false;
			this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.RepaintContainer);
			// 
			// LayerWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(200, 400);
			this.ControlBox = false;
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LayerWindow";
			this.ShowInTaskbar = false;
			this.Text = "LayerWindow";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LayerWindow_FormClosing);
			this.Load += new System.EventHandler(this.LayerWindow_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.RepaintContainer);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}