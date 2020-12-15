using AdventOfCode.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.TwentyTwenty.DayFour.Tests
{
	[TestClass]
	public class PassportProcessingTests
	{
		private string[] inputExample;
		private string[] input;

		[TestInitialize]
		public async Task InitInput()
		{
			this.inputExample = await FileUtils.ReadFileContentFromPathAsync("AOC-2020-D-4-example-input.txt");
			this.input = await FileUtils.ReadFileContentFromPathAsync("AOC-2020-D-4-input.txt");
		}

		[TestMethod]
		public void CountPasswordValidFromExampleInput()
		{
			IEnumerable<string> passports = this.GetPassports(this.inputExample);

			int passwordValidCount = passports.Count(this.ContainsValidFields);

			Assert.IsTrue(passwordValidCount == 2);
		}

		[TestMethod]
		public void CountPasswordValid()
		{
			IEnumerable<string> passports = this.GetPassports(this.input);

			int passwordValidCount = passports.Count(this.ContainsValidFields);

			Assert.IsTrue(passwordValidCount == 206);
		}

		private IEnumerable<string> GetPassports(string[] input)
		{
			List<string> passports = new List<string>();
			StringBuilder stringBuilder = new StringBuilder();
			int lineCounter = 1;

			foreach (string line in input)
			{
				if (!string.IsNullOrEmpty(line))
				{
					stringBuilder.Append(line);
				}
				else
				{
					passports.Add(stringBuilder.ToString());
					stringBuilder = new StringBuilder();
				}

				lineCounter++;
				if (lineCounter == input.Length + 1)
					passports.Add(stringBuilder.ToString());
			}

			return passports;
		}

		private bool ContainsValidFields(string passport) => passport.Contains("byr:") && passport.Contains("iyr:") && passport.Contains("eyr:") && passport.Contains("hgt:")
					&& passport.Contains("hcl:") && passport.Contains("ecl:") && passport.Contains("pid:");
	}
}