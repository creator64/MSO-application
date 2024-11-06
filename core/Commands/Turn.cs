using core.Movement;

namespace core.Commands;

public class Turn : CommandLeaf
{
    private readonly TurnDirection direction;
    public Turn(TurnDirection direction)
    {
        this.direction = direction;
    }

    private Direction getNewDirection(Direction old)
    {
        var d = (direction == TurnDirection.LEFT ? -1 : 1);
        int newD = (int)(d + old) % 4;
        if (newD == -1) return Direction.WEST;
        return (Direction)newD;
    }

    public override void Execute(IMoveable obj)
    {
        Direction newDirection = getNewDirection(obj.getDirection());
        obj.setDirection(newDirection);
        var dir = direction == TurnDirection.LEFT ? "left" : "right";
        Console.WriteLine($"Turn {dir}");
    }
}

public enum TurnDirection
{
    LEFT,
    RIGHT
}