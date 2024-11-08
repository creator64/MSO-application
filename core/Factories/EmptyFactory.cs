using core.Commands;

namespace core.Factories;

public class EmptyFactory : CommandFactory
{
    public override bool isEmpty() => true;

    public override Command buildCommand(List<string> args, List<Command>? commands)
    {
        throw new Exception("buildCommand() called on EmptyFactory");
    }
}