using System.Text.RegularExpressions;

namespace Day04;

public class Solver : Solver<List<Scratchcard>, int>
{
    public Solver() : base("./Day04/input.txt") { }

    public override int PartOne(List<Scratchcard> scratchcards)
    {
        return scratchcards.Select(sc =>
        {
            int result = 0;

            int matchCount = sc.ScratchedNumbers.Count(sn => sc.WinningNumbers.Contains(sn));
            for (int i = matchCount; i >= 1; i--)
            {
                result *= i;
            }

            return result;
        }).Sum();
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
            return input.Replace("  ", " ").Split(" ").Select(number => int.Parse(number)!).ToList();
        }
    }
}

public class Scratchcard
{
    public List<int> WinningNumbers { get; set; }
    public List<int> ScratchedNumbers { get; set; }
}