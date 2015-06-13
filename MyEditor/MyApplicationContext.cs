using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyEditor
{
	public class CloseEventArgs : EventArgs
	{
		int _formNo;
		public int formNo
		{
			set
			{
				_formNo = value;
			}
			get
			{
				return _formNo;
			}
		}
		string _message;
		public string message 
		{
			set
			{
				_message = value;
			}
			get
			{
				return _message;
			}
		}
	}
	// デリゲートの宣言
	public delegate void CloseEventHandler(object sender, CloseEventArgs e);

	class MyApplicationContext : ApplicationContext
	{

		/// <summary> 	/// コンストラクタ 始めのフォームを開く
		/// </summary>
		public MyApplicationContext()
		{
			AnimationEditor f1 = new AnimationEditor();
			f1.CloseEvent += new CloseEventHandler(Closed_Form);
			this.MainForm = f1;
		}

		private void Closed_Form(object sender, CloseEventArgs e)
		{
			// エディタの変更
			if (e.message == "change")
			{
				// 確認
				if (MessageBox.Show("エディタを切り替えます。変更を保存していない場合、\n内容が破棄されてしまいますがよろしいですか？",
									"エディタの切り替え",
									MessageBoxButtons.YesNo,
									MessageBoxIcon.Question
								) == DialogResult.No) return;

				if (e.formNo == 1)
				{
					AnimationEditor f1 = new AnimationEditor();
					f1.CloseEvent += new CloseEventHandler(Closed_Form);
					f1.Location = MainForm.Location;
					this.MainForm = f1;
					f1.Show();
				}
				else if(e.formNo == 2)
				{
					MotionEditor f2 = new MotionEditor();
					f2.CloseEvent += new CloseEventHandler(Closed_Form);
					f2.Location = MainForm.Location;
					this.MainForm = f2;
					f2.Show();
				}
				((Form)sender).Close();		// 送られてきたフォームは閉じる
				sender = null;	// 一応
			}
			else if (e.message == "exit")
			{
				Application.Exit();	//	アプリケーションを閉じる
			}
		}
	}
}
