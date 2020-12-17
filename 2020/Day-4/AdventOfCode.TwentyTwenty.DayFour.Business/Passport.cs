using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.TwentyTwenty.DayFour.Business
{
    public sealed class Passport
    {
        public string KeysValues { get; set; }
        public Dictionary<string, string> Dictionary { get; set; }
        public IEnumerable<Field> Fields { get; set; }
        public bool IsValid { get => !this.Fields.IsNullOrEmpty() && this.Fields.Count(field => field.IsValid) == this.Fields.Count(); }
    }

    public abstract class Field
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public bool IsValid { get => this.IsValidKey() && this.IsValidValue(); }
        public abstract bool IsValidKey();
        public abstract bool IsValidValue();
    }

    public sealed class BirthYearField : Field
    {
        public override bool IsValidKey() => this.Key.Equals(Keys.BirthYearFieldKey);

        public override bool IsValidValue() => this.Value.Length == 4 && int.TryParse(this.Value, out int valueAsInt) && valueAsInt >= 1920 && valueAsInt <= 2002;
    }

    public sealed class IssueYearField : Field
    {
        public override bool IsValidKey() => this.Key.Equals(Keys.IssueYearFieldKey);

        public override bool IsValidValue() => this.Value.Length == 4 && int.TryParse(this.Value, out int valueAsInt) && valueAsInt >= 2010 && valueAsInt <= 2020;
    }

    public sealed class ExpirationYearField : Field
    {
        public override bool IsValidKey() => this.Key.Equals(Keys.ExpirationYearFieldKey);

        public override bool IsValidValue() => this.Value.Length == 4 && int.TryParse(this.Value, out int valueAsInt) && valueAsInt >= 2020 && valueAsInt <= 2030;
    }

    public sealed class HeightField : Field
    {
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

    public sealed class HairColorFiel : Field
    {
        public override bool IsValidKey() => this.Key.Equals(Keys.HairColorFieldKey);

        public override bool IsValidValue() => this.Value.Length == 7 && Regex.IsMatch(this.Value, "^(#[0-9]{3}[a-f]{3}$)");
    }

    public sealed class EyeColorField : Field
    {
        public override bool IsValidKey() => this.Key.Equals(Keys.EyeColorFieldKey);

        public override bool IsValidValue() => this.Value.Length == 3 && Regex.IsMatch(this.Value, "amb|blu|brn|gry|grn|hzl|oth");
    }

    public sealed class PassportIdField : Field
    {
        public override bool IsValidKey() => this.Key.Equals(Keys.PassportIdFieldKey);

        public override bool IsValidValue() => this.Value.Length == 9 && int.TryParse(this.Value, out int passportId) && passportId > 0;
    }
}