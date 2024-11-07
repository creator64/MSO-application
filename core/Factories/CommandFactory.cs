using core.Commands;
using core.Errors;
using core.Parsing;

namespace core.Factories;

public abstract class CommandFactory
{
    public virtual bool isEmpty() => false;
    protected List<ArgumentTypeChecker>? argumentTypeCheckers { get; init; }
    public bool isCommandContainer { get; init; }

    public List<ArgumentError> canBuild(List<string> arguments)
    {
        List<ArgumentError> errors = new List<ArgumentError>();
        if (argumentTypeCheckers == null)
            throw new Exception($"argumentTypeCheckers of class {GetType()} is not set");
        if (arguments.Count != argumentTypeCheckers.Count) 
            errors.Add(new ArgumentSizeMismatch(argumentTypeCheckers.Count, arguments.Count));
        
        for (int i = 0; i < argumentTypeCheckers.Count; i++)
        {
            if (i >= arguments.Count) break;
            var error = argumentTypeCheckers[i].canBuild(arguments[i]);
            if (error != null) errors.Add(error);
        }
        
        return errors;
    }

    public abstract Command buildCommand(List<string> args, List<Command>? commands);
}