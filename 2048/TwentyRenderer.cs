using System;
using System.Collections;
using System.Text;

namespace Application
{
	class TwentyRenderer
	{
		public TwentyRenderer () {
		}
		const string ROWSeparator = "+---++---++---++---+";
		private string padInt (int val, int target) {
			string res = val.ToString();
			int padding = (int) (target - res.Length) / 2;
			for (int a = 0; a < padding; a++) {
				res = " " + res + " ";
			}
			if (res.Length < target) {
				res += " ";
			}
			return res;
		}
		private string buildRow (Array row)
		{
			StringBuilder res = new StringBuilder();
			foreach (int val in row) {
				res.Append (padInt (val, 5));
			}
			return ROWSeparator + res.ToString () + ROWSeparator;
		}
		public void text (string str) {
			Console.Clear ();
			Console.WriteLine (str);
		}
		public void render(TwentyGrid grid, int score)
		{
			StringBuilder newBuffer = new StringBuilder();
			for ( int row = 0; row < 4; row++ ) {
				newBuffer.Append(buildRow (grid.getRow (row)));
			}
			Console.Clear ();
			//Console.Write (newBuffer.ToString());
			Console.Write ((string)newBuffer.ToString());
		}
	}
}
