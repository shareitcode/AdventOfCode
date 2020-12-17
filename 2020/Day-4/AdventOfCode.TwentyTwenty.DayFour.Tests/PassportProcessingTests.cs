using AdventOfCode.TwentyTwenty.DayFour.Business;
using AdventOfCode.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
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
			IEnumerable<string> passportsKeysValues = this.passportProcessing.GetPassportsKeysValues();
			IEnumerable<Passport> passports = this.passportProcessing.GetPassports();

			int passportsKeysValuesValidCount = this.passportProcessing.CountValidPassport(passportsKeysValues);
			int passwordValidCount = passports.Count(passport => passport.IsValid);

			Assert.IsTrue(passportsKeysValuesValidCount == 2);
		}

		[TestMethod]
		public void CountPasswordValid()
		{
			this.passportProcessing = new PassportProcessing(this.input);
			IEnumerable<string> passportsKeysValues = this.passportProcessing.GetPassportsKeysValues();

			int passwordValidCount = this.passportProcessing.CountValidPassport(passportsKeysValues);

			Assert.IsTrue(passwordValidCount == 206);
		}

		[TestMethod]
		public void GetKeysValuesFromPassport()
		{
			this.passportProcessing = new PassportProcessing(this.inputExample);
			IEnumerable<Passport> passports = this.passportProcessing.GetPassports();

			int passwordValidCount = passports.Count(passport => passport.IsValid);

			Assert.IsTrue(passwordValidCount == 2);
		}
	}
}