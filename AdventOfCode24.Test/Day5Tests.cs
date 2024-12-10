using AdventOfCode24.Days;
using FluentAssertions;

namespace AdventOfCode24.Test;

public class Day5Tests
{
    [Fact]
    public void DayFivePartOne_ReturnCorrectResult()
    {
        var dayFive = new Day5("C:\\Users\\cerny\\dev_projects\\AdventOfCode24\\AdventOfCode24.Test\\TestFiles\\Day5.txt");
        var result = dayFive.SolvePartOne();

        result.Should().Be(3);
    }
}