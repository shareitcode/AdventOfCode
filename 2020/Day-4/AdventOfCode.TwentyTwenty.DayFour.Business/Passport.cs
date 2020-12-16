using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode.TwentyTwenty.DayFour.Business
{
	public sealed class Passport
	{
		public string KeysValues { get; set; }
		public Dictionary<string, string> Dictionary { get; set; }
		public bool IsValid { get; set; }
	}

	public abstract class Field
	{
		public string Key { get; set; }
		public string Value { get; set; }
		public bool IsValid { get; set; }
		public abstract void IsValidField();
	}

	public sealed class BirthYearField : Field
	{
		public override void IsValidField() => this.IsValid = this.Value.Length == 4 && int.TryParse(this.Value, out int valueAsInt) && valueAsInt >= 1920 && valueAsInt <= 2002;
	}

	public sealed class IssueYearField : Field
	{
		public override void IsValidField() => this.IsValid = this.Value.Length == 4 && int.TryParse(this.Value, out int valueAsInt) && valueAsInt >= 2010 && valueAsInt <= 2020;
	}

	public sealed class ExpirationYearField : Field
	{
		public override void IsValidField() => this.IsValid = this.Value.Length == 4 && int.TryParse(this.Value, out int valueAsInt) && valueAsInt >= 2020 && valueAsInt <= 2030;
	}

	public sealed class HeightField : Field
	{
		public override void IsValidField()
		{
			if (this.HeightUseInchUnit())
			{
				this.IsValid = int.TryParse(this.Value.Split('i')[0], out int height) && height >= 59 && height <= 76;
			}
			else if (this.HeightUserCentimeterUnit())
			{
				this.IsValid = int.TryParse(this.Value.Split('c')[0], out int height) && height >= 150 && height <= 193;
			}
		}

		private bool HeightUserCentimeterUnit() => this.Value.EndsWith("cm");
		private bool HeightUseInchUnit() => this.Value.EndsWith("in");
	}

	public sealed class HairColorFiel : Field
	{
		public override void IsValidField() => this.IsValid = this.Value.Length == 7 && Regex.IsMatch(this.Value, "^(#[0-9]{3}[a-f]{3}$)");
	}

	public sealed class EyeColorField : Field
	{
		public override void IsValidField() => this.IsValid = this.Value.Length == 3 && Regex.IsMatch(this.Value, "amb|blu|brn|gry|grn|hzl|oth");
	}

	public sealed class PassportIdField : Field
	{
		public override void IsValidField() => this.IsValid = this.Value.Length == 9 && int.TryParse(this.Value, out int passportId) && passportId > 0;
	}
}