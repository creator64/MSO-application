using core.Commands;
using core.Errors;
using core.Parsing;

namespace tests;

public class ParserTest
{
    [Fact]
    public void IntTest()
    {
        List<String> validArguments = new List<string>() { "20", "0" };
        List<String> invalidArguments = new List<string>() { "20.0", "nonsense", "2-0", "-6" };
        testTypeCheckerCanBuild(new IntOption(), validArguments, invalidArguments);
        Assert.Equal(new IntOption().parse("3"), 3);
    }
    
    [Fact]
    public void TurnOptionTest()
    {
        List<String> validArguments = new List<string>() { "left", "right" };
        List<String> invalidArguments = new List<string>() { "front", "back", "20", "WallAhead", "Left", "Right" };
        testTypeCheckerCanBuild(new TurnOption(), validArguments, invalidArguments);
        Assert.Equal(new TurnOption().parse("left"), TurnDirection.LEFT);
    }
    
    [Fact]
    public void RepeatUntilOptionTest()
    {
        List<String> validArguments = new List<string>() { "WallAhead", "GridEdge" };
        List<String> invalidArguments = new List<string>() { "wallahead", "gridedge", "20", "left", "bla" };
        testTypeCheckerCanBuild(new RepeatUntilOption(), validArguments, invalidArguments);
        Assert.Equal(new RepeatUntilOption().parse("WallAhead"), RepeatUntilCondition.WallAhead);
    }

    private void testTypeCheckerCanBuild(ArgumentTypeChecker checker, List<String> validArguments,
        List<String> invalidArguments)
    {
        Assert.All(invalidArguments, arg => Assert.IsType(typeof(ArgumentTypeMismatch), checker.canBuild(arg)));
        Assert.All(validArguments, arg => Assert.Null(checker.canBuild(arg)));
    }
}