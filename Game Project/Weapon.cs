using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Weapon : Item
{
    //ATTACK
    private int _atk;
    public int Attack
    {
        get { return _atk; }
        set { _atk = value; }
    }

    //DEFENSE
    private int _def;
    public int Defense
    {
        get { return _def; }
        set { _def = value; }
    }

    //SPEED
    private int _spd;
    public int Speed
    {
        get { return _spd; }
        set { _spd = value; }
    }

    //DURABILITY
    private int _durability;
    public int Durability
    {
        get { return _durability; }
        set { _durability = value; }
    }

    //BUILDER
    public Weapon(string name, string description, int atk, int def, int spd) : base(name, description)
    {
        Name = name;
        Description = description;
        Attack = atk;
        Defense = def;
        Speed = spd;
        Durability = atk+def+spd;
    }
}
