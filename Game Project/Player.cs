using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Player
{
    //NAME
    private string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value != null ? value : _name; }
    }

    //HEALTH
    private int _hp;
    public int Health
    {
        get { return _hp; }
        set { _hp = value; }
    }

    //KILLS
    private int[] _bounty;
    public int Bounty
    {
        get { return _hp; }
        set { _hp = value; }
    }

    private Weapon _wep;
    public Weapon Weapon
    {
        get { return _wep; }
        set { _wep = value; }
    }
    public bool EquipWeapon(Weapon wep)
    {
        if (HasItem(wep))
        {
            PickUpItem(Weapon);
            DropItem(wep);
            Weapon = wep;
            return true;
        }
        else return false;
    }

    //INVENTORY
    private Dictionary<Item, int> _inventory;
    public Dictionary<Item, int> Inventory
    {
        get { return _inventory; }
        set { _inventory = value; }
    }

    public bool HasItem(Item item)
    {
        return Inventory.ContainsKey(item);
    }
    public bool HasItem(Item item, int count)
    {
        if (Inventory.ContainsKey(item)) if (Inventory[item] > count) 
                return true; else return false; else return false;
    }
    public void PickUpItem(Item item)
    {
        if (HasItem(item)) Inventory[item]++; else Inventory.Add(item, 1);
    }
    public void DropItem(Item item)
    {
        if (HasItem(item)) if (Inventory[item]>1) Inventory[item]--; else Inventory.Remove(item);
    }
    public void PrintInv()
    {
        foreach (KeyValuePair<Item, int> kvp in Inventory)
        {
            Console.WriteLine("{0}*{1}", kvp.Value, kvp.Key);
        }
    }

    //BUILDER
    public Player()
    {
        Name = "Player";
        Health = 100;
        Inventory = new Dictionary<Item, int>();
    }
}
