using AdventOfCode24.Days;
using FluentAssertions;

namespace AdventOfCode24.Test;

public class Day2Tests
{
    [Fact]
    public void DayTwoSolvePartOne_ReturnsCorrectResult()
    {
        var dayTwo = new Day2("C:\\Users\\cerny\\dev_projects\\AdventOfCode24\\AdventOfCode24.Test\\TestFiles\\DayTwoTestFile.txt");
        var result = dayTwo.SolvePartOne();

        result.Should().Be(19);
    }
}