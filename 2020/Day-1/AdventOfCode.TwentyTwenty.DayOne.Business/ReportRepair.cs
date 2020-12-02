using System.Linq;

namespace AdventOfCode.TwentyTwenty.DayOne.Business
{
	public sealed class ReportRepair
	{
		public static int SumWithTwoNumbersFromNumbers(short[] numbers)
		{
			int result = 0;
			foreach (short nOne in numbers)
				foreach (short nTwo in numbers.Where(nTwo => nOne + nTwo == 2020))
				{
					result = nOne * nTwo;
					break;
				}
			return result;
		}

		public static int SumWithThreeNumbersFromNumbers(short[] numbers)
		{
			int result = 0;
			foreach (short nOne in numbers)
				foreach (short nTwo in numbers)
					foreach (short nThree in numbers.Where(nThree => nOne + nTwo + nThree == 2020))
					{
						result = nOne * nTwo * nThree;
						break;
					}
			return result;
		}
	}
}