using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.TwentyTwenty.DayFour.Business
{
	public sealed class PassportProcessing
	{
		private readonly string[] _input;
		private readonly List<string> _passportsKeysValues;
		private StringBuilder _stringBuilder;
		private int _lineCounter = 1;

		public PassportProcessing(string[] input)
		{
			this._input = input;
			this._passportsKeysValues = new List<string>();
			this.InitStringBuilder();
		}

		public IEnumerable<Passport> GetPassports()
		{
			List<Passport> passports = new List<Passport>();
			IEnumerable<string> passportsKeysValues = this.GetPassportsKeysValues();

			foreach (string passportKeyValue in passportsKeysValues)
			{
				Passport passport = new Passport()
				{
					KeysValues = passportKeyValue,
					Dictionary = new Dictionary<string, string>()
				};
				if (this.ContainsValidFields(passportKeyValue))
				{
					string[] keysValues = passportKeyValue.Split(' ');

					foreach (string keyValue in keysValues)
					{
						string[] keyValueSplit = keyValue.Split(':');
						passport.Dictionary.Add(keyValueSplit[0], keyValueSplit[1]);
					}
				}
				passports.Add(passport);
			}

			return passports;
		}

		public IEnumerable<string> GetPassportsKeysValues()
		{
			foreach (string line in this._input)
			{
				if (LineIsNotNullOrEmpty(line))
					this.BuildPassport(line);
				else
				{
					this.AddPassport();
					this.InitStringBuilder();
				}

				this.IncrementLineCounter();

				if (this.IsLastLineOfFile())
					this.AddPassport();
			}

			return this._passportsKeysValues;
		}

		private void InitStringBuilder() => this._stringBuilder = new StringBuilder();

		#region Get passportKeyValue private methods
		private static bool LineIsNotNullOrEmpty(string line) => !string.IsNullOrEmpty(line);

		private void BuildPassport(string line) => this._stringBuilder.Append(this._stringBuilder.Length > 0 ? $" {line}" : line);

		private void AddPassport() => this._passportsKeysValues.Add(this._stringBuilder.ToString());

		private void IncrementLineCounter() => this._lineCounter++;

		private bool IsLastLineOfFile() => this._lineCounter == this._input.Length + 1;
		#endregion

		public int CountValidPassport() => this._passportsKeysValues.Count(this.ContainsValidFields);

		public bool ContainsValidFields(string passportKeyValue) => passportKeyValue.Contains(Keys.BirthYearField) && passportKeyValue.Contains(Keys.IssueYearField)
			&& passportKeyValue.Contains(Keys.ExpirationYearField) && passportKeyValue.Contains(Keys.HeightField) && passportKeyValue.Contains(Keys.HairColorField)
			&& passportKeyValue.Contains(Keys.EyeColorField) && passportKeyValue.Contains(Keys.PassportIdField);
	}
}