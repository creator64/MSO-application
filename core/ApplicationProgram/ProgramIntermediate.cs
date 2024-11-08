using core.Commands;
using core.Errors;
using core.Factories;

namespace core.ApplicationProgram;

public class ProgramIntermediate
{
    private List<string> commandStrings;

    public ProgramIntermediate(List<string> commandStrings)
    {
        this.commandStrings = commandStrings;
    }

    public static CommandFactory getFactory(string command)
    {
        return command switch
        {
            "Move" => new MoveFactory(),
            "Teleport" => new TeleportFactory(),
            "Repeat" => new RepeatFactory(),
            "RepeatUntil" => new RepeatUntilFactory(),
            "Turn" => new TurnFactory(),
            _ => new EmptyFactory()
        };
    }

    public List<ProgramError> validate()
    {
        int currentNestingLevel = 0;
        List<ProgramError> errors = new List<ProgramError>();
        foreach (string commandString in commandStrings)
        {
            List<ProgramError> lineErrors = new List<ProgramError>();

            void SaveErrors()
            {
                foreach (var e in lineErrors) e.line = commandStrings.IndexOf(commandString) + 1;

                errors = errors.Concat(lineErrors).ToList();
            }

            if (commandString.Trim() == "") continue;
            var parts = commandString.Trim().Split(" ");
            CommandFactory f = getFactory(parts[0]);
            if (f.isEmpty())
            {
                lineErrors.Add(new CommandNotFound($"Command {parts[0]} does not exist"));
                SaveErrors();
                continue;
            }
            int nestingLevel = getNestingLevel(commandString);
            if (nestingLevel == -1) lineErrors.Add(new IllegalIndentation("Incorrect indent size found. Found an indent that is not a multiple of 4."));
            
            if (nestingLevel > currentNestingLevel) lineErrors.Add(new IllegalIndentation("Unexpected extra indent"));
            currentNestingLevel = nestingLevel;
            if (f.isCommandContainer) currentNestingLevel++;

            List<ArgumentError> argumentErrors = f.canBuild(parts.ToList().Slice(1, parts.Length - 1));
            lineErrors = lineErrors.Concat(argumentErrors.ConvertAll(a => (ProgramError)a)).ToList();

            SaveErrors();
        }

        return errors;
    }
    
    public ApplicationProgram BuildProgram()
    {
        return new ApplicationProgram(getCommandListRecursive(this.commandStrings, 0));
    }

    private List<Command> getCommandListRecursive(List<String> commandStrings, int targetNestingLevel)
    {
        List<Command> commands = new List<Command>();
        for (int i = 0; i < commandStrings.Count; i++)
        {
            var commandString = commandStrings[i];
            if (commandString.Trim() == "") continue;
            var parts = commandString.Trim().Split(" ");
            var args = parts.ToList().Slice(1, parts.Length - 1);
            CommandFactory f = getFactory(parts[0]);
            int nestingLevel = getNestingLevel(commandString);

            if (f.isCommandContainer)
            {
                var containerCommands = getCommandListRecursive(
                    commandStrings.Slice(i + 1, commandStrings.Count - i - 1), targetNestingLevel + 1);
                commands.Add(f.buildCommand(args, containerCommands));
            }
            else if (nestingLevel < targetNestingLevel) break;
            else if (nestingLevel == targetNestingLevel) commands.Add(f.buildCommand(args, null));
        }

        return commands;
    }

    public static int getNestingLevel(string line)
    {
        int count = 0;
        while (line != "" && line[0] == ' ')
        {
            line = line.Substring(1);
            count++;
        }
        
        if (count % 4 != 0) return -1;
        return count / 4;
    }
}