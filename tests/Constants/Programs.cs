using core.Commands;
using core.ApplicationProgram;

namespace tests.Constants;

public static class Programs
{
    public static readonly ApplicationProgram simpleProgram = new (new List<Command>()
    {
        new Move(10), new Turn(TurnDirection.RIGHT),
        new Move(10), new Turn(TurnDirection.RIGHT),
        new Move(10), new Turn(TurnDirection.RIGHT),
        new Move(10), new Turn(TurnDirection.RIGHT),
        new Move(3)
    });

    public static readonly ApplicationProgram mediumProgram = new (new()
    {
        new Repeat(4, new List<Command>
        {
            new Move(10), new Turn(TurnDirection.RIGHT),
        }),
        new Turn(TurnDirection.LEFT), 
        new Move(3)
    });

    public static readonly ApplicationProgram advancedProgram = new (new()
    {
        new Move(5),
        new Turn(TurnDirection.LEFT),
        new Turn(TurnDirection.LEFT),
        new Move(3),
        new Turn(TurnDirection.RIGHT),
        new Repeat(3, new()
        {
            new Move(1),
            new Turn(TurnDirection.RIGHT),
            new Repeat(5, new()
            {
                new Move(2)
            })
        }),
        new Turn(TurnDirection.LEFT)
    });
}