using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Utils
{
	public sealed class InputManager
	{
		private StringBuilder _stringBuilder = new StringBuilder();
		private int _lineCounter;

		public IEnumerable<string> GetSingleLinesElementsSeparateByCarriageReturnFromInput(string[] input)
		{
			List<string> passportsKeysValues = new List<string>();

			foreach (string line in input)
			{
				if (LineIsNotNullOrEmpty(line))
					this.AppendLine(line);
				else
				{
					passportsKeysValues.Add(this.StringBuilderToString());
					this.InitStringBuilder();
				}

				this.IncrementLineCounter();

				if (this.IsLastLineOfInput(input))
					passportsKeysValues.Add(this.StringBuilderToString());
			}

			return passportsKeysValues;
		}

		#region Get passportKeyValue private methods
		private void InitStringBuilder() => this._stringBuilder = new StringBuilder();

		private static bool LineIsNotNullOrEmpty(string line) => !string.IsNullOrEmpty(line);

		private void AppendLine(string line) => this._stringBuilder.Append(this._stringBuilder.Length > 0 ? $" {line}" : line);

		private string StringBuilderToString() => this._stringBuilder.ToString();

		private void IncrementLineCounter() => this._lineCounter++;

		private bool IsLastLineOfInput(string[] input) => this._lineCounter == input.Length;
		#endregion
	}
}