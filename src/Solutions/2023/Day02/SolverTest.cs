namespace Day02;

public class SolverTest : TestEngine<Solver, List<CubeConundrum>, int>
{
    public override Puzzle PartOne => new()
    {
        Example = new()
        {
            RawInput =
            [
                "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
                "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
                "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
                "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
                "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
            ],
            Input =
            [
                new()
                {
                    GameId = 1,
                    Rounds =
                    [
                        new() { RedCubeCount = 4, GreenCubeCount = 0, BlueCubeCount = 3 },
                        new() { RedCubeCount = 1, GreenCubeCount = 2, BlueCubeCount = 6 },
                        new() { RedCubeCount = 0, GreenCubeCount = 2, BlueCubeCount = 0 }
                    ]
                },
                new()
                {
                    GameId = 2,
                    Rounds =
                    [
                        new() { RedCubeCount = 0, GreenCubeCount = 2, BlueCubeCount = 1 },
                        new() { RedCubeCount = 1, GreenCubeCount = 3, BlueCubeCount = 4 },
                        new() { RedCubeCount = 0, GreenCubeCount = 1, BlueCubeCount = 1 }
                    ]
                },
                new()
                {
                    GameId = 3,
                    Rounds =
                    [
                        new() { RedCubeCount = 20, GreenCubeCount = 8, BlueCubeCount = 6 },
                        new() { RedCubeCount = 4, GreenCubeCount = 13, BlueCubeCount = 5 },
                        new() { RedCubeCount = 1, GreenCubeCount = 5, BlueCubeCount = 0 }
                    ]
                },
                new()
                {
                    GameId = 4,
                    Rounds =
                    [
                        new() { RedCubeCount = 3, GreenCubeCount = 1, BlueCubeCount = 6 },
                        new() { RedCubeCount = 6, GreenCubeCount = 3, BlueCubeCount = 0 },
                        new() { RedCubeCount = 14, GreenCubeCount = 3, BlueCubeCount = 15 }
                    ]
                },
                new()
                {
                    GameId = 5,
                    Rounds =
                    [
                        new() { RedCubeCount = 6, GreenCubeCount = 3, BlueCubeCount = 1 },
                        new() { RedCubeCount = 1, GreenCubeCount = 2, BlueCubeCount = 2 }
                    ]
                },
            ],
            Result = 8
        },
        Solution = 2237
    };

    public override Puzzle PartTwo => new()
    {
        Example = new()
        {
            RawInput =
            [
                "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
                "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
                "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
                "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
                "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
            ],
            Input =
            [
                new()
                {
                    GameId = 1,
                    Rounds =
                    [
                        new() { RedCubeCount = 4, GreenCubeCount = 0, BlueCubeCount = 3 },
                        new() { RedCubeCount = 1, GreenCubeCount = 2, BlueCubeCount = 6 },
                        new() { RedCubeCount = 0, GreenCubeCount = 2, BlueCubeCount = 0 }
                    ]
                },
                new()
                {
                    GameId = 2,
                    Rounds =
                    [
                        new() { RedCubeCount = 0, GreenCubeCount = 2, BlueCubeCount = 1 },
                        new() { RedCubeCount = 1, GreenCubeCount = 3, BlueCubeCount = 4 },
                        new() { RedCubeCount = 0, GreenCubeCount = 1, BlueCubeCount = 1 }
                    ]
                },
                new()
                {
                    GameId = 3,
                    Rounds =
                    [
                        new() { RedCubeCount = 20, GreenCubeCount = 8, BlueCubeCount = 6 },
                        new() { RedCubeCount = 4, GreenCubeCount = 13, BlueCubeCount = 5 },
                        new() { RedCubeCount = 1, GreenCubeCount = 5, BlueCubeCount = 0 }
                    ]
                },
                new()
                {
                    GameId = 4,
                    Rounds =
                    [
                        new() { RedCubeCount = 3, GreenCubeCount = 1, BlueCubeCount = 6 },
                        new() { RedCubeCount = 6, GreenCubeCount = 3, BlueCubeCount = 0 },
                        new() { RedCubeCount = 14, GreenCubeCount = 3, BlueCubeCount = 15 }
                    ]
                },
                new()
                {
                    GameId = 5,
                    Rounds =
                    [
                        new() { RedCubeCount = 6, GreenCubeCount = 3, BlueCubeCount = 1 },
                        new() { RedCubeCount = 1, GreenCubeCount = 2, BlueCubeCount = 2 }
                    ]
                },
            ],
            Result = 2286
        },
        Solution = 66681
    };
}
