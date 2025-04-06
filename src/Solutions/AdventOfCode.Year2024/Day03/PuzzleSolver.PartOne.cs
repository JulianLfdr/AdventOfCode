namespace AdventOfCode.Year2024.Day03;

public sealed partial class PuzzleSolver
{
    protected override Puzzle<IEnumerable<Instruction>, int> PartOne
        => new()
        {
            Example = new()
            {
                RawInput =
                [
                    "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))"
                ],
                Input =
                [
                    new Instruction(Enabled: true, FirstNumber: 2,  SecondNumber:4),
                    new Instruction(Enabled: true, FirstNumber: 5,  SecondNumber:5),
                    new Instruction(Enabled: true, FirstNumber: 11, SecondNumber:8),
                    new Instruction(Enabled: true, FirstNumber: 8,  SecondNumber:5),
                ],
                Result = 161
            },
            Solution = 174336360
        };

    protected override int SolvePartOne(IEnumerable<Instruction> input)
        => input.Sum(i => i.FirstNumber * i.SecondNumber);
}
