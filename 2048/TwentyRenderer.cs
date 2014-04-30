using System;
using System.Collections;
using System.Text;

namespace Application
{
	class TwentyRenderer
	{
		public TwentyRenderer () {
		}
		const string ROWSeparator = "+ ++ ++ ++ +";
		const string ROWBoxStart = "|";
		const string ROWBoxEnd = "|";
		const string ROWPadding = "-  --  -";
		private string buildRow (Array row)
		{
			StringBuilder res = new StringBuilder();
			foreach (var val in row) {
				res.Append (ROWBoxStart);
				res.Append (val);
				res.Append (ROWBoxEnd);
			}
			res.Append (ROWPadding);
			return res.ToString ();
		}
		public void render(TwentyGrid grid, int score)
		{
			Array newBuffer = Array.CreateInstance (typeof(Char), 168);
			string rowString;
			for ( int row = 0; row < 4; row++ ) {
				rowString = buildRow (grid.getRow (row));
			}
			Console.Clear ();
			Console.Write (newBuffer);
		}
	}
}
