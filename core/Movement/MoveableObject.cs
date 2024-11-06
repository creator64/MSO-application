namespace core.Movement;

public class MoveableObject  : IMoveable
{
    private Position position;
    private Direction direction;
    public MoveableObject(Position position, Direction direction)
    {
        this.position = position;
        this.direction = direction;
    }

    public Direction getDirection()
    {
        return this.direction;
    }

    public Position getPosition()
    {
        return this.position;
    }

    public void setDirection(Direction d)
    {
        this.direction = d;
    }
    
    public void setPosition(Position p)
    {
        this.position = p;
    }

    public void setMovingType(MovingType t)
    {
        return;
    }
}