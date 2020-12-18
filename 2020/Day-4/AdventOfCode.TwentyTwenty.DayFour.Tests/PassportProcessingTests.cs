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
		private string[] _inputExample;
		private string[] _input;
		private PassportProcessing _passportProcessing;

		[TestInitialize]
		public async Task InitInput()
		{
			this._inputExample = await FileUtils.ReadFileContentFromPathAsync("AOC-2020-D-4-example-input.txt");
			this._input = await FileUtils.ReadFileContentFromPathAsync("AOC-2020-D-4-input.txt");
		}

		[TestMethod]
		public void CountPasswordValidFromExampleInput()
		{
			this._passportProcessing = new PassportProcessing(this._inputExample);
			IEnumerable<string> passportsKeysValues = this._passportProcessing.GetPassportsKeysValues();

			int passportsKeysValuesValidCount = this._passportProcessing.CountValidPassportKeysValues(passportsKeysValues);

			Assert.IsTrue(passportsKeysValuesValidCount == 2);
		}

		[TestMethod]
		public void CountPasswordValid()
		{
			this._passportProcessing = new PassportProcessing(this._input);
			IEnumerable<string> passportsKeysValues = this._passportProcessing.GetPassportsKeysValues();

			int passwordValidCount = this._passportProcessing.CountValidPassportKeysValues(passportsKeysValues);

			Assert.IsTrue(passwordValidCount == 206);
		}

		[TestMethod]
		public void GetKeysValuesFromPassportWithExampleInput()
		{
			this._passportProcessing = new PassportProcessing(this._inputExample);
			IEnumerable<Passport> passports = this._passportProcessing.GetPassports();

			int passwordValidCount = this._passportProcessing.CountValidPassport(passports);

			Assert.IsTrue(passwordValidCount == 2);
		}

		[TestMethod]
		public void GetKeysValuesFromPassport()
		{
			this._passportProcessing = new PassportProcessing(this._input);
			IEnumerable<Passport> passports = this._passportProcessing.GetPassports();

			int passwordValidCount = this._passportProcessing.CountValidPassport(passports);

			Assert.IsTrue(passwordValidCount == 123);
		}
	}
}