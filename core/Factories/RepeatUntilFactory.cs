using core.Commands;
using core.Parsing;

namespace core.Factories;

public class RepeatUntilFactory : CommandFactory
{
    public RepeatUntilFactory()
    {
        argumentTypeCheckers = new List<ArgumentTypeChecker>() { new RepeatUntilOption() };
    }
    
    public override Command buildCommand(List<string> args, List<Command>? commands)
    {
        commands ??= new List<Command>();
        return new RepeatUntil(new RepeatUntilOption().parse(args[0]), commands);
    }
}