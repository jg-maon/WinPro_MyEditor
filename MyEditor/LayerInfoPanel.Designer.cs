namespace MyEditor
{
	partial class LayerInfoPanel
	{
		/// <summary> 
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region コンポーネント デザイナーで生成されたコード

		/// <summary> 
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(20, 23);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(15, 14);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.TabStop = false;
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Location = new System.Drawing.Point(50, 5);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(50, 50);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
			this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.SystemColors.Control;
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.Location = new System.Drawing.Point(106, 23);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(85, 12);
			this.textBox1.TabIndex = 3;
			this.textBox1.TabStop = false;
			this.textBox1.Text = "レイヤー";
			this.textBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseClick);
			this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LayerInfoPanel_KeyDown);
			this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
			this.textBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseDoubleClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(104, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 12);
			this.label1.TabIndex = 4;
			this.label1.Text = "レイヤー";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			this.label1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label1_MouseClick);
			this.label1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDoubleClick);
			// 
			// LayerInfoPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.checkBox1);
			this.DoubleBuffered = true;
			this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.Name = "LayerInfoPanel";
			this.Size = new System.Drawing.Size(208, 60);
			this.Load += new System.EventHandler(this.LayerInfoPanel_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.LayerInfoPanel_Paint);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LayerInfoPanel_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;



	}
}
