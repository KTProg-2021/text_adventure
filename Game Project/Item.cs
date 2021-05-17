using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Item
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

    //ART
    private string _art = "";
    public string Art
    {
        get { return _art; }
        set { _art = value != null ? value : _art; }
    }

    //BUILDER
    public Item(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
