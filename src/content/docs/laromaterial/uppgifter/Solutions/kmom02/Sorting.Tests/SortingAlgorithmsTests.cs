using System;
using System.IO;
using System.Linq;
using Xunit;
using Sorting;

namespace Sorting.Tests;

public class SortingAlgorithmsTests
{
    private static BusStop[] BuildBusStops(string[] names)
    {
        return names.Select((name, idx) => new BusStop(idx, name)).ToArray();
    }

    private static bool IsSorted<T>(T[] arr) where T : IComparable<T>
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i].CompareTo(arr[i + 1]) > 0)
                return false;
        }
        return true;
    }

    private static BusStop[] ReadStopsFromFile(string filename, int nrOf = -1)
    {
        string path = Path.Combine(AppContext.BaseDirectory, filename);
        if (!File.Exists(path))
            throw new FileNotFoundException("Could not find stops.txt", path);

        string[] stops = File.ReadAllLines(path);
        if (nrOf == -1 || nrOf > stops.Length)
            nrOf = stops.Length - 1;

        BusStop busStops = new BusStop[nrOf];
        for (int i = 0; i < nrOf; i++)
        {
            string[] parts = stops[i + 1].Split(",");
            busStops[i] = new BusStop(int.Parse(parts[0].Substring(8)), parts[1], "-");
        }

        return busStops;
    }

    [Fact]
    public void Insertionsort_Correctness()
    {
        var stringInput = new[] { "E", "C", "A", "D", "B" };
        SortingAlgorithms.Insertionsort(stringInput, stringInput.Length);
        Assert.True(IsSorted(stringInput));

        var intInput = new[] { 5, 3, 1, 4, 2 };
        SortingAlgorithms.Insertionsort(intInput, intInput.Length);
        Assert.True(IsSorted(intInput));

        var busStops = BuildBusStops(new[] { "E", "C", "A", "D", "B" });
        SortingAlgorithms.Insertionsort(busStops, busStops.Length);
        Assert.True(IsSorted(busStops));
    }

    [Fact]
    public void Quicksort_Correctness()
    {
        var stringInput = new[] { "E", "C", "A", "D", "B" };
        SortingAlgorithms.Quicksort(stringInput, 0, stringInput.Length - 1);
        Assert.True(IsSorted(stringInput));

        var intInput = new[] { 5, 3, 1, 4, 2 };
        SortingAlgorithms.Quicksort(intInput, 0, intInput.Length - 1);
        Assert.True(IsSorted(intInput));

        var busStops = BuildBusStops(new[] { "E", "C", "A", "D", "B" });
        SortingAlgorithms.Quicksort(busStops, 0, busStops.Length - 1);
        Assert.True(IsSorted(busStops));
    }

    [Fact]
    public void QuicksortUsingMedianOfThree_Correctness()
    {
        var stringInput = new[] { "E", "C", "A", "D", "B" };
        SortingAlgorithms.QuicksortUsingMedianOfThree(stringInput, 0, stringInput.Length - 1);
        Assert.True(IsSorted(stringInput));

        var intInput = new[] { 5, 3, 1, 4, 2 };
        SortingAlgorithms.QuicksortUsingMedianOfThree(intInput, 0, intInput.Length - 1);
        Assert.True(IsSorted(intInput));

        var busStops = BuildBusStops(new[] { "E", "C", "A", "D", "B" });
        SortingAlgorithms.QuicksortUsingMedianOfThree(busStops, 0, busStops.Length - 1);
        Assert.True(IsSorted(busStops));
    }

    [Fact]
    public void QuicksortUsingInsertionsort_Correctness()
    {
        var stringInput = new[] { "E", "C", "A", "D", "B" };
        SortingAlgorithms.QuicksortUsingInsertionsort(stringInput, 0, stringInput.Length - 1);
        Assert.True(IsSorted(stringInput));

        var intInput = new[] { 5, 3, 1, 4, 2 };
        SortingAlgorithms.QuicksortUsingInsertionsort(intInput, 0, intInput.Length - 1);
        Assert.True(IsSorted(intInput));

        var busStops = BuildBusStops(new[] { "E", "C", "A", "D", "B" });
        SortingAlgorithms.QuicksortUsingInsertionsort(busStops, 0, busStops.Length - 1);
        Assert.True(IsSorted(busStops));
    }

/*
    [Fact]
    public void Sort_OnAlreadySortedInput_IsStable()
    {
        var stringInput = new[] { "A", "B", "C", "D" };
        SortingAlgorithms.Quicksort(stringInput, 0, stringInput.Length - 1);
        Assert.True(IsSorted(stringInput));

        var intInput = new[] { 1, 2, 3, 4 };
        SortingAlgorithms.Quicksort(intInput, 0, intInput.Length - 1);
        Assert.True(IsSorted(intInput));

        var busStops = BuildBusStops(new[] { "A", "B", "C", "D" });
        BusStop.ResetNrOfComparisons();
        SortingAlgorithms.Quicksort(busStops, 0, busStops.Length - 1);
        int sortingComparisons = BusStop.GetNrOfComparisons();
        Assert.True(IsSorted(busStops));
        Assert.Equal(6, sortingComparisons);
    }

    [Fact]
    public void Quicksort_LargeBusStopsFromFile_Correctness()
    {
        var busStops = ReadStopsFromFile("stops.txt", 100);
        Assert.True(busStops.Length == 100);

        SortingAlgorithms.Quicksort(busStops, 0, busStops.Length - 1);
        int sortingComparisons = BusStop.GetNrOfComparisons();
        Assert.True(IsSorted(busStops));
        Assert.True(sortingComparisons > 0);
    }

    [Fact]
    public void Insertionsort_Comparisons()
    {
        var busStops = BuildBusStops(new[] { "E", "C", "A", "D", "B" });
        BusStop.ResetNrOfComparisons();
        SortingAlgorithms.Insertionsort(busStops, busStops.Length);
        int sortingComparisons = BusStop.GetNrOfComparisons();
        Assert.True(IsSorted(busStops));
        Assert.Equal(9, sortingComparisons);
    }

    [Fact]
    public void Quicksort_Comparisons()
    {
        var busStops = BuildBusStops(new[] { "E", "C", "A", "D", "B" });
        BusStop.ResetNrOfComparisons();
        SortingAlgorithms.Quicksort(busStops, 0, busStops.Length - 1);
        int sortingComparisons = BusStop.GetNrOfComparisons();
        Assert.True(IsSorted(busStops));
        Assert.Equal(7, sortingComparisons);
    }

    [Fact]
    public void QuicksortUsingMedianOfThree_Comparisons()
    {
        var busStops = BuildBusStops(new[] { "E", "C", "A", "D", "B" });
        BusStop.ResetNrOfComparisons();
        SortingAlgorithms.QuicksortUsingMedianOfThree(busStops, 0, busStops.Length - 1);
        int sortingComparisons = BusStop.GetNrOfComparisons();
        Assert.True(IsSorted(busStops));
        Assert.Equal(12, sortingComparisons);
    }

    [Fact]
    public void QuicksortUsingInsertionsort_Comparisons()
    {
        var busStops = BuildBusStops(new[] { "E", "C", "A", "D", "B" });
        BusStop.ResetNrOfComparisons();
        SortingAlgorithms.QuicksortUsingInsertionsort(busStops, 0, busStops.Length - 1);
        int sortingComparisons = BusStop.GetNrOfComparisons();
        Assert.True(IsSorted(busStops));
        Assert.Equal(9, sortingComparisons);
    }

    [Fact]
    public void Sort_OnAlreadySortedInput_Comparisons()
    {
        var busStops = BuildBusStops(new[] { "A", "B", "C", "D" });
        BusStop.ResetNrOfComparisons();
        SortingAlgorithms.Quicksort(busStops, 0, busStops.Length - 1);
        int sortingComparisons = BusStop.GetNrOfComparisons();
        Assert.True(IsSorted(busStops));
        Assert.True(sortingComparisons > 0);
    }

    [Fact]
    public void Quicksort_LargeBusStopsFromFile_Comparisons()
    {
        var busStops = ReadStopsFromFile("stops.txt", 100);
        Assert.True(busStops.Length == 100);

        BusStop.ResetNrOfComparisons();
        SortingAlgorithms.Quicksort(busStops, 0, busStops.Length - 1);
        int sortingComparisons = BusStop.GetNrOfComparisons();
        Assert.True(IsSorted(busStops));
        Assert.True(sortingComparisons > 0);
    }
    */
}


