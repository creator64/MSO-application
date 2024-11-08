using core.Movement;

namespace core.Commands;

public class Repeat : CommandContainer
{
    private readonly int amount;

    public Repeat(int amount, List<Command> commands) : base(commands)
    {
        this.amount = amount;
    }

    public override int amountOfRepeats()
    {
        return base.amountOfRepeats() + 1;
    }

    public override void Execute(Moveable obj)
    {
        for (int i = 0; i < amount; i++) 
            foreach (Command command in children) command.Execute(obj);
    }
}