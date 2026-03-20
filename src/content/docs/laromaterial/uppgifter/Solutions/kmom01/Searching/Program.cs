using Searching;

int[] nrs = HelperMethods.RandomOrderedNumbers(1, 100, 10);

for (int i=0; i<10; i++)
{
    Console.WriteLine(nrs[i]);
}

BusStop stop = new BusStop(101, "Katthult", "bla bla");
Console.WriteLine(stop);
string[] words = HelperMethods.ReadWordsFromFile("orderedwords1200.txt", 10);
for (int k=0; k<10; k++)
{
    Console.WriteLine(words[k]);
}

Console.WriteLine("------------- LinearSearch -------------");
nrs = new int[]{20, 40, 30, 70, 60, 50};
List<int> indexes = new List<int>();

int index = SearchAlgorithms.LinearSearch(nrs, 6, 30, indexes);
Console.WriteLine($"index = {index}");
foreach (int elem in indexes)
    Console.Write($"{elem}, ");
Console.WriteLine();

Console.WriteLine("------------- BinarySearch -------------");
int[] orderedNrs = new int[]{22, 33, 44, 55, 66, 77, 88};
indexes = new List<int>();

index = SearchAlgorithms.BinarySearch(orderedNrs, 7, 55, indexes);
Console.WriteLine($"index = {index}");
foreach (int elem in indexes)
    Console.Write($"{elem}, ");
Console.WriteLine();