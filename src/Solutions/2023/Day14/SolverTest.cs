namespace Day14;

public class SolverTest : TestEngine<Solver, int, int>
{
    public override Puzzle PartOne => new()
    {
        ShouldSkipTests = true,
        Example = new()
        {
            RawInput = [],
            Input = 0,
            Result = 0
        },
        Solution = 0
    };

    public override Puzzle PartTwo => new()
    {
        ShouldSkipTests = true,
        Example = new()
        {
            RawInput = [],
            Input = 0,
            Result = 0
        },
        Solution = 0
    };
}
