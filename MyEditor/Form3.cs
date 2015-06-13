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
	/// アニメーション確認別窓
	/// </summary>
	public partial class Form3 : Form
	{
		#region 変数宣言
		/// <summary>		/// 親フォームの情報
		/// </summary>
		Form1 parent;
		/// <summary>
		/// 確認用オフスクリーン
		/// </summary>
		Graphics offScreen;
		/// <summary>
		/// オフスクリーン適用ビットマップ
		/// </summary>
		Bitmap offBitmap;
		
		/// <summary>		/// 現在表示中のモーション番号(カウント)
		/// </summary>
		int motionNo = 0;
		
		/// <summary>		/// アニメーション表示累計時間(基準時間)
		/// </summary>
		float animeTime = 0.0f;
		
		/// <summary>		/// モーション移行カウント(タイマー)
		/// </summary>
		int nextMotionTime = 0;

		/// <summary>		/// アニメーション表示時間
		/// </summary>
		int dispTime = 0;

		#endregion 変数宣言

		public Form3(Form1 parent)
		{
			InitializeComponent();
			this.parent = parent;
			this.Owner = parent;
		}

		/// <summary>		/// アニメーションスタート準備
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form3_Load(object sender, EventArgs e)
		{
			ClientSize = parent.charaSize;
			this.Text = "クリックするとウィンドウを閉じます";

			// 変数初期化
			motionNo = 0;
			nextMotionTime = parent.motionTime[motionNo];
			animeTime = 0.0f;
			dispTime = 0;


			// アニメーション確認用準備
			offBitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
			offScreen = Graphics.FromImage(offBitmap);

			// タイマー
			timer1.Interval = 17;
			timer1.Start();

		}

		/// <summary>		/// アニメーション確認
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer1_Tick(object sender, EventArgs e)
		{

			animeTime += parent.animeSpeed;
			dispTime = (int)animeTime;
			// 表示時間がアニメーション更新時間に達したら
			if (dispTime == nextMotionTime)
			{
				if (++motionNo == parent.motionMax)
				{
					// モーション数が最後まで来たら
					// ループするか
					if (parent.checkBox1Checked)
					{
						motionNo = 0;   // ループ
					}
					else
					{
						motionNo--;	// モーションの固定
					}
				}
				nextMotionTime += parent.motionTime[motionNo];

				// オフスクリーン作成
				offScreen.Clear(this.BackColor);
				int n = parent.animePicNo[motionNo];
				offScreen.DrawImage(parent.characterPic,
					// 表示領域
					ClientRectangle,
					// 読み込み領域
					new Rectangle(
						parent.ColNo(n) * parent.charaSize.Width,
						parent.RowNo(n) * parent.charaSize.Height,
						parent.charaSize.Width,
						parent.charaSize.Height),
					GraphicsUnit.Pixel);

				// オフスクリーンの内容をフォームに適用
				Graphics g = CreateGraphics();
				g.DrawImage(offBitmap, 0, 0);
				g.Dispose();
			}

		}


		/// <summary>		/// フォームのリサイズ(オフスクリーンの作り直し)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form3_Resize(object sender, EventArgs e)
		{
			// リサイズされたらオフスクリーンの作り直し
			offBitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
			offScreen = Graphics.FromImage(offBitmap);

		}

		/// <summary>		/// 画像がクリックされたらフォームを閉じる
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form3_Click(object sender, EventArgs e)
		{
			Close();
		}
		/// <summary>		/// フォームを閉じる
		/// </summary>
		private void Form3_FormClosing(object sender, FormClosingEventArgs e)
		{
			timer1.Stop();
			// Form1にも終了処理をするように呼ぶ(自分でフォームをクローズしているのでForm1ではクローズさせない)
			parent.StopAnimation(false);
		}

	}
}
