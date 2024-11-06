using core.Movement;

namespace core.Commands;

public interface Command
{
    public void Execute(IMoveable obj);
    public int commandCount();
    public int maxNestingLevel();
    public int amountOfRepeats();
}

public abstract class CommandContainer : Command
{
    protected readonly List<Command> children;

    protected CommandContainer(List<Command> children)
    {
        this.children = children;
    }
    
    public abstract void Execute(IMoveable obj);
    public int commandCount()
    {
        return 1 + children.Sum(c => c.commandCount());
    }

    public int maxNestingLevel()
    {
        return 1 + children.Max(c => c.maxNestingLevel());
    }

    public virtual int amountOfRepeats()
    {
        return 0 + children.Sum(c => c.amountOfRepeats());
    }
}

public abstract class CommandLeaf : Command
{
    public abstract void Execute(IMoveable obj);
    
    public int commandCount() { return 1; }
    public int maxNestingLevel() { return 0; }
    public int amountOfRepeats() { return 0; }
}