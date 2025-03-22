namespace AdventOfCode.Year2024.Day01;

public sealed partial class PuzzleSolver : PuzzleSolver<LocationIdLists, int>
{
    public PuzzleSolver() : base(AdventOfCodeConstants.Days.Day01) { }

    protected override Puzzle<LocationIdLists, int> PartOne
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
                Result = 11
            },
            Solution = 2031679
        };

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

    protected override LocationIdLists ParseInput(IEnumerable<string> puzzleInput)
    {
        string locationIdsSeparator = "   ";

        List<int> locationIdListA = [];
        List<int> locationIdListB = [];
        foreach (string input in puzzleInput)
        {
            var line = input.Split(locationIdsSeparator);
            locationIdListA.Add(int.Parse(line[0]));
            locationIdListB.Add(int.Parse(line[1]));
        }

        return new LocationIdLists(
            LocationIdListA: locationIdListA,
            LocationIdListB: locationIdListB);
    }

    /// <summary>
    /// Calculate the total distance between two lists of location IDs.
    /// </summary>
    /// <remarks>
    /// Time Complexity: O(n log n)
    ///
    /// n is the length of elements in each list.
    ///
    /// - Sorting each list: O(n log n) as it's a sorting algorithm.
    /// - Zipping and summing distances: O(n) as it involves a single pass through the list.
    /// </remarks>
    protected override int SolvePartOne(LocationIdLists input)
    {
        var totalDistance = 0;

        var sortedLocationIdListA = input.LocationIdListA.Order().ToArray();
        var sortedLocationIdListB = input.LocationIdListB.Order().ToArray();

        foreach (var (locationIdA, locationIdB) in sortedLocationIdListA.Zip(sortedLocationIdListB))
        {
            totalDistance += Math.Abs(locationIdA - locationIdB);
        }

        return totalDistance;
    }

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
    private LocationIdLists ParseInputV2(IEnumerable<string> puzzleInput)
    {
        const string locationIdsSeparator = "   ";

        var parsedLists = puzzleInput
            .Select(input => input.Split(locationIdsSeparator))
            .Select(line => (int.Parse(line[0]), int.Parse(line[1])))
            .ToList();

        return new LocationIdLists(
            LocationIdListA: parsedLists.Select(tuple => tuple.Item1),
            LocationIdListB: parsedLists.Select(tuple => tuple.Item2));
    }

    private int SolvePartOneV2(LocationIdLists input)
    {
        var totalDistance = 0;

        var sortedLocationIdListA = input.LocationIdListA.Order().ToArray();
        var sortedLocationIdListB = input.LocationIdListB.Order().ToArray();

        for (int index = 0; index < input.LocationIdListA.Count(); index++)
        {
            totalDistance += Math.Abs(sortedLocationIdListA[index] - sortedLocationIdListB[index]);
        }

        return totalDistance;
    }

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
