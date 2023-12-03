namespace Day03;

public class SolverTest : TestEngine<Solver, List<SurroundingCheckResult>, int>
{
    public override Puzzle PartOne => new()
    {
        Example = new()
        {
            RawInput =
            [
                "467..114..",
                "...*......",
                "..35..633.",
                "......#...",
                "617*......",
                ".....+.58.",
                "..592.....",
                "......755.",
                "...$.*....",
                ".664.598.."
            ],
            Input =
            [
               new SurroundingCheckResult()
               {
                   Number = 467,
                   LastDigitColumnId = 3,
                   IsAdjacentToSpecialCharacter = true,
                   SurroundingCharacter = '*',
                   SurroundingCharacterLocation = new(1, 3)
               },
                new SurroundingCheckResult()
                {
                    Number = 35,
                    LastDigitColumnId = 4,
                    IsAdjacentToSpecialCharacter = true,
                    SurroundingCharacter = '*',
                    SurroundingCharacterLocation = new(1, 3)
                },
                new SurroundingCheckResult()
                {
                    Number = 633,
                    LastDigitColumnId = 9,
                    IsAdjacentToSpecialCharacter = true,
                    SurroundingCharacter = '#',
                    SurroundingCharacterLocation = new(3, 6)
                },
                new SurroundingCheckResult()
                {
                    Number = 617,
                    LastDigitColumnId = 3,
                    IsAdjacentToSpecialCharacter = true,
                    SurroundingCharacter = '*',
                    SurroundingCharacterLocation = new(4, 3)
                },
                new SurroundingCheckResult()
                {
                    Number = 592,
                    LastDigitColumnId = 5,
                    IsAdjacentToSpecialCharacter = true,
                    SurroundingCharacter = '+',
                    SurroundingCharacterLocation = new(5, 5)
                },
                new SurroundingCheckResult()
                {
                    Number = 755,
                    LastDigitColumnId = 9,
                    IsAdjacentToSpecialCharacter = true,
                    SurroundingCharacter = '*',
                    SurroundingCharacterLocation = new(8, 5)
                },
                new SurroundingCheckResult()
                {
                    Number = 664,
                    LastDigitColumnId = 4,
                    IsAdjacentToSpecialCharacter = true,
                    SurroundingCharacter = '$',
                    SurroundingCharacterLocation = new(8, 3)
                },
                new SurroundingCheckResult()
                {
                    Number = 598,
                    LastDigitColumnId = 8,
                    IsAdjacentToSpecialCharacter = true,
                    SurroundingCharacter = '*',
                    SurroundingCharacterLocation = new(8, 5)
                }
            ],
            Result = 4361
        },
        Solution = 544433
    };

    public override Puzzle PartTwo => new()
    {
        Example = new()
        {
            RawInput =
            [
                "467..114..",
                "...*......",
                "..35..633.",
                "......#...",
                "617*......",
                ".....+.58.",
                "..592.....",
                "......755.",
                "...$.*....",
                ".664.598.."
            ],
            Input =
            [
               new SurroundingCheckResult()
               {
                   Number = 467,
                   LastDigitColumnId = 3,
                   IsAdjacentToSpecialCharacter = true,
                   SurroundingCharacter = '*',
                   SurroundingCharacterLocation = new(1, 3)
               },
                new SurroundingCheckResult()
                {
                    Number = 35,
                    LastDigitColumnId = 4,
                    IsAdjacentToSpecialCharacter = true,
                    SurroundingCharacter = '*',
                    SurroundingCharacterLocation = new(1, 3)
                },
                new SurroundingCheckResult()
                {
                    Number = 633,
                    LastDigitColumnId = 9,
                    IsAdjacentToSpecialCharacter = true,
                    SurroundingCharacter = '#',
                    SurroundingCharacterLocation = new(3, 6)
                },
                new SurroundingCheckResult()
                {
                    Number = 617,
                    LastDigitColumnId = 3,
                    IsAdjacentToSpecialCharacter = true,
                    SurroundingCharacter = '*',
                    SurroundingCharacterLocation = new(4, 3)
                },
                new SurroundingCheckResult()
                {
                    Number = 592,
                    LastDigitColumnId = 5,
                    IsAdjacentToSpecialCharacter = true,
                    SurroundingCharacter = '+',
                    SurroundingCharacterLocation = new(5, 5)
                },
                new SurroundingCheckResult()
                {
                    Number = 755,
                    LastDigitColumnId = 9,
                    IsAdjacentToSpecialCharacter = true,
                    SurroundingCharacter = '*',
                    SurroundingCharacterLocation = new(8, 5)
                },
                new SurroundingCheckResult()
                {
                    Number = 664,
                    LastDigitColumnId = 4,
                    IsAdjacentToSpecialCharacter = true,
                    SurroundingCharacter = '$',
                    SurroundingCharacterLocation = new(8, 3)
                },
                new SurroundingCheckResult()
                {
                    Number = 598,
                    LastDigitColumnId = 8,
                    IsAdjacentToSpecialCharacter = true,
                    SurroundingCharacter = '*',
                    SurroundingCharacterLocation = new(8, 5)
                }
            ],
            Result = 467835
        },
        Solution = 76314915
    };
}
