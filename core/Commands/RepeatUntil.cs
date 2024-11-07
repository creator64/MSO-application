using core.Movement;

namespace core.Commands;

public class RepeatUntil : CommandContainer
{
    private RepeatUntilCondition condition;
    
    public RepeatUntil(RepeatUntilCondition c, List<Command> children) : base(children)
    {
        this.condition = c;
    }

    public override void Execute(IMoveable obj)
    {
        
    }
}

public enum RepeatUntilCondition
{
    WallAhead,
    GridEdge
}