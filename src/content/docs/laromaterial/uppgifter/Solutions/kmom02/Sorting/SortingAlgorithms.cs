

namespace Sorting;

public class SortingAlgorithms
{
    
    public static void Insertionsort<T>(T[] A, int n) where T : IComparable<T>
    {
        Insertionsort(A, 0, n-1);
    }

    public static void Insertionsort<T>(T[] A, int start, int end) where T : IComparable<T>
    {
        for (int index = start+1; index <= end; index++)
        {
            T element = A[index];
            int indexOfSorted = index - 1;
            while (indexOfSorted >= start && element.CompareTo(A[indexOfSorted]) < 0)
            {
                A[indexOfSorted + 1] = A[indexOfSorted] ;
                indexOfSorted--;
            }
            
            A[indexOfSorted + 1] = element;
        }
    }

    private static int IndexOfMedianOfThree<T>(T[] A, int start, int end) where T : IComparable<T>
    {
        int mid = (start + end)/2;
        T elemA = A[start], elemB = A[mid], elemC = A[end];

        if (elemA.CompareTo(elemB) <= 0)
        {
            if (elemB.CompareTo(elemC) <= 0) 
                return mid;
            return elemA.CompareTo(elemC) <= 0 ? end : start;
        }
        else
        {
            if (elemA.CompareTo(elemC) <= 0) 
                return start;
            return elemB.CompareTo(elemC) <= 0 ? end : mid;
        }
    }
    private static int Partition<T>(T[] A, int start, int end) where T : IComparable<T>
    {
        T pivot = A[end];
        int i = start - 1;
        
        for (int j = start; j < end; j++)
        {
            if (A[j].CompareTo(pivot) < 0)
            {
                i++;
                (A[i], A[j]) = (A[j], A[i]);
            }
        }
        (A[i + 1], A[end]) = (A[end], A[i + 1]);
        return i + 1;
    }

    public static void Quicksort<T>(T[] A, int start, int end) where T : IComparable<T>
    {
        if (start < end)
        {
            int pivotIndex = Partition(A, start, end);              
            Quicksort(A, start, pivotIndex - 1);
            Quicksort(A, pivotIndex + 1, end);
        }
    }

    private static int PartitionMedOfThree<T>(T[] A, int start, int end) where T : IComparable<T>
    {
        int indexOfMedian = IndexOfMedianOfThree(A, start, end);
        (A[end], A[indexOfMedian]) = (A[indexOfMedian], A[end]);

        return Partition(A, start, end);
    }

    public static void QuicksortUsingMedianOfThree<T>(T[] A, int start, int end) where T : IComparable<T>
    {
        if (start < end)
        {
            int pivotIndex = PartitionMedOfThree(A, start, end);              
            QuicksortUsingMedianOfThree(A, start, pivotIndex - 1);
            QuicksortUsingMedianOfThree(A, pivotIndex + 1, end);
        }
    }

    public static void QuicksortUsingInsertionsort<T>(T[] A, int start, int end) where T : IComparable<T>
    {
        int limit = 10;
        if (end - start > limit )
        {
            int pivotIndex = Partition(A, start, end);              
            QuicksortUsingInsertionsort(A, start, pivotIndex - 1);
            QuicksortUsingInsertionsort(A, pivotIndex + 1, end);
        }
        else
        {
            Insertionsort(A, start, end);
        }
    }

}
