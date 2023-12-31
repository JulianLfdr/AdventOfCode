﻿namespace Day01;

public class SolverTest : TestEngine<Solver, CalibrationDocument, int>
{
    public override Puzzle PartOne => new()
    {
        Example = new()
        {
            RawInput = ["1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet"],
            Input = new CalibrationDocument
            {
                CalibrationValues = ["1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet"]
            },
            Result = 142
        },
        Solution = 54159
    };

    public override Puzzle PartTwo => new()
    {
        Example = new()
        {
            RawInput = ["two1nine", "eightwothree", "abcone2threexyz", "xtwone3four", "4nineeightseven2", "zoneight234", "7pqrstsixteen"],
            Input = new CalibrationDocument
            {
                CalibrationValues = ["two1nine", "eightwothree", "abcone2threexyz", "xtwone3four", "4nineeightseven2", "zoneight234", "7pqrstsixteen"]
            },
            Result = 281
        },
        Solution = 53866
    };
}
