using core.ApplicationProgram;
using tests.Constants;

namespace tests;

public class MetricsTest
{
    [Fact]
    public void simpleProgramMetrics()
    {
        Metrics metrics = new(9, 0, 0);
        Assert.Equal(metrics, Programs.simpleProgram.calculateMetrics());
    }
    
    [Fact]
    public void mediumProgramMetrics()
    {
        Metrics metrics = new(5, 1, 1);
        Assert.Equal(metrics, Programs.mediumProgram.calculateMetrics());
    }
    
    [Fact]
    public void advancedProgramMetrics()
    {
        Metrics metrics = new(11, 2, 2);
        Assert.Equal(metrics, Programs.advancedProgram.calculateMetrics());
    } 
}