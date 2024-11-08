using core.Commands;
using core.Parsing;

namespace core.Factories;

public class RepeatFactory : CommandFactory
{
    public RepeatFactory()
    {
        argumentTypeCheckers = new List<ArgumentTypeChecker>() { new IntOption() };
        isCommandContainer = true;
    }

    public override Command buildCommand(List<string> args, List<Command>? commands)
    {
        commands ??= new List<Command>();
        return new Repeat(new IntOption().parse(args[0]), commands);
    }
}