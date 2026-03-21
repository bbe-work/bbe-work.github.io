namespace Searching;
public class SearchAlgorithms
{
    public static int LinearSearch<T>(T[] A, int n, T toFind, List<int>? indexes) 
        where T : IComparable<T>
    {
        for (int index=0; index< n; index++)
        {
            indexes?.Add(index);
            if (A[index].CompareTo(toFind) == 0)
                return index;
        }
        return -1;
    }

    public static int BinarySearch<T>(T[] A, int n, T toFind, List<int>? indexes) 
        where T : IComparable<T>
    {
        int startIndex = 0;
        int endIndex = n-1;
        int midIndex = (startIndex + endIndex) / 2;
        indexes?.Add(midIndex);
        while (startIndex <= endIndex && A[midIndex].CompareTo(toFind) != 0)
        {
            if (toFind.CompareTo(A[midIndex]) < 0)
                endIndex = midIndex - 1;
            else
                startIndex = midIndex + 1;

            midIndex = (startIndex + endIndex) / 2;
            indexes?.Add(midIndex);
        }
        if (startIndex > endIndex && indexes != null)
        {
            indexes.RemoveAt(indexes.Count - 1); // den extra mittberäkningen som görs
            midIndex = -1;
        }
        return midIndex;
    }
}

