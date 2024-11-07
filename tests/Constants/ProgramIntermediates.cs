using core.ApplicationProgram;

namespace tests.Constants;

public static class ProgramIntermediates
{
    public static readonly ProgramIntermediate simple = new (
    new () {
        "Move 10",
        "Turn right",
        "Move 10",
        "Turn right",
        "Move 10",
        "Turn right",
        "Move 10",
        "Turn right",
        "Move 3"
        }
    );
    
    public static readonly ProgramIntermediate medium = new (new ()
    {
        "Repeat 4",
        "    Move 10",
        "    Turn right",
        "Turn left",
        "Move 3"
    });
    
    public static readonly ProgramIntermediate invalidTabAfterContainer = new (new ()
    {
        "Repeat 4",
        "        Move 10",
        "    Turn right",
    });
    
    public static readonly ProgramIntermediate invalidTab = new (new ()
    {
        "Repeat 4",
        "Move 10",
        "    Turn right",
    });
    
    public static readonly ProgramIntermediate unknownCommand = new (new ()
    {
        "Jump 4",
        "Move 10",
        "Turn right",
    });
    
    public static readonly ProgramIntermediate tooMuchArguments = new (new ()
    {
        "Repeat 4 8",
        "    Move 10",
        "    Turn right",
    });

    public static readonly ProgramIntermediate tooLittleArguments = new(new()
    {
        "Move 10",
        "Turn",
    });
    
    public static readonly ProgramIntermediate wrongArgument = new (new ()
    {
        "Repeat 4",
        "    Move string",
        "    Turn right",
    });
}