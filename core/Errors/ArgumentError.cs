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
    public ArgumentSizeMismatch(string description) : base(description, "WRONG ARGUMENT SIZE")
    {
        
    }
}

public class ArgumentTypeMismatch : ArgumentError
{
    public ArgumentTypeMismatch(string description) : base(description, "WRONG ARGUMENT TYPE")
    {
        
    }
}