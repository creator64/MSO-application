using core.Commands;
using core.Parsing;

namespace core.Factories;

public class TurnFactory : CommandFactory
{
    public TurnFactory()
    {
        argumentTypeCheckers = new List<ArgumentTypeChecker>() { new TurnOption() };
    }
    
    public override Command buildCommand(List<string> args, List<Command>? commands)
    {
        return new Turn(new TurnOption().parse(args[0]));
    }
}