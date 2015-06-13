using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MyEditor
{
	/// <summary>
	/// モーションエディタ
	/// </summary>
	public partial class MotionEditor : Form
	{
		public MotionEditor()
		{
			InitializeComponent();
		}

        //=====================================================================
		#region クラス、変数宣言
		/// <summary>		/// エディタ切り替え用イベントデリゲート
		/// </summary>
		public event CloseEventHandler CloseEvent;

        //==============================================
        #region パーツウィンドウ

        Bitmap _partsImg;
        /// <summary>        /// パーツ画像
        /// </summary>
		public Bitmap partsImg
		{
			get
			{
				return _partsImg;
			}
		}
        /// <summary>        /// パーツファイル名
        /// </summary>
        string partsFile = "";

        /// <summary>        /// パーツウィンドウ
        /// </summary>
        PartsWindow partsWindow;

        #endregion パーツウィンドウ
        //==============================================


        //==============================================
        #region レイヤーウィンドウ
        
        /// <summary>		/// レイヤーウィンドウ
		/// </summary>
		LayerWindow layerWindow;

        #endregion レイヤーウィンドウ
        //==============================================

        //==============================================
        #region ワークスペース

        /// <summary>        /// 複数レイヤーを一つにまとめるクラス(一枚画像)を複数(各種枚数)
        /// </summary>
        List<List<Layer>> motions = new List<List<Layer>>();

        List<MotionOneScene> motion = new List<MotionOneScene>();

        #endregion ワークスペース
        //==============================================

        #endregion クラス、変数宣言
        //=====================================================================

		//=====================================================================
		/// <summary>		/// 各種準備
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MotionEditor_Load(object sender, EventArgs e)
		{
			//------------------------------------
			// ワークスペース準備
			#region ワークスペース準備

			#endregion ワークスペース準備
			//------------------------------------
		}

		//=====================================================================
		// メニュー関数
		#region
		//----------------------------------------------------
		#region 閉じるかフォームを切り替える処理

        /// <summary>        /// フォームを閉じる際、レイヤーウィンドウも閉じる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MotionEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (partsWindow != null)
            {
                partsWindow.WindowClose();
            }
            if (layerWindow != null)
            {
                layerWindow.WindowClose();
            }
            e.Cancel = false;
        }

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
		
		#endregion 閉じるかフォームを切り替える処理
		//----------------------------------------------------
		
		//----------------------------------------------------
		#region ファイル読み込み

		/// <summary>		/// キャラクタ一覧の読み込みメニュー 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void loadPartsLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openFileDialog1.Filter =
				"Images (*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png|" +
				"All files (*.*)|*.*";

			// デフォルトロードキャラファイル名
			openFileDialog1.FileName = partsFile;

			openFileDialog1.Multiselect = false;    // 複数選択禁止
			openFileDialog1.Title = "読み込むパーツファイルを選択してください。";
			openFileDialog1.ShowDialog();           // ダイアログ表示
		}

		/// <summary>		/// キャラクタ一覧用のファイル読み込み,各ウィンドウ表示
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
		{
			// ファイル名
			partsFile = openFileDialog1.SafeFileName;

            // ビットマップ読み込み
            Stream s = openFileDialog1.OpenFile();
            _partsImg = (Bitmap)System.Drawing.Bitmap.FromStream(s);
            s.Close();

            _partsImg.MakeTransparent(_partsImg.GetPixel(0, 0));

            //-------------------------------------
            #region 各種ウィンドウ表示

            //--------------------------
            // パーツウィンドウ表示
            if (partsWindow != null)
            {
                partsWindow.WindowClose();
                partsWindow.Close();
            }
            if (layerWindow != null)
            {
                layerWindow.WindowClose();
                layerWindow.Close();
            }
            // レイヤーウィンドウ表示
            layerWindow = new LayerWindow(this);
            layerWindow.Show(this);
			// パーツウィンドウ
            partsWindow = new PartsWindow(this, layerWindow);
            partsWindow.Show(this);
			// ウィンドウの位置揃え
			layerWindow.Location = new Point(this.Right, partsWindow.Bottom);
			layerWindow.Refresh();
            #endregion 各種ウィンドウ表示
            //-------------------------------------

        }
		
		#endregion ファイル読み込み
		//----------------------------------------------------

		//----------------------------------------------------
		#region ファイル書き出し

		/// <summary>		/// モーションの保存ダイアログ表示
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void exportMotionEToolStripMenuItem_Click(object sender, EventArgs e)
		{
			/*
			saveFileDialog1.Filter =
				"Text file (*.txt)|*.txt|" + "All files (*.*)|*.*";
			if (exportFileName == null)
			{
				saveFileDialog1.FileName = "";
			}
			else
			{
				saveFileDialog1.FileName = exportFileName;
			}
			saveFileDialog1.Title = "アニメーションの保存";

			saveFileDialog1.ShowDialog();
			*/
		}
		/// <summary>		/// モーション保存処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
		{
			/*
			GetMotionTime();
			ExportAnimation(saveFileDialog1.FileName);
			Panel2Disp();
			 * */
		}
		/// <summary>		/// モーションファイルの作成
		/// </summary>
		/// <param name="fileName">作成するファイル名</param>
		private void ExportAnimation(string fileName)
		{
			/*
			exportFileName = Path.GetFileName(fileName);
			bool append = false;
			Encoding encode = Encoding.GetEncoding("shift_jis");
			StreamWriter writer = new StreamWriter(fileName, append, encode);
			try
			{
				using (StreamReader reader = new StreamReader(
					"motionFormat.txt", Encoding.GetEncoding("shift_jis")))
				{
					// 書き出し設定
					string format = reader.ReadToEnd();

					// 書き込み準備
					#region
					// 読み込み画像ファイル名
					string data = format.Replace("$FileName$", characterFile);
					// アニメーション一コマ画像横幅
					data = data.Replace("$Width$", charaSize.Width.ToString());
					// アニメーション一コマ画像高さ
					data = data.Replace("$Height$", charaSize.Height.ToString());
					// アニメーション列数
					data = data.Replace("$RowNum$", picRowMax.ToString());
					// アニメーション画像総数
					data = data.Replace("$AnimationNum$", _motionMax.ToString());
					// アニメーション画像番号一覧
					string buf = "";
					for (int i = 0; i < _motionMax; ++i)
					{
						buf += _animePicNo[i].ToString("D").PadLeft(4);
						if (i != 0)
						{
							if (i % 10 == 0)
							{
								// 10毎に改行
								buf += "\r\n";
							}
							else if (i % 5 == 0)
							{
								// 5毎にタブ
								buf += "\t";
							}
						}
					}
					data = data.Replace("$AnimationImageNumbers$", buf);

					// モーションウェイト
					buf = "";
					for (int i = 0; i < _motionMax; ++i)
					{
						buf += _motionTime[i].ToString("D").PadLeft(3);
						if (i != 0)
						{
							if (i % 10 == 0)
							{
								// 10毎に改行
								buf += "\r\n";
							}
							else if (i % 5 == 0)
							{
								// 5毎にタブ
								buf += "\t";
							}
						}
					}
					data = data.Replace("$MotionWaits$", buf);
					#endregion

					// 一斉書き込み
					writer.Write(data);

				}
			}
			catch (Exception)
			{
				// デフォルト設定で書き出し
				writer.Write("#FileName ");
				writer.WriteLine(characterFile);
				writer.Write("#Size ");
				writer.WriteLine(charaSize);
				writer.Write("#AnimationNum ");
				writer.WriteLine(_motionMax);
				writer.WriteLine("#AnimImgNo");
				for (int i = 0; i < _motionMax; ++i)
				{
					string buf = _animePicNo[i].ToString("D").PadLeft(4);
					if (i != 0)
					{
						if (i % 10 == 0)
						{
							writer.WriteLine();
						}
						else if (i % 5 == 0)
						{
							writer.Write("\t");
						}
					}
					writer.Write(buf);
				}
				writer.WriteLine();
				writer.WriteLine("#MotionWait");
				for (int i = 0; i < _motionMax; ++i)
				{
					string buf = _motionTime[i].ToString("D").PadLeft(3);
					if (i != 0)
					{
						if (i % 10 == 0)
						{
							writer.WriteLine();
						}
						else if (i % 5 == 0)
						{
							writer.Write("\t");
						}
					}
					writer.Write(buf);
				}
			}
			writer.Close();
			 * */
		}

		#endregion ファイル書き出し

        //----------------------------------------------------

        #endregion メニュー関数

	}
}
