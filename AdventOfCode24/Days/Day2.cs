using AdventOfCode24.Shared;

namespace AdventOfCode24.Days;

public class Day2
{
    private string[] _rawInput;

    public Day2(string path)
    {
        _rawInput = File.ReadAllLines(path);
    }

    public int SolvePartOne()
    {
        int sum = 0;
        foreach (var line in _rawInput)
        {
            var report = InputParser.WhitespaceSplitRegex().Split(line);
            var reportAsInts = report.Select(int.Parse).ToArray();
            if (ValidateReport(reportAsInts))
            {
                sum++;
            }
        }

        return sum;
    }

    private bool ValidateReport(int[] report, int maxStep = 3)
    {
        bool? isIncreasing = null;
        int errorCount = 0;

        for (int i = 1; i < report.Length; i++)
        {
            int diff = report[i] - report[i - 1];

            if (Math.Abs(diff) > maxStep)
            {
                errorCount++;
            }

            if (diff == 0)
            {
                errorCount++;
            }

            if (isIncreasing == null)
            {
                isIncreasing = diff > 0;
            }
            else if ((isIncreasing.Value && diff < 0) || (!isIncreasing.Value && diff > 0))
            {
                errorCount++;
            }
        }

        return errorCount <= 1;
    }
}