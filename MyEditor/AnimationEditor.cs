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
	/// アニメーションエディタ
	/// </summary>
    public partial class AnimationEditor : Form
    {
        public AnimationEditor()
        {
            InitializeComponent();
            
        }
        //=====================================================================
        // 変数 クラス宣言
        #region 変数 クラス宣言

        // イベントデリゲート
		public event CloseEventHandler CloseEvent;


		//==========================================
		// Panel1
		#region Panel1
		/// <summary>		/// Panel1の最小サイズ(初期値)
		/// </summary>
		Size panel1MinSize;

		/// <summary>		/// キャラチップファイル名
		/// </summary>
		string characterFile = null;

		/// <summary>		/// キャラクタ一覧用のビットマップ
		/// </summary>
		Bitmap _characterPic = null;
		/// <summary>		/// キャラクタ一覧用のビットマップ
		/// </summary>
		public Bitmap characterPic
		{
			get { return _characterPic; }
		}
		
		/// <summary>		/// キャラクタ画像のサイズ
		/// </summary>
		Size charaImgSize;

		/// <summary>		/// キャラクタ一覧オフスクリーン用ビットマップ
		/// </summary>
        Bitmap offBitmap = null;

		/// <summary>		/// キャラクタ一覧オフスクリーン作成用グラフィックス
		/// </summary>
        Graphics offScreen = null;
		
		/// <summary>		/// キャラクタ一コマのサイズ
		/// </summary>
		Size _charaSize = new Size(-1, -1);
		/// <summary>		/// キャラクタ一コマのサイズ
		/// </summary>
		public Size charaSize
		{
			get { return _charaSize; }
		}

		
		/// <summary>		/// キャラクタ一覧列最大数
		/// </summary>
        int picColMax = 0;
		/// <summary>		/// キャラクタ一覧行最大数
		/// </summary>
        int picRowMax = 0;

		/// <summary>		/// 選択されたキャラクタ画像の番号
		/// </summary>
		int charaNo = 0;
		/// <summary>		/// 選択されたキャラクタ画像の列位置
		/// </summary>
		int charaRow = -1;
		/// <summary>		/// 選択されたキャラクタ画像の行位置
		/// </summary>
		int charaCol = -1;
		
		/// <summary>		/// ループ再生チェックボックスのチェック状態を返す
		/// </summary>
		public bool checkBox1Checked
		{
			get { return checkBox1.Checked; }
		}

		#endregion
		// Panel1

		//==========================================
		//Panel2
		#region Panel2

		/// <summary>		/// アニメーション数
		/// </summary>
		int animeMax = 15;

		/// <summary>		/// Panel2最小サイズ(初期値)
		/// </summary>
		Size panel2MinSize;

		/// <summary>		/// アニメーション画像番号表示用ラベル
		/// </summary>
        Label[] animeNo;
		/// <summary>		/// アニメーション画像(1コマ)表示用
		/// </summary>
        PictureBox[] animePic;

		/// <summary>		/// animePicサイズ
		/// </summary>
		Size animePicSize = new Size(48, 48);		
		/// <summary>		/// アニメーション表示回数選択用
		/// </summary>
        ComboBox[] motionCount;
		
		/// <summary>		/// 選択されたアニメーションメンバ
		/// </summary>
        int selectAnimeMember = -1;

		/// <summary>		/// アニメーション画像用キャラクタ番号
		/// </summary>
        int[] _animePicNo;
		/// <summary>		/// アニメーション画像用キャラクタ番号
		/// </summary>
		public int[] animePicNo
		{
			get { return _animePicNo; }
		}

		#endregion
		// Panel2
		
		//==========================================
		// Panel3
		#region Panel3
		/// <summary>		/// アニメーション確認フォーム
		/// </summary>
		AnimationViewer f3 = null;

		/// <summary>		/// モーション数
		/// </summary>
        int _motionMax = 0;
		/// <summary>		/// モーション数
		/// </summary>
		public int motionMax
		{
			get { return _motionMax; }
		}

		/// <summary>		/// コマの表示時間(繰り返し回数)
		/// </summary>
		int[] _motionTime;
		/// <summary>		/// コマの表示時間(繰り返し回数)
		/// </summary>
		public int[] motionTime
		{
			get { return _motionTime; }
		}

		/// <summary>		/// アニメーションスピード
		/// </summary>
        float _animeSpeed = 0.2f;
		/// <summary>		/// アニメーションスピード
		/// </summary>
		public float animeSpeed
		{
			get { return _animeSpeed; }
		}
		
		/// <summary>		/// モーションカウントガイドメッセ―ジ
		/// </summary>
        bool motionCountMsg = false;

		/// <summary>		/// 書き出しファイル名
		/// </summary>
		string exportFileName = null;

		#endregion
		// Panel3

        #endregion
        //=====================================================================

		// Panel1 : キャラクタ一覧画像
		// Panel2 : アニメーション選択
		// Panel3 : モーション確認


		//=====================================================================
		// 汎用関数
		#region 汎用関数

		#region フォーム全体に関わるもの


		/// <summary>		/// フォームのロード(Initialize)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void AnimationEditor_Load(object sender, EventArgs e)
        {
			// 初期ウィンドウ位置の調整
			Location = new Point(20, 20);
			// フォームのタイトル
			Text = "AnimationEditor";


			// 必要変数の設定
			panel1.MinimumSize = panel1.Size;
			panel2.MinimumSize = panel2.Size;
			panel1MinSize = panel1.Size;
			panel2MinSize = panel2.Size;


			//--------------------------------------
			// メニュー、パネル類設定
			#region

			//========================================
			// Panel1
			panel1.Visible = false;     // パネル1(キャラクターアニメ一覧)非表示
			// キャラチップロードメニュー非表示
			VisibleMenu(loadCharacterLToolStripMenuItem, false);
			// キャラクタサイズ選択用メニュー非表示
			VisibleMenu(changeSizeSToolStripMenuItem, false);

			//========================================
			// Panel2
			panel2.Visible = false;     // パネル2(キャラクターモーション)非表示

			//========================================
			// Panel3
			panel3.Visible = false;     // パネル3(アニメーション確認)非表示
			// アニメーション保存メニュー非表示
			VisibleMenu(exportAnimationEToolStripMenuItem, false);
            timer1.Stop();				// タイマーオフ
			#endregion
			// メニュー、パネル類

			// ヘルプメッセージの表示
			HelpMsg(loadCharacterLToolStripMenuItem.Width+16, menuStrip1.Bottom+3,
					"アニメーションに使用するキャラクタの一覧ファイルを読み込んでください".Length,
					2,
					"「file」の「loadCharacter」を実行して、\n"
				  + "アニメーションに使用するキャラクタの一覧ファイルを読み込んでください");
			// キャラチップロードメニュー有効化
			VisibleMenu(loadCharacterLToolStripMenuItem, true);


        }

		//========================================
		/// <summary>		/// パネル2再描画 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AnimationEditor_Paint(object sender, PaintEventArgs e)
		{
			Panel2Disp();
		}

		//========================================
		/// <summary>		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer1_Tick(object sender, EventArgs e)
		{
            
		}

		//========================================
		/// <summary>		/// フォームのリサイズ時パネルサイズを変更する
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AnimationEditor_ResizeEnd(object sender, EventArgs e)
		{
			// 横 右端から求めたいが、Rightは使えないためWidth = Right - Leftを使う
			panel1.Width = ClientRectangle.Right - panel1.Left - this.AutoScrollMargin.Width;
			panel2.Width = ClientRectangle.Right - panel2.Left - this.AutoScrollMargin.Width;
			// 縦 Height = Bottom - Top
			panel1.Height = ClientRectangle.Bottom - panel1.Top - this.AutoScrollMargin.Height;
		}

		#endregion フォーム全体に関わるもの


		//========================================
		//========================================
		#region その他
		/// <summary> 		/// ヘルプメッセージの表示
		/// </summary>
		/// <param name="p">表示座標</param>
		/// <param name="len">1列の文字数</param>
		/// <param name="lines">行数</param>
		/// <param name="msg">内容</param>
		private void HelpMsg(Point p, int len, int lines, string msg)
		{
			HelpMsg(p.X, p.Y, len, lines, msg);
		}
        private void HelpMsg(int x, int y, int len, int lines, string msg)
        {
            label2.SetBounds(x, y, len * 10, lines * 13);
            label2.ForeColor = Color.DarkGreen;
            label2.BackColor = Color.Azure;
            label2.Text = msg;
            label2.Visible = true;
        }
		/// <summary>		/// ヘルプメッセージ非表示
		/// </summary>
        private void HelpMsg()
        {
            label2.Visible = false;
        }

		/// <summary> 		/// メニューの表示(有効非有効)切り替え
		/// </summary>
		/// <param name="item">表示切り替えをするメニュー</param>
		/// <param name="flag">表示状態</param>
		private void VisibleMenu(ToolStripMenuItem item, bool flag)
		{
			item.Enabled = flag;
			item.Visible = flag;
			foreach (ToolStripMenuItem child in item.DropDownItems)
			{
				VisibleMenu(child, flag);
			}
		}

		/// <summary>		/// 行番号を取り出す
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		public int ColNo(int n)
		{
			return n % picColMax;
		}

		/// <summary>		/// 列番号を取り出す
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		public int RowNo(int n)
		{
			return n / picColMax;
		}

		#endregion その他



		#endregion
		// 汎用関数

		//=====================================================================
		// メニュー関数
		#region メニュー関数

		//==========================================
		// 未分類
		#region フォームを閉じるか切り替える
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
		/// <summary> 		/// アプリケーションを終了させる
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

		private void animationEditorAToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CloseEventArgs c = new CloseEventArgs();
			c.message = "change";
			c.formNo = 1;		// フォームの番号を指定
			this.OnClose(c);
		}

		private void motionEditorMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CloseEventArgs c = new CloseEventArgs();
			c.message = "change";
			c.formNo = 2;		// フォームの番号を指定
			this.OnClose(c);
		}
		#endregion フォームを閉じるか切り替える
		// 未分類

		//==========================================
		// Panel1
		#region
		/// <summary>		/// キャラクタ一覧の読み込みメニュー 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void changeSizeSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter =
                "Images (*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png|" +
                "All files (*.*)|*.*";

            // デフォルトロードキャラファイル名
			openFileDialog1.FileName = "";

            openFileDialog1.Multiselect = false;    // 複数選択禁止
            openFileDialog1.Title = "読み込むキャラクタファイルを選択してください。";
            openFileDialog1.ShowDialog();           // ダイアログ表示
        }

		/// <summary>		/// キャラクタ一覧用のファイル読み込み
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            // ファイル名
            characterFile = openFileDialog1.SafeFileName;

            // ビットマップ読み込み
            Stream s = openFileDialog1.OpenFile();
            _characterPic = (Bitmap)System.Drawing.Bitmap.FromStream(s);
            s.Close();

			_characterPic.MakeTransparent(_characterPic.GetPixel(0, 0));

			// リソースの関係上反対から順に準備
			///////////////////////////////////////////////////
			// パネル3(アニメーション確認)
			#region

			panel3.Visible = true;
            comboBox1.SelectedIndex = 1;            // アニメーションスピード0.2

			#endregion

			///////////////////////////////////////////////////
			// パネル2(モーション)
			#region

			SetPanel2Controls();			// パネル2コントロール準備
			panel2.Visible = true;          // パネル2(アニメーション選択)表示

			SelectAnimationMember(0);		// PictureBox0番目を選択させておく

			#endregion

            ///////////////////////////////////////////////////
			// パネル1(キャラチップ)
			#region
			panel1.Visible = true;          // パネル表示

			// キャラクタ一覧のサイズをセット
			charaImgSize = _characterPic.Size;
			
			// キャラクタ一覧表示
			pictureBox1.Image = _characterPic;
			pictureBox1.Size = _characterPic.Size;

			// 初期コマサイズ64x64
			if (_charaSize.Width == -1)
			{
				SelectCheckedItem(x64ToolStripMenuItem);
				ChangeCharacterChipSize(64);
			}
			else
			{
				ChangeCharacterChipSize(_charaSize);
			}
			/*
			ChangeCharacterChipSize(64);
			x64ToolStripMenuItem.Checked = true;
			*/

			// コマサイズ変更メニュー有効化
			VisibleMenu(changeSizeSToolStripMenuItem, true);

			// モーション書き出しメニュー有効化
			VisibleMenu(exportAnimationEToolStripMenuItem, true);

			#endregion



		}
		
		//==============================
		// サイズ変更
		#region
		/// <summary>		/// サイズ変更
		/// </summary>
		/// <param name="size">幅高さ</param>
		private void ChangeCharacterChipSize(Size size)
		{
			ChangeCharacterChipSize(size.Width, size.Height);
		}
		/// <summary>		/// サイズ変更
		/// </summary>
		/// <param name="width">幅</param>
		/// <param name="height">高さ(省略時幅と同値)</param>
		private void ChangeCharacterChipSize(int width, int height = -1)
		{
			_charaSize.Width = width;
			if (height != -1)
			{
				_charaSize.Height = height;
			}
			else
			{
				// 正方形にする
				_charaSize.Height = width;
			}
			// ビットマップサイズを割り切れるように
			offBitmap = new Bitmap(charaImgSize.Width + charaImgSize.Width % charaSize.Width + 2,
									charaImgSize.Height + charaImgSize.Height % charaSize.Height + 2);
			pictureBox1.Size = offBitmap.Size;

			DispCharaChipBorder();
			// アニメーションパネルの内容を更新する
			for (int i = 0; i < _animePicNo.Length; ++i)
			{
				// サイズ外のアニメーションを選択することになったら、初期化する
				if (_animePicNo[i] < 0 || _animePicNo[i]*charaSize.Width > _characterPic.Width)
				{
					_animePicNo[i] = -1;
				}
			}
			Panel2Disp();


		}
		
		/// <summary>		/// メニューにチェックマークを付ける
		/// </summary>
		/// <param name="sender">どのメニューか</param>
		private void SelectCheckedItem(object sender)
		{
			foreach (ToolStripMenuItem item in changeSizeSToolStripMenuItem.DropDownItems)
			{
				if (item.Equals(sender))
				{
					item.Checked = true;
				}
				else
				{
					item.Checked = false;
				}
			}
		}
		// Size x Size
		private void x16ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectCheckedItem(sender);
			ChangeCharacterChipSize(16);
		}
		private void x32ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectCheckedItem(sender);
			ChangeCharacterChipSize(32);
		}
		private void x48ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectCheckedItem(sender);
			ChangeCharacterChipSize(48);
		}
		private void x64ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectCheckedItem(sender);
			ChangeCharacterChipSize(64);
		}
		private void x96ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectCheckedItem(sender);
			ChangeCharacterChipSize(96);
		}
		// 任意サイズ
		private void inputSizeIToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SettingDialog setting = new SettingDialog();

			setting.ShowDialog(charaSize);

			if (setting.DialogResult == DialogResult.OK)
			{
				//"OK";
				SelectCheckedItem(sender);
				ChangeCharacterChipSize(setting.GetSize());
			}
			else if (setting.DialogResult == DialogResult.Cancel)
			{
				//"Cancel";
			}
			setting.Dispose();

		}

		#endregion
		// サイズ変更

		#endregion
		// Panel1

		//==========================================
		// Panel2
		#region
		#endregion
		// Panel2

		//==========================================
		// Panel3
		#region
		/// <summary>		/// アニメーションの保存ダイアログ表示
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void exportAnimationEToolStripMenuItem_Click(object sender, EventArgs e)
		{
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
		}
		/// <summary>		/// アニメーション保存
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
		{
			GetMotionTime();
			ExportAnimation(saveFileDialog1.FileName);
			Panel2Disp();
		}
		/// <summary>		/// アニメーションファイルの作成
		/// </summary>
		/// <param name="fileName">作成するファイル名</param>
		private void ExportAnimation(string fileName)
		{
			exportFileName = Path.GetFileName(fileName);
			bool append = false;
			Encoding encode = Encoding.GetEncoding("shift_jis");
			StreamWriter writer = new StreamWriter(fileName, append, encode);
			try
			{
				using (StreamReader reader = new StreamReader(
					"animationFormat.txt", Encoding.GetEncoding("shift_jis")))
				{
					// 書き出し設定
					string format = reader.ReadToEnd();

					// 書き込み準備
					#region
					// 読み込み画像ファイル名
					string data = format.Replace("$FileName$",characterFile);
					// アニメーション一コマ画像横幅
					data = data.Replace("$Width$",charaSize.Width.ToString());
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
		}
		#endregion
		// Panel3

		#endregion
		// メニュー関数

		//=====================================================================
		// 各パネルイベント等処理
		#region

        ////////////////////////////////////////////////////////////////////
        // Panel1
        //
        #region Panel1
        

		/// <summary>		/// キャラクタ一覧上でクリックされたとき
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			// キャラクタが選択されていたら
			if (selectAnimeMember != -1)
			{
				charaCol = e.X / charaSize.Width;
				charaRow = e.Y / charaSize.Height;

				// 画像内でなかったらスキップ
				if (!(charaCol < picColMax && charaRow < picRowMax))
					return;

				// 画像上でも右クリックでなし要素
				if (e.Button == MouseButtons.Right)
				{
					charaNo = -1;
				}
				else
				{
					// 通し番号
					charaNo = charaRow * picColMax + charaCol;
				}
				// キャラクタ一覧に選択されたキャラ枠を表示
				DispCharaChipBorder();

				// pictureBox用に番号格納
				_animePicNo[selectAnimeMember] = charaNo;
				// キャラクタ画像表示
				DispChara(selectAnimeMember);

			}
			if (selectAnimeMember == 0)
			{
				int x = panel3.Width/2;
				int w = 150;
				label3.SetBounds(x-w/2, button1.Bottom+5, w, 90);
				label3.ForeColor = Color.DarkGreen;
				label3.BackColor = Color.LightBlue;
				label3.Text = "\n必要なコマ数分\n"
							+ "アニメーションのコマの選択と\n"
							+ "登録する画像のクリックを\n"
							+ "繰り返し、登録が完了したら\n"
							+ "アニメーションの確認を\n"
							+ "実行し確認してください。\n ";
				label3.Visible = true;
			}
			// HelpMsg();
			// 次のボックスを自動選択
			if (selectAnimeMember + 1 < animePic.Length)
			{
				SelectAnimationMember(selectAnimeMember + 1);
			}
		}

		/// <summary>		/// キャラチップに枠線を書く
		/// </summary>
		private void DispCharaChipBorder()
		{
			if (offBitmap == null) return;
			// キャラクタ一覧表示用オフスクリーンの作成
			offScreen = Graphics.FromImage(offBitmap);
			// 前回の絵を消去
			offScreen.Clear(this.BackColor);

			// キャラクタ一覧を表示し直し
			offScreen.DrawImage(_characterPic, 0, 0);
			//--------------------------------------------------
			// キャラクタのサイズに合わせ枠を表示する
			picColMax = charaImgSize.Width / charaSize.Width;
			if (picColMax == 0)
			{
				// 最低でも1つは描画する
				picColMax = 1;
			}
			else if (charaImgSize.Width % charaSize.Width != 0)
			{
				// 割り切れない場合も一つは余分に描画しておく
				picColMax += 1;
			}
			picRowMax = charaImgSize.Height / charaSize.Height;
			if (picRowMax == 0)
			{
				// 最低でも1つは描画する
				picRowMax = 1;
			}
			else if (charaImgSize.Height % charaSize.Height != 0)
			{
				// 割り切れない場合も一つは余分に描画しておく
				picRowMax += 1;
			}
			for (int row = 0; row < picRowMax; ++row)
			{
				for (int col = 0; col < picColMax; ++col)
				{
					// 1キャラ分青い四角で囲む
					offScreen.DrawRectangle(Pens.Blue,
											new Rectangle(col * charaSize.Width,
															row * charaSize.Height,
															charaSize.Width, charaSize.Height));
				}
			}
			// 選択中のものは別色を囲む
			if (charaNo >= 0)
			{
				offScreen.DrawRectangle(Pens.Yellow,
										new Rectangle(ColNo(charaNo) * charaSize.Width,
														RowNo(charaNo) * charaSize.Height,
														charaSize.Width, charaSize.Height));
			}

			pictureBox1.Image = offBitmap;      // ピクチャーボックスに適用して表示させる

			offScreen.Dispose();

		}



        #endregion Panel1
        // Panel1



        ////////////////////////////////////////////////////////////////////
        // Panel2
        //
        #region Panel2
		/// <summary>		/// 各種コントロールの用意
		/// </summary>
        private void SetPanel2Controls()
        {
            animeNo = new Label[animeMax];
            animePic = new PictureBox[animeMax];
            _animePicNo = new int[animeMax];
            for (int i = 0; i < _animePicNo.Length; ++i) _animePicNo[i] = -1;
            motionCount = new ComboBox[animeMax];
            //----------------------------------------
			// コントロール設定
			#region コントロール設定
			panel2.Controls.Clear();
			panel2.Controls.Add(button2);
			panel2.Controls.Add(button3);
			for (int i = 0; i < animeMax; ++i)
            {
                // 番号ラベル
                animeNo[i] = new Label();
                {
                    animeNo[i].SetBounds(20 + (8 + animePicSize.Width) * i, 4, animePicSize.Width + 4, 18);
                    animeNo[i].Text = i.ToString("D2");
                }
                panel2.Controls.Add(animeNo[i]);

                // pictureBox
                animePic[i] = new PictureBox();
                {
                    animePic[i].SetBounds(animeNo[i].Left, animeNo[i].Bottom + 2, animePicSize.Width, animePicSize.Height);
                    animePic[i].Tag = i;
                    animePic[i].BorderStyle = BorderStyle.FixedSingle;
                    // クリックされた時のイベント
					animePic[i].MouseClick += new MouseEventHandler(animePic_MouseClick);
					animePic[i].Paint += new PaintEventHandler(panel2_Paint);
					toolTip1.SetToolTip(animePic[i], "右クリックで削除");
                }
                panel2.Controls.Add(animePic[i]);

                // comboBox
                motionCount[i] = new ComboBox();
                {
                    motionCount[i].SetBounds(animePic[i].Left, animePic[i].Bottom + 2, animePic[i].Width, 18);
                    motionCount[i].Tag = i;
                    motionCount[i].DropDownStyle = ComboBoxStyle.DropDownList;
                    // 中身
                    for (int n = 1; n <= 5; ++n)
                    {
                        motionCount[i].Items.Add(n.ToString() + "回");
                    }
                    motionCount[i].SelectedIndex = 0;
                    // ヘルプメッセージ用イベント
                    motionCount[i].MouseHover += new System.EventHandler(motionCount_MouseHover);
                    motionCount[i].MouseLeave += new System.EventHandler(motionCount_MouseLeave);
                }
                panel2.Controls.Add(motionCount[i]);
			}
			#endregion コントロール設定
			//-----------------------------------------

			//-----------------------------------------
            #region アニメーション数増減ボタン設定
            {
                int l, t;   // 左上
                if (animeMax <= 0)
                {
                    l = 20;           // animePicなし時の左
                    t = 4 + 18 + 2;   // animePicなし時の上
                    // 左余白、ラベル高さ、ラベル縦余白
                }
                else
                {
                    l = animePic[animeMax - 1].Right;
                    t = animePic[animeMax - 1].Top;
					// ついでにanimePicの先頭にを選択しておく(でないとボタン(一番最後)が選択されてしまっているため)
					animePic[0].Select();
                }
                // 余白
                l += 5;
                // 真ん中から上下に配置する
                t += animePicSize.Height / 2;
                const int marginX = 5;  // 横余白
                const int marginY = 6;  // 縦余白

                button2.Left = l + marginX;
                button2.Top = t - (button2.Height+marginY/2);

                button3.Left = l + marginX;
                button3.Top = t + marginY/2;

			}
			#endregion アニメーション数増減ボタン設定
			//-----------------------------------------
           
			
        }

        
		/// <summary>		/// アニメーションpictureBoxがクリックされた時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void animePic_MouseClick(object sender, MouseEventArgs e)
        {
			// 選択されたアニメーションメンバーを取得
			int no =(int)((PictureBox)sender).Tag;
			if (e.Button == MouseButtons.Right)
			{
				// コマ内容を消去
				_animePicNo[no] = -1;
			}
			// コマ選択
			SelectAnimationMember(no);
        }


		/// <summary>		/// アニメーションメンバ画像を選択
		/// </summary>
		/// <param name="memberNo">選択した画像番号</param>
		private void SelectAnimationMember(int memberNo)
		{
			if (memberNo < 0 || memberNo >= animeMax) return;

			// 選択した画像番号をキャラクタ一覧に適用
			charaNo = _animePicNo[memberNo];
			
			DispCharaChipBorder();


			// 選択されたアニメーションメンバーを取得
			selectAnimeMember = memberNo;

			// 外枠表示
			DispAnimationMemberBorder();


			if (_animePicNo[selectAnimeMember] < 0)
			{
				HelpMsg(180, 120, 40, 3,
							"\nアニメーション"
							+ selectAnimeMember.ToString()
							+ "コマ目にする画像を下記の一覧より選びクリックしてください\n ");
			}

		}        

		/// <summary>		/// 選択コマ(animePic)に枠表示
		/// </summary>
		private void DispAnimationMemberBorder()
		{
			if (selectAnimeMember >= animePic.Length) return;
			// パネル2に表示させるためのグラフィックス
			Graphics gr = panel2.CreateGraphics();

			gr.FillRectangle(new SolidBrush(this.BackColor), 0, 0, panel2.Width, panel2.Height);

			// 選択表示に黄色の枠
			const int BorderWidth = 2;
			gr.FillRectangle(new SolidBrush(Color.Yellow),
								new Rectangle(animePic[selectAnimeMember].Left - BorderWidth,
											animePic[selectAnimeMember].Top - BorderWidth,
											animePic[selectAnimeMember].Width + BorderWidth * 2,
											animePic[selectAnimeMember].Height + BorderWidth * 2));
			gr.Dispose();

		}


		
		/// <summary>		/// Panel2のpictureBoxにキャラ画像を描画
		/// </summary>
		/// <param name="no">pictureBoxの配列番号</param>
        private void DispChara(int no)
        {
            // 登録されているキャラ番号を取り出す
            int n = _animePicNo[no];
            // グラフィックス用意
			Graphics gr = animePic[no].CreateGraphics();
            gr.Clear(this.BackColor);
			if (n >= 0)
			{
			// キャラクタ一覧より選択された画像をアニメーションメンバーに表示
                gr.DrawImage(_characterPic,
                                new Rectangle(0, 0, animePic[no].Width, animePic[no].Height),
                                new Rectangle(ColNo(n) * charaSize.Width,
												RowNo(n) * charaSize.Height,
                                                charaSize.Width, charaSize.Height),
                                GraphicsUnit.Pixel);
            }
			gr.Dispose();
        }


		/// <summary>		/// Panel2再描画時などに使用
		/// </summary>
        private void Panel2Disp()
        {
            if (panel2.Visible)
			{
                for (int i = 0; i < animeMax; ++i)
                {
                    DispChara(i);
				}
				DispAnimationMemberBorder();
            }
        }

		private void panel2_Paint(object sender, PaintEventArgs e)
		{
			Panel2Disp();
		}
		/// <summary>		/// Panel2スクロール時再描画
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void panel2_Scroll(object sender, ScrollEventArgs e)
        {
            Panel2Disp();
        }


		/// <summary>		/// モーションカウントの説明を表示
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void motionCount_MouseHover(object sender, EventArgs e)
        {
            if (charaNo >= 0)
            {
                // マウスカーソルのあるComboBoxの番号を調べる
                int no = (int)((ComboBox)sender).Tag;
                int x = 20 + (8 + animePicSize.Width) * no;
                int y = 75 + animePicSize.Height;

                // ヘルプメッセージを表示
                HelpMsg(x, y, 18, 3, "\n同じ画像を表示する場合は\n"
                                    + "表示する回数を選択してください。\n ");
                motionCountMsg = true;
            }
        }
        
		/// <summary>		/// モーションカウントの説明を非表示
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void motionCount_MouseLeave(object sender, EventArgs e)
        {
            if (motionCountMsg)
            {
                HelpMsg();
                motionCountMsg = false;
            }
        }

		//=====================================================================
		/// <summary>		/// モーション追加
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AddMotion(object sender, EventArgs e)
		{
			_motionMax = animeNo.Length;
			StopAnimation();
			//============================================
			// 以下追加処理
			#region
			//========================
			// 入れ物用意
			List<Label> animeNos = animeNo.ToList<Label>();
			List<PictureBox> animePics = animePic.ToList<PictureBox>();
			List<int> animePicNos = _animePicNo.ToList<int>();
			List<ComboBox> motionCounts = motionCount.ToList<ComboBox>();
			//========================
			// 追加分用意
			// 番号ラベル
			Label l = new Label();
			{
				l.SetBounds(20 + (8 + animePicSize.Width) * animeMax + panel2.AutoScrollPosition.X,
                            4,
                            animePicSize.Width + 4,
                            18);
				l.Text = animeMax.ToString("D2");
			}
			animeNos.Add(l);
			//----------------------
			// pictureBox
			PictureBox p = new PictureBox();
			{
				p.SetBounds(l.Left, l.Bottom + 2, l.Width, animePicSize.Height);
				p.Tag = _motionMax;
				p.BorderStyle = BorderStyle.FixedSingle;
				p.MouseClick += new MouseEventHandler(animePic_MouseClick);
				p.Paint += new PaintEventHandler(panel2_Paint);
				toolTip1.SetToolTip(p, "右クリックで削除");
			}
			animePics.Add(p);
			//----------------------
			// picNo
			animePicNos.Add(-1);
			//----------------------
			// comboBox
			ComboBox c = new ComboBox();
			{
				c.SetBounds(p.Left, p.Bottom + 2, p.Width, 18);
				c.Tag = _motionMax;
				c.DropDownStyle = ComboBoxStyle.DropDownList;
				// 中身
				for (int n = 1; n <= 5; ++n)
				{
					c.Items.Add(n.ToString() + "回");
				}
				c.SelectedIndex = 0;
				// ヘルプメッセージ用イベント
				c.MouseHover += new System.EventHandler(motionCount_MouseHover);
				c.MouseLeave += new System.EventHandler(motionCount_MouseLeave);
			}
			motionCounts.Add(c);

			//================================
			// パネルに配置
			panel2.Controls.Add(l);
			panel2.Controls.Add(p);
			panel2.Controls.Add(c);

			//===============================
			// 配列に設定しなおし
			animeNo = animeNos.ToArray();
			animePic = animePics.ToArray();
			_animePicNo = animePicNos.ToArray();
			motionCount = motionCounts.ToArray();
			#endregion

			//===============================
			// ボタンの位置調整
			button2.Left += animePicSize.Width + 8;
			button3.Left += animePicSize.Width + 8;


			//===============================
			// アニメーション数を+1
			animeMax++;
			// 末尾を選択していたら末尾を選択しておく (++したので-1、animeMaxは配列のサイズなので最終要素番号=max-1)
			if (selectAnimeMember == animeMax - 2)
			{
				// 最終要素番号 = max-1
				SelectAnimationMember(animeMax - 1);
			}

		}
		/// <summary>		/// モーション削除
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DeleteMotion(object sender, EventArgs e)
		{
			// アニメーションを停止する(末尾参照時に消すと要素オーバーするので一応。)
			StopAnimation();
			animeMax = animeNo.Length;
			// モーション数が0の時はスキップ
			if (animeMax == 0) return;
			// Maxを一つ減らしておく
			animeMax--;
			// 削除前選択が末尾だった場合、消去後の参照番号を末尾にする(削除後の末尾に調整する)
			SelectAnimationMember((selectAnimeMember >= animeMax) ? animeMax - 1 : selectAnimeMember);
			//============================================
			// 以下削除処理
			#region
			//========================
			// 入れ物用意
			List<Label> animeNos = animeNo.ToList<Label>();
			List<PictureBox> animePics = animePic.ToList<PictureBox>();
			List<int> animePicNos = _animePicNo.ToList<int>();
			List<ComboBox> motionCounts = motionCount.ToList<ComboBox>();

			//================================
			// パネルから除去
			panel2.Controls.Remove(animeNo[animeMax]);
			panel2.Controls.Remove(animePics[animeMax]);
			panel2.Controls.Remove(motionCount[animeMax]);

			//================================
			// 末尾を消す
			animeNos.RemoveAt(animeMax);
			animePics.RemoveAt(animeMax);
			animePicNos.RemoveAt(animeMax);
			motionCounts.RemoveAt(animeMax);


			//===============================
			// 配列に設定しなおし
			animeNo = animeNos.ToArray();
			animePic = animePics.ToArray();
			_animePicNo = animePicNos.ToArray();
			motionCount = motionCounts.ToArray();

			#endregion

			//===============================
			// ボタンの位置調整
			button2.Left -= (animePicSize.Width + 8);
			button3.Left -= (animePicSize.Width + 8);

			// 再描画
			Panel2Disp();
		}


        #endregion Panel2
        // panel2


        ////////////////////////////////////////////////////////////////////
        // Panel3
        //
        #region Panel3
		/// <summary>		/// アニメーション確認ボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
			if (_animePicNo.Length > 0 && _animePicNo[0] >= 0 && f3 == null)
            {
				// アニメーションスタート
				// アニメーションに必要な準備をする
				SetStartAnimation();
				// アニメーション開始
				f3 = new AnimationViewer(this);
				f3.BackColor = colorDialog1.Color;
				f3.Show();
            }
			else if (f3 != null)
			{
				// アニメーション終了処理をする
                StopAnimation();
            }
        }
		/// <summary>		/// アニメーション確認背景色変更ダイアログボックス表示ボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button4_Click(object sender, EventArgs e)
		{
			colorDialog1.ShowDialog();
		}

		/// <summary>		/// モーションカウントの取り出し(セット)
		/// </summary>
        private void GetMotionTime()
        {
            int i = 0;
            for (i = 0; i < animeMax; ++i)
            {
                if (_animePicNo[i] < 0)
                    break;
            }
            _motionMax = i;
            _motionTime = new int[_motionMax];
            for (i = 0; i < _motionMax; ++i)
            {
                // ComboBoxの内容をモーションタイムにセット
                _motionTime[i] = int.Parse(motionCount[i].Text.Replace("回", ""));
            }
        }

		/// <summary>		/// アニメーション表示開始
		/// </summary>
        private void SetStartAnimation()
        {
            // 変数初期化
			GetMotionTime();
                
            _animeSpeed = float.Parse(comboBox1.Text);

			
			button1.Text = "アニメーション停止";
        }
		/// <summary>		/// アニメーション確認停止
		/// </summary>
		/// <param name="closeFlag">フォームを閉じるか(フォーム先のクローズ処理ならスキップ)</param>
		public void StopAnimation(bool closeFlag = true)
		{
			// アニメーション終了
			if (f3 != null)
			{
				if (closeFlag)
				{
					// アニメーションフォームを閉じて消す
					f3.Close();
				}
				f3 = null;
			}
			button1.Text = "アニメーションの確認";
		}



        // アニメーション確認ボタンマウスエンター
		/// <summary>		/// ボタンの説明表示
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            HelpMsg(panel3.Left + b.Left + 20, panel3.Top + b.Bottom + 5,
                    "アニメーションが確認できます。".Length, 4,
                    "\nクリックすると作成した\n"
                  + "アニメーションが確認できます\n ");

        }
		/// <summary>		/// ボタンの説明非表示
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            HelpMsg();
        }

        // アニメーションスピード変更
		/// <summary>		/// アニメーションスピードの変更
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _animeSpeed = float.Parse(comboBox1.Text);
        }

        // アニメーションスピード変更ボタン
		/// <summary>		/// ボタンの説明表示
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;
            HelpMsg(panel3.Left + c.Left + 20, panel3.Top + c.Bottom + 5,
                "スピードが変えられます。".Length, 2,
                "アニメーションの\n"
              + "スピードが変えられます。");
        }
		/// <summary>		/// ボタンの説明非表示
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void comboBox1_MouseLeave(object sender, EventArgs e)
        {
            HelpMsg();
        }



        #endregion Panel3
		// Panel3


		/// <summary>		/// フォーカス
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panel1_MouseClick(object sender, MouseEventArgs e)
		{
			panel1.Focus();

		}
		/// <summary>		/// フォーカス
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>	
		private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
		{
			panel1.Focus();

		}

		/// <summary>		/// フォーカス
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>	
		private void panel2_MouseClick(object sender, MouseEventArgs e)
		{
			panel2.Focus();

		}

		/// <summary>		/// フォーカス
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panel3_MouseClick(object sender, MouseEventArgs e)
		{
			panel3.Focus();

		}


		#endregion
		// 各パネルイベント等処理
		//=====================================================================
	}
}
