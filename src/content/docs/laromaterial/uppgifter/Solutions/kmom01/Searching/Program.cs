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