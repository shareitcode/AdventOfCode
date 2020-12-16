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
			passportProcessing = new PassportProcessing(this.inputExample);
			passportProcessing.GetPassports();

			int passwordValidCount = passportProcessing.CountValidPassport();

			Assert.IsTrue(passwordValidCount == 2);
		}

		[TestMethod]
		public void CountPasswordValid()
		{
			passportProcessing = new PassportProcessing(this.input);
			passportProcessing.GetPassports();

			int passwordValidCount = passportProcessing.CountValidPassport();

			Assert.IsTrue(passwordValidCount == 206);
		}

		[TestMethod]
		public void GetKeysValuesFromPassport()
		{
			passportProcessing = new PassportProcessing(this.inputExample);
			IEnumerable<string> passports = passportProcessing.GetPassports();
			List<Dictionary<string, string>> keyValuePairs = new List<Dictionary<string, string>>();
			string[] keysValues = System.Array.Empty<string>();

			foreach (string passwport in passports)
            {
				if (passportProcessing.ContainsValidFields(passwport))
					keysValues = passwport.Split(' ');
            }

            foreach (string keyValue in keysValues)
            {
				if ()
            }
		}
	}
}