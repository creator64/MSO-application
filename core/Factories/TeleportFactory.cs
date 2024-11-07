using core.Commands;
using core.Parsing;

namespace core.Factories;

public class TeleportFactory : CommandFactory
{
    public TeleportFactory()
    {
        argumentTypeCheckers = new List<ArgumentTypeChecker>() { new IntOption(), new IntOption() };
    }
    
    public override Command buildCommand(List<string> args, List<Command>? commands)
    {
        return new Teleport(new IntOption().parse(args[0]), new IntOption().parse(args[1]));
    }
}