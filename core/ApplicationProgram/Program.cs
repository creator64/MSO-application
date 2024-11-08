using core.Movement;
using core.Commands;
using core.PracticeExercises;

namespace core.ApplicationProgram;

public class ApplicationProgram
{
    private readonly List<Command> commands;

    private PracticeExercises.Exercise exercise;
    public static bool isExercise;

    public ApplicationProgram(List<Command> commands)
    {
        this.commands = commands;

        isExercise = false;

        Grid.Grid grid1 = new Grid.Grid("Level1.txt");
        Grid.Grid grid2 = new Grid.Grid("Level2.txt");
        Grid.Grid grid3 = new Grid.Grid("Level3.txt");

        exercise = new Exercise(grid1);
    }

    public void execute(IMoveable moveable)
    {
        foreach (Command command in commands)
        {
            command.Execute(moveable);


            if (!isExercise) continue; //if we are running an exercise the execute method should do some extra checking regarding the exercise

            try
            {
                exercise.CheckPosition();
            }
            catch (OutOfBoundsException)
            {
                throw;
            }
            catch (BlockedCellException)
            {
                throw;
            }
        }
        if (isExercise) exercise.CheckSuccess();
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