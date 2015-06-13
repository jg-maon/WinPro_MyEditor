using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyEditor
{
	/// <summary>
	/// モーションエディタ
	/// </summary>
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}

		// イベントデリゲート
		public event CloseEventHandler CloseEvent;


		//=====================================================================
		// メニュー関数
		#region
		/// <summary>		/// フォームを閉じるイベントを発生させる
		/// </summary>
		/// <param name="e">イベントの情報</param>
		protected virtual void OnClose(CloseEventArgs e)
		{
			if (CloseEvent != null)
			{
				CloseEvent(this, e);
			}
		}

		/// <summary>		/// アプリケーションを終了させる
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void closeXToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//Application.Exit();
			CloseEventArgs c = new CloseEventArgs();
			c.message = "exit";
			// イベントの発生
			this.OnClose(c);
		}
		/// <summary>		/// animationEditorを起動
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void animationEditorAToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CloseEventArgs c = new CloseEventArgs();
			c.message = "change";
			c.formNo = 1;		// フォームの番号を指定
			this.OnClose(c);
		}
		/// <summary>		/// motionEditorを起動
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void motionEditorMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CloseEventArgs c = new CloseEventArgs();
			c.message = "change";
			c.formNo = 2;		// フォームの番号を指定
			this.OnClose(c);
		}

		#endregion
		// メニュー関数

	}
}
