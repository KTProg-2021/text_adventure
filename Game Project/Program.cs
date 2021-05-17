using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Project
{
    public enum Direction
    {
        //directions
        North,
        West,
        South,
        East
    }
    class Program
    {
        //PLAYER    
        static public Player player = new Player();

        //ITEM BANK
        static public Item items(string item)
        {
            Dictionary<string, Item> itemArray = new Dictionary<string, Item>();
            itemArray.Add("staff", new Weapon("Training Staff", "A small staff with high attack and low defense", 8, 8, 8));
            itemArray.Add("wood_axe", new Weapon("Woodcutter's Axe", "A small axe with high defense and low speed", 8, 12, 3));
            itemArray.Add("sword", new Weapon("Sword", "A strong sword with high attack and low defense", 15, 5, 10));
            itemArray.Add("axe", new Weapon("Axe", "A large axe with high defense and low speed", 10, 15, 5));
            itemArray.Add("spear", new Weapon("Spear", "A long spear with high speed and low attack", 5, 10, 15));
            itemArray.Add("blade", new Weapon("Water Blade", "A strong sword with high attack and low defense", 25, 15, 20));
            itemArray.Add("labrys", new Weapon("Minotaur's Labrys", "A double headed axe with high defense and low speed", 20, 25, 15));
            itemArray.Add("branch", new Weapon("Branch Staff", "A long spear with high speed and low attack", 15, 20, 25));
            itemArray.Add("bigboy", new Weapon("Big Boy", "ur mom", 99, 99, 99));
            itemArray.Add("coin", new Item("Gold Coin", "In Game Currency"));
            itemArray.Add("bandage", new Item("Bandage", "Heals 10 hp"));
            itemArray.Add("lesser_heal", new Item("Lesser Healing Potion", "Heals 20 hp"));
            itemArray.Add("greater_heal", new Item("Greater Healing Potion", "Heals 40 hp"));
            itemArray.Add("atk_pot", new Item("Strength Potion", "Increases your attack by 5 for one battle"));
            itemArray.Add("def_pot", new Item("Protection Potion", "Increases your defense by 5 for one battle"));
            itemArray.Add("spd_pot", new Item("Haste Potion", "Increases your speed by 5 for one battle"));
            itemArray.Add("bounty_pot", new Item("Wealth Potion", "Doubles your bounty rate for one battle"));

            return itemArray[item];
        }

        //ENEMY BANK
        static public Enemy enemies(string enemy)
        {
            Dictionary<string, Enemy> enemyArray = new Dictionary<string, Enemy>();
            enemyArray.Add("leon1", new Enemy("Leon", "lelon lol", 5, 5, 5, 1, "main"));
            enemyArray.Add("slime", new Enemy("Slime", "An aggravated slime with high speed and low defense", 10, 5, 15, 2, "lake"));
            enemyArray.Add("shark", new Enemy("Shark", "A hungry, hostile shark with high attack and low defense", 15, 5, 10, 4, "lake"));
            enemyArray.Add("bees", new Enemy("Swarm of Bees", "A cluster of angry bees with high speed and low attack", 5, 10, 15, 2, "forest"));
            enemyArray.Add("bear", new Enemy("Bear", "A large brown bear with high attack and low speed", 15, 10, 5, 4, "forest"));
            enemyArray.Add("elemental", new Enemy("Elemental", "A ruined elemental with high defense and low speed", 10, 15, 5, 3, "ruins"));
            enemyArray.Add("goblin", new Enemy("Goblin", "A ruffian goblin with high speed and low defense", 10, 5, 15, 3, "ruins"));
            enemyArray.Add("armor", new Enemy("Haunted Armor", "A possessed set of knight's armor with high attack and low defense", 15, 5, 10, 3, "fortress"));
            enemyArray.Add("wyvern", new Enemy("Wyvern", "A large angry wyvern with high defense and low attack", 5, 15, 10, 4, "fortress"));
            enemyArray.Add("spirit", new Enemy("Water Spirit", "The sassy and mischevious spirit haunting the lake who has high attack and low defense", 5, 15, 10, 5, "lake"));
            enemyArray.Add("ent", new Enemy("Ent", "The telepathic and wise tree creature residing in the forest who has high speed and low attack", 5, 15, 10, 5, "forest"));
            enemyArray.Add("minotaur", new Enemy("Minotaur", "The gruff and angry man bull lost in the ruins who has high defense and low speed", 5, 15, 10, 5, "ruins"));
            enemyArray.Add("leon2", new Enemy("Leon", "lelon dead lol", 10, 10, 10, 6, "fortress"));
            enemyArray["bear"].Art = "\n      ____________________________             _\n    /                             \\        __ | | __\n   |                               \\_____ /      _ \\\n   |                                             .  \\\n  _|                                                 \\_\n |                                               _____ |\n |_                                                \\/__|\n   |                                 _____          /\n   |                                /     \\_______ /\n   |         ____________          /\n    \\       /            \\        /\n     |     |               |     |\n     |     |               |     |\n     | ______\\             | ______\\";
            enemyArray["elemental"].Art = "\n  * /\\ /\\ \n/\\ //\\\\\\/ \n\\///  _\\  \n  \\\\ / \\  \n <>\\\\\\_/ \n    \\/ *";
            return enemyArray[enemy];
        }

        //MAKE CHOICE
        static public int Choice(string[] choices)
        {
            if (choices.Length > 1)
            {
                Console.WriteLine("Make a choice, {0} (1-{1}):", player.Name, choices.Length);
                System.Threading.Thread.Sleep(500);
                for (int i = 0; i < choices.Length; i++)
                {
                    Console.WriteLine("{0}: {1}", i + 1, choices[i]);
                    System.Threading.Thread.Sleep(100);
                }
                System.Threading.Thread.Sleep(500);
                int outp = 0;
                try { outp = Convert.ToInt32(Console.ReadLine()); Console.WriteLine();}
                catch (FormatException e) { Console.WriteLine(); outp = Choice(choices); }
                if (outp <= 0 || outp > choices.Length) { outp = Choice(choices); }
                return outp;
            }
            return 0;
        }

        //COMBAT
        static public void Combat(Enemy enemy)
        {
            Console.WriteLine("A{0} {1} approaches", enemy.Name.ToLower()[0] == 'a' || enemy.Name.ToLower()[0] == 'e' ||
                                                        enemy.Name.ToLower()[0] == 'i' || enemy.Name.ToLower()[0] == 'o' ||
                                                        enemy.Name.ToLower()[0] == 'u' ? "n" : "", enemy.Name);
            Console.WriteLine(enemy.Art+"\n");
            System.Threading.Thread.Sleep(500);
            bool ran = false;
            int timer = 1;
            while (enemy.Health > 0 && player.Health > 0 && !ran)
            {
                if ( player.Weapon.Speed % timer == 0 )
                {
                    Console.WriteLine("{0}'{1} health: {2} | {3}'{4} health: {5}", player.Name, player.Name[0] != 's' ? 's' : "", player.Health, enemy.Name, enemy.Name[0] != 's' ? 's' : "", enemy.Health);
                    System.Threading.Thread.Sleep(500);
                    switch (Choice(new string[] { "Attack", "Use Item", "Inspect", "Run" }))
                    {
                        case 1:
                            int atk = Math.Max(player.Weapon.Attack - enemy.Defense, 0);
                            enemy.Health -= atk;
                            Console.WriteLine("{0} did {1} damage", player.Name, atk);
                            break;
                        case 2:
                            Console.WriteLine("Use Item does not work");
                            break;
                        case 3:
                            Console.WriteLine("{0}: {1}", enemy.Name, enemy.Description);
                            break;
                        case 4:
                            ran = true;
                            Console.WriteLine("{0} ran away", player.Name);
                            break;
                    }
                    Console.WriteLine();
                    System.Threading.Thread.Sleep(500);
                }
                if (enemy.Health > 0 && enemy.Speed % timer == 0 )
                {
                    Console.WriteLine("{0}'{1} health: {2} | {3}'{4} health: {5}", player.Name, player.Name[0] != 's' ? 's' : "", player.Health, enemy.Name, enemy.Name[0] != 's' ? 's' : "", enemy.Health);
                    Console.WriteLine("{0} attacked", enemy.Name);
                    System.Threading.Thread.Sleep(500);
                    int atk = Math.Max(enemy.Attack - player.Weapon.Defense, 0);
                    player.Health -= atk;
                    Console.WriteLine("{0} took {1} damage", player.Name, atk);
                    System.Threading.Thread.Sleep(500);
                }
                timer++;
            }
            if (player.Health < 1) Console.WriteLine("{0} Died", player.Name);
            else if (enemy.Health < 1) Console.WriteLine("{0} Died", enemy.Name);
        }
        
        static void Main(string[] args)
        {
            Console.Write("What's your name?\n");
            player.Name = Console.ReadLine();
            player.Weapon = (Weapon)items("bigboy");
            Map map = new Map(5, 5);
            map.initialize();
            map.X = 2; map.Y = 2;
            map.pieceDirection(1, 2, Direction.West, false);
            map.print();
            bool continuie = true;
            while (continuie)
            {
                Console.Write("Which way would you like to go?\n");
                switch (Choice(new string[] {"North","East","South","West","Byebye"}))
                {
                    case 1:
                        map.Move(Direction.North);
                        break;
                    case 2:
                        map.Move(Direction.East);
                        break;
                    case 3:
                        map.Move(Direction.South);
                        break;
                    case 4:
                        map.Move(Direction.West);
                        break;
                    case 5:
                        continuie = false;
                        break;
                    default: Console.WriteLine("Not good :("); break;
                }
                if (map.X == 2 && map.Y == 1)
                {
                    Combat(enemies("elemental"));
                    map.print();
                }
                if (map.X == 0 && map.Y == 2)
                {
                    Combat(enemies("bear"));
                    map.print();
                }
            }
        }
    }
    class Cell
    {
        private string _name;
        private char _data;
        private Cell _northCell;
        private Cell _southCell;
        private Cell _eastCell;
        private Cell _westCell;
        public Cell(Cell north, Cell south, Cell east, Cell west)
        {
            _northCell = north;
            _southCell = south;
            _eastCell = east;
            _westCell = west;
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public Cell North
        {
            get { return _northCell; }
            set { _northCell = value; }
        }
        public Cell South
        {
            get { return _southCell; }
            set { _southCell = value; }
        }
        public Cell East
        {
            get { return _eastCell; }
            set { _eastCell = value; }
        }
        public Cell West
        {
            get { return _westCell; }
            set { _westCell = value; }
        }
        public char Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
    class Map
    {
        Cell[,] cells;
        private int x = 0;
        private int y = 0;
        bool _show = true;
        //char model = '\x0D9E';
        char model = '#';
        public Map(int length, int height)
        {
            cells = new Cell[length, height];
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    cells[i, j] = new Cell(null, null, null, null);
                    cells[i, j].Data = makeMap(cells[i, j]);
                }
            }
        }
        public char makeMap(Cell current)
        {

            if (current.North != null && current.South != null && current.West != null && current.East != null)
            {
                return '╬';
            }
            else if (current.North != null && current.South != null && current.West == null && current.East != null)
            {
                return '╠';
            }
            else if (current.North != null && current.South != null && current.West != null && current.East == null)
            {
                return '╣';
            }
            else if (current.North != null && current.South == null && current.West != null && current.East != null)
            {
                return '╩';
            }
            else if (current.North == null && current.South != null && current.West != null && current.East != null)
            {
                return '╦';
            }
            else if (current.North == null && current.South == null && current.West != null && current.East != null)
            {
                return '═';
            }
            else if (current.North != null && current.South != null && current.West == null && current.East == null)
            {
                return '║';
            }
            else if (current.North != null && current.South == null && current.West == null && current.East != null)
            {
                return '╚';
            }
            else if (current.North == null && current.South != null && current.West == null && current.East != null)
            {
                return '╔';
            }
            else if (current.North == null && current.South != null && current.West != null && current.East == null)
            {
                return '╗';
            }
            else if (current.North != null && current.South == null && current.West != null && current.East == null)
            {
                return '╝';
            }
            else if (current.North == null && current.South != null && current.West == null && current.East == null)
            {
                return '╥';
            }
            else if (current.North != null && current.South == null && current.West == null && current.East == null)
            {
                return '╨';
            }
            else if (current.North == null && current.South == null && current.West != null && current.East == null)
            {
                return '╡';
            }
            else if (current.North == null && current.South == null && current.West == null && current.East != null)
            {
                return '╞';
            }
            return '█';
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public void initialize()
        {
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    if (i != 0)
                    {
                        cells[i, j].North = cells[i - 1, j];
                    }
                    if (i != cells.GetLength(0) - 1)
                    {
                        cells[i, j].South = cells[i + 1, j];
                    }
                    if (j != 0)
                    {
                        cells[i, j].West = cells[i, j - 1];
                    }
                    if (j != cells.GetLength(1) - 1)
                    {
                        cells[i, j].East = cells[i, j + 1];
                    }
                }
            }
        }
        public void threeByThreeGorrest()
        {
            pieceDirection(0, 0, Direction.East, false);

        }
        public void pieceDirection(int x, int y, Direction direction, bool toggle)
        {
            switch (direction)
            {
                case Direction.North:
                    if (toggle)
                    {
                        cells[y, x].North = cells[y - 1, x];
                        cells[y - 1, x].South = cells[y, x];
                    }
                    else
                    {
                        cells[y, x].North = null;
                        cells[y - 1, x].South = null;
                    }
                    break;
                case Direction.South:
                    if (toggle)
                    {
                        cells[y, x].South = cells[y + 1, x];
                        cells[y + 1, x].North = cells[y, x];
                    }
                    else
                    {
                        cells[y, x].South = null;
                        cells[y + 1, x].North = null;
                    }
                    break;
                case Direction.East:
                    if (toggle)
                    {
                        cells[y, x].East = cells[y, x + 1];
                        cells[y, x + 1].West = cells[y, x];
                    }
                    else
                    {
                        cells[y, x].East = null;
                        cells[y + 1, x].West = null;
                    }
                    break;
                case Direction.West:
                    if (toggle)
                    {
                        cells[y, x].West = cells[y, x - 1];
                        cells[y, x - 1].East = cells[y, x];
                    }
                    else
                    {
                        cells[y, x].West = null;
                        cells[y - 1, x].East = null;
                    }
                    break;
            }
        }
        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    if (cells[y, x].North != null)
                    {
                        cells[y, x].Data = makeMap(cells[y, x]); cells[y - 1, x].Data = model; y--;
                        print();
                    }
                    else { Console.WriteLine("You cant go north"); }
                    break;
                case Direction.South:
                    if (cells[y, x].South != null)
                    {
                        cells[y, x].Data = makeMap(cells[y, x]); cells[y + 1, x].Data = model; y++;
                        print();
                    }
                    else { Console.WriteLine("You cant go south"); }
                    break;
                case Direction.East:
                    if (cells[y, x].East != null)
                    {
                        cells[y, x].Data = makeMap(cells[y, x]); cells[y, x + 1].Data = model; x++;
                        print();
                    }
                    else { Console.WriteLine("You cant go east"); }
                    break;
                case Direction.West:
                    if (cells[y, x].West != null)
                    {
                        cells[y, x].Data = makeMap(cells[y, x]); cells[y, x - 1].Data = model; x--;
                        print();
                    }
                    else { Console.WriteLine("You cant go west"); }
                    break;
            }

        }
        public void print()
        {
            cells[Y, X].Data = model;
            if (_show)
            {
                for (int i = 0; i < cells.GetLength(0); i++)
                {
                    for (int j = 0; j < cells.GetLength(1); j++)
                    {
                        Console.Write(cells[i, j].Data);
                    }
                    Console.WriteLine("");
                }

            }

        }
    }
}
