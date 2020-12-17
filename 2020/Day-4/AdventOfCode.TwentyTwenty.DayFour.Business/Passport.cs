using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.TwentyTwenty.DayFour.Business
{
	public sealed class Passport
	{
		public IEnumerable<Field> Fields { get; set; }
		public bool IsValid => !this.Fields.IsNullOrEmpty() && this.FieldsIsValid();

		private bool FieldsIsValid()
		{
			int optionalValid = this.Fields.Count(field => field.IsValid && Regex.IsMatch(field.Key, "byr|iyr|eyr|hgt|hcl|ecl|pid"));
			int optional = this.Fields.Count();
			return optionalValid == optional;
		}
	}

	public abstract class Field
	{
		public string Key;
		public string Value;
		public bool IsValid => this.IsValidKey() && this.IsValidValue();

		protected Field(string key, string value)
		{
			this.Key = key;
			this.Value = value;
		}

		public abstract bool IsValidKey();
		public abstract bool IsValidValue();
	}

	public sealed class BirthYearField : Field
	{
		public BirthYearField(string key, string value) : base(key, value)
		{
		}

		public override bool IsValidKey() => this.Key.Equals(Keys.BirthYearFieldKey);

		public override bool IsValidValue() => this.Value.Length == 4 && int.TryParse(this.Value, out int valueAsInt) && valueAsInt >= 1920 && valueAsInt <= 2002;
	}

	public sealed class IssueYearField : Field
	{
		public IssueYearField(string key, string value) : base(key, value)
		{
		}

		public override bool IsValidKey() => this.Key.Equals(Keys.IssueYearFieldKey);

		public override bool IsValidValue() => this.Value.Length == 4 && int.TryParse(this.Value, out int valueAsInt) && valueAsInt >= 2010 && valueAsInt <= 2020;
	}

	public sealed class ExpirationYearField : Field
	{
		public ExpirationYearField(string key, string value) : base(key, value)
		{
		}

		public override bool IsValidKey() => this.Key.Equals(Keys.ExpirationYearFieldKey);

		public override bool IsValidValue() => this.Value.Length == 4 && int.TryParse(this.Value, out int valueAsInt) && valueAsInt >= 2020 && valueAsInt <= 2030;
	}

	public sealed class HeightField : Field
	{
		public HeightField(string key, string value) : base(key, value)
		{
		}

		public override bool IsValidKey() => this.Key.Equals(Keys.HeightFieldKey);

		public override bool IsValidValue()
		{
			bool isValid = false;

			if (this.HeightUseInchUnit())
				isValid = int.TryParse(this.Value.Split('i')[0], out int height) && height >= 59 && height <= 76;
			else if (this.HeightUserCentimeterUnit())
				isValid = int.TryParse(this.Value.Split('c')[0], out int height) && height >= 150 && height <= 193;

			return isValid;
		}

		private bool HeightUserCentimeterUnit() => this.Value.EndsWith("cm");
		private bool HeightUseInchUnit() => this.Value.EndsWith("in");
	}

	public sealed class HairColorField : Field
	{
		public HairColorField(string key, string value) : base(key, value)
		{
		}

		public override bool IsValidKey() => this.Key.Equals(Keys.HairColorFieldKey);

		public override bool IsValidValue() => this.Value.Length == 7 && Regex.IsMatch(this.Value, "^#[0-9a-f]{6}");
	}

	public sealed class EyeColorField : Field
	{
		public EyeColorField(string key, string value) : base(key, value)
		{
		}

		public override bool IsValidKey() => this.Key.Equals(Keys.EyeColorFieldKey);

		public override bool IsValidValue() => this.Value.Length == 3 && Regex.IsMatch(this.Value, "amb|blu|brn|gry|grn|hzl|oth");
	}

	public sealed class PassportIdField : Field
	{
		public PassportIdField(string key, string value) : base(key, value)
		{
		}

		public override bool IsValidKey() => this.Key.Equals(Keys.PassportIdFieldKey);

		public override bool IsValidValue() => this.Value.Length == 9 && int.TryParse(this.Value, out int passportId) && passportId > 0;
	}

	public sealed class CountryIdField : Field
	{
		public CountryIdField(string key, string value) : base(key, value)
		{
		}

		public override bool IsValidKey() => this.Key.Equals(Keys.CountryIdFieldKey);

		public override bool IsValidValue() => true;
	}

	public sealed class UnknownField : Field
	{
		public UnknownField(string key, string value) : base(key, value)
		{
		}

		public override bool IsValidKey() => false;

		public override bool IsValidValue() => false;
	}
}