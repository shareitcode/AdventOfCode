using AdventOfCode.TwentyTwenty.DayTwo.Business.Models;
using System.Text.RegularExpressions;

namespace AdventOfCode.TwentyTwenty.DayTwo.Business
{
	public sealed class PasswordPhilosophy
	{
		private const string _leastTimeOccurrenceNumberRegex = "^[0-9]{1,2}-";
		private const string _mostTimeOccurrenceNumberRegex = "-[0-9]{1,2}";
		private const string _charOccurrenceRegex = " [a-z]:";
		private const string _passwordRegex = ": [a-z]+";

		public static PasswordPolicy GetPasswordPolicy(string passwordWithPolicy) => new PasswordPolicy()
		{
			NumberLeastTimeCharOccurrence = GetNumberLeastTimeCharOccurrence(passwordWithPolicy),
			NumberMostTimeCharOccurrence = GetNUmberMostTimeCharOccurrence(passwordWithPolicy),
			OccurrenceCharacterReference = GetOccurrenceCharacterReference(passwordWithPolicy)
		};

		public static short GetNumberLeastTimeCharOccurrence(string passwordWithPolicy)
		{
			string regexResult = Regex.Match(passwordWithPolicy, _leastTimeOccurrenceNumberRegex).Value;
			string number = regexResult.Replace("-", string.Empty);
			short.TryParse(number, out short numerParsed);
			return numerParsed;
		}

		public static short GetNUmberMostTimeCharOccurrence(string passwordWithPolicy)
		{
			string regexResult = Regex.Match(passwordWithPolicy, _mostTimeOccurrenceNumberRegex).Value;
			string number = regexResult.Replace("-", string.Empty);
			short.TryParse(number, out short numerParsed);
			return numerParsed;
		}

		public static string GetOccurrenceCharacterReference(string passwordWithPolicy)
		{
			string regexResult = Regex.Match(passwordWithPolicy, _charOccurrenceRegex).Value;
			return regexResult.Replace(":", string.Empty).Trim();
		}

		public static string GetPassword(string passwordWithPolicy)
		{
			string regexResult = Regex.Match(passwordWithPolicy, _passwordRegex).Value;
			return regexResult.Replace(":", string.Empty).Trim();
		}

		public static int GetNumbersValidPasswordsContainsOccurrenceCharacter(string[] passwords)
		{
			int passwordValidCount = 0;
			if (passwords != null && passwords.Length > 0)
			{
				foreach (string passwordWithPolicy in passwords)
				{
					PasswordPolicy passwordPolicy = GetPasswordPolicy(passwordWithPolicy);
					string password = GetPassword(passwordWithPolicy);
					if (PasswordContainsOneOrMoreOccurrenceCharacterReferenceIsValid(passwordPolicy, password))
						passwordValidCount++;
				}
			}
			return passwordValidCount;
		}

		public static bool PasswordContainsOneOrMoreOccurrenceCharacterReferenceIsValid(PasswordPolicy passwordPolicy, string password)
		{
			MatchCollection regexResult = Regex.Matches(password, passwordPolicy.OccurrenceCharacterReference);
			return regexResult.Count >= passwordPolicy.NumberLeastTimeCharOccurrence
					&& regexResult.Count <= passwordPolicy.NumberMostTimeCharOccurrence;
		}

		public static int GetNumbersValidPasswordsContainsExactlyOccurrenceCharacter(string[] passwords)
		{
			int passwordValidCount = 0;
			if (passwords != null && passwords.Length > 0)
			{
				foreach (string passwordWithPolicy in passwords)
				{
					PasswordPolicy passwordPolicy = GetPasswordPolicy(passwordWithPolicy);
					string password = GetPassword(passwordWithPolicy);
					if (PasswordContainsExactlyOneOccurrenceCharacterReferenceIsValid(passwordPolicy, password))
						passwordValidCount++;
				}
			}
			return passwordValidCount;
		}

		public static bool PasswordContainsExactlyOneOccurrenceCharacterReferenceIsValid(PasswordPolicy passwordPolicy, string password)
		{
			string validCharacterAtPositionOne = password.Substring(passwordPolicy.NumberLeastTimeCharOccurrence - 1, 1);
			string validCharacterAtPositionTwo = password.Substring(passwordPolicy.NumberMostTimeCharOccurrence - 1, 1);
			bool positionOneIsValid = !string.IsNullOrEmpty(validCharacterAtPositionOne) && validCharacterAtPositionOne.Equals(passwordPolicy.OccurrenceCharacterReference);
			bool positionTwoIsValid = !string.IsNullOrEmpty(validCharacterAtPositionTwo) && validCharacterAtPositionTwo.Equals(passwordPolicy.OccurrenceCharacterReference);
			return (positionOneIsValid && !positionTwoIsValid) || (!positionOneIsValid && positionTwoIsValid);
		}
	}
}