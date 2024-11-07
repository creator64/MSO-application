namespace core.Errors;

public class IllegalIndentation : ProgramError
{
    public IllegalIndentation(string description) : base(description, "INCORRECT INDENTATION")
    {
        
    }
}