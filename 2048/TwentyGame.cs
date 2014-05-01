// This example demonstrates the Console.WindowLeft and
//                               Console.WindowTop properties.
using System;
using System.Text;
using System.IO;

//
namespace Application
{
	class TwentyGame
	{
		private TwentyRenderer renderer;
		private TwentyGrid grid;
		private int score;
		private Random rand;
		public TwentyGame () {
			grid = new TwentyGrid ();
			renderer = new TwentyRenderer ();
			rand = new Random();
			score = 0;
		}
		private Array logic (Array vals, int direction) {
			Array res = Array.CreateInstance (typeof(int), 4);
			int shift = 0;
			int prev = 1;
			int b = (int) (1.5 + direction * -1.5);
			int index;
			for (int iter = 0; iter < 4; iter++)
			{
				index = iter * direction + b;
				int next = (int) vals.GetValue (index);
				if (prev == 0) {
					shift-=direction;
					prev = next;
				} else if (prev == next) {
					shift-=direction;
					next += prev;
					score += prev;
				} else {
					prev = next;
				}

				res.SetValue (next, index + shift);
			}
			return res;
		}

		private void hcondense (int dir) {
			for (int row = 0; row < 4; row++) {
				grid.setRow (row, logic (grid.getRow (row), dir));
			}
			postCondense ();
		}

		private void vcondense (int dir) {
			for (int column = 0; column < 4; column++) {
				grid.setColumn (column, logic (grid.getColumn (column), dir));
			}
			postCondense ();
		}

		public void left () {
			hcondense (1);
		}
		public void right () {
			hcondense (-1);
		}
		public void up () {
			vcondense (1);
		}
		public void down () {
			vcondense (-1);
		}
		public bool addRandom () {
			int val = rand.Next() % 2 * 2 + 2;
			return grid.setEmpty(val, rand.Next() % 16);
		}
		public void postCondense () {
			if (addRandom())
			{
				renderer.render (grid, score);
			} else
			{
				endGame();
			}
		}
		private void endGame () {
			renderer.text("Game Over");
		}
	}
}