using core.Errors;

namespace core.Parsing;

public class IntOption : ArgumentParser<int>, ArgumentTypeChecker
{
    public int parse(string argument)
    {
        return 0;
    }

    public ArgumentTypeMismatch canBuild(string argument)
    {
        return null;
    }
}