namespace AdventOfCode.Year2024.Day01;

public sealed partial class PuzzleSolver : PuzzleSolver<LocationIdLists, int>
{
    public PuzzleSolver() : base(AdventOfCodeConstants.Days.Day01) { }

    protected override LocationIdLists ParseInput(IEnumerable<string> puzzleInput)
    {
        List<int> locationIdListA = [];
        List<int> locationIdListB = [];
        foreach (string input in puzzleInput)
        {
            var line = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            locationIdListA.Add(int.Parse(line[0]));
            locationIdListB.Add(int.Parse(line[1]));
        }

        return new LocationIdLists(
            LocationIdListA: locationIdListA,
            LocationIdListB: locationIdListB);
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
}
