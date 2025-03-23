namespace AdventOfCode.Year2024.Day02;

public sealed partial class PuzzleSolver : PuzzleSolver<IEnumerable<Report>, int>
{
    public PuzzleSolver() : base(AdventOfCodeConstants.Days.Day02) { }

    protected override IEnumerable<Report> ParseInput(IEnumerable<string> puzzleInput)
    {
        return puzzleInput
            .Select(i => new Report(
                i.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)));
    }
}
