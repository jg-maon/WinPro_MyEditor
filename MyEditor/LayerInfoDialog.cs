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
	public partial class LayerInfoDialog : Form
	{

		//===================================================
		#region 変数、クラス宣言
		Rectangle _src;
		/// <summary>		/// 参照領域
		/// </summary>
		public Rectangle src
		{
			get
			{
				return _src;
			}
		}

		string _name;
		/// <summary>		/// レイヤー名
		/// </summary>
		public string name
		{
			get
			{
				return _name;
			}
		}
		#endregion 変数、クラス宣言
		//===================================================

		public LayerInfoDialog(string layerName, Rectangle srcRect)
		{
			_name = layerName;
			_src = srcRect;
			InitializeComponent();
		}

		public LayerInfoDialog()
		{
			InitializeComponent();
		}
		
		private void LayerInfoDialog_Load(object sender, EventArgs e)
		{
			textBox1.Text = _name;
			textBox2.Text = _src.X.ToString();
			textBox3.Text = _src.Y.ToString();
			textBox4.Text = _src.Width.ToString();
			textBox5.Text = _src.Height.ToString();
		}

		/// <summary>		/// フォームを閉じる際に例外判定
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LayerInfoDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (DialogResult == DialogResult.Cancel)
			{
				return;
			}
			try
			{
				// 正常に値が入っているか 明示的にfalseで初期化
				bool[] ok = new bool[4] { false, false, false, false };

				//----------------------------------------
				// 数値か判断
				int x = -1;
				if (int.TryParse(textBox2.Text, out x))
				{
					ok[0] = true;
				}
				int y = -1;
				if (int.TryParse(textBox3.Text, out y))
				{
					ok[1] = true;
				}
				int w = -1;
				if (int.TryParse(textBox4.Text, out w))
				{
					ok[2] = true;
				}
				int h = -1;
				if (int.TryParse(textBox5.Text, out h))
				{
					ok[3] = true;
				}

				//----------------------------------------
				// 値の範囲を確認
				if (x < 0 || y < 0 || w <= 0 || h <= 0)
				{
					// 一つでも異常な値が入っていたら
					ok[0] = false;
				}

				//----------------------------------------
				// All OK か確認
				int i;
				for (i = 0; i < ok.Length; ++i)
				{
					if (!ok[i])
					{
						// 一つでもfalseがあればループ終了
						break;
					}
				}
				if (i != ok.Length)
				{
					// エラー
					e.Cancel = true;
					MessageBox.Show(this,"入力情報を確認して下さい。", "入力エラー",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					// 完了
					_name = textBox1.Text;
					_src = new Rectangle(x, y, w, h);
				}
			}
			catch (Exception ex)
			{
				e.Cancel = true;
				MessageBox.Show(ex.Message);
			}
		}

		private void textBox_MouseEnter(object sender, EventArgs e)
		{
			SettingDialog.SelectTextBox((TextBox)sender);
		}

		private void textBox_Enter(object sender, EventArgs e)
		{
			SettingDialog.SelectTextBox((TextBox)sender);
		}




	}
}
