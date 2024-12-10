namespace AdventOfCode24.Days;

public class Day5
{
    private List<(int, int)> _rules = [];
    private List<List<int>> _updateSequences = [];
    private Dictionary<int, List<int>> _graph = [];

    public Day5()
    {
        SplitInput(File.ReadAllLines(@"Input\\Day5.txt"));
        _graph = BuildGraph();
        Print();
    }

    public Day5(string path)
    {
        SplitInput(File.ReadAllLines(path));
        _graph = BuildGraph();
    }

    public int SolvePartOne()
    {
        var result = 0;
        
        foreach (var updateSequence in _updateSequences)
        {
            if (ValidateUpdateSequence(_graph, updateSequence)) result++;
        }

        return result;
    }

    public int SolvePartTwo()
    {
        return 0;
    }


    private void SplitInput(string[] input)
    {
        // rules
        var spaceIndex = Array.IndexOf(input, "");
        var rulesSplit = input.Take(spaceIndex).ToArray();
        foreach (var rule in rulesSplit)
        {
            var ruleSplit = rule.Split("|");
            _rules.Add((int.Parse(ruleSplit[0]), int.Parse(ruleSplit[1])));
        }

        // update sequences
        var updatesSplit = input.Skip(spaceIndex + 1).ToArray();

        foreach (var update in updatesSplit)
        {
            var updateSplit = update.Split(",");
            var updateList = new List<int>();

            foreach (var item in updateSplit)
            {
                updateList.Add(int.Parse(item));
            }

            _updateSequences.Add(updateList);
        }
    }

    private Dictionary<int, List<int>> BuildGraph()
    {
        var graph = new Dictionary<int, List<int>>();

        foreach (var (dependency, dependent) in _rules)
        {
            if (!graph.ContainsKey(dependency))
            {
                graph[dependency] = [];
            }

            graph[dependency].Add(dependent);
        }

        return graph;
    }

    static bool ValidateUpdateSequence(Dictionary<int, List<int>> graph, List<int> updateSequence)
    {
        var visited = new HashSet<int>();
        var position = new Dictionary<int, int>();

        for (var i = 0; i < updateSequence.Count; i++)
        {
            position[updateSequence[i]] = i;
        }

        foreach (var node in updateSequence)
        {
            return DepthFirstSearch(graph, node, visited, position);
        }

        return true;
    }

    static bool DepthFirstSearch(Dictionary<int, List<int>> graph, int node, HashSet<int> visited,
        Dictionary<int, int> position)
    {
        if (!graph.ContainsKey(node))
        {
            return true;
        }

        if (visited.Contains(node))
        {
            return true;
        }

        visited.Add(node);

        foreach (var dependant in graph[node])
        {
            if (!position.ContainsKey(dependant) || position[dependant] <= position[node])
            {
                return false;
            }
        }

        return true;
    }

    private void Print()
    {
        // foreach (var rule in _rules)    
        // {
        //     Console.WriteLine($"Rule: {rule.Item1} | {rule.Item2}");
        // }

        // foreach (var sequence in _updateSequences)
        // {
        //     Console.WriteLine(string.Join(",", sequence));
        // }

        // foreach (var kvp in _graph)
        // {
        //     foreach (var list in kvp.Value)
        //     {
        //         Console.WriteLine(kvp.Key + "," + string.Join(",", list));
        //     }
        // }
    }
}