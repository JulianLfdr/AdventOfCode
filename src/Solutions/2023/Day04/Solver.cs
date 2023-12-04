using System.Text.RegularExpressions;

namespace Day04;

public class Solver : Solver<List<Scratchcard>, int>
{
    public Solver() : base("./Day04/input.txt") { }

    public override int PartOne(List<Scratchcard> scratchcards)
    {
        return GetTotalPoints(scratchcards);

        static int GetTotalPoints(IEnumerable<Scratchcard> scratchcards)
        {
            return scratchcards
                .Where(sc => sc.ScratchedNumbers.Any(sn => sc.WinningNumbers.Contains(sn)))
                .Select(sc =>
                {
                    int matchCount = sc.ScratchedNumbers.Count(sn => sc.WinningNumbers.Contains(sn));
                    return Enumerable.Range(0, matchCount - 1).Aggregate(1, (current, _) => current * 2);
                }).Sum();
        }
    }

    public override int PartTwo(List<Scratchcard> scratchcards)
    {
        throw new NotImplementedException();
    }

    public override List<Scratchcard> ParseInput(IEnumerable<string> input)
    {
        return input.Select(i =>
        {
            Match match = Regex.Match(i, @".+:\s+(?<winningNumbers>\d+.+)\|\s+(?<scratchedNumbers>\d+.+)");

            return new Scratchcard
            {
                WinningNumbers = ExtractNumbers(match.Groups["winningNumbers"].Value),
                ScratchedNumbers = ExtractNumbers(match.Groups["scratchedNumbers"].Value)
            };
        }).ToList();

        static List<int> ExtractNumbers(string input)
        {
            return input
                .Replace("  ", " ")
                .Trim()
                .Split(" ")
                .Select(number => int.Parse(number)!)
                .ToList();
        }
    }
}

public class Scratchcard
{
    public List<int> WinningNumbers { get; set; }
    public List<int> ScratchedNumbers { get; set; }
}