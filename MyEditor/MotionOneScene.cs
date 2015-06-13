using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEditor
{
	class MotionOneScene
	{
		#region 変数、クラス宣言
		List<Layer> _Layers = new List<Layer>();
		/// <summary>		/// レイヤーセット
		/// </summary>
		public List<Layer> Layers
		{
			get
			{
				return _Layers;
			}
		}

		double Opacity; 

		#endregion 変数、クラス宣言
	}
}
