namespace AdventOfCode.Core;

public record Puzzle<TInput, TResult>
{
    public required PuzzleExample<TInput, TResult> Example { get; set; }

    public required TResult Solution { get; set; }
}
