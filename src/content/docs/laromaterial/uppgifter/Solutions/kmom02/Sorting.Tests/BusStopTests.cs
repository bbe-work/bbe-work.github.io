using Sorting;

namespace Sorting.Tests;


[TestFixture]
public class BusStopTests
{
    [SetUp]
    public void Setup()
    {
        BusStop.ResetNrOfComparisons();
    }

    [Test]
    public void CompareTo_ShouldIncreaseComparisonCounter()
    {
        var a = new BusStop(1, "A", "-");
        var b = new BusStop(2, "B", "-");

        a.CompareTo(b);

        Assert.AreEqual(1, BusStop.GetNrOfComparisons());
    }
}
    

