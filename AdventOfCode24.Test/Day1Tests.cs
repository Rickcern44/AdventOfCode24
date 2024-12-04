using AdventOfCode24.Days;
using FluentAssertions;

namespace AdventOfCode24.Test;

public class Day1Tests
{
    [Fact]
    public void DayOne_SortsCorrectly()
    {
        var dayOne =
            new Day1(
                "C:\\Users\\cerny\\dev_projects\\AdventOfCode24\\AdventOfCode24.Test\\TestFiles\\Day1.txt");

        dayOne.ListOne[0].Should().Be("12");
        dayOne.ListTwo[0].Should().Be("45");
        dayOne.ListOne[1].Should().Be("34");
        dayOne.ListTwo[1].Should().Be("67");
    }

    [Fact]
    public void DayOne_CreatesLocationSets()
    {
        var dayOne =
            new Day1(
                "C:\\Users\\cerny\\dev_projects\\AdventOfCode24\\AdventOfCode24.Test\\TestFiles\\Day1.txt");

        dayOne.LocationSets[0].LocationOne.Should().Be("12");
        dayOne.LocationSets[0].LocationTwo.Should().Be("45");
        dayOne.LocationSets[0].Diff.Should().Be(33);
        dayOne.LocationSets[1].LocationOne.Should().Be("34");
        dayOne.LocationSets[1].LocationTwo.Should().Be("67");
        dayOne.LocationSets[1].Diff.Should().Be(33);
        dayOne.LocationSets[2].LocationOne.Should().Be("54");
        dayOne.LocationSets[2].LocationTwo.Should().Be("90");
        dayOne.LocationSets[2].Diff.Should().Be(36);
    }

    [Fact]
    public void DayOne_SolvesCorrectly()
    {
        var dayOne =
            new Day1(
                "C:\\Users\\cerny\\dev_projects\\AdventOfCode24\\AdventOfCode24.Test\\TestFiles\\Day1.txt");

        var solution = dayOne.SolvePartOne();
        solution.Should().Be(102);
    }
}