using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.TwentyTwenty.DayFour.Business
{
	public sealed class PassportProcessing
	{
		private readonly string[] _input;
		private StringBuilder _stringBuilder;
		private int _lineCounter = 1;

		public PassportProcessing(string[] input)
		{
			this._input = input;
			this.InitStringBuilder();
		}

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

		private static IEnumerable<Field> GetPassportFields(string[] keysValues)
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
			{
				field = new BirthYearField(key, value);
			}
			if (key.Equals(Keys.IssueYearFieldKey))
			{
				field = new IssueYearField(key, value);
			}
			if (key.Equals(Keys.ExpirationYearFieldKey))
			{
				field = new ExpirationYearField(key, value);
			}
			if (key.Equals(Keys.HeightFieldKey))
			{
				field = new HeightField(key, value);
			}
			if (key.Equals(Keys.HairColorFieldKey))
			{
				field = new HairColorField(key, value);
			}
			if (key.Equals(Keys.EyeColorFieldKey))
			{
				field = new EyeColorField(key, value);
			}
			if (key.Equals(Keys.PassportIdFieldKey))
			{
				field = new PassportIdField(key, value);
			}
			if (key.Equals(Keys.CountryIdFieldKey))
			{
				field = new CountryIdField(key, value);
			}

			return field;
		}

		public IEnumerable<string> GetPassportsKeysValues()
		{
			List<string> passportsKeysValues = new List<string>();
			foreach (string line in this._input)
			{
				if (LineIsNotNullOrEmpty(line))
					this.BuildPassport(line);
				else
				{
					passportsKeysValues.Add(this.AddPassport());
					this.InitStringBuilder();
				}

				this.IncrementLineCounter();

				if (this.IsLastLineOfFile())
					passportsKeysValues.Add(this.AddPassport());
			}

			return passportsKeysValues;
		}

		private void InitStringBuilder() => this._stringBuilder = new StringBuilder();

		#region Get passportKeyValue private methods
		private static bool LineIsNotNullOrEmpty(string line) => !string.IsNullOrEmpty(line);

		private void BuildPassport(string line) => this._stringBuilder.Append(this._stringBuilder.Length > 0 ? $" {line}" : line);

		private string AddPassport() => this._stringBuilder.ToString();

		private void IncrementLineCounter() => this._lineCounter++;

		private bool IsLastLineOfFile() => this._lineCounter == this._input.Length + 1;
		#endregion

		public int CountValidPassport(IEnumerable<string> passports) => passports.Count(this.ContainsValidFields);

		public bool ContainsValidFields(string passportKeyValue) => passportKeyValue.Contains(Keys.BirthYearField) && passportKeyValue.Contains(Keys.IssueYearField)
			&& passportKeyValue.Contains(Keys.ExpirationYearField) && passportKeyValue.Contains(Keys.HeightField) && passportKeyValue.Contains(Keys.HairColorField)
			&& passportKeyValue.Contains(Keys.EyeColorField) && passportKeyValue.Contains(Keys.PassportIdField);
	}
}