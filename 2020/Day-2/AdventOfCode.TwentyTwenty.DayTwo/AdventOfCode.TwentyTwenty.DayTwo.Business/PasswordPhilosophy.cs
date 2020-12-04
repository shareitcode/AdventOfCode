using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.TwentyTwenty.DayTwo.Business
{
    public sealed class PasswordPhilosophy
    {
        const string leastTimeOccurrenceNumberRegex = "^[0-9]{1,2}-";
        const string mostTimeOccurrenceNumberRegex = "-[0-9]{1,2}";
        const string charOccurrenceRegex = " [a-z]:";
        const string passwordRegex = ": [a-z]+";

        public static PasswordPolicy GetPasswordPolicy(string passwordWithPolicy)
        {
            return new PasswordPolicy()
            {
                NumberLeastTimeCharOccurrence = GetNumberLeastTimeCharOccurrence(passwordWithPolicy),
                NumberMostTimeCharOccurrence = GetNUmberMostTimeCharOccurrence(passwordWithPolicy),
                OccurrenceCharacterReference = GetOccurrenceCharacterReference(passwordWithPolicy)
            };
        }

        public static short GetNumberLeastTimeCharOccurrence(string passwordWithPolicy)
        {
            string regexResult = Regex.Match(passwordWithPolicy, leastTimeOccurrenceNumberRegex).Value;
            string number = regexResult.Replace("-", string.Empty);
            short.TryParse(number, out short numerParsed);
            return numerParsed;
        }

        public static short GetNUmberMostTimeCharOccurrence(string passwordWithPolicy)
        {
            string regexResult = Regex.Match(passwordWithPolicy, mostTimeOccurrenceNumberRegex).Value;
            string number = regexResult.Replace("-", string.Empty);
            short.TryParse(number, out short numerParsed);
            return numerParsed;
        }

        public static char GetOccurrenceCharacterReference(string passwordWithPolicy)
        {
            string regexResult = Regex.Match(passwordWithPolicy, charOccurrenceRegex).Value;
			string referenceCharacter = regexResult.Replace(":", string.Empty).Trim();
            char.TryParse(referenceCharacter, out char referenceCharacterParsed);
            return referenceCharacterParsed;
        }

        public static string GetPassword(string passwordWithPolicy)
        {
            string regexResult = Regex.Match(passwordWithPolicy, passwordRegex).Value;
            return regexResult.Replace(":", string.Empty).Trim();
        }

        public static bool PasswordIsValid(PasswordPolicy passwordPolicy, string password)
        {
            var regexResult = Regex.Matches(password, passwordPolicy.OccurrenceCharacterReference.ToString());
            return regexResult.Count >= passwordPolicy.NumberLeastTimeCharOccurrence
                && regexResult.Count <= passwordPolicy.NumberMostTimeCharOccurrence;
        }

        public static string GetNumbersOfValidPasswords(string[] passwords)
        {
            return string.Empty;
        }
    }

    public sealed class PasswordPolicy
    {
        public short NumberLeastTimeCharOccurrence { get; set; }
        public short NumberMostTimeCharOccurrence { get; set; }
        public char OccurrenceCharacterReference { get; set; }
    }
}