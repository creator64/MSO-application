using core.Commands;
using core.Errors;

namespace core.Parsing;

public class TurnOption : ArgumentParser<TurnDirection>, ArgumentTypeChecker
{
    public TurnDirection parse(string argument)
    {
        throw new NotImplementedException();
    }

    public ArgumentTypeMismatch canBuild(string argument)
    {
        throw new NotImplementedException();
    }
}