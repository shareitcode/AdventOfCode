using System;
using System.Threading.Tasks;
using AdventOfCode.TwentyTwenty.DayThree.Business;
using AdventOfCode.Utils;

namespace AdventOfCode.TwentyTwenty.DayThree.ConsoleApp
{
	internal sealed class Program
	{
		internal static async Task Main(string[] args)
		{
			string[] input = await FileUtils.ReadFileContentFromPathAsync("AOC-2020-D-3-input.txt");

			Console.WriteLine("====================================================");
			Console.WriteLine("ADVENT OF CODE 2020 - DAY 3: TOBOGGAN TRAJECTORY");
			Console.WriteLine("====================================================");
			Console.WriteLine("----- PART 1 -----");
			Console.WriteLine($"Result: {TobogganTrajectory.TreeCounterFromInput(input)}");
			Console.WriteLine("----- PART 2 -----");
			Console.WriteLine($"Result: N/A");
		}
	}
}