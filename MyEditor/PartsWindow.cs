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
    /// パーツ画像表示フォーム
    /// </summary>
    public partial class PartsWindow : Form
    {
        //=================================================================
        #region 変数、クラス宣言

        /// <summary>        /// モーションエディタ(Bitmap用)のキャッシュ
        /// </summary>
        MotionEditor parent;

        /// <summary>        /// レイヤーパネル追加用レイヤーウィンドウのキャッシュ
        /// </summary>
        LayerWindow layerWindow;

        /// <summary>        /// 一つ当たりのパーツのサイズ
        /// </summary>
        Size partsSize = new Size(64, 64);


        /// <summary>        /// 表示用オフスクリーン
        /// </summary>
        Graphics offScreen;
        /// <summary>        /// オフスクリーン適用ビットマップ
        /// </summary>
        Bitmap offBitmap;



        /// <summary>        /// アプリケーションをを終了させるフラグ
        /// </summary>
        bool exitFlag = false;

        #endregion 変数、クラス宣言
        //=================================================================

        public PartsWindow(MotionEditor owner, LayerWindow lWindow)
        {
            InitializeComponent();
            parent = owner;
            layerWindow = lWindow;

        }

        public PartsWindow()
        {
            InitializeComponent();
        }

        private void PartsWindow_Load(object sender, EventArgs e)
        {
            this.Location = new Point(parent.Location.X + parent.Width,
                                    parent.Location.Y);
            pictureBox1.Size = parent.partsImg.Size;
            offBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            offScreen = Graphics.FromImage(offBitmap);
            DrawPartsImage();
        }

        public void WindowClose()
        {
            exitFlag = true;
        }

        private void PartsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!exitFlag)
            {
                e.Cancel = true;
                exitFlag = false;
            }
        }




        //==================================================================
        public void ChangeSize(Size size)
        {
            this.MinimumSize = size;
            partsSize = size;
        }


        /// <summary>        /// 選択中のパーツをレイヤーに追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // マウス座標をマス目座標に
            int x = (e.X / partsSize.Width) * partsSize.Width;
            int y = (e.Y / partsSize.Height) * partsSize.Height;
            // レイヤー追加
            layerWindow.AddLayerOne(new Rectangle(x, y, partsSize.Width, partsSize.Height));
        }


        /// <summary>        /// パーツ画像の表示等
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //DrawPartsImage();
        }
        /// <summary>        /// パーツ画像の表示等
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PartsWindow_Paint(object sender, PaintEventArgs e)
        {
            DrawPartsImage();
        }

        /// <summary>        /// パーツ画像の表示
        /// </summary>
        private void DrawPartsImage()
        {
            // オフスクリーン作成
            offScreen.Clear(this.BackColor);
            offScreen.DrawImage(parent.partsImg, 0, 0);
            pictureBox1.Image = offBitmap;
        }

        /// <summary>		/// フォームのリサイズ(オフスクリーンの作り直し)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PartsWindow_Resize(object sender, EventArgs e)
        {
            // リサイズされたらオフスクリーンの作り直し
            offBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            offScreen = Graphics.FromImage(offBitmap);
        }


    }
}