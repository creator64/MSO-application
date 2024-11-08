using core.Commands;
using core.Parsing;

namespace core.Factories;

public class MoveFactory : CommandFactory
{
    public MoveFactory()
    {
        argumentTypeCheckers = new List<ArgumentTypeChecker>() { new IntOption() };
    }
    
    public override Command buildCommand(List<string> args, List<Command>? commands)
    {
        return new Move(new IntOption().parse(args[0]));
    }
}