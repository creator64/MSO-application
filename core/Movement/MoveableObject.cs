namespace core.Movement;

public class MoveableObject  : Moveable
{
    public MoveableObject(Position position, Direction direction)
    {
        this.position = position;
        this.direction = direction;
    }
}