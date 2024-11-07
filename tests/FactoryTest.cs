using core.Commands;
using core.Errors;
using core.Factories;

namespace tests;

public class FactoryTest
{
    [Fact]
    public void emptyFactoryIsEmpty()
    {
        Assert.True(new EmptyFactory().isEmpty());
    }

    [Fact]
    public void testLeafBuildCommand()
    {
        List<Tuple<CommandFactory, string[], Command>> data = new List<Tuple<CommandFactory, string[], Command>>()
        {
            new (new MoveFactory(), new [] {"10"}, new Move(10)),
            new (new TurnFactory(), new [] {"left"}, new Turn(TurnDirection.LEFT)),
            new (new TeleportFactory(), new [] {"10", "20"}, new Teleport(10, 20))
        };
        Assert.All(data, tuple => Assert.Equivalent(tuple.Item3, tuple.Item1.buildCommand(tuple.Item2.ToList())));
        
    }
    
    [Fact]
    public void testContainerBuildCommand()
    {
        List<Command> commandList = new List<Command>() { new Move(10), new Teleport(10, 20) };
        
        List<Tuple<CommandFactory, string[], Command>> data = new List<Tuple<CommandFactory, string[], Command>>()
        {
            new (new RepeatFactory(), new [] {"10"}, new Repeat(10, commandList)),
            new (new RepeatUntilFactory(), new [] {"GridEdge"}, new RepeatUntil(RepeatUntilCondition.GridEdge, commandList)),
        };
        
        Assert.All(data, tuple => Assert.Equivalent(tuple.Item3, tuple.Item1.buildCommand(tuple.Item2.ToList())));
    }

    [Theory]
    [InlineData(new string[] { "10", "20", "30" }, new Type[] {typeof(ArgumentSizeMismatch)})]
    [InlineData(new string[] {}, new Type[] {typeof(ArgumentSizeMismatch)})]
    [InlineData(new string[] { "10.0" }, new Type[] {})]
    [InlineData(new string[] { "10.0", "20" }, new Type[] {typeof(ArgumentTypeMismatch), typeof(ArgumentSizeMismatch)})]
    public void repeatFactoryTest(string[] args, Type[] expectedErrors)
    {
        testFactoryCanBuild(new RepeatFactory(), args, expectedErrors);
    }
    
    [Theory]
    [InlineData(new string[] { "10", "20", "30" }, new Type[] {typeof(ArgumentSizeMismatch)})]
    [InlineData(new string[] {}, new Type[] {typeof(ArgumentSizeMismatch)})]
    [InlineData(new string[] { "10.0" }, new Type[] {})]
    [InlineData(new string[] { "10.0", "20" }, new Type[] {typeof(ArgumentTypeMismatch), typeof(ArgumentSizeMismatch)})]
    public void moveFactoryTest(string[] args, Type[] expectedErrors)
    {
        testFactoryCanBuild(new MoveFactory(), args, expectedErrors);
    }
    
    [Theory]
    [InlineData(new string[] { "WallAhead" }, new Type[] {})]
    [InlineData(new string[] { "GridEdge" }, new Type[] {})]
    [InlineData(new string[] {"WallAhead", "GridEdge"}, new Type[] {typeof(ArgumentSizeMismatch)})]
    [InlineData(new string[] { "WallAhead", "20" }, new Type[] {typeof(ArgumentSizeMismatch)})]
    [InlineData(new string[] { "20", "WallAhead" }, new Type[] {typeof(ArgumentSizeMismatch), typeof(ArgumentTypeMismatch)})]
    public void repeatUntilFactoryTest(string[] args, Type[] expectedErrors)
    {
        testFactoryCanBuild(new RepeatUntilFactory(), args, expectedErrors);
    }

    [Theory]
    [InlineData(new string[] { "left" }, new Type[] {})]
    [InlineData(new string[] { "right" }, new Type[] {})]
    [InlineData(new string[] {"left", "right"}, new Type[] {typeof(ArgumentSizeMismatch)})]
    [InlineData(new string[] {"20"}, new Type[] {typeof(ArgumentTypeMismatch)})]
    public void turnFactoryTest(string[] args, Type[] expectedErrors)
    {
        testFactoryCanBuild(new TurnFactory(), args, expectedErrors);
    }
    
    [Theory]
    [InlineData(new string[] { "20", "40" }, new Type[] {})]
    [InlineData(new string[] { "text" }, new Type[] {typeof(ArgumentTypeMismatch)})]
    [InlineData(new string[] {"left", "right"}, new Type[] {typeof(ArgumentSizeMismatch), typeof(ArgumentTypeMismatch)})]
    [InlineData(new string[] {"20"}, new Type[] {typeof(ArgumentSizeMismatch)})]
    public void teleportFactoryTest(string[] args, Type[] expectedErrors)
    {
        testFactoryCanBuild(new TeleportFactory(), args, expectedErrors);
    }

    private void testFactoryCanBuild(CommandFactory f, string[] args, Type[] expectedErrors)
    {
        var mapToTypes = ErrorUtils.mapToTypes;
        var errors = f.canBuild(args.ToList()).ConvertAll(e => (ProgramError)e);
        Assert.Equivalent(expectedErrors, mapToTypes(errors));
    }
}