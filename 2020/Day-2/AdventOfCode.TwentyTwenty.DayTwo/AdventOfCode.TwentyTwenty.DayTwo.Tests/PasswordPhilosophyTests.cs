using AdventOfCode.TwentyTwenty.DayTwo.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.TwentyTwenty.DayTwo.Tests
{
	[TestClass]
	public class PasswordPhilosophyTests
	{
		[TestMethod]
		public void TryBusinessRulesWithExampleOne()
		{
			string passwordsWithPolicy = "1-3 a: abcde";
			PasswordPolicy passwordPolicy = PasswordPhilosophy.GetPasswordPolicy(passwordsWithPolicy);
			string password = PasswordPhilosophy.GetPassword(passwordsWithPolicy);
			bool passwordIsValid = PasswordPhilosophy.PasswordIsValid(passwordPolicy, password);

			Assert.AreEqual(1, passwordPolicy.NumberLeastTimeCharOccurrence);
			Assert.AreEqual(3, passwordPolicy.NumberMostTimeCharOccurrence);
			Assert.AreEqual('a', passwordPolicy.OccurrenceCharacterReference);
			Assert.AreEqual("abcde", password);
			Assert.IsTrue(passwordIsValid);
		}

		[TestMethod]
		public void TryBusinessRulesWithExampleTwo()
		{
			string passwordsWithPolicy = "1-3 b: cdefg";
			PasswordPolicy passwordPolicy = PasswordPhilosophy.GetPasswordPolicy(passwordsWithPolicy);
			string password = PasswordPhilosophy.GetPassword(passwordsWithPolicy);
			bool passwordIsValid = PasswordPhilosophy.PasswordIsValid(passwordPolicy, password);

			Assert.AreEqual(1, passwordPolicy.NumberLeastTimeCharOccurrence);
			Assert.AreEqual(3, passwordPolicy.NumberMostTimeCharOccurrence);
			Assert.AreEqual('b', passwordPolicy.OccurrenceCharacterReference);
			Assert.AreEqual("cdefg", password);
			Assert.IsFalse(passwordIsValid);
		}
		
		[TestMethod]
		public void TryBusinessRulesWithExampleThree()
		{
			string passwordsWithPolicy = "2-9 c: ccccccccc";
			PasswordPolicy passwordPolicy = PasswordPhilosophy.GetPasswordPolicy(passwordsWithPolicy);
			string password = PasswordPhilosophy.GetPassword(passwordsWithPolicy);
			bool passwordIsValid = PasswordPhilosophy.PasswordIsValid(passwordPolicy, password);

			Assert.AreEqual(2, passwordPolicy.NumberLeastTimeCharOccurrence);
			Assert.AreEqual(9, passwordPolicy.NumberMostTimeCharOccurrence);
			Assert.AreEqual('c', passwordPolicy.OccurrenceCharacterReference);
			Assert.AreEqual("ccccccccc", password);
			Assert.IsTrue(passwordIsValid);
		}
	}
}