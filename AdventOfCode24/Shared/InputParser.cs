using System.Text.RegularExpressions;

namespace AdventOfCode24.Shared;

public static partial class InputParser
{
    [GeneratedRegex(@"\s+")]
    public static partial Regex WhitespaceSplitRegex();

    [GeneratedRegex(@"mul\((\d{1,3}),(\d{1,3})\)")]
    public static partial Regex MulParser();

    [GeneratedRegex(@"do\(()\)")]
    public static partial Regex DoParser();
    
    [GeneratedRegex(@"don't\(()\)")]
    public static partial Regex DontParser();


    public static string[] ParseInput(string path)
    {
        return File.ReadAllLines(path);
    }
}