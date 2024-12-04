using System.Globalization;
using System.Text;

namespace AdventOfCode24.Days;

public class Day4
{
    private List<List<char>> LettersMatrix;

    public Day4(string path)
    {
        var input = File.ReadAllLines(path);
        LettersMatrix = CreateWordSearch(input);
        CheckIndex();
    }

    public int Solve()
    {
        return 0;
    }
    

    private List<List<char>> CreateWordSearch(string[] lines)
    {
        var wordSearch = new List<List<char>>();

        foreach (var line in lines)
        {
            var letters = new List<char>();

            foreach (var letter in line)
            {
                letters.Add(letter);
            }

            wordSearch.Add(letters);
        }

        return wordSearch;
    }

    public bool CheckIndex()
    {
        var upperBoundary = 3;
        var lowerBoundary = -3;

        foreach (var list in LettersMatrix)
        {
            var count = 1;
            
            foreach (var letter in list)
            {
                Console.WriteLine($"List One: ");
            }

            count++;
        }
        
        return true;
    }
}