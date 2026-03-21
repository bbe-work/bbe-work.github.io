namespace Searching;

public class BusStop: IComparable<BusStop>
{
    private string _name; 
    private int _nr;
    private string? _note;

    public BusStop(int nr, string name, string note = "-")
    {
        this._name = name ?? "";
        this._nr = nr;
        this._note = note;
    }

    public int CompareTo(BusStop? other)
    {
        if (other == null || other._name == null)
            return 1;
        return this._name.CompareTo(other._name);
    }

    public override string ToString()
    {
        string res =  $"{this._nr}: {this._name}";
        if (this._note != null && !this._note.Equals("-"))
        {
            res += "\n" + this._note;
        }
        return res;
    }

    /*public override bool Equals(object? obj)
    {
        if (obj == null || this.GetType() != obj.GetType())
            return false;
        BusStop other = (BusStop)obj;

        return this._nr == other._nr && this._name == other._name!;
    }*/

    public int GetNr()
    {
        return this._nr;
    }

    public string GetName()
    {
        return this._name;
    }

    public string GetNote()
    {
        return this._note ?? string.Empty;
    }


    public BusStop GetCopy()
    {
        return new BusStop(this._nr, this._name, this._note ?? "-");
    }
}
