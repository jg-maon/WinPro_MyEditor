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
    /// レイヤーパネル表示フォーム
    /// </summary>
    public partial class LayerWindow : Form
    {

		#region 変数、クラス宣言

		/// <summary>		/// 親オブジェクトモーションエディタ(Bitmap用)
		/// </summary>
		MotionEditor parent;
		


		/// <summary>		/// レイヤーパネル
		/// </summary>
		List<LayerInfoPanel> layerInfoPanel = new List<LayerInfoPanel>();
		/// <summary>		/// レイヤーパネルのレイヤー名用カウント変数
		/// </summary>
		int layerNameNo = 0;

		/// <summary>		/// 選択中のレイヤー
		/// </summary>
		int selectLayer = -1;

        /// <summary>        /// アプリケーションをを終了させるフラグ
        /// </summary>
        bool exitFlag = false;


		#endregion 変数、クラス宣言

		
		/// <summary>		/// 親オブジェクトを引き継ぐ
		/// </summary>
		/// <param name="obj"></param>
		public LayerWindow(MotionEditor obj)
		{
			InitializeComponent();
			parent = obj;		// 親オブジェクトのキャッシュ
		}

        public void WindowClose()
        {
            exitFlag = true;
        }


		private void LayerWindow_Load(object sender, EventArgs e)
        {
			toolTip1.SetToolTip(button1, "レイヤー追加");
			toolTip1.SetToolTip(button2, "レイヤーを前面に");
			toolTip1.SetToolTip(button3, "レイヤーを背面に");
			toolTip1.SetToolTip(button4, "レイヤーを削除");
		}

        private void LayerWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!exitFlag)
            {
                e.Cancel = true;
                exitFlag = false;
            }
        }


		//===================================================
		#region レイヤー追加部

		/// <summary>		/// テキストボックスにマウスが載ったらフォーカスを入れる
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void textBox_MouseEnter(object sender, EventArgs e)
        {
            SettingDialog.SelectTextBox((TextBox)sender);
        }



		/// <summary>		/// テキストボックス内でキーが押されたら
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void textBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				// ESCが押された
				e.SuppressKeyPress = true;		// beep音を鳴らなくする
			}
			else if (e.KeyCode == Keys.Enter)
			{
				// Enterが押された
				e.SuppressKeyPress = true;      // beep音を鳴らなくする
				AddLayer();
			}
		}

		/// <summary>		/// レイヤー追加ボタンがクリックされた
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			AddLayer();
		}

		/// <summary>		/// レイヤーを追加するかの判定など
		/// </summary>
		private void AddLayer()
		{
			try
			{
				// 正常に値が入っているか 明示的にfalseで初期化
				bool[] ok = new bool[4]{false,false,false,false};

				//----------------------------------------
				// 数値か判断
				int x = -1;
				if (int.TryParse(textBox1.Text, out x))
				{
					ok[0] = true;
				}
				int y = -1;
				if (int.TryParse(textBox2.Text, out y))
				{
					ok[1] = true;
				}
				int w = -1;
				if (int.TryParse(textBox3.Text, out w))
				{
					ok[2] = true;
				}
				int h = -1;
				if (int.TryParse(textBox4.Text, out h))
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
				if (i == ok.Length)
				{
					// All OK ならばここに入る
					AddLayerOne(new Rectangle(x, y, w, h));
				}
				else
				{
					// 何もしない
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		#endregion レイヤー追加部
		//===================================================

		//===================================================
		#region レイヤーパネル
		/// <summary>		/// 実レイヤー追加処理
		/// </summary>
		/// <param name="src">読み込み領域</param>
		public void AddLayerOne(Rectangle src)
		{
			LayerInfoPanel l = new LayerInfoPanel(parent.partsImg, src);
			l.Tag = layerInfoPanel.Count;	// 最後尾に追加するため(上から何番目か)
			// フォーム用設定
            l.Size = new Size(this.flowLayoutPanel1.Width - l.Margin.Horizontal - SystemInformation.VerticalScrollBarWidth, 60);
			l.TabStop = false;

			// イベント
			l.MouseClick += new MouseEventHandler(layerInfoPanel_MouseClick);
			l.MouseDoubleClick += new MouseEventHandler(layerInfoPanel_MouseDoubleClick);



			// 次の追加レイヤー名用にカウント+
			layerNameNo++;
            l.layerName += layerNameNo;

            // 管理リストに追加
            layerInfoPanel.Add(l);
            // 表示用にレイヤーウィンドウに追加
            flowLayoutPanel1.Controls.Add(l);

			flowLayoutPanel1.Refresh();
		}

        //===================================================
		#region レイヤー選択系

		/// <summary>		/// レイヤー情報がクリックされたら選択したことにする
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void layerInfoPanel_MouseClick(object sender, MouseEventArgs e)
		{
			LayerInfoPanel lip = (LayerInfoPanel)sender;
			if (0 <= selectLayer && selectLayer < layerInfoPanel.Count)
			{
				layerInfoPanel[selectLayer].UnSelectPanel();
			}
			selectLayer = (int)lip.Tag;
            layerInfoPanel[selectLayer].SelectPanel();
            //flowLayoutPanel1.Focus();
            flowLayoutPanel1.Refresh();
		}

		/// <summary>		/// レイヤー情報がダブルクリックされたら情報変更ダイアログを表示
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void layerInfoPanel_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			int no = (int)((LayerInfoPanel)sender).Tag;
			LayerInfoDialog layerDialog = new LayerInfoDialog(
								layerInfoPanel[no].layerName,layerInfoPanel[no].src);
			
			layerDialog.ShowDialog(this);

			if (layerDialog.DialogResult == DialogResult.OK)
			{
				layerInfoPanel[no].layerName = layerDialog.name;
				layerInfoPanel[no].src = layerDialog.src;
			}


			layerDialog.Dispose();
		}

		#endregion レイヤー選択系

		/// <summary>
		/// レイヤーの入れ替え(インデクサではrefが使えないため、要素番号で代用)
		/// 入れ替え後Zオーダー(Tag)を再設定する
		/// </summary>
		/// <param name="a">入れ替えレイヤー番号1</param>
		/// <param name="b">入れ替えレイヤー番号2</param>
		private void SwapLayer(int a, int b)
		{
			LayerInfoPanel swap = layerInfoPanel[a];
			layerInfoPanel[a] = layerInfoPanel[b];
			layerInfoPanel[b] = swap;

			for (int i = 0; i < layerInfoPanel.Count; ++i)
			{
				layerInfoPanel[i].Tag = i;
			}
		}


		/// <summary>
		/// FlowLayoutPanel上のレイヤーパネル情報を更新
		/// </summary>
		private void UpdateFlowLayoutPanelLayerPanel()
		{
			flowLayoutPanel1.Controls.Clear();
			flowLayoutPanel1.Controls.AddRange(layerInfoPanel.ToArray());
		}


		/// <summary>        /// レイヤーを前面に
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button2_Click(object sender, EventArgs e)
		{
			if (selectLayer == -1) return;
			if (selectLayer > 0)
			{
				// 上に一つ上がる
				layerInfoPanel[selectLayer].UnSelectPanel();
				// スワップ
				SwapLayer(selectLayer, selectLayer - 1);
				// パネル上のレイヤーも入れ替える
				UpdateFlowLayoutPanelLayerPanel();

				selectLayer--;
				layerInfoPanel[selectLayer].SelectPanel();
            }
            flowLayoutPanel1.Refresh();
        }

        /// <summary>        /// レイヤーを背面に
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
			if (selectLayer == -1) return;
			if (selectLayer < layerInfoPanel.Count-1)
			{
				// 下に一つ下がる
				layerInfoPanel[selectLayer].UnSelectPanel();
				// スワップ
				SwapLayer(selectLayer, selectLayer + 1);
				// パネル上のレイヤーも入れ替える
				UpdateFlowLayoutPanelLayerPanel();

				selectLayer++;
				layerInfoPanel[selectLayer].SelectPanel();
			}
			flowLayoutPanel1.Refresh();
        }

        /// <summary>        /// レイヤーを削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button4_Click(object sender, EventArgs e)
		{
			if (selectLayer == -1) return;
			// 消す番号
			int eraseNo = selectLayer;
			layerInfoPanel[selectLayer].UnSelectPanel();
			// 消す番号以降のレイヤーの番号を詰める
			for (int i = eraseNo; i < layerInfoPanel.Count - 1; ++i)
			{
				LayerInfoPanel swap = layerInfoPanel[i];
				layerInfoPanel[i] = layerInfoPanel[i + 1];
				layerInfoPanel[i + 1] = swap;
			}
			for (int i = 0; i < layerInfoPanel.Count; ++i)
			{
				layerInfoPanel[i].Tag = i;
			}
			// 詰めたため、削除レイヤーは最後尾(layerInfoPanel.Count-1)に来ている
			flowLayoutPanel1.Controls.Remove(layerInfoPanel[layerInfoPanel.Count - 1]);
			layerInfoPanel.Remove(layerInfoPanel[layerInfoPanel.Count - 1]);
			// 削除した後、削除前の一つ上のレイヤーを選択させておく
			// 削除レイヤーが0の時は、削除後0を選択
			if (eraseNo == 0)
			{
				selectLayer = 0;
			}
			else
			{
				selectLayer = eraseNo - 1;
			}
			if (selectLayer < layerInfoPanel.Count)
			{
				layerInfoPanel[selectLayer].SelectPanel();
			}
			else
			{
				selectLayer = -1;
			}
			flowLayoutPanel1.Refresh();
		}

        #endregion レイヤーパネル


		private void textBox_Enter(object sender, EventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			textBox.SelectAll();
		}

		private void RepaintContainer(object sender, PaintEventArgs e)
		{
			foreach (Control c in ((Control)sender).Controls)
			{
				c.Refresh();
			}
		}

        
        //===================================================


    }
}
