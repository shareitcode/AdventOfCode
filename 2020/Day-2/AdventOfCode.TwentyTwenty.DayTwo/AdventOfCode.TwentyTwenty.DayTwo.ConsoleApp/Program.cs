using AdventOfCode.Utils;
using System;
using System.Threading.Tasks;
using AdventOfCode.TwentyTwenty.DayTwo.Business;

namespace AdventOfCode.TwentyTwenty.DayTwo.ConsoleApp
{
	internal sealed class Program
	{
		private static string[] _passwords;

		internal static async Task Main(string[] args)
		{
			_passwords = await FileUtils.ReadFileContentFromPathAsync("AOC-2020-D-2-input.txt");
			PasswordPhilosophy.GetNumbersOfValidPasswords(_passwords);
		}
	}
}
