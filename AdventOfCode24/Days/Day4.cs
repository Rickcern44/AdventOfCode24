namespace AdventOfCode24.Days;

public class Day4
{
    private readonly string[] _input;

    public Day4()
    {
        _input = File.ReadAllLines(@"Input\\Day4.txt");
        Console.WriteLine($"Part One: {Solve()}");
        Console.WriteLine($"Part Two: {SolvePartTwo()}");
    }

    public Day4(string path)
    {
        _input = File.ReadAllLines(path);
        Console.WriteLine($"Part One: {Solve()}");
        Console.WriteLine($"Part Two: {SolvePartTwo()}");
    }

    public int Solve()
    {
        var sum = 0;
        var lines = _input;

        int rows = lines.Length;
        int cols = lines[0].ToCharArray().Length;

        char[,] matrix = new char[rows, cols];

        // populate the array
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = lines[i][j];
            }
        }

        const char searchLetter = 'X';

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] != searchLetter) continue;

                if (CheckDirections(Direction.Left, matrix, i, j)) sum++;
                if (CheckDirections(Direction.Right, matrix, i, j)) sum++;
                if (CheckDirections(Direction.Up, matrix, i, j)) sum++;
                if (CheckDirections(Direction.Down, matrix, i, j)) sum++;
                if (CheckDirections(Direction.LeftUp, matrix, i, j)) sum++;
                if (CheckDirections(Direction.LeftDown, matrix, i, j)) sum++;
                if (CheckDirections(Direction.RightUp, matrix, i, j)) sum++;
                if (CheckDirections(Direction.RightDown, matrix, i, j)) sum++;
            }
        }

        return sum;
    }

    public int SolvePartTwo()
    {
        var sum = 0;
        var lines = _input;

        int rows = lines.Length;
        int cols = lines[0].ToCharArray().Length;

        char[,] matrix = new char[rows, cols];

        // populate the array
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = lines[i][j];
            }
        }

        const char searchLetter = 'A';
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] != searchLetter) continue;
                if (CheckForMasPattern(matrix, i, j)) sum++;
            }
        }

        return sum;
    }

    private bool CheckDirections(Direction direction, char[,] matrix, int row, int col)
    {
        var outOfBoundsUp = row - 3 < matrix.GetLowerBound(0);
        var outOfBoundsDown = row + 3 > matrix.GetUpperBound(0);
        var outOfBoundsLeft = col - 3 < matrix.GetLowerBound(1);
        var outOfBoundsRight = col + 3 > matrix.GetUpperBound(1);

        if (direction is Direction.Left && outOfBoundsLeft) return false;
        if (direction is Direction.Right && outOfBoundsRight) return false;
        if (direction is Direction.Up && outOfBoundsUp) return false;
        if (direction is Direction.Down && outOfBoundsDown) return false;
        if (direction is Direction.LeftUp && (outOfBoundsUp || outOfBoundsLeft)) return false;
        if (direction is Direction.LeftDown && (outOfBoundsDown || outOfBoundsLeft)) return false;
        if (direction is Direction.RightUp && (outOfBoundsUp || outOfBoundsRight)) return false;
        if (direction is Direction.RightDown && (outOfBoundsDown || outOfBoundsRight)) return false;


        switch (direction)
        {
            case Direction.Right:
                char[] rightLetters =
                    [matrix[row, col], matrix[row, col + 1], matrix[row, col + 2], matrix[row, col + 3]];
                // Console.WriteLine(string.Join("", rightLetters));
                return string.Join("", rightLetters) == "XMAS";
            case Direction.Left:
                char[] leftLetters =
                    [matrix[row, col], matrix[row, col - 1], matrix[row, col - 2], matrix[row, col - 3]];
                return string.Join("", leftLetters) == "XMAS";
            case Direction.Up:
                char[] upLetters =
                    [matrix[row, col], matrix[row - 1, col], matrix[row - 2, col], matrix[row - 3, col]];
                return string.Join("", upLetters) == "XMAS";
            case Direction.Down:
                char[] downLetters =
                    [matrix[row, col], matrix[row + 1, col], matrix[row + 2, col], matrix[row + 3, col]];
                return string.Join("", downLetters) == "XMAS";
            case Direction.LeftUp:
                char[] leftUpLetters =
                    [matrix[row, col], matrix[row - 1, col - 1], matrix[row - 2, col - 2], matrix[row - 3, col - 3]];
                return string.Join("", leftUpLetters) == "XMAS";
            case Direction.LeftDown:
                char[] leftDownLetters =
                    [matrix[row, col], matrix[row + 1, col - 1], matrix[row + 2, col - 2], matrix[row + 3, col - 3]];
                return string.Join("", leftDownLetters) == "XMAS";
            case Direction.RightUp:
                char[] rightUpLetters =
                    [matrix[row, col], matrix[row - 1, col + 1], matrix[row - 2, col + 2], matrix[row - 3, col + 3]];
                return string.Join("", rightUpLetters) == "XMAS";
            case Direction.RightDown:
                char[] rightDownLetters =
                    [matrix[row, col], matrix[row + 1, col + 1], matrix[row + 2, col + 2], matrix[row + 3, col + 3]];
                return string.Join("", rightDownLetters) == "XMAS";
            default:
                return false;
        }
    }

    private bool CheckForMasPattern(char[,] matrix, int row, int col)
    {
        // If on edge of the file rows or columns the pattern will not be possible
        if (col == matrix.GetLowerBound(0) || col == matrix.GetUpperBound(0)) return false;
        if (row == matrix.GetLowerBound(1) || row == matrix.GetUpperBound(1)) return false;

        char[] topLeftToBottomRight = [matrix[row - 1, col - 1], matrix[row, col], matrix[row + 1, col + 1]];
        char[] topRightToBottomLeft = [matrix[row - 1, col + 1], matrix[row, col], matrix[row + 1, col - 1]];
        Array.Sort(topLeftToBottomRight);
        Array.Sort(topRightToBottomLeft);
        var tlbrAsString = string.Join("", topLeftToBottomRight);
        var trblAsString = string.Join("", topRightToBottomLeft);

        return string.Equals(tlbrAsString, trblAsString) && tlbrAsString.Equals("AMS") && trblAsString.Equals("AMS");
    }

    private void PrintMatrix(char[,] matrix)
    {
        for (int i = 0; i < matrix.GetUpperBound(0); i++)
        {
            for (int j = 0; j < matrix.GetUpperBound(1); j++)
            {
                Console.Write(matrix[i, j]);
            }
        }
    }

    private enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        LeftUp,
        LeftDown,
        RightUp,
        RightDown
    }
}