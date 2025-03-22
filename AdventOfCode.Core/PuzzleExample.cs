namespace AdventOfCode.Core;

public record PuzzleExample<TInput, TResult>
{
    public required IEnumerable<string> RawInput { get; set; }

    public required TInput Input { get; set; }

    public required TResult Result { get; set; }
}
