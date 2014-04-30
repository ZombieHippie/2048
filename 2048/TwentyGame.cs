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
		public TwentyGame () {
			grid = new TwentyGrid ();
			renderer = new TwentyRenderer ();
			score = 0;
		}
		public void left () {

		}
		public void right () {

		}
		public void up () {

		}
		public void down () {

		}
		public void render () {
			renderer.render (grid, score);
		}
	}
}