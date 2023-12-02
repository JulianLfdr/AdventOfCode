using AdventOfCode.Commons;
using System.Text.RegularExpressions;

namespace Day02;

public class Solver : Solver<List<CubeConundrum>, int>
{
    private const int MAX_RED_CUBES = 12;
    private const int MAX_GREEN_CUBES = 13;
    private const int MAX_BLUE_CUBES = 14;

    public Solver() : base("./input.txt")
    {
    }

    public override int PartOne(List<CubeConundrum> games)
    {
        return games.Where(g => g.Rounds.All(r =>
            r.RedCubeCount <= MAX_RED_CUBES
            && r.GreenCubeCount <= MAX_GREEN_CUBES
            && r.BlueCubeCount <= MAX_BLUE_CUBES
        )).Sum(g => g.GameId);
    }

    public override int PartTwo(List<CubeConundrum> games)
    {
        return games.Select(g => 
            g.Rounds.Max(r => r.RedCubeCount) * g.Rounds.Max(r => r.GreenCubeCount) * g.Rounds.Max(r => r.BlueCubeCount)
        ).Sum();
    }

    public override List<CubeConundrum> ParseInput(IEnumerable<string> games)
    {
        return games.Select(game =>
        {
            return new CubeConundrum
            {
                GameId = int.Parse(Regex.Match(game, @"(?<id>\d+):").Groups["id"].Value),
                Rounds = ParseGameRounds(game)
            };
        }).ToList();

        static List<CubeCount> ParseGameRounds(string input)
        {
            var rounds = input.Split(";");
            var cubeCounts = new List<CubeCount>();

            foreach (var round in rounds)
            {
                var colorMatches = Regex.Matches(round, @"(?<colorCount>\d+) (?<colorName>\w+)");

                cubeCounts.Add(new CubeCount
                {
                    RedCubeCount = GetColorCount(colorMatches, "red"),
                    GreenCubeCount = GetColorCount(colorMatches, "green"),
                    BlueCubeCount = GetColorCount(colorMatches, "blue")
                });
            }

            return cubeCounts;
        }

        static int GetColorCount(MatchCollection matches, string colorName)
        {
            var colorMatch = matches.FirstOrDefault(a => a.Groups["colorName"].Value == colorName);

            if (colorMatch == null)
            {
                return 0;
            }

            return int.Parse(colorMatch.Groups["colorCount"].Value);
        }
    }
}

public class CubeConundrum
{
    public required int GameId { get; set; }
    public required List<CubeCount> Rounds { get; set; }
}

public class CubeCount
{
    public int RedCubeCount { get; set; }
    public int GreenCubeCount { get; set; }
    public int BlueCubeCount { get; set; }
}
