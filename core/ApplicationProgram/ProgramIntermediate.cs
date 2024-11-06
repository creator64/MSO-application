using core.Factories;

namespace core.ApplicationProgram;

public class ProgramIntermediate
{
    public CommandFactory getFactory(string command)
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
}