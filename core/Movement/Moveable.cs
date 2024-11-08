namespace core.Movement;

public abstract class Moveable
{
    protected Position position;
    protected Direction direction;
    protected MovingType movingType;
    
    public Position getPosition()
    {
        return position;
    }

    public Direction getDirection()
    {
        return direction;
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
        this.movingType = t;
    }
}