using System.Text.RegularExpressions;

namespace AdventOfCode.Year2024.Day03;

public sealed partial class PuzzleSolver : PuzzleSolver<IEnumerable<Instruction>, int>
{
    public PuzzleSolver() : base(AdventOfCodeConstants.Days.Day03) { }

    protected override IEnumerable<Instruction> ParseInput(IEnumerable<string> puzzleInput)
    {
        bool enabled = true;
        IEnumerable<Match> matchedInstructions = puzzleInput.SelectMany(i => InstructionPattern().Matches(i));

        return matchedInstructions
            .Select(i =>
            {
                if (string.Equals(i.Value, "do()", StringComparison.InvariantCultureIgnoreCase))
                {
                    enabled = true;
                    return null;
                }
                if (string.Equals(i.Value, "don't()", StringComparison.InvariantCultureIgnoreCase))
                {
                    enabled = false;
                    return null;
                }

                return new Instruction(
                    Enabled: enabled,
                    FirstNumber: int.Parse(i.Groups["first"].Value),
                    SecondNumber: int.Parse(i.Groups["second"].Value));
            }).Where(instruction => instruction is not null)!;
    }

    [GeneratedRegex(@"mul\((?<first>\d{1,3}),(?<second>\d{1,3})\)|(?<do>do\(\))|(?<doNot>don't\(\))")]
    private static partial Regex InstructionPattern();
}
