using core.Errors;

namespace core.Parsing;

public interface ArgumentTypeChecker
{
    public ArgumentTypeMismatch canBuild(string argument);
}