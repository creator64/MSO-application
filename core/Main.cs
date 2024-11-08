// See https://aka.ms/new-console-template for more information


using core;
using core.ApplicationProgram;
using core.Movement;

// IMoveable obj = new MoveableObject(new Position(0, 0), Direction.EAST);
// Programs.advancedProgram.execute(obj);

string baseDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;

// TextFileParser parser = new (Path.Combine(baseDir, "tests/source/simple.txt"));
// parser.Parse();

var lines = File.ReadAllLines(Path.Combine(baseDir, "tests/source/medium.txt")).ToList();

// foreach (string line in lines)
// {
//     Console.WriteLine(line[0] == ' ');
// }


// ProgramIntermediate advanced = new(new()
// {
//     "Move 5",
//     "Turn left",
//     "Turn left",
//     "Move 3",
//     "  ",
//     "Turn right",
//     "Repeat 3",
//     "    Move 1",
//     "    Turn right",
//     "    Repeat 5",
//     "        Move 2",
//     "Turn left"
// });
//
// advanced.BuildProgram().execute(new MoveableObject(new Position(0, 0), Direction.EAST));

// Console.WriteLine(int.TryParse("20.5", out _));


