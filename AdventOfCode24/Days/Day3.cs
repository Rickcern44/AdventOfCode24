using System.Collections;
using System.Text.RegularExpressions;
using AdventOfCode24.Shared;

namespace AdventOfCode24.Days;

public class Day3
{
    private readonly List<string> _parsedInput = new();


    public Day3(string path)
    {
        var rawInput =
            File.ReadAllText(path);


        var mulMatches = InputParser.MulParser().Matches(rawInput);
        var doMatches = InputParser.DoParser().Matches(rawInput);
        var dontMatches = InputParser.DontParser().Matches(rawInput);

        var allMatches = mulMatches.Union(doMatches).Union(dontMatches).ToList();
        allMatches.Sort((x, y) => x.Index.CompareTo(y.Index));

        var enabled = true;
        foreach (var match in allMatches)
        {
            if (doMatches.Contains(match))
            {
                enabled = true;
            }

            if (dontMatches.Contains(match))
            {
                enabled = false;
            }
            
            if (enabled && mulMatches.Contains(match))
            {
                _parsedInput.Add(match.ToString());
            }
        }
    }

    public int SolvePartOne()
    {
        var sum = 0;
        foreach (var mul in _parsedInput)
        {
            var cleanedInput = mul.Replace("mul(", "").Replace(")", "").Split(",");
            _ = int.TryParse(cleanedInput[0], out int left);
            _ = int.TryParse(cleanedInput[1], out int right);

            sum += left * right;
        }

        return sum;
    }
}