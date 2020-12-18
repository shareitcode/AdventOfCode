using AdventOfCode.Utils;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.TwentyTwenty.DayFour.Business
{
	public sealed class PassportProcessing
	{
		private readonly string[] _input;

		public PassportProcessing(string[] input) => this._input = input;

		public IEnumerable<Passport> GetPassports()
		{
			List<Passport> passports = new List<Passport>();
			IEnumerable<string> passportsKeysValues = this.GetPassportsKeysValues();

			foreach (string passportKeyValue in passportsKeysValues)
			{
				Passport passport = new Passport
				{
					Fields = GetPassportFields(passportKeyValue.Split(' '))
				};
				passports.Add(passport);
			}

			return passports;
		}

		private static IEnumerable<Field> GetPassportFields(IEnumerable<string> keysValues)
		{
			List<Field> fields = new List<Field>();

			foreach (string keyValue in keysValues)
			{
				string[] keyValueSplit = keyValue.Split(':');
				fields.Add(BuildPassportField(keyValueSplit[0], keyValueSplit[1]));
			}

			return fields;
		}

		private static Field BuildPassportField(string key, string value)
		{
			Field field = new UnknownField(string.Empty, string.Empty);

			if (key.Equals(Keys.BirthYearFieldKey))
				field = new BirthYearField(key, value);

			if (key.Equals(Keys.IssueYearFieldKey))
				field = new IssueYearField(key, value);

			if (key.Equals(Keys.ExpirationYearFieldKey))
				field = new ExpirationYearField(key, value);

			if (key.Equals(Keys.HeightFieldKey))
				field = new HeightField(key, value);

			if (key.Equals(Keys.HairColorFieldKey))
				field = new HairColorField(key, value);

			if (key.Equals(Keys.EyeColorFieldKey))
				field = new EyeColorField(key, value);

			if (key.Equals(Keys.PassportIdFieldKey))
				field = new PassportIdField(key, value);

			if (key.Equals(Keys.CountryIdFieldKey))
				field = new CountryIdField(key, value);

			return field;
		}

		public IEnumerable<string> GetPassportsKeysValues() => new InputManager().GetSingleLinesElementsSeparateByCarriageReturnFromInput(this._input);

		public int CountValidPassportKeysValues(IEnumerable<string> passports) => passports.Count(this.ContainsValidFields);

		public int CountValidPassport(IEnumerable<Passport> passports) => passports.Count(passport => passport.IsValid);

		public bool ContainsValidFields(string passportKeyValue) => passportKeyValue.Contains(Keys.BirthYearField) && passportKeyValue.Contains(Keys.IssueYearField)
			&& passportKeyValue.Contains(Keys.ExpirationYearField) && passportKeyValue.Contains(Keys.HeightField) && passportKeyValue.Contains(Keys.HairColorField)
			&& passportKeyValue.Contains(Keys.EyeColorField) && passportKeyValue.Contains(Keys.PassportIdField);
	}
}