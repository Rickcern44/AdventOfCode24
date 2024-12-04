using AdventOfCode24.Days;

Console.WriteLine("Advent of Code24");
Console.WriteLine("-------------------------------------");

var input = @"C:\Users\cerny\dev_projects\AdventOfCode24\AdventOfCode24\Input\Day3.txt";

// var dayOne = new DayOne(@"C:\Users\cerny\dev_projects\AdventOfCode24\AdventOfCode24\Input\DayOne.txt");
// Console.WriteLine($"Part One: {dayOne.SolvePartOne()}");
// Console.WriteLine($"Part Two: {dayOne.SolvePartTwo()}");

// var dayTwo = new DayTwo(input);
// Console.WriteLine($"Part One: {dayTwo.SolvePartOne()}");
// Console.WriteLine($"Part Two: {dayOne.SolvePartTwo()}");

var dayThree = new Day3(input);
Console.WriteLine($"Part One: {dayThree.SolvePartOne()}");
Console.WriteLine("-------------------------------------");