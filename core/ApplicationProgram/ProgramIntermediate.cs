using core.Errors;
using core.Factories;

namespace core.ApplicationProgram;

public class ProgramIntermediate
{
    private List<string> commandStrings;

    public ProgramIntermediate(List<string> commandStrings)
    {
        this.commandStrings = commandStrings;
    }

    public static CommandFactory getFactory(string command)
    {
        return command switch
        {
            "Move" => new MoveFactory(),
            "Teleport" => new TeleportFactory(),
            "Repeat" => new RepeatFactory(),
            "RepeatUntil" => new RepeatUntilFactory(),
            "Turn" => new TurnFactory(),
            _ => new EmptyFactory()
        };
    }

    public List<ProgramError> validate()
    {
        return null;
    }

    public ApplicationProgram BuildProgram()
    {
        return null;
    }
}