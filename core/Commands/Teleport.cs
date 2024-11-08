using core.Movement;

namespace core.Commands;

public class Teleport : CommandLeaf
{
    private readonly int x;
    private readonly int y;

    public Teleport(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public override void Execute(Moveable obj)
    {
        obj.setPosition(new Position(x, y));
    }
}