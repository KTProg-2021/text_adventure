using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Enemy : Weapon
{
    //TIER
    private int _tier;
    public int Tier
    {
        get { return _tier; }
        set { _tier = value < 1 ? 1 : value > 10 ? 10 : value; }
    }

    //HEALTH
    private int _hp;
    public int Health
    {
        get { return _hp; }
        set { _hp = value; }
    }

    //REGION
    private string _region;
    public string Region
    {
        get { return _region; }
        set { if (value.Equals("main") || value.Equals("lake") || value.Equals("ruins") || value.Equals("forest") || value.Equals("fortress")) _region = value; }
    }

    //BUILDER
    public Enemy(string name, string description, int atk, int def, int spd, int tier, string region) : base(name, description, atk, def, spd)
    {
        Name = name;
        Description = description;
        Attack = atk;
        Defense = def;
        Speed = spd;
        Tier = tier;
        Health = (tier*5)+20;
        Region = region;
    }
}
