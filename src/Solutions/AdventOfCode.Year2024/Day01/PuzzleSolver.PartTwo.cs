namespace AdventOfCode.Year2024.Day01;

public sealed partial class PuzzleSolver : PuzzleSolver<LocationIdLists, int>
{
    protected override Puzzle<LocationIdLists, int> PartTwo
        => new()
        {
            Example = new()
            {
                RawInput =
                [
                    "3   4",
                    "4   3",
                    "2   5",
                    "1   3",
                    "3   9",
                    "3   3"
                ],
                Input = new(
                    LocationIdListA: [3, 4, 2, 1, 3, 3],
                    LocationIdListB: [4, 3, 5, 3, 9, 3]),
                Result = 31
            },
            Solution = 19678534
        };

    /// <summary>
    /// Calculate a similarity score based on how often each number from the first list appears in the second list.
    /// </summary>
    /// <remarks>
    /// Time Complexity: O(n + m)
    ///
    /// n and m are the lengths of the two lists.
    ///
    /// - Building the count dictionary: O(m)
    /// - Iterating and calculating the score: O(n)
    /// </remarks>
    protected override int SolvePartTwo(LocationIdLists input)
    {
        var similarityScore = 0;

        var locationIdCountInListB = input.LocationIdListB
            .GroupBy(l => l)
            .ToDictionary(g => g.Key, g => g.Count());

        foreach (var locationIdA in input.LocationIdListA)
        {
            if (locationIdCountInListB.TryGetValue(locationIdA, out int count))
            {
                similarityScore += locationIdA * count;
            }
        }

        return similarityScore;
    }

#pragma warning disable S1144, CA1822
    /// <remarks>
    /// Time Complexity: O(n × m)
    ///
    /// n and m are the lengths of the two lists.
    ///
    /// - Counting occurrences for each element: O(n × m) as an operation on ListB is performed for each element in ListA.
    /// </remarks>
    private int SolvePartTwoV1(LocationIdLists input)
    {
        var similarityScore = 0;

        foreach (var locationIdA in input.LocationIdListA)
        {
            similarityScore += locationIdA * input.LocationIdListB.Count(l => l == locationIdA);
        }

        return similarityScore;
    }
}
