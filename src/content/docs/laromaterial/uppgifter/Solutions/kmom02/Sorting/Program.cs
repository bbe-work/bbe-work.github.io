using System;
using Sorting;

BusStop[] ReadFromFile(string filename, int nrOf = -1)
{
    try 
    {
        string[] stops = File.ReadAllLines(filename);
        if (nrOf == -1 || nrOf > stops.Length)
            nrOf = stops.Length - 1;
        BusStop[] busStops = new BusStop[nrOf];
        for (int i=0; i<nrOf; i++)
        {
            string[] parts = stops[i+1].Split(",");
            busStops[i] = new BusStop(int.Parse(parts[0].Substring(8)), parts[1]);
        }
        return busStops;
    }
    catch(Exception e)
    {
        return null;
    }
}

int AverageComparisons(Action<BusStop[], int, int> SortMethod, BusStop[] busStops, int n, int nrOfTimes)
{
    int totalComparisons = 0;
    for (int i = 0; i < nrOfTimes; i++)
    {
        if (nrOfTimes != 1)
            HelperMethods.Shuffle(busStops, n);
        BusStop.ResetNrOfComparisons();
        SortMethod(busStops, 0, n - 1);
        totalComparisons += BusStop.GetNrOfComparisons();
    }
    return totalComparisons / nrOfTimes;
}


int nrOfTimes = 5;
int nrOfElements = 10;
Console.WriteLine("************* INSERTIONSORT *************");

Console.WriteLine("Array med slumpmässig data");
for (int i=0; i<3; i++)
{
    BusStop[] busStops = ReadFromFile("stops.txt", nrOfElements);
    int compInsertionsort = AverageComparisons(SortingAlgorithms.Insertionsort, busStops, nrOfElements, nrOfTimes);
    Console.WriteLine($"Sortering av {nrOfElements} krävde {compInsertionsort} jämförelser");
    nrOfElements*= 10;
}

nrOfElements = 10;
Console.WriteLine("\nArray med sorterad data");
for (int i=0; i<3; i++)
{
    BusStop[] busStops = ReadFromFile("stops.txt", nrOfElements);
    Array.Sort(busStops);
    int compInsertionsort = AverageComparisons(SortingAlgorithms.Insertionsort, busStops, nrOfElements, 1);
    Console.WriteLine($"Sortering av {nrOfElements} krävde {compInsertionsort} jämförelser");
    nrOfElements*= 10;
}

nrOfElements = 10;
Console.WriteLine("\nArray med omvänd sorterad data");
for (int i=0; i<3; i++)
{
    BusStop[] busStops = ReadFromFile("stops.txt", nrOfElements);
    Array.Sort(busStops);
    Array.Reverse(busStops);
    int compInsertionsort = AverageComparisons(SortingAlgorithms.Insertionsort, busStops, nrOfElements, 1);
    Console.WriteLine($"Sortering av {nrOfElements} krävde {compInsertionsort} jämförelser");
    nrOfElements*= 10;
}

Console.WriteLine("\n************* QUICKSORT *************");
nrOfElements = 10;
Console.WriteLine("Array med slumpmässig data");
for (int i=0; i<3; i++)
{
    BusStop[] busStops = ReadFromFile("stops.txt", nrOfElements);
    int compQuicksort = AverageComparisons(SortingAlgorithms.Quicksort, busStops, nrOfElements, nrOfTimes);
    Console.WriteLine($"Sortering av {nrOfElements} krävde {compQuicksort} jämförelser");
    nrOfElements*= 10;
}

nrOfElements = 10;
Console.WriteLine("\nArray med sorterad data");
for (int i=0; i<3; i++)
{
    BusStop[] busStops = ReadFromFile("stops.txt", nrOfElements);
    Array.Sort(busStops);
    int compQuicksort = AverageComparisons(SortingAlgorithms.Quicksort, busStops, nrOfElements, 1);
    Console.WriteLine($"Sortering av {nrOfElements} krävde {compQuicksort} jämförelser");
    nrOfElements*= 10;
}

nrOfElements = 10;
Console.WriteLine("\nArray med omvänd sorterad data");
for (int i=0; i<3; i++)
{
    BusStop[] busStops = ReadFromFile("stops.txt", nrOfElements);
    Array.Sort(busStops);
    Array.Reverse(busStops);
    int compQuicksort = AverageComparisons(SortingAlgorithms.Quicksort, busStops, nrOfElements, 1);
    Console.WriteLine($"Sortering av {nrOfElements} krävde {compQuicksort} jämförelser");
    nrOfElements*= 10;
}

Console.WriteLine("\n************* QUICKSORT MEDIAN AV TRE *************");
nrOfElements = 10;
Console.WriteLine("Array med slumpmässig data");
for (int i=0; i<3; i++)
{
    BusStop[] busStops = ReadFromFile("stops.txt", nrOfElements);
    int compQuicksort = AverageComparisons(SortingAlgorithms.QuicksortUsingMedianOfThree, busStops, nrOfElements, nrOfTimes);
    Console.WriteLine($"Sortering av {nrOfElements} krävde {compQuicksort} jämförelser");
    nrOfElements*= 10;
}


nrOfElements = 10;
Console.WriteLine("\nArray med sorterad data");
for (int i=0; i<3; i++)
{
    BusStop[] busStops = ReadFromFile("stops.txt", nrOfElements);
    Array.Sort(busStops);
    int compQuicksort = AverageComparisons(SortingAlgorithms.QuicksortUsingMedianOfThree, busStops, nrOfElements, 1);
    Console.WriteLine($"Sortering av {nrOfElements} krävde {compQuicksort} jämförelser");
    nrOfElements*= 10;
}

nrOfElements = 10;
Console.WriteLine("\nArray med omvänd sorterad data");
for (int i=0; i<3; i++)
{
    BusStop[] busStops = ReadFromFile("stops.txt", nrOfElements);
    Array.Sort(busStops);
    Array.Reverse(busStops);
    int compQuicksort = AverageComparisons(SortingAlgorithms.QuicksortUsingMedianOfThree, busStops, nrOfElements, 1);
    Console.WriteLine($"Sortering av {nrOfElements} krävde {compQuicksort} jämförelser");
    nrOfElements*= 10;
}

Console.WriteLine("\n************* QUICKSORT USING INSERTIONSORT *************");
nrOfElements = 10;
Console.WriteLine("Array med slumpmässig data");
for (int i=0; i<3; i++)
{
    BusStop[] busStops = ReadFromFile("stops.txt", nrOfElements);
    int compQuicksort = AverageComparisons(SortingAlgorithms.QuicksortUsingInsertionsort, busStops, nrOfElements, nrOfTimes);
    Console.WriteLine($"Sortering av {nrOfElements} krävde {compQuicksort} jämförelser");
    nrOfElements*= 10;
}


nrOfElements = 10;
Console.WriteLine("\nArray med sorterad data");
for (int i=0; i<3; i++)
{
    BusStop[] busStops = ReadFromFile("stops.txt", nrOfElements);
    Array.Sort(busStops);
    int compQuicksort = AverageComparisons(SortingAlgorithms.QuicksortUsingInsertionsort, busStops, nrOfElements, 1);
    Console.WriteLine($"Sortering av {nrOfElements} krävde {compQuicksort} jämförelser");
    nrOfElements*= 10;
}

nrOfElements = 10;
Console.WriteLine("\nArray med omvänd sorterad data");
for (int i=0; i<3; i++)
{
    BusStop[] busStops = ReadFromFile("stops.txt", nrOfElements);
    Array.Sort(busStops);
    Array.Reverse(busStops);
    int compQuicksort = AverageComparisons(SortingAlgorithms.QuicksortUsingInsertionsort, busStops, nrOfElements, 1);
    Console.WriteLine($"Sortering av {nrOfElements} krävde {compQuicksort} jämförelser");
    nrOfElements*= 10;
}
