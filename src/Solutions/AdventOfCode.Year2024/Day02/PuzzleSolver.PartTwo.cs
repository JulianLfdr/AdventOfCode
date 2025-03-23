namespace AdventOfCode.Year2024.Day02;

public sealed partial class PuzzleSolver
{
    protected override Puzzle<IEnumerable<Report>, int> PartTwo
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
                Result = 4
            },
            Solution = 349
        };

    /// <summary>
    /// Determine the number of safe reports considering the "Problem Dampener," which allows one level to be removed to make a report safe.
    /// </summary>
    /// <remarks>
    /// Time Complexity: O(n * m^2)
    ///
    /// n is the number of reports.
    /// m is the number of levels in each report.
    ///
    /// - Initial safety check: O(m) for each report.
    /// - Removing each level and re-checking safety: O(m^2) for each report.
    /// - Overall complexity: O(n * m^2) due to iterating through each report and potentially removing each level.
    /// </remarks>
    protected override int SolvePartTwo(IEnumerable<Report> reports)
    {
        var safeReportCount = 0;

        foreach (var levels in reports.Select(r => r.Levels))
        {
            var levelComparisonList = levels
                .Zip(levels.Skip(1), (currentLevel, nextLevel) => (currentLevel, nextLevel));

            if (IsReportSafe(levelComparisonList))
            {
                safeReportCount++;
                continue;
            }

            // Removing one level and re-check safety
            for (var index = 0; index < levels.Count(); index++)
            {
                var derivedLevelsList = levels.Where((_, i) => i != index);
                var derivedLevelComparisonList = derivedLevelsList.Zip(
                    derivedLevelsList.Skip(1),
                    (currentLevel, nextLevel) => (currentLevel, nextLevel));

                if (IsReportSafe(derivedLevelComparisonList))
                {
                    safeReportCount++;
                    break;
                }
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
    private int SolvePartTwoV2(IEnumerable<Report> reports)
    {
        return reports.Count(report =>
        {
            var levelComparisonList = report.Levels
                .Zip(report.Levels.Skip(1), (currentLevel, nextLevel) => (currentLevel, nextLevel));

            if (IsReportSafe(levelComparisonList))
            {
                return true;
            }

            for (var index = 0; index < report.Levels.Count(); index++)
            {
                var derivedLevelsList = report.Levels.Where((_, i) => i != index);
                var derivedLevelComparisonList = derivedLevelsList.Zip(
                    derivedLevelsList.Skip(1),
                    (currentLevel, nextLevel) => (currentLevel, nextLevel));

                if (IsReportSafe(derivedLevelComparisonList))
                {
                    return true;
                }
            }

            return false;
        });

        static bool IsReportSafe(IEnumerable<(int currentLevel, int nextLevel)> levelComparisonList)
        {
            Direction currentDirection = Direction.None;
            Direction previousDirection = Direction.None;

            foreach (var (currentLevel, nextLevel) in levelComparisonList)
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

    private enum Direction
    {
        None,
        Increasing,
        Decreasing
    }
}
