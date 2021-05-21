using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Npc
{
    //NAME
    private string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value != null ? value : _name; }
    }

    //DESCRIPTION
    private string _description;
    public string Description
    {
        get { return _description; }
        set { _description = value != null ? value : _description; }
    }

    //TRADES
    private Dictionary<Item, int> _trades;
    public Dictionary<Item, int> Trades
    {
        get { return _trades; }
        set { _trades = value; }
    }

    //BUILDER
    public Npc(string name, string description)
    {
        Name = name;
        Description = description;
        Trades = new Dictionary<Item, int>();
    }

    //BUILDER
    public Npc(string name, string description, Dictionary<Item, int> trades)
    {
        Name = name;
        Description = description;
        Trades = trades;
    }
}
