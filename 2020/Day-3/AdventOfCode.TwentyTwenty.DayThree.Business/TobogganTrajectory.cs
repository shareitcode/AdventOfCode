namespace AdventOfCode.TwentyTwenty.DayThree.Business
{
	public static class TobogganTrajectory
	{
		public static int TreeCounterFromInput(string[] input)
		{
			int linesCount = input.Length;
			int currentLine = 1;
			int currentColumn = 3;
			int treeCounter = 0;

			foreach (string line in input)
			{
				if (currentLine > 1)
				{
					if (line[currentColumn] == '#')
						treeCounter++;

					currentColumn = currentColumn <= line.Length && (currentColumn + 3) <= line.Length ? currentColumn + 3 : 3;
				}
				currentLine++;
			}

			return treeCounter;
		}
	}
}