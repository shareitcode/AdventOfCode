using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.TwentyTwenty.DayFour.Business
{
    public sealed class PassportProcessing
    {
        private readonly string[] input;
        private readonly List<string> passports;
        private StringBuilder stringBuilder;
        private int lineCounter = 1;

        public PassportProcessing(string[] input)
        {
            this.input = input;
            this.passports = new List<string>();
            this.InitStringBuilder();
        }

        public IEnumerable<string> GetPassports()
        {
            foreach (string line in this.input)
            {
                if (LineIsNotNullOrEmpty(line))
                    this.BuildPasswport(line);
                else
                {
                    this.AddPassport();
                    this.InitStringBuilder();
                }

                this.IncrementeLineCounter();

                if (this.IsLastLineOfFile())
                    this.AddPassport();
            }

            return this.passports;
        }

        private void InitStringBuilder() => this.stringBuilder = new StringBuilder();

        #region Get passports private methods
        private static bool LineIsNotNullOrEmpty(string line) => !string.IsNullOrEmpty(line);

        private void BuildPasswport(string line)
        {
            if (this.stringBuilder.Length > 0)
                this.stringBuilder.Append($" {line}");
            else
                this.stringBuilder.Append(line);
        }

        private void AddPassport() => this.passports.Add(this.stringBuilder.ToString());

        private void IncrementeLineCounter() => this.lineCounter++;

        private bool IsLastLineOfFile() => this.lineCounter == this.input.Length + 1;
        #endregion

        public int CountValidPassport() => passports.Count(ContainsValidFields);

        public bool ContainsValidFields(string passport) => passport.Contains(Keys.BirthYearFieldKey) && passport.Contains(Keys.IssueYearFieldKey)
            && passport.Contains(Keys.ExpirationYearFieldKey) && passport.Contains(Keys.HeightFieldKey) && passport.Contains(Keys.HairColorFieldKey)
            && passport.Contains(Keys.EyeColorFieldKey) && passport.Contains(Keys.PassportIdFieldKey);
    }
}