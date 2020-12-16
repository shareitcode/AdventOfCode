using AdventOfCode.TwentyTwenty.DayFour.Business;
using AdventOfCode.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventOfCode.TwentyTwenty.DayFour.Tests
{
	[TestClass]
	public class PassportProcessingTests
	{
		private string[] inputExample;
		private string[] input;
		private PassportProcessing passportProcessing;

		[TestInitialize]
		public async Task InitInput()
		{
			this.inputExample = await FileUtils.ReadFileContentFromPathAsync("AOC-2020-D-4-example-input.txt");
			this.input = await FileUtils.ReadFileContentFromPathAsync("AOC-2020-D-4-input.txt");
		}

		[TestMethod]
		public void CountPasswordValidFromExampleInput()
		{
			this.passportProcessing = new PassportProcessing(this.inputExample);
			this.passportProcessing.GetPassports();

			int passwordValidCount = this.passportProcessing.CountValidPassport();

			Assert.IsTrue(passwordValidCount == 2);
		}

		[TestMethod]
		public void CountPasswordValid()
		{
			this.passportProcessing = new PassportProcessing(this.input);
			this.passportProcessing.GetPassports();

			int passwordValidCount = this.passportProcessing.CountValidPassport();

			Assert.IsTrue(passwordValidCount == 206);
		}

		[TestMethod]
		public void GetKeysValuesFromPassport()
		{
			this.passportProcessing = new PassportProcessing(this.inputExample);
			IEnumerable<string> passports = this.passportProcessing.GetPassportsKeysValues();
			List<Dictionary<string, string>> passportsValues = new List<Dictionary<string, string>>();

			foreach (string passport in passports)
			{
				if (this.passportProcessing.ContainsValidFields(passport))
				{
					string[] keysValues = passport.Split(' ');
					Dictionary<string, string> passportKeysValues = new Dictionary<string, string>();

					foreach (string keyValue in keysValues)
					{
						string[] keyValueStrings = keyValue.Split(':');
						passportKeysValues.Add(keyValueStrings[0], keyValueStrings[1]);
					}
					passportsValues.Add(passportKeysValues);
				}
			}
		}
	}
}