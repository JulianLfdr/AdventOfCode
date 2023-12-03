using AdventOfCode.Commons;
using System.Drawing;
using System.Text;

namespace Day03;

public class Solver : Solver<List<SurroundingCheckResult>, int>
{
    public Solver() : base("./input.txt") { }

    public override int PartOne(List<SurroundingCheckResult> surroundingCheckResults)
    {
        return surroundingCheckResults.Sum(r => r.Number);
    }

    public override int PartTwo(List<SurroundingCheckResult> surroundingCheckResults)
    {
        return surroundingCheckResults
            .Where(r => r.SurroundingCharacter == '*')
            .GroupBy(r => r.SurroundingCharacterLocation)
            .Where(g => g.Count() == 2)
            .Select(g => g.Aggregate(seed: 1, (accumulator, checkResult) => accumulator * checkResult.Number))
            .Sum();
    }

    public override List<SurroundingCheckResult> ParseInput(IEnumerable<string> engineSchematic)
    {
        char[,] engineSchematicGrid = GetEngineSchematicGrid(engineSchematic);
        return GetSurroundingCheckResults(engineSchematicGrid);

        static char[,] GetEngineSchematicGrid(IEnumerable<string> engineSchematic)
        {
            int rowCount = engineSchematic.Count();
            int columnCount = engineSchematic.Max(e => e.Length);

            var grid = new char[rowCount, columnCount];

            for (int rowId = 0; rowId < rowCount; rowId++)
            {
                string currentRow = engineSchematic.ElementAt(rowId);

                for (int columnId = 0; columnId < columnCount; columnId++)
                {
                    grid[rowId, columnId] = currentRow.ElementAtOrDefault(columnId);
                }
            }

            return grid;
        }

        static List<SurroundingCheckResult> GetSurroundingCheckResults(char[,] engineSchematicGrid)
        {
            List<SurroundingCheckResult> surroundingCheckResults = [];

            int rowCount = engineSchematicGrid.GetLength(0) - 1;
            int columnCount = engineSchematicGrid.GetLength(1) - 1;

            for (int rowId = 0; rowId <= rowCount; rowId++)
            {
                for (int columnId = 0; columnId <= columnCount; columnId++)
                {
                    char currentChar = engineSchematicGrid[rowId, columnId];
                    if (char.IsDigit(currentChar))
                    {
                        var checkResult = CheckCurrentDigitSurroundingsForSpecialCharacters(engineSchematicGrid, rowId, columnId, rowCount, columnCount);
                        if (checkResult.IsAdjacentToSpecialCharacter)
                        {
                            // In case multiple digits follows each other,
                            // the returned number will be all digits combined
                            surroundingCheckResults.Add(checkResult);

                            // In case multiple digits follows each other,
                            // set the current column to the one of the last digit
                            columnId = checkResult.LastDigitColumnId;
                        }
                    }
                }
            }

            return surroundingCheckResults;

            static SurroundingCheckResult CheckCurrentDigitSurroundingsForSpecialCharacters(char[,] grid, int currentDigitRowId, int currentDigitColumnId, int rowCount, int columnCount)
            {
                int firstRowToCheck = DetermineFirstRowOrColumnToCheck(currentDigitRowId);
                int lastRowToCheck = DetermineLastRowToCheck(currentDigitRowId, rowCount);

                int firstColumnToCheck = DetermineFirstRowOrColumnToCheck(currentDigitColumnId);
                int lastColumnToCheck = DetermineLastColumnToCheck(grid, currentDigitRowId, currentDigitColumnId, columnCount);

                for (int rowId = firstRowToCheck; rowId <= lastRowToCheck; rowId++)
                {
                    for (int columnId = firstColumnToCheck; columnId <= lastColumnToCheck; columnId++)
                    {
                        char currentChar = grid[rowId, columnId];

                        if (IsSpecialCharacter(currentChar))
                        {
                            string number = ExtractNumber(grid, currentDigitRowId, currentDigitColumnId, lastColumnToCheck);

                            return new SurroundingCheckResult
                            {
                                Number = int.Parse(number),
                                LastDigitColumnId = currentDigitColumnId + number.Length,
                                IsAdjacentToSpecialCharacter = true,
                                SurroundingCharacter = currentChar,
                                SurroundingCharacterLocation = new(rowId, columnId)
                            };
                        }
                    }
                }

                return new SurroundingCheckResult
                {
                    IsAdjacentToSpecialCharacter = false
                };
            }

            /// <summary>
            /// Determine the first row or column to be checked.
            /// </summary>
            /// <remarks>
            /// Will be the row above except if current row is the first one.
            /// Will be the column before except if current column is the last one.
            /// </remarks>
            static int DetermineFirstRowOrColumnToCheck(int currentDigitRowId) => currentDigitRowId == 0 ? 0 : currentDigitRowId - 1;

            /// <summary>
            /// Determine the last row to be checked.
            /// </summary>
            /// <remarks>
            /// Will be the row bellow except if current row is the last one.
            /// </remarks>
            static int DetermineLastRowToCheck(int currentDigitColumnId, int columnCount) => currentDigitColumnId == columnCount ? columnCount : currentDigitColumnId + 1;

            /// <summary>
            /// Determine the last column to be checked.
            /// </summary>
            /// <remarks>
            /// Will be the column after if current column is the last one.
            /// Otherwise, if next column is a digit, will be the last adjacent digit column.
            /// </remarks>
            static int DetermineLastColumnToCheck(char[,] grid, int currentDigitRowId, int currentDigitColumnId, int columnCount)
            {
                // The next or current column
                int nextColumnId = currentDigitColumnId == columnCount ? columnCount : currentDigitColumnId + 1;

                // Find digit chain last column, if any
                char nextChar = grid[currentDigitRowId, nextColumnId];
                while (char.IsDigit(nextChar))
                {
                    if (nextColumnId == columnCount)
                    {
                        break;
                    }

                    nextColumnId++;
                    nextChar = grid[currentDigitRowId, nextColumnId];
                }

                return nextColumnId;
            }

            static string ExtractNumber(char[,] grid, int currentDigitRowId, int currentDigitColumnId, int lastColumnToCheck)
            {
                return Enumerable.Range(currentDigitColumnId, lastColumnToCheck - currentDigitColumnId + 1)
                    .Select(columnIndex => grid[currentDigitRowId, columnIndex])
                    .Where(char.IsDigit)
                    .Aggregate(new StringBuilder(), (stringBuilder, digit) => stringBuilder.Append(digit))
                    .ToString();
            }

            static bool IsSpecialCharacter(char c)
            {
                return c != '.' && !char.IsDigit(c);
            }
        }
    }
}

public class SurroundingCheckResult
{
    public int Number { get; set; }
    public int LastDigitColumnId { get; set; }
    public bool IsAdjacentToSpecialCharacter { get; set; }
    public char SurroundingCharacter { get; set; }
    public Point SurroundingCharacterLocation { get; set; }
}
