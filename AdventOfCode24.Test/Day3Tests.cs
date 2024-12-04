﻿using AdventOfCode24.Days;
using FluentAssertions;

namespace AdventOfCode24.Test;

public class Day3Tests
{
    [Fact]
    public void DayThreeTest()
    {
        var dayThree =
            new Day3("C:\\Users\\cerny\\dev_projects\\AdventOfCode24\\AdventOfCode24.Test\\TestFiles\\Day3.txt");

        var answer = dayThree.SolvePartOne();

        answer.Should().Be(48);

    }
}