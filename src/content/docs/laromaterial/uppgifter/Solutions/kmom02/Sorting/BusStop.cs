namespace Sorting;
public class BusStop: IComparable<BusStop>
{
    private string? _name; 
    private int _nr;
    private string? _note;
    private static int NrOfComparisons;

    public BusStop(string? name, int nr, string? note = "-")
    {
        this._name = name;
        this._nr = nr;
        this._note = note;
    }

    public int CompareTo(BusStop? other)
    {
        NrOfComparisons++;
        if (other == null)
            return 1;
        return this._name.CompareTo(other._name);
    }

    public static void ResetNrOfComparisons()
    {
        NrOfComparisons = 0;
    }

    public static int GetNrOfComparisons()
    {
        return NrOfComparisons;
    }


    public string GetInfo()
    {
        string res =  $"{this._nr}: {this._name}";
        if (this._note != null && !this._note.Equals("-"))
        {
            res += "\n" + this._note;
        }
        return res;
    }

    public int GetNr()
    {
        return this._nr;
    }

    public string GetName()
    {
        return this._name ?? string.Empty;
    }

    public string GetNote()
    {
        return this._note ?? string.Empty;
    }

    BusStop GetCopy()
    {
        return new BusStop(this._name, this._nr, this._note);
    }
}
