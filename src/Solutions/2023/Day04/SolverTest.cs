namespace Day04;

public class SolverTest : TestEngine<Solver, List<Scratchcard>, int>
{
    public override Puzzle PartOne => new()
    {
        Example = new()
        {
            RawInput =
            [
                "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
                "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
                "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
                "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
                "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
                "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
            ],
            Input = 
            [
                new() { WinningNumbers = [41, 48, 83, 86, 17], ScratchedNumbers = [83, 86, 6, 31, 17, 9, 48, 53] },
                new() { WinningNumbers = [13, 32, 20, 16, 61], ScratchedNumbers = [61, 30, 68, 82, 17, 32, 24, 19] },
                new() { WinningNumbers = [1, 21, 53, 59, 44], ScratchedNumbers = [69, 82, 63, 72, 16, 21, 14, 1] },
                new() { WinningNumbers = [41, 92, 73, 84, 69], ScratchedNumbers = [59, 84, 76, 51, 58, 5, 54, 83] },
                new() { WinningNumbers = [87, 83, 26, 28, 32], ScratchedNumbers = [88, 30, 70, 12, 93, 22, 82, 36] },
                new() { WinningNumbers = [31, 18, 13, 56, 72], ScratchedNumbers = [74, 77, 10, 23, 35, 67, 36, 11] }
            ],
            Result = 13
        },
        Solution = 25010
    };

    public override Puzzle PartTwo => new()
    {
        ShouldSkipTests = true, Example = new() { RawInput =  [], Input = 0, Result = 0 }, Solution = 0
    };
}