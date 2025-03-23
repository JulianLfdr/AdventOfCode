namespace AdventOfCode.Year2024.Day02;

public sealed partial class PuzzleSolver
{
    protected override Puzzle<IEnumerable<Report>, int> PartOne
        => new()
        {
            Example = new()
            {
                RawInput =
                [
                    "7 6 4 2 1",
                    "1 2 7 8 9",
                    "9 7 6 2 1",
                    "1 3 2 4 5",
                    "8 6 4 4 1",
                    "1 3 6 7 9"
                ],
                Input =
                [
                    new Report([7, 6, 4, 2, 1]),
                    new Report([1, 2, 7, 8, 9]),
                    new Report([9, 7, 6, 2, 1]),
                    new Report([1, 3, 2, 4, 5]),
                    new Report([8, 6, 4, 4, 1]),
                    new Report([1, 3, 6, 7, 9])
                ],
                Result = 2
            },
            Solution = 282
        };

    /// <summary>
    /// Determine the number of safe reports.
    /// </summary>
    /// <remarks>
    /// Time Complexity: O(n x m)
    ///
    /// n is the number of reports.
    /// m is the number of levels in each report.
    ///
    /// - Zipping and comparing levels: O(m) for each report.
    /// - Checking safety conditions: O(m) for each report.
    /// - Overall complexity: O(n * m) as it involves iterating through each report and its levels.
    /// </remarks>
    protected override int SolvePartOne(IEnumerable<Report> reports)
    {
        var safeReportCount = 0;

        foreach (var levels in reports.Select(r => r.Levels))
        {
            var levelComparisonList = levels
                .Zip(levels.Skip(1), (currentLevel, nextLevel) => (currentLevel, nextLevel));

            if (IsReportSafe(levelComparisonList))
            {
                safeReportCount++;
            }
        }

        return safeReportCount;

        static bool IsReportSafe(IEnumerable<(int currentLevel, int nextLevel)> levelComparisonList)
        {
            var areAllLevelsIncreasing = levelComparisonList.All(l => l.currentLevel < l.nextLevel);
            var areAllLevelsDecreasing = levelComparisonList.All(l => l.currentLevel > l.nextLevel);
            var areAllLevelsWithinSafetyRange = levelComparisonList
                .Select(l => Math.Abs(l.currentLevel - l.nextLevel))
                .All(l => l >= 1 && l <= 3);

            return areAllLevelsWithinSafetyRange && (areAllLevelsIncreasing || areAllLevelsDecreasing);
        }
    }

#pragma warning disable S1144, CA1822
    /// Just a different way to solve the problem but with the same complexity.
    private int SolvePartOneV1(IEnumerable<Report> reports)
    {
        return reports.Count(report =>
        {
            var levelComparisonList = report.Levels
                .Zip(report.Levels.Skip(1), (currentLevel, nextLevel) => (currentLevel, nextLevel));

            return IsReportSafe(levelComparisonList);
        });

        static bool IsReportSafe(IEnumerable<(int currentLevel, int nextLevel)> levelComparisons)
        {
            Direction currentDirection = Direction.None;
            Direction previousDirection = Direction.None;

            foreach (var (currentLevel, nextLevel) in levelComparisons)
            {
                var difference = currentLevel - nextLevel;

                bool isWithinSafetyRange = Math.Abs(difference) >= 1 && Math.Abs(difference) <= 3;
                if (!isWithinSafetyRange)
                {
                    return false;
                }

                bool isIncreasing = difference < 0;
                bool isDecreasing = difference > 0;
                if (isIncreasing)
                {
                    currentDirection = Direction.Increasing;
                }
                else if (isDecreasing)
                {
                    currentDirection = Direction.Decreasing;
                }

                if (previousDirection != Direction.None && previousDirection != currentDirection)
                {
                    return false;
                }

                previousDirection = currentDirection;
            }

            return true;
        }
    }
}
