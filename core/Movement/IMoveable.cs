namespace core.Movement;

public interface IMoveable
{
    Position getPosition();
    Direction getDirection();
    void setDirection(Direction direction);
    void setPosition(Position p);
    void setMovingType(MovingType t);
}