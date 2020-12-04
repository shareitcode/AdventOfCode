using AdventOfCode.TwentyTwenty.DayTwo.Business;
using AdventOfCode.TwentyTwenty.DayTwo.Business.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.TwentyTwenty.DayTwo.Tests
{
	[TestClass]
	public class PasswordPhilosophyTests
	{
		private PasswordPolicy _passwordPolicy;
		private string _password;
		private bool _passwordIsValid;

		[TestMethod]
		public void TryBusinessRulesWithExampleOne()
		{
			this.SetPasswordTestProperties("1-3 a: abcde");

			Assert.AreEqual(1, this._passwordPolicy.NumberLeastTimeCharOccurrence);
			Assert.AreEqual(3, this._passwordPolicy.NumberMostTimeCharOccurrence);
			Assert.AreEqual("a", this._passwordPolicy.OccurrenceCharacterReference);
			Assert.AreEqual("abcde", this._password);
			Assert.IsTrue(this._passwordIsValid);
		}

		[TestMethod]
		public void TryBusinessRulesWithExampleTwo()
		{
			this.SetPasswordTestProperties("1-3 b: cdefg");

			Assert.AreEqual(1, this._passwordPolicy.NumberLeastTimeCharOccurrence);
			Assert.AreEqual(3, this._passwordPolicy.NumberMostTimeCharOccurrence);
			Assert.AreEqual("b", this._passwordPolicy.OccurrenceCharacterReference);
			Assert.AreEqual("cdefg", this._password);
			Assert.IsFalse(this._passwordIsValid);
		}

		[TestMethod]
		public void TryBusinessRulesWithExampleThree()
		{
			this.SetPasswordTestProperties("2-9 c: ccccccccc");

			Assert.AreEqual(2, this._passwordPolicy.NumberLeastTimeCharOccurrence);
			Assert.AreEqual(9, this._passwordPolicy.NumberMostTimeCharOccurrence);
			Assert.AreEqual("c", this._passwordPolicy.OccurrenceCharacterReference);
			Assert.AreEqual("ccccccccc", this._password);
			Assert.IsTrue(this._passwordIsValid);
		}

		[TestMethod]
		public void CountValidPasswordWithExampleOfPartOne()
		{
			string[] passwords = new[] { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc" };
			int validPasswordsCount = PasswordPhilosophy.GetNumbersValidPasswordsContainsOccurrenceCharacter(passwords);
			Assert.IsTrue(validPasswordsCount == 2);
		}

		[TestMethod]
		public void CountValidPasswordWithExampleOfPartTwo()
		{
			string[] passwords = new[] { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc" };
			int validPasswordsCount = PasswordPhilosophy.GetNumbersValidPasswordsContainsExactlyOccurrenceCharacter(passwords);
			Assert.IsTrue(validPasswordsCount == 1);
		}

		private void SetPasswordTestProperties(string passwordsWithPolicy)
		{
			this._passwordPolicy = PasswordPhilosophy.GetPasswordPolicy(passwordsWithPolicy);
			this._password = PasswordPhilosophy.GetPassword(passwordsWithPolicy);
			this._passwordIsValid = PasswordPhilosophy.PasswordContainsOneOrMoreOccurrenceCharacterReferenceIsValid(this._passwordPolicy, this._password);
		}
	}
}