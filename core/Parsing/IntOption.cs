using core.Errors;

namespace core.Parsing;

public class IntOption : ArgumentParser<int>, ArgumentTypeChecker
{
    public int parse(string argument)
    {
        return int.Parse(argument);
    }

    public ArgumentTypeMismatch? canBuild(string argument)
    {
        bool succes = int.TryParse(argument, out int result);
        if (result < 0) return new ArgumentTypeMismatch($"Negative number {result} is not a valid integer option");
        if (!succes) return new ArgumentTypeMismatch($"Cannot parse integer from {argument}");
        return null;
    }
}