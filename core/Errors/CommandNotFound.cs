namespace core.Errors;

public class CommandNotFound : ProgramError
{
    public CommandNotFound(string description) : base(description, "COMMAND NOT FOUND")
    {
        
    }
}