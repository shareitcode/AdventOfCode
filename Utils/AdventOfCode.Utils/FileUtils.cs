using System;
using System.IO;
using System.Threading.Tasks;

namespace AdventOfCode.Utils
{
	public sealed class FileUtils
	{
		public static async Task<string[]> ReadFileContentFromPathAsync(string filePath)
		{
			return !string.IsNullOrEmpty(filePath) && File.Exists(filePath) ? await File.ReadAllLinesAsync(filePath) : Array.Empty<string>();
		}
	}
}