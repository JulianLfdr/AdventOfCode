namespace AdventOfCode.Core;

public abstract class PuzzleSolver<TInput, TResult>
{
    private readonly Lazy<TInput> _puzzleInput;

    protected abstract Puzzle<TInput, TResult> PartOne { get; }

    protected abstract Puzzle<TInput, TResult> PartTwo { get; }

    protected PuzzleSolver(string day)
    {
        _puzzleInput = new Lazy<TInput>(() =>
        {
            var puzzleInputLines = File.ReadAllLines($"./{day}/input.txt");
            return ParseInput(puzzleInputLines);
        });
    }

    protected abstract TResult SolvePartOne(TInput input);

    protected abstract TResult SolvePartTwo(TInput input);

    protected abstract TInput ParseInput(IEnumerable<string> puzzleInput);

    #region Part #1
    [Fact(DisplayName = "1.1 - Parsing")]
    public void PartOneParsingTest()
    {
        // Arrange
        var input = PartOne.Example.RawInput;

        // Act
        var result = ParseInput(input);

        // Assert
        result.Should().BeEquivalentTo(PartOne.Example.Input);
    }

    [Fact(DisplayName = "1.2 - Example")]
    public void PartOneExampleTest()
    {
        // Arrange
        var input = PartOne.Example.Input;

        // Act
        var result = SolvePartOne(input);

        // Assert
        result.Should().Be(PartOne.Example.Result);
    }

    [Fact(DisplayName = "1.3 - Solution")]
    public void PartOneSolutionTest()
    {
        // Arrange
        var input = _puzzleInput;

        // Act
        var result = SolvePartOne(input.Value);

        // Assert
        result.Should().Be(PartOne.Solution);
    }
    #endregion

    #region Part #2
    [Fact(DisplayName = "2.1 - Parsing")]
    public void PartTwoParsingTest()
    {
        // Arrange
        var input = PartTwo.Example.RawInput;

        // Act
        var result = ParseInput(input);

        // Assert
        result.Should().BeEquivalentTo(PartTwo.Example.Input);
    }

    [Fact(DisplayName = "2.2 - Example")]
    public void PartTwoExampleTest()
    {
        // Arrange
        var input = PartTwo.Example.Input;

        // Act
        var result = SolvePartTwo(input);

        // Assert
        result.Should().Be(PartTwo.Example.Result);
    }

    [Fact(DisplayName = "2.3 - Solution")]
    public void PartTwoSolutionTest()
    {
        // Arrange
        var input = _puzzleInput;

        // Act
        var result = SolvePartTwo(input.Value);

        // Assert
        result.Should().Be(PartTwo.Solution);
    }
    #endregion
}
