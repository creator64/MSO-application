using core.Movement;
using core.Commands;

namespace core.ApplicationProgram;

public class ApplicationProgram
{
    private readonly List<Command> commands;
    
    public ApplicationProgram(List<Command> commands)
    {
        this.commands = commands;
    }

    public void execute(IMoveable moveable)
    {
        foreach (Command command in commands)
        {
            command.Execute(moveable);
        }
    }

    public Metrics calculateMetrics()
    {
        int commandCount = commands.Sum(c => c.commandCount());
        int amountOfRepeats = commands.Sum(c => c.amountOfRepeats());
        int maxNestingLevel = commands.Max(c => c.maxNestingLevel());
        return new Metrics(commandCount, amountOfRepeats, maxNestingLevel);
    }
}

public readonly struct Metrics
{
    public readonly int commandCount;
    public readonly int amountOfRepeats;
    public readonly int maxNestingLevel;

    public Metrics(int commandCount, int amountOfRepeats, int maxNestingLevel)
    {
        this.commandCount = commandCount;
        this.amountOfRepeats = amountOfRepeats;
        this.maxNestingLevel = maxNestingLevel;
    }

    public override string ToString()
    {
        return $"amount of commands: {commandCount}\n amount of repeats: {amountOfRepeats}\n maximum nesting level: {maxNestingLevel}";
    }
}