namespace MyEditor
{
    partial class Form1
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadCharacterLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changeSizeSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x16ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x48ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x64ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x96ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.inputSizeIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportAnimationEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changeEditorCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.animationEditorAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.motionEditorMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.panel2 = new System.Windows.Forms.Panel();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.label2 = new System.Windows.Forms.Label();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.menuStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileFToolStripMenuItem,
            this.changeEditorCToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(724, 26);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileFToolStripMenuItem
			// 
			this.fileFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadCharacterLToolStripMenuItem,
            this.changeSizeSToolStripMenuItem,
            this.exportAnimationEToolStripMenuItem,
            this.closeXToolStripMenuItem});
			this.fileFToolStripMenuItem.Name = "fileFToolStripMenuItem";
			this.fileFToolStripMenuItem.Size = new System.Drawing.Size(54, 22);
			this.fileFToolStripMenuItem.Text = "file(&F)";
			// 
			// loadCharacterLToolStripMenuItem
			// 
			this.loadCharacterLToolStripMenuItem.Name = "loadCharacterLToolStripMenuItem";
			this.loadCharacterLToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
			this.loadCharacterLToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
			this.loadCharacterLToolStripMenuItem.Text = "loadCharacter(&L)";
			this.loadCharacterLToolStripMenuItem.Click += new System.EventHandler(this.changeSizeSToolStripMenuItem_Click);
			// 
			// changeSizeSToolStripMenuItem
			// 
			this.changeSizeSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x16ToolStripMenuItem,
            this.x32ToolStripMenuItem,
            this.x48ToolStripMenuItem,
            this.x64ToolStripMenuItem,
            this.x96ToolStripMenuItem,
            this.inputSizeIToolStripMenuItem});
			this.changeSizeSToolStripMenuItem.Name = "changeSizeSToolStripMenuItem";
			this.changeSizeSToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
			this.changeSizeSToolStripMenuItem.Text = "changeSize(&S)";
			// 
			// x16ToolStripMenuItem
			// 
			this.x16ToolStripMenuItem.Name = "x16ToolStripMenuItem";
			this.x16ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
			this.x16ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.x16ToolStripMenuItem.Text = "16 x 16(&1)";
			this.x16ToolStripMenuItem.Click += new System.EventHandler(this.x16ToolStripMenuItem_Click);
			// 
			// x32ToolStripMenuItem
			// 
			this.x32ToolStripMenuItem.Name = "x32ToolStripMenuItem";
			this.x32ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
			this.x32ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.x32ToolStripMenuItem.Text = "32 x 32(&2)";
			this.x32ToolStripMenuItem.Click += new System.EventHandler(this.x32ToolStripMenuItem_Click);
			// 
			// x48ToolStripMenuItem
			// 
			this.x48ToolStripMenuItem.Name = "x48ToolStripMenuItem";
			this.x48ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
			this.x48ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.x48ToolStripMenuItem.Text = "48 x 48(&3)";
			this.x48ToolStripMenuItem.Click += new System.EventHandler(this.x48ToolStripMenuItem_Click);
			// 
			// x64ToolStripMenuItem
			// 
			this.x64ToolStripMenuItem.Name = "x64ToolStripMenuItem";
			this.x64ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
			this.x64ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.x64ToolStripMenuItem.Text = "64 x 64(&4)";
			this.x64ToolStripMenuItem.Click += new System.EventHandler(this.x64ToolStripMenuItem_Click);
			// 
			// x96ToolStripMenuItem
			// 
			this.x96ToolStripMenuItem.Name = "x96ToolStripMenuItem";
			this.x96ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D5)));
			this.x96ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.x96ToolStripMenuItem.Text = "96 x 96(&5)";
			this.x96ToolStripMenuItem.Click += new System.EventHandler(this.x96ToolStripMenuItem_Click);
			// 
			// inputSizeIToolStripMenuItem
			// 
			this.inputSizeIToolStripMenuItem.Name = "inputSizeIToolStripMenuItem";
			this.inputSizeIToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
			this.inputSizeIToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.inputSizeIToolStripMenuItem.Text = "inputSize(&I)";
			this.inputSizeIToolStripMenuItem.Click += new System.EventHandler(this.inputSizeIToolStripMenuItem_Click);
			// 
			// exportAnimationEToolStripMenuItem
			// 
			this.exportAnimationEToolStripMenuItem.Name = "exportAnimationEToolStripMenuItem";
			this.exportAnimationEToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.exportAnimationEToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
			this.exportAnimationEToolStripMenuItem.Text = "exportAnimation(&E)";
			this.exportAnimationEToolStripMenuItem.Click += new System.EventHandler(this.exportAnimationEToolStripMenuItem_Click);
			// 
			// closeXToolStripMenuItem
			// 
			this.closeXToolStripMenuItem.Name = "closeXToolStripMenuItem";
			this.closeXToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
			this.closeXToolStripMenuItem.Text = "endApplication(&X)";
			this.closeXToolStripMenuItem.Click += new System.EventHandler(this.closeXToolStripMenuItem_Click);
			// 
			// changeEditorCToolStripMenuItem
			// 
			this.changeEditorCToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.animationEditorAToolStripMenuItem,
            this.motionEditorMToolStripMenuItem});
			this.changeEditorCToolStripMenuItem.Name = "changeEditorCToolStripMenuItem";
			this.changeEditorCToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
			this.changeEditorCToolStripMenuItem.Text = "changeEditor(&C)";
			// 
			// animationEditorAToolStripMenuItem
			// 
			this.animationEditorAToolStripMenuItem.Name = "animationEditorAToolStripMenuItem";
			this.animationEditorAToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.animationEditorAToolStripMenuItem.Text = "AnimationEditor(&A)";
			this.animationEditorAToolStripMenuItem.Click += new System.EventHandler(this.animationEditorAToolStripMenuItem_Click);
			// 
			// motionEditorMToolStripMenuItem
			// 
			this.motionEditorMToolStripMenuItem.Name = "motionEditorMToolStripMenuItem";
			this.motionEditorMToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.motionEditorMToolStripMenuItem.Text = "MotionEditor(&M)";
			this.motionEditorMToolStripMenuItem.Click += new System.EventHandler(this.motionEditorMToolStripMenuItem_Click);
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Location = new System.Drawing.Point(210, 190);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(416, 350);
			this.panel1.TabIndex = 1;
			this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(100, 50);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
			this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
			// 
			// panel2
			// 
			this.panel2.AutoScroll = true;
			this.panel2.Controls.Add(this.button3);
			this.panel2.Controls.Add(this.button2);
			this.panel2.Location = new System.Drawing.Point(12, 26);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
			this.panel2.Size = new System.Drawing.Size(614, 158);
			this.panel2.TabIndex = 2;
			this.panel2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel2_Scroll);
			this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
			this.panel2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseClick);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(344, 50);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(20, 20);
			this.button3.TabIndex = 0;
			this.button3.Text = "←";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.DeleteMotion);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(344, 24);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(20, 20);
			this.button2.TabIndex = 0;
			this.button2.Text = "→";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.AddMotion);
			// 
			// panel3
			// 
			this.panel3.AutoScroll = true;
			this.panel3.Controls.Add(this.checkBox1);
			this.panel3.Controls.Add(this.label3);
			this.panel3.Controls.Add(this.button1);
			this.panel3.Controls.Add(this.comboBox1);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Location = new System.Drawing.Point(12, 190);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(192, 350);
			this.panel3.TabIndex = 3;
			this.panel3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseClick);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(50, 58);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(77, 16);
			this.checkBox1.TabIndex = 5;
			this.checkBox1.Text = "ループ再生";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(48, 139);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 12);
			this.label3.TabIndex = 4;
			this.label3.Text = "label3";
			this.label3.Visible = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(35, 80);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(116, 30);
			this.button1.TabIndex = 0;
			this.button1.Text = "アニメーションの確認";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
			this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "0.1",
            "0.2",
            "0.3",
            "0.4",
            "0.5",
            "0.6",
            "0.7",
            "0.8",
            "0.9",
            "1.0"});
			this.comboBox1.Location = new System.Drawing.Point(133, 23);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(42, 20);
			this.comboBox1.TabIndex = 3;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			this.comboBox1.MouseEnter += new System.EventHandler(this.comboBox1_MouseEnter);
			this.comboBox1.MouseLeave += new System.EventHandler(this.comboBox1_MouseLeave);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(24, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(103, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "アニメーションスピード";
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(553, 543);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 12);
			this.label2.TabIndex = 4;
			this.label2.Text = "HelpMessage";
			this.label2.Visible = false;
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoScrollMargin = new System.Drawing.Size(60, 60);
			this.ClientSize = new System.Drawing.Size(724, 618);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.menuStrip1);
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
			this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadCharacterLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeSizeSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x16ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x32ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x48ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x64ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x96ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeXToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem exportAnimationEToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ToolStripMenuItem inputSizeIToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem changeEditorCToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem animationEditorAToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem motionEditorMToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

