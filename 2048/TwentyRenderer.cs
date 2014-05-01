using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Application
{
	class TwentyRenderer
	{
		static byte[] GetBytes(object str)
		{
			return System.Text.Encoding.ASCII.GetBytes (str.ToString ().ToCharArray ());
		}
		Stream buf;
		public TwentyRenderer () {
			buf = Console.OpenStandardOutput();
		}
		public void text (string str) {
			Console.Clear ();
			Console.WriteLine (str);
		}
		public void render(TwentyGrid grid, int score)
		{
			byte[] newBuffer = new byte[280];
			for (int row = 0; row < 4; row++) {
				Array rowVals = grid.getRow (row);
				for (int col = 0; col < 4; col++) {
					int offset = row * 20 + col * 5;
					GetBytes (rowVals.GetValue (col)).CopyTo(newBuffer, offset);
				}
			}
			buf.Write (newBuffer, 0, 260);
		}
	}
}
