using AdventOfCode.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using AdventOfCode.TwentyTwenty.DayThree.Business;

namespace AdventOfCode.TwentyTwenty.DayThree.Tests
{
	[TestClass]
	public class TobogganTrajectoryTests
	{
		private string[] input;

		[TestInitialize]
		public async Task InitInput() => this.input = await FileUtils.ReadFileContentFromPathAsync("AOC-2020-D-3-example-input.txt");

		[TestMethod]
		public void TreeCounterFromExample()
		{
			int treeCounter = TobogganTrajectory.TreeCounterFromInput(this.input);

			Assert.IsTrue(treeCounter == 7);
		}
	}
}