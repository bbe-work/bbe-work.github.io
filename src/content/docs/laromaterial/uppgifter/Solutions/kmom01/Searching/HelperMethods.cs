namespace Searching;
public class HelperMethods
{
    public static BusStop[] ReadBustStopsFromFile(string filename, int nrOf = -1)
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
                busStops[i] = new BusStop(parts[1], int.Parse(parts[0].Substring(8)));
            }
            Array.Sort(busStops);
            return busStops;
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public static string[] ReadWordsFromFile(string filename, int nrOf = -1)
    {
        if (nrOf == -1)
        {
            string[] all = File.ReadAllLines(filename);
            return all;
        }

        string[] words = new string[nrOf];

        using (var reader = new StreamReader(filename))
        {
            string? word;
            int index = 0;

            while ((word = reader.ReadLine()) != null && index < nrOf)
            {
                words[index] = word;
                index++;
            }
        }

        return words;
    }

    public static int[] RandomOrderedNumbers(int minValue, int maxValue, int nrOf, int seed = 1234)
    {
        Random random = new Random(seed);

        int[] nrs = new int[nrOf];
        for (int i = 0; i<nrOf; i++)
            nrs[i] = random.Next(minValue, maxValue + 1);
        Array.Sort(nrs);
        return nrs;
    }
}