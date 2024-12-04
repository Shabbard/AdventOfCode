namespace Day2;

public record Report(List<int> Levels, bool Safe)
{
    public List<int> Levels { get; } = Levels;

    public bool Safe { get; } = Safe;
}
