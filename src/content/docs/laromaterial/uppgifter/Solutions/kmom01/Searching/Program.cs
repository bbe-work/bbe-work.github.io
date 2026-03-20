using Searching;

int[] nrs = HelperMethods.RandomOrderedNumbers(1, 100, 10);

for (int i=0; i<10; i++)
{
    Console.WriteLine(nrs[i]);
}

/*BusStop[] busStops = HelperMethods.ReadBustStopsFromFile("stops.txt", 20);
for (int i=0; i<20; i++)
{
    Console.WriteLine(busStops[i].GetInfo());
}*/

string[] words = HelperMethods.ReadWordsFromFile("orderedwords1200.txt", 10);
for (int k=0; k<10; k++)
{
    Console.WriteLine(words[k]);
}