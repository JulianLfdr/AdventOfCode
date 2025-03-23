namespace AdventOfCode.Year2024.Day01;

public sealed partial class PuzzleSolver : PuzzleSolver<LocationIdLists, int>
{
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
    /// - Overall complexity: O(n log n) due to the sorting step dominating the time complexity.
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

#pragma warning disable S1144, CA1822
    /// Just a different way to solve the problem but with the same complexity
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
}
