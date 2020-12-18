using AdventOfCode.TwentyTwenty.DayFour.Business;
using AdventOfCode.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventOfCode.TwentyTwenty.DayFour.ConsoleApp
{
	internal sealed class Program
	{
		internal static async Task Main()
		{
			string[] input = await FileUtils.ReadFileContentFromPathAsync("AOC-2020-D-4-input.txt");
			PassportProcessing passportProcessing = new PassportProcessing(input);

			IEnumerable<string> passportsKeysValues = passportProcessing.GetPassportsKeysValues();
			IEnumerable<Passport> passports = passportProcessing.GetPassports();

			Console.WriteLine("====================================================");
			Console.WriteLine("ADVENT OF CODE 2020 - DAY 4: PASSPORT PROCESSING");
			Console.WriteLine("====================================================");
			Console.WriteLine("----- PART 1 -----");
			Console.WriteLine($"Result: {passportProcessing.CountValidPassportKeysValues(passportsKeysValues)}");
			Console.WriteLine("----- PART 2 -----");
			Console.WriteLine($"Result: {passportProcessing.CountValidPassport(passports)}");
		}
	}
}