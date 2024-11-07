namespace core.Errors;

public abstract class ProgramError
{
    private readonly string errorName;
    private readonly string description;
    public readonly int? line;

    protected ProgramError(string description, string errorName)
    {
        this.errorName = errorName;
        this.description = description;
    }

    public override string ToString()
    {
        String lineText = line != null ? $"on line {line}:" : "";
        return $"[{errorName}] {lineText} {description}";
    }
}