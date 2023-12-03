using AdventOfCode.Commons;
using System.Text.RegularExpressions;

namespace Day01;

public class Solver : Solver<CalibrationDocument, int>
{
    public Solver() : base("./input.txt") { }

    public override int PartOne(CalibrationDocument calibrationDocument)
    {
        return calibrationDocument.CalibrationValues
            .Select(v =>
            {
                var digits = v.Where(char.IsDigit);
                return int.Parse($"{digits.FirstOrDefault()}{digits.LastOrDefault()}");
            }).Sum();
    }

    public override int PartTwo(CalibrationDocument calibrationDocument)
    {
        return calibrationDocument.CalibrationValues
            .Select(RecoverCalibrationValue)
            .Sum();

        int RecoverCalibrationValue(string calibrationValue)
        {
            return int.Parse($"{FindFirstDigit(calibrationValue)}{FindFirstDigit(calibrationValue, RegexOptions.RightToLeft)}");
        };

        string FindFirstDigit(string calibrationValue, RegexOptions regexOptions = RegexOptions.None)
        {
            var pattern = @"\d|one|two|three|four|five|six|seven|eight|nine";
            return ParseMatch(Regex.Match(calibrationValue, pattern, regexOptions).Value);
        };

        string ParseMatch(string match) => match switch
        {
            "one" => "1",
            "two" => "2",
            "three" => "3",
            "four" => "4",
            "five" => "5",
            "six" => "6",
            "seven" => "7",
            "eight" => "8",
            "nine" => "9",
            _ => match
        };
    }

    public override CalibrationDocument ParseInput(IEnumerable<string> input)
    {
        return new()
        {
            CalibrationValues = input.ToList()
        };
    }
}

public class CalibrationDocument
{
    public required List<string> CalibrationValues { get; set; }
}
