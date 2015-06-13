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
    public partial class SettingDialog : Form
    {
        public SettingDialog()
        {
            InitializeComponent();
        }

		private enum SIZE
		{
			WIDTH=0, HEIGHT
		}
		Label[] errAttentions = new Label[2];
		Label errLabel = new Label();

		// 戻り値用変数宣言
		#region
		/// <summary>
		/// 一コマ幅高さ
		/// </summary>
		private Size _size = new Size();
		#endregion
		// 戻り値用変数
        //===================================================


		private void SettingDialog_Load(object sender, EventArgs e)
		{
			textBox1.Text = _size.Width.ToString();
			textBox2.Text = _size.Height.ToString();
			textBox1.Select();
			// エラーラベルの配置
			int[] left = new int[2] { textBox1.Right + 3, textBox2.Right + 3 };
			int[] top = new int[2] { textBox1.Top + 2, textBox2.Top + 2 };
			for (int i = 0; i < errAttentions.Length; ++i)
			{
				errAttentions[i] = new Label();
				errAttentions[i].ForeColor = Color.Red;
				errAttentions[i].Left = left[i];
				errAttentions[i].Top = top[i];
				tabPage1.Controls.Add(errAttentions[i]);
			}
			errLabel.Text = "サイズは1以上の整数を入れてください。";
			errLabel.ForeColor = Color.Red;
			errLabel.Left = label2.Left;
			errLabel.Top = label2.Bottom + 12;
			errLabel.AutoSize = true;
			errLabel.Visible = false;
			tabPage1.Controls.Add(errLabel);

		}

		/// <summary>
		/// 初期サイズを指定したダイアログボックスを表示
		/// </summary>
		/// <param name="size">初期サイズ</param>
		public void ShowDialog(Size size)
		{
			_size = size;
			ShowDialog();
		}

		/// <summary>
		/// サイズを取得(値をセットした後に呼ぶ)
		/// </summary>
		/// <returns>キャラチップ画像1コマサイズ</returns>
		public Size GetSize()
		{
			return _size;
		}
		/// <summary>
		/// 1コマサイズ
		/// </summary>
		public Size size
		{
			get
			{
				return _size;
			}
		}

		/// <summary>
		/// フォームを閉じる瞬間(前)に呼ばれる
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SettingDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (DialogResult == DialogResult.Cancel)
			{
				return;
			}
			try
			{
				errAttentions[(int)SIZE.WIDTH].Text = "";
				errAttentions[(int)SIZE.HEIGHT].Text = "";
				// 数値か判断
				int width = -1;
				if (int.TryParse(textBox1.Text, out width))
				{
					_size.Width = width;
				}
				else
				{
					errAttentions[(int)SIZE.WIDTH].Text = "*";
				}
				int height = -1;
				if (int.TryParse(textBox2.Text, out height))
				{
					_size.Height = height;
				}
				else
				{
					errAttentions[(int)SIZE.HEIGHT].Text = "*";
				}

				// サイズの確認
				if (_size.Width <= 0 || _size.Height <= 0)
				{
					if (_size.Width <= 0)
					{
						errAttentions[(int)SIZE.WIDTH].Text = "*";
					}
					else if (_size.Height <= 0)
					{
						errAttentions[(int)SIZE.HEIGHT].Text = "*";
					}
				}

				if (	errAttentions[(int)SIZE.WIDTH].Text	!= ""
					||	errAttentions[(int)SIZE.HEIGHT].Text != "")
				{
					errLabel.Visible = true;
					MessageBox.Show(errLabel.Text);
					e.Cancel = true;
				}
			}
			catch (Exception ex)
			{
				e.Cancel = true;
				MessageBox.Show(ex.Message);
			}
		}


        /// <summary>        /// テキストボックスにマウスが乗ったら、内容を選択
        /// </summary>
        /// <param name="sender">TextBox</param>
        /// <param name="e"></param>
        private void textBox_MouseEnter(object sender, EventArgs e)
        {
            SelectTextBox((TextBox)sender);
        }
        /// <summary>
        /// テキストボックスを選択する
        /// </summary>
        /// <param name="sender"></param>
        static public void SelectTextBox(TextBox sender)
        {
            sender.Focus();
			sender.SelectAll();
        }

    }
}
