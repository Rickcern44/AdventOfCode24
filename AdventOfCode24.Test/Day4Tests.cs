using AdventOfCode24.Days;
using FluentAssertions;

namespace AdventOfCode24.Test;

public class Day4Tests
{
    [Fact]
    public void DayFour_ReturnsCorrectResult()
    {
        var dayFour = new Day4("C:\\Users\\cerny\\dev_projects\\AdventOfCode24\\AdventOfCode24.Test\\TestFiles\\Day4.txt");
        
        dayFour.Solve().Should().Be(18);
    }
}