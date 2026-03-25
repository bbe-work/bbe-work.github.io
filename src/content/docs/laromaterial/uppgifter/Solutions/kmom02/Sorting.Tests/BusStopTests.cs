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

    [Test]
public void CompareTo_MultipleCalls_ShouldCountAllComparisons()
{
    var a = new BusStop(1, "A", "-");
    var b = new BusStop(2, "B");
    var c = new BusStop(3, "C");

    a.CompareTo(b);
    b.CompareTo(c);
    a.CompareTo(c);

    Assert.AreEqual(3, BusStop.GetNrOfComparisons());
}
}
    

