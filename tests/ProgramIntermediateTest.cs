using core.Factories;
using core.ApplicationProgram;

namespace tests;

public class ProgramIntermediateTest
{
    [Theory]
    [InlineData("Move", typeof(MoveFactory))]
    [InlineData("Teleport", typeof(TeleportFactory))]
    [InlineData("Repeat", typeof(RepeatFactory))]
    [InlineData("RepeatUntil", typeof(RepeatUntilFactory))]
    [InlineData("Turn", typeof(TurnFactory))]
    [InlineData("turn", typeof(EmptyFactory))]
    [InlineData("does not exist", typeof(EmptyFactory))]
    public void returnRightFactory(string command, Type type)
    {
        CommandFactory f = new ProgramIntermediate().getFactory(command);
        Assert.True(f.GetType() == type);
    }

    public void validationTest()
    {
        
    }
}