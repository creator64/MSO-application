using core.Commands;
using core.Errors;

namespace core.Factories;

public abstract class CommandFactory
{
    public virtual bool isEmpty() => false;

    public List<ArgumentError> canBuild(List<string> arguments)
    {
        return null;
    }

    public Command buildCommand(List<string> toList)
    {
        return null;
    }
}