using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyEditor
{
    /// <summary>
    /// レイヤー情報パネル
    /// 領域(src)とレイヤー名(layerName)
    /// 表示フラグ(layerVisible)を持つ
    /// </summary>
	public partial class LayerInfoPanel : UserControl
	{
		#region 変数、クラス宣言

		#region 外部から呼び出されるもの
		/// <summary>		/// レイヤー名
		/// </summary>
		public string layerName
		{
			get
			{
				return label1.Text;
			}
			set
			{
				label1.Text = value;
				textBox1.Text = label1.Text;
			}
		}

		Rectangle _src;
		/// <summary>		/// 参照領域
		/// </summary>
		public Rectangle src
		{
			get
			{
				return _src;
			}
			set
			{
				_src = value;
			}
		}
		
		/// <summary>		/// レイヤーの表示非表示
		/// </summary>
		public bool layerVisible
		{
			get
			{
				return checkBox1.Checked;
			}
			set
			{
				checkBox1.Checked = value;
			}
		}
		

		#endregion 外部から呼び出されるもの

		/// <summary>		/// 参照先画像
		/// </summary>
		Bitmap bitmap = null;


		/// <summary>		/// オフスクリーン用ビットマップ
		/// </summary>
		Bitmap offBitmap = null;


		/// <summary>		/// 選択中レイヤーを示す背景色
		/// </summary>
		Color selectBackColor = Color.FromArgb(60, 60, 60);


		#endregion 変数、クラス宣言

		public LayerInfoPanel()
		{
			InitializeComponent();
			textBox1.KeyDown += new KeyEventHandler(textBox1_KeyDown);
		}

		public LayerInfoPanel(Bitmap srcImg, Rectangle srcRect)
		{
			InitializeComponent();
			bitmap = srcImg;
			_src = srcRect;
			offBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);


			PreviewDraw();
		}

        private void LayerInfoPanel_Load(object sender, EventArgs e)
        {
            //textBox1.ForeColor = Color.White;
			textBox1.Enabled = false;
			label1.Visible = true;
        }

		/// <summary>		/// pictureBox描画
		/// </summary>
		private void PreviewDraw()
		{
			if (offBitmap == null || bitmap == null) return;
			// オフスクリーンからグラフィックスの作成
			Graphics gr = Graphics.FromImage(offBitmap);
			gr.Clear(this.BackColor);

			gr.DrawImage(bitmap, 0, 0, _src, GraphicsUnit.Pixel);

			// オフスクリーンの内容をpictureBoxに適用
			pictureBox1.Image = offBitmap;
			gr.Dispose();
			


		}

		private void LayerInfoPanel_Paint(object sender, PaintEventArgs e)
		{
			PreviewDraw();
		}

		/// <summary>		/// 反転選択する
		/// </summary>
		public void SelectPanel()
		{
			this.BackColor = selectBackColor;
			textBox1.BackColor = selectBackColor;
			this.ForeColor = Color.White;
			textBox1.ForeColor = Color.White;
            this.Focus();
		}

		/// <summary>		/// 反転選択を解除
		/// </summary>
		public void UnSelectPanel()
		{
			this.BackColor = DefaultBackColor;
			this.ForeColor = DefaultForeColor;
			textBox1.BackColor = TextBox.DefaultBackColor;
			textBox1.ForeColor = TextBox.DefaultForeColor;
		}

		/// <summary>		/// レイヤー名変更モード
		/// </summary>
		private void StartLayerNameEdit()
		{
			textBox1.Text = label1.Text;
			label1.Visible = false;
			textBox1.Enabled = true;
			textBox1.BackColor = Color.FromArgb(20, 20, 20);
			textBox1.ForeColor = Color.White;
			textBox1.Focus();
			textBox1.SelectAll();
		}

		/// <summary>		/// レイヤー名変更終了
		/// </summary>
		/// <param name="apply">レイヤー名を変えるか</param>
		private void EndLayerNameEdit(bool apply)
		{
			if (apply)
			{
				// レイヤー名変更
				label1.Text = textBox1.Text;
			}
			textBox1.Enabled = false;
			textBox1.BackColor = selectBackColor;
			label1.Visible = true;
			textBox1.Focus();
		}

		//=========================================================================
		#region イベントいっぱい

		private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
		{
			this.OnMouseClick(e);
		}

		private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.OnMouseDoubleClick(e);
		}

		private void textBox1_MouseClick(object sender, MouseEventArgs e)
		{
			if (!textBox1.Enabled)
			{
				this.OnMouseClick(e);
			}
		}

		private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (!textBox1.Enabled)
			{
				this.OnMouseDoubleClick(e);
			}
		}

		private void LayerInfoPanel_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F2)
			{
				StartLayerNameEdit();
			}
			if (sender == textBox1)
			{
				textBox1_KeyDown(sender, e);
			}
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			// 編集モード終了
			EndLayerNameEdit(true);

		}
		
		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				// beep音
				e.SuppressKeyPress = true;
				// レイヤー名変更キャンセル
				EndLayerNameEdit(false);
			}
			else if(e.KeyCode == Keys.Enter)
			{
				// Beep
				e.SuppressKeyPress = true;
				// レイヤー名変更
				EndLayerNameEdit(true);
			}
		}

		private void label1_MouseClick(object sender, MouseEventArgs e)
		{
			
			this.OnMouseClick(e);

		}

		private void label1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.OnMouseDoubleClick(e);
		}

		#endregion イベントいっぱい

		private void label1_Click(object sender, EventArgs e)
		{
			textBox1.Focus();
		}
		//=========================================================================

	}
}
