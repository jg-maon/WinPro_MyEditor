namespace MyEditor
{
	partial class MotionEditor
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPartsLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeSizeSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x16ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x48ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x64ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x96ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputSizeIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportMotionEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeEditorCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animationEditorAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motionEditorMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControlEx1 = new MyEditor.TabControlEx();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.tabControlEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileFToolStripMenuItem,
            this.changeEditorCToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(571, 26);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileFToolStripMenuItem
            // 
            this.fileFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadPartsLToolStripMenuItem,
            this.changeSizeSToolStripMenuItem,
            this.exportMotionEToolStripMenuItem,
            this.closeXToolStripMenuItem});
            this.fileFToolStripMenuItem.Name = "fileFToolStripMenuItem";
            this.fileFToolStripMenuItem.Size = new System.Drawing.Size(54, 22);
            this.fileFToolStripMenuItem.Text = "file(&F)";
            // 
            // loadPartsLToolStripMenuItem
            // 
            this.loadPartsLToolStripMenuItem.Name = "loadPartsLToolStripMenuItem";
            this.loadPartsLToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadPartsLToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.loadPartsLToolStripMenuItem.Text = "loadParts(&L)";
            this.loadPartsLToolStripMenuItem.Click += new System.EventHandler(this.loadPartsLToolStripMenuItem_Click);
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
            this.changeSizeSToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.changeSizeSToolStripMenuItem.Text = "changeSize(&S)";
            // 
            // x16ToolStripMenuItem
            // 
            this.x16ToolStripMenuItem.Name = "x16ToolStripMenuItem";
            this.x16ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.x16ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.x16ToolStripMenuItem.Text = "16 x 16(&1)";
            // 
            // x32ToolStripMenuItem
            // 
            this.x32ToolStripMenuItem.Name = "x32ToolStripMenuItem";
            this.x32ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.x32ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.x32ToolStripMenuItem.Text = "32 x 32(&2)";
            // 
            // x48ToolStripMenuItem
            // 
            this.x48ToolStripMenuItem.Name = "x48ToolStripMenuItem";
            this.x48ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.x48ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.x48ToolStripMenuItem.Text = "48 x 48(&3)";
            // 
            // x64ToolStripMenuItem
            // 
            this.x64ToolStripMenuItem.Name = "x64ToolStripMenuItem";
            this.x64ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.x64ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.x64ToolStripMenuItem.Text = "64 x 64(&4)";
            // 
            // x96ToolStripMenuItem
            // 
            this.x96ToolStripMenuItem.Name = "x96ToolStripMenuItem";
            this.x96ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D5)));
            this.x96ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.x96ToolStripMenuItem.Text = "96 x 96(&5)";
            // 
            // inputSizeIToolStripMenuItem
            // 
            this.inputSizeIToolStripMenuItem.Name = "inputSizeIToolStripMenuItem";
            this.inputSizeIToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.inputSizeIToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.inputSizeIToolStripMenuItem.Text = "inputSize(&I)";
            // 
            // exportMotionEToolStripMenuItem
            // 
            this.exportMotionEToolStripMenuItem.Name = "exportMotionEToolStripMenuItem";
            this.exportMotionEToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.exportMotionEToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.exportMotionEToolStripMenuItem.Text = "exportMotion(&E)";
            this.exportMotionEToolStripMenuItem.Click += new System.EventHandler(this.exportMotionEToolStripMenuItem_Click);
            // 
            // closeXToolStripMenuItem
            // 
            this.closeXToolStripMenuItem.Name = "closeXToolStripMenuItem";
            this.closeXToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
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
            // openFileDialog1
            // 
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // tabControlEx1
            // 
            this.tabControlEx1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlEx1.Controls.Add(this.tabPage1);
            this.tabControlEx1.ItemSize = new System.Drawing.Size(10, 18);
            this.tabControlEx1.Location = new System.Drawing.Point(0, 26);
            this.tabControlEx1.Name = "tabControlEx1";
            this.tabControlEx1.Padding = new System.Drawing.Point(25, 3);
            this.tabControlEx1.SelectedIndex = 0;
            this.tabControlEx1.Size = new System.Drawing.Size(572, 390);
            this.tabControlEx1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(564, 364);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "newScene1";
            // 
            // MotionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 416);
            this.Controls.Add(this.tabControlEx1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MotionEditor";
            this.Text = "MotionEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MotionEditor_FormClosing);
            this.Load += new System.EventHandler(this.MotionEditor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControlEx1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileFToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadPartsLToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem changeSizeSToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x16ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x32ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x48ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x64ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x96ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem inputSizeIToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportMotionEToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeXToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem changeEditorCToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem animationEditorAToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem motionEditorMToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private TabControlEx tabControlEx1;
		private System.Windows.Forms.TabPage tabPage1;
	}
}