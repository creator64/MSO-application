namespace core.Movement;

public struct Position
{
    private int x;
    private int y;

    public Position(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Position move(int xSteps, int ySteps)
    {
        return new Position(x + xSteps, y + ySteps);
    }

    public override string ToString()
    {
        return $"Position<x: {x}, y: {y}>";
    }
}