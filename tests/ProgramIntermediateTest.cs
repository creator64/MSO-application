using core.Factories;
using core.ApplicationProgram;
using core.Errors;
using tests.Constants;

namespace tests;

public class ProgramIntermediateTest
{
    [Theory]
    [InlineData("Move", typeof(MoveFactory))]
    [InlineData("Teleport", typeof(TeleportFactory))]
    [InlineData("Repeat", typeof(RepeatFactory))]
    [InlineData("RepeatUntil", typeof(RepeatUntilFactory))]
    [InlineData("Turn", typeof(TurnFactory))]
    [InlineData("turn", typeof(EmptyFactory))]
    [InlineData("Doesnotexist", typeof(EmptyFactory))]
    public void returnRightFactory(string command, Type type)
    {
        CommandFactory f = ProgramIntermediate.getFactory(command);
        Assert.True(f.GetType() == type);
    }
    
    [Fact]
    public void validationTest()
    {
        var mapToTypes = ErrorUtils.mapToTypes;
        
        Assert.Empty(ProgramIntermediates.simple.validate());
        Assert.Empty(ProgramIntermediates.medium.validate());
        
        Assert.Contains(typeof(ArgumentSizeMismatch),
            mapToTypes(
                ProgramIntermediates.tooMuchArguments.validate()
                ));

        Assert.Contains(typeof(ArgumentSizeMismatch),
            mapToTypes(
                ProgramIntermediates.tooLittleArguments.validate()
                ));

        Assert.Contains(typeof(CommandNotFound),
            mapToTypes(
                ProgramIntermediates.unknownCommand.validate()
                ));
        
        Assert.Contains(typeof(IllegalIndentation),
            mapToTypes(
                ProgramIntermediates.invalidTabAfterContainer.validate()
            ));
        
        Assert.Contains(typeof(IllegalIndentation),
            mapToTypes(
                ProgramIntermediates.invalidTab.validate()
            ));
        
        Assert.Contains(typeof(ArgumentTypeMismatch),
            mapToTypes(
                ProgramIntermediates.wrongArgument.validate()
            ));

        var errors = mapToTypes(ProgramIntermediates.unknownCommand.validate())
            .Concat(mapToTypes(ProgramIntermediates.invalidTab.validate())).ToList();
        var expectedErrors = new List<Type>() { typeof(CommandNotFound), typeof(IllegalIndentation) };
        Assert.Equivalent(expectedErrors, errors);
    }

    [Fact]
    public void buildTest()
    {
        Assert.Equivalent(Programs.simpleProgram, ProgramIntermediates.simple.BuildProgram());
        Assert.Equivalent(Programs.mediumProgram, ProgramIntermediates.medium.BuildProgram());
        Assert.Equivalent(Programs.advancedProgram, ProgramIntermediates.advanced.BuildProgram());
    }

    [Theory]
    [InlineData("    Nest1", 1)]
    [InlineData("Nest0", 0)]
    [InlineData("        Nest2", 2)]
    [InlineData("        Nest2 with other objects", 2)]
    [InlineData("       NestInvalid", -1)]
    [InlineData("      NestInvalid2", -1)]
    public void testNestingLevel(string line, int level)
    {
        Assert.Equal(ProgramIntermediate.getNestingLevel(line), level);
    }
}

public static class ErrorUtils
{
    public static List<Type> mapToTypes(List<ProgramError> errors)
    {
        return errors.Select(e => e.GetType()).ToList();
    }
}