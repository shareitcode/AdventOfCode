namespace AdventOfCode.TwentyTwenty.DayTwo.Business.Models
{
	public sealed class PasswordPolicy
	{
		public short NumberLeastTimeCharOccurrence { get; set; }
		public short NumberMostTimeCharOccurrence { get; set; }
		public string OccurrenceCharacterReference { get; set; }
	}
}