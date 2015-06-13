using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEditor
{
	/// <summary>        /// レイヤークラス
	/// </summary>
	class Layer
	{
		#region Layer member
		Rectangle _src;
		/// <summary>            /// 元画像取得領域
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

		Point _move;
		/// <summary>            /// 移動量
		/// </summary>
		public Point move
		{
			get
			{
				return _move;
			}
			set
			{
				_move = value;
			}
		}

		Size _size;
		/// <summary>            /// レイヤーサイズ
		/// </summary>
		public Size size
		{
			get
			{
				return _size;
			}
		}
		/// <summary>            /// 半分の大きさ
		/// </summary>
		public Size HalfSize
		{
			get
			{
				return new Size(_size.Width / 2, _size.Height);
			}
		}


		float _angle;
		/// <summary>            /// 回転量
		/// </summary>
		public float angle
		{
			get
			{
				return _angle;
			}
			set
			{
				_angle = value;
			}
		}
		#endregion Layer member

		#region Layer method
		/// <summary>            /// レイヤーサイズを指定してインスタンスの生成
		/// </summary>
		/// <param name="s">レイヤーサイズ</param>
		public Layer(Rectangle r)
		{
			src = r;
		}
		#endregion Layer method

	}
}
