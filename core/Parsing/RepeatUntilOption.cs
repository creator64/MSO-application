using core.Commands;
using core.Errors;

namespace core.Parsing;

public class RepeatUntilOption : ArgumentParser<RepeatUntilCondition>, ArgumentTypeChecker
{
    public RepeatUntilCondition parse(string argument)
    {
        return Enum.Parse<RepeatUntilCondition>(argument);
    }

    public ArgumentTypeMismatch? canBuild(string argument)
    {
        ArgumentTypeMismatch error = new ($"{argument} is not a valid option for repeatUntil. Must be either GridEdge or WallAhead");

        if (int.TryParse(argument, out _)) return error;
        bool succes = Enum.TryParse(argument, out RepeatUntilCondition _);
        if (!succes) return error;
        
        return null;
    }
}