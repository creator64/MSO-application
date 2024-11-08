using core.Commands;
using core.Errors;

namespace core.Parsing;

public class TurnOption : ArgumentParser<TurnDirection>, ArgumentTypeChecker
{
    public TurnDirection parse(string argument)
    {
        String mappedArgument = argument == "left" ? "LEFT" : argument == "right" ? "RIGHT" : argument;
        return Enum.Parse<TurnDirection>(mappedArgument);
    }

    public ArgumentTypeMismatch? canBuild(string argument)
    {
        ArgumentTypeMismatch error = new ($"{argument} is not a valid option for turn. Must be either left or right");

        if (int.TryParse(argument, out _)) return error;
        
        String mappedArgument = argument == "left" ? "LEFT" : argument == "right" ? "RIGHT" : argument;
        bool succes = Enum.TryParse(mappedArgument, out TurnDirection _);
        if (!succes) return error;
        
        return null;
    }
}