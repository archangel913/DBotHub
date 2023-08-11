using DBotHub.Domain;

namespace DBotHub.TestDomain;
public class ExperimentTest
{
    [Fact]
    public void TestExperiment()
    {
        var experiment = new Experiment();
        Assert.Equal("experiment", experiment.DoExperiment());
    }
}