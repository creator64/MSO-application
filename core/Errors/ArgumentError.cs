namespace core.Errors;

public abstract class ArgumentError : ProgramError
{
    public string? commandType;

    protected ArgumentError(string description, string errorType) : base(description, errorType)
    {
    }
}

public class ArgumentSizeMismatch : ArgumentError
{
    private int expectedSize, actualSize;
    public ArgumentSizeMismatch(int expectedSize, int actualSize) : base(createDescription(expectedSize, actualSize), "WRONG ARGUMENT SIZE")
    {
        this.expectedSize = expectedSize;
        this.actualSize = actualSize;
    }

    private static string createDescription(int expectedSize, int actualSize)
    {
        return $"Expected {expectedSize} arguments, but received {actualSize}";
    }
}

public class ArgumentTypeMismatch : ArgumentError
{
    public ArgumentTypeMismatch(string description) : base(description, "WRONG ARGUMENT TYPE")
    {
        
    }
}