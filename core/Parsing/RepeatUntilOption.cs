using core.Commands;
using core.Errors;

namespace core.Parsing;

public class RepeatUntilOption : ArgumentParser<RepeatUntilCondition>, ArgumentTypeChecker
{
    public RepeatUntilCondition parse(string argument)
    {
        throw new NotImplementedException();
    }

    public ArgumentTypeMismatch canBuild(string argument)
    {
        throw new NotImplementedException();
    }
}