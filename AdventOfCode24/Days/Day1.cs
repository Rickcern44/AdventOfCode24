using System.Text.RegularExpressions;

namespace AdventOfCode24.Days;

public partial class Day1
{
    private List<string> RawInput { get; set; }
    public List<LocationSet> LocationSets { get; set; }
    public List<string> ListOne { get; set; }
    public List<string> ListTwo { get; set; }

    public Day1(string filePath)
    {
        RawInput = File.ReadLines(filePath)
            .ToList();
        ListOne = GetLocations(0).OrderBy(l => l).ToList();
        ListTwo = GetLocations(1).OrderBy(l => l).ToList();
        LocationSets = GetLocationSets();
    }

    public int SolvePartOne()
    {
        return LocationSets.Sum(x => x.Diff);
    }

    public int SolvePartTwo()
    {
        int sumOfDuplicates = 0;

        foreach (var location in ListOne)
        {
            var matches = ListTwo.FindAll(x => x == location);
            _ = int.TryParse(location, out int locationAsInt);
            
            sumOfDuplicates +=  locationAsInt * matches.Count;
        }
        return sumOfDuplicates;
    }


    public void Print()
    {
        var test = 0;
        while (test < 10)
        {
            Console.WriteLine(LocationSets[test]);
            test++;
        }
    }

    private List<string> GetLocations(int location)
    {
        var locations = new List<string>();

        foreach (var item in RawInput)
        {
            locations.Add(SplitRegex().Split(item)[location]);
        }

        return locations;
    }

    private List<LocationSet> GetLocationSets()
    {
        var locationSets = new List<LocationSet>();

        for (var i = 0; i < RawInput.Count; i++)
        {
            locationSets.Add(new LocationSet(ListOne[i], ListTwo[i]));
        }

        return locationSets;
    }

    [GeneratedRegex(@"\s+")]
    private static partial Regex SplitRegex();
}

public record LocationSet(string LocationOne, string LocationTwo)
{
    public int Diff => GetDiff();

    private int GetDiff()
    {
        int.TryParse(LocationOne, out int locOneInt);
        int.TryParse(LocationTwo, out int locTwoInt);

        return Math.Abs(locOneInt - locTwoInt);
    }
};