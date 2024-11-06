using core.Movement;
using tests.Constants;

namespace tests;

public class ExecutionTest
{
    [Fact]
    public void executeSimple()
    {
        IMoveable obj = new MoveableObject(new Position(0, 0), Direction.EAST);
        Programs.simpleProgram.execute(obj);
        Assert.Equal(new Position(3, 0), obj.getPosition());
        Assert.Equal(Direction.EAST, obj.getDirection());
    }
    
    [Fact]
    public void executeMedium()
    {
        IMoveable obj = new MoveableObject(new Position(0, 0), Direction.EAST);
        Programs.mediumProgram.execute(obj);
        Assert.Equal(new Position(0, -3), obj.getPosition());
        Assert.Equal(Direction.NORTH, obj.getDirection());
    }
    
    [Fact]
    public void executeAdvanced()
    {
        IMoveable obj = new MoveableObject(new Position(0, 0), Direction.EAST);
        Programs.advancedProgram.execute(obj);
        Assert.Equal(new Position(3, 10), obj.getPosition());
        Assert.Equal(Direction.SOUTH, obj.getDirection());
    }
}