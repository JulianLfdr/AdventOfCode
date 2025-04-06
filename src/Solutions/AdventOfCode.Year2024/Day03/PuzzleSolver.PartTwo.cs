namespace AdventOfCode.Year2024.Day03;

public sealed partial class PuzzleSolver
{
    protected override Puzzle<IEnumerable<Instruction>, int> PartTwo
        => new()
        {
            Example = new()
            {
                RawInput =
                [
                    "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))"
                ],
                Input =
                [
                    new Instruction(Enabled: true,  FirstNumber: 2,  SecondNumber:4),
                    new Instruction(Enabled: false, FirstNumber: 5,  SecondNumber:5),
                    new Instruction(Enabled: false, FirstNumber: 11, SecondNumber:8),
                    new Instruction(Enabled: true,  FirstNumber: 8,  SecondNumber:5),
                ],
                Result = 48
            },
            Solution = 88802350
        };

    protected override int SolvePartTwo(IEnumerable<Instruction> input)
        => input.Where(i => i.Enabled).Sum(i => i.FirstNumber * i.SecondNumber);
}
