using Sorting;

namespace Sorting;

static class HelperMethods
{
    public static bool CheckSorted<T>(T[] arr, int n) where T: IComparable<T>
    {
        for (int i=1; i<arr.Length-1; i++)
        {
            if (arr[i].CompareTo(arr[i+1])>0)
                return false;
        }
        return true;
    }

    public static void Shuffle<T>(T[] arr, int n) where T: IComparable<T>
    {
        var random = new Random();
        for (int times=1; times<n; times++)
        {
            int i = random.Next(0, n);
            int j = random.Next(0, n);
            (arr[i], arr[j]) = (arr[j], arr[i]);
        }
    }

    public static BusStop[] ReadFromFile(string filename, int nrOf = -1)
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

    public static int AverageComparisons(Action<BusStop[], int, int> SortMethod, BusStop[] busStops, int n, int nrOfTimes)
    {
        int totalComparisons = 0;
        for (int i = 0; i < nrOfTimes; i++)
        {
            if (nrOfTimes != 1)
                Shuffle(busStops, n);
            BusStop.ResetNrOfComparisons();
            SortMethod(busStops, 0, n - 1);
            totalComparisons += BusStop.GetNrOfComparisons();
        }
        return totalComparisons / nrOfTimes;
    }
}
