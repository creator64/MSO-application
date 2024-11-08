using core.Movement;

namespace core.Commands;

public class Move : CommandLeaf
{
    private readonly int steps;
    public Move(int steps)
    {
        this.steps = steps;
    }

    private (int, int) getSteps(Direction d)
    {
        int stepX = 0, stepY = 0;
        switch (d)
        {
            case Direction.NORTH: stepY = -steps; break;
            case Direction.EAST: stepX = steps; break;
            case Direction.SOUTH: stepY = steps; break;
            case Direction.WEST: stepX = -steps; break;
        }
        return (stepX, stepY);
    }

    public override void Execute(Moveable obj)
    {
        (int xSteps, int ySteps) = this.getSteps(obj.getDirection());
        obj.setPosition(obj.getPosition().move(xSteps, ySteps));
        Console.WriteLine($"Move {steps}");
    }
}