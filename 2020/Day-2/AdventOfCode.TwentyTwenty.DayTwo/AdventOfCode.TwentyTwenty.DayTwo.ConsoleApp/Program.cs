using AdventOfCode.TwentyTwenty.DayTwo.Business;
using AdventOfCode.Utils;
using System;
using System.Threading.Tasks;

namespace AdventOfCode.TwentyTwenty.DayTwo.ConsoleApp
{
	internal sealed class Program
	{
		internal static async Task Main(string[] args)
		{
			string[] passwords = await FileUtils.ReadFileContentFromPathAsync("AOC-2020-D-2-input.txt");
			int countValidPasswordPartOne = 0;
			if (passwords != null && passwords.Length > 0)
				countValidPasswordPartOne = PasswordPhilosophy.GetNumbersValidPasswordsContainsOccurrenceCharacter(passwords);
			int countValidPasswordPartTwo = 0;
			if (passwords != null && passwords.Length > 0)
				countValidPasswordPartTwo = PasswordPhilosophy.GetNumbersValidPasswordsContainsExactlyOccurrenceCharacter(passwords);

			Console.WriteLine("==========================================");
			Console.WriteLine("ADVENT OF CODE 2020 - DAY 1: REPORT REPAIR");
			Console.WriteLine("==========================================");
			Console.WriteLine("----- PART 1 -----");
			Console.WriteLine($"Result: {countValidPasswordPartOne}");
			Console.WriteLine("----- PART 2 -----");
			Console.WriteLine($"Result: {countValidPasswordPartTwo}");
		}
	}
}