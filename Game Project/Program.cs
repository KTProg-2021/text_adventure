using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Project
{
    public enum Direction
    {
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
            itemArray.Add("staff", new Weapon("Training Staff", "A small staff with high attack and low defense", 99, 99, 5));
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
            enemyArray.Add("leon1", new Enemy("Leon", "lelon lol", 8, 0, 8, 0, "main"));
            enemyArray.Add("slime", new Enemy("Slime", "An aggravated slime with high speed and low defense", 10, 5, 15, 2, "lake"));
            enemyArray["slime"].Art = "\n _------_ \n/  o___o \\ \n\\________/";
            enemyArray.Add("shark", new Enemy("Shark", "A hungry, hostile shark with high attack and low defense", 15, 5, 10, 4, "lake"));
            enemyArray["shark"].Art = "\n\\.          |\\ \n   \\`.___-- - ~~~~~--_ \n   //~~----___  (_o_-~ \n  \'           |/\'";
            enemyArray.Add("bees", new Enemy("Swarm of Bees", "A cluster of angry bees with high speed and low attack", 5, 10, 15, 2, "forest"));
            enemyArray["bees"].Art = "\n     (\\\\ \n    -###) \n      \"\"   //) \n   (\\\\    (###- \n  -###)    \"\" \n    \"\"";
            enemyArray.Add("bear", new Enemy("Bear", "A large brown bear with high attack and low speed", 15, 10, 5, 4, "forest"));
            enemyArray["bear"].Art = "\n   ..------~~~--.__ \n  /               c~\\ \n  /             \\__ `\\ \n  |  /~~--__/  /\'\\ ~~\' \n /'/'\\ |    | |`\\ \\_ \n`-))  `-))  `-)) `-))";
            enemyArray.Add("elemental", new Enemy("Elemental", "A ruined elemental with high defense and low speed", 10, 15, 5, 3, "ruins"));
            enemyArray["elemental"].Art = "\n  * /\\ /\\ \n/\\ //\\\\\\/ \n\\///  _\\  \n  \\\\ / \\  \n <>\\\\\\_/ \n    \\/ *";
            enemyArray.Add("goblin", new Enemy("Goblin", "A ruffian goblin with high speed and low defense", 10, 5, 15, 3, "ruins"));
            enemyArray["goblin"].Art = "\n  _ _ \n<(\'Δ\')> \n`-(_)-, \n  / \\";
            enemyArray.Add("armor", new Enemy("Haunted Armor", "A possessed set of knight's armor with high attack and low defense", 15, 5, 10, 3, "fortress"));
            enemyArray["armor"].Art = "\n      .-. \n    __|=|__ \n   (_/`-`\\_) \n   //\\___/\\\\ \n   <>/   \\<> \n    \\|_._|/ \n     <_I_> \n      ||| \n     /_|_\\";
            enemyArray.Add("wyvern", new Enemy("Wyvern", "A large angry wyvern with high defense and low attack", 5, 15, 10, 4, "fortress"));
            enemyArray["wyvern"].Art = "\n       ___-----__ \n     _/__------_/\' \n    /   )__---__| \n           `\\_,-\\ \n  __        _--\\ \\-__,,_ \n<\'  \\\\____,/      ____`•\\ \n     `======-\\ )`'    `\'-` \n             // \n            `\\\\,,";
            enemyArray.Add("spirit", new Enemy("Water Spirit", "The sassy and mischevious spirit haunting the lake who has high attack and low defense", 5, 15, 10, 5, "lake"));
            enemyArray.Add("ent", new Enemy("Ent", "The telepathic and wise tree creature residing in the forest who has high speed and low attack", 5, 15, 10, 5, "forest"));
            enemyArray.Add("minotaur", new Enemy("Minotaur", "The gruff and angry man bull lost in the ruins who has high defense and low speed", 5, 15, 10, 5, "ruins"));
            enemyArray.Add("leon2", new Enemy("Leon", "lelon dead lol", 10, 10, 10, 6, "fortress"));
            enemyArray.Add("leon3", new Enemy("Leon", "lelon dead again???", 10, 10, 10, 7, "fortress"));
            return enemyArray[enemy];
        }

        //NPC BANK
        static public Npc npcs(string item)
        {
            Dictionary<string, Npc> npcArray = new Dictionary<string, Npc>();
            npcArray.Add("spirit", new Npc("Water Spirit", "Female spirit. She's sassy and mysterious. She seems to be looking for something."));
            npcArray.Add("ent", new Npc("Ent", "Large tree creature. It speaks telepathically and is very wise. It seems to be looking for something."));
            npcArray.Add("minotaur", new Npc("Minotaur", "Large bull man. He's angry and gruff. It seems to be looking for something."));
            npcArray.Add("leon", new Npc("Leon", "Young adult man. Your childhood friend and training buddy."));
            npcArray.Add("captain", new Npc("Fritz", "The Captain. Middle aged man. He seems mature and formal but a bit weary."));
            npcArray.Add("innkeep", new Npc("Lyn", "The Innkeep. Young adult woman. She is polite and formal, and wants new people staying at the inn."));
            npcArray.Add("hinter", new Npc("Sonal", "The Hinter. Elder person. They are mysterious and wise. They know more than they let on..."));
            npcArray.Add("guard", new Npc("Konrad", "The Town Guard Leader. Adult man. He was born to be a leader."));
            npcArray.Add("alchemist", new Npc("Andrea", "The Alchemist. Middle aged woman. She is friendly and welcoming. She sells healing items and potions."));
                npcArray["alchemist"].Trades.Add(items("bandage"), 5);
                npcArray["alchemist"].Trades.Add(items("lesser_heal"), 10);
                npcArray["alchemist"].Trades.Add(items("greater_heal"), 20);
                npcArray["alchemist"].Trades.Add(items("atk_pot"), 30);
                npcArray["alchemist"].Trades.Add(items("def_pot"), 30);
                npcArray["alchemist"].Trades.Add(items("spd_pot"), 30);
                npcArray["alchemist"].Trades.Add(items("bounty_pot"), 50);
            npcArray.Add("blacksmith", new Npc("Owen", "The Blacksmith. Middle aged man. He is gruff and concise. He sells weapons and other gear."));

            return npcArray[item];
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
                try { outp = Convert.ToInt32(Console.ReadLine()); Console.WriteLine(); }
                catch (FormatException) { Console.WriteLine(); outp = Choice(choices); }
                if (outp <= 0 || outp > choices.Length) { outp = Choice(choices); }
                return outp;
            }
            return 0;
        }

        //COMBAT
        static public int Combat(Enemy enemy)
        {
            Console.WriteLine("A{0} {1} approaches", enemy.Name.ToLower()[0] == 'a' || enemy.Name.ToLower()[0] == 'e' ||
                                                        enemy.Name.ToLower()[0] == 'i' || enemy.Name.ToLower()[0] == 'o' ||
                                                        enemy.Name.ToLower()[0] == 'u' ? "n" : "", enemy.Name);
            Console.WriteLine(enemy.Art + "\n");
            System.Threading.Thread.Sleep(500);
            int action = 0;
            int timer = 1;
            while (enemy.Health > 0 && player.Health > 0 && action < 4)
            {
                if (player.Weapon.Speed % timer == 0)
                {
                    Console.WriteLine("{0}'{1} health: {2} | {3}'{4} health: {5}", player.Name, player.Name[0] != 's' ? 's' : "", player.Health, enemy.Name, enemy.Name[0] != 's' ? 's' : "", enemy.Health);
                    System.Threading.Thread.Sleep(500);
                    switch (Choice(new string[] { "Attack", "Defend", "Inspect", "Run" }))
                    {
                        case 1:
                            int atk = Math.Max(player.Weapon.Attack - (int)(enemy.Defense / 2), 0);
                            enemy.Health -= atk;
                            Console.WriteLine("{0} did {1} damage", player.Name, atk);
                            action = 1;
                            break;
                        case 2:
                            Console.WriteLine("{0} defended", player.Name);
                            action = 2;
                            break;
                        case 3:
                            Console.WriteLine("{0}: {1}", enemy.Name, enemy.Description);
                            action = 3;
                            break;
                        case 4:
                            Console.WriteLine("{0} ran away", player.Name);
                            action = 4;
                            break;
                    }
                    Console.WriteLine();
                    System.Threading.Thread.Sleep(500);
                }
                if (enemy.Health > 0 && enemy.Speed % timer == 0)
                {
                    Console.WriteLine("{0}'{1} health: {2} | {3}'{4} health: {5}", player.Name, player.Name[0] != 's' ? 's' : "", player.Health, enemy.Name, enemy.Name[0] != 's' ? 's' : "", enemy.Health);
                    Console.WriteLine("{0} attacked", enemy.Name);
                    System.Threading.Thread.Sleep(500);
                    int atk = Math.Max(enemy.Attack - (int)(action == 2 ? player.Weapon.Defense : player.Weapon.Defense / 2), 0);
                    player.Health -= atk;
                    Console.WriteLine("{0} took {1} damage", player.Name, atk);
                    System.Threading.Thread.Sleep(500);
                }
                timer++;
            }
            if (player.Health < 1) { Console.WriteLine("{0} Died", player.Name); return 0; }
            else if (enemy.Health < 1) { Console.WriteLine("{0} Died", enemy.Name); return 1; }
            else if (action == 4) { return 2; }
            else return 3;
        }
        static public int IntroCombat()
        {
            Enemy enemy = enemies("leon1");
            Console.WriteLine(enemy.Name+" approaches");
            Console.WriteLine(enemy.Art + "\n");
            System.Threading.Thread.Sleep(500);
            int action = 0;
            int timer = 1;
            while (enemy.Health > 0 && player.Health > 0 && action < 4)
            {
                if (player.Weapon.Speed % timer == 0)
                {
                    Console.WriteLine("{0}'{1} health: {2} | {3}'{4} health: {5}", player.Name, player.Name[0] != 's' ? 's' : "", player.Health, enemy.Name, enemy.Name[0] != 's' ? 's' : "", enemy.Health);
                    System.Threading.Thread.Sleep(500);
                    switch (Choice(new string[] { "Attack", "Defend", "Inspect" }))
                    {
                        case 1:
                            int atk = Math.Max(player.Weapon.Attack - (int)(enemy.Defense / 2), 0);
                            enemy.Health -= atk;
                            Console.WriteLine("{0} did {1} damage", player.Name, atk);
                            action = 1;
                            break;
                        case 2:
                            Console.WriteLine("{0} defended", player.Name);
                            action = 2;
                            break;
                        case 3:
                            Console.WriteLine("{0}: {1}", enemy.Name, enemy.Description);
                            action = 3;
                            break;
                    }
                    Console.WriteLine();
                    System.Threading.Thread.Sleep(500);
                }
                if (enemy.Health > 0 && enemy.Speed % timer == 0)
                {
                    Console.WriteLine("{0}'{1} health: {2} | {3}'{4} health: {5}", player.Name, player.Name[0] != 's' ? 's' : "", player.Health, enemy.Name, enemy.Name[0] != 's' ? 's' : "", enemy.Health);
                    Console.WriteLine("{0} attacked", enemy.Name);
                    System.Threading.Thread.Sleep(500);
                    int atk = Math.Max(enemy.Attack - (int)(action == 2 ? player.Weapon.Defense : player.Weapon.Defense / 2), 0);
                    player.Health -= atk;
                    Console.WriteLine("{0} took {1} damage", player.Name, atk);
                    System.Threading.Thread.Sleep(500);
                }
                timer++;
            }
            if (player.Health < 1) { Console.WriteLine("{0} Died", player.Name); return 0; }
            else if (enemy.Health < 1) { Console.WriteLine("{0} Died", enemy.Name); return 1; }
            else if (action == 4) { return 2; }
            else return 3;
        }

        //SHOP
        static public void Shop(Npc npc)
        {
            Say("Welcome to "+ npc.Name + "\'s shop! What would you like to buy?");
            string[] Trades = new string[npc.Trades.Count+1];
            Trades[0] = "Exit Shop";
            for(int i = 0; i < npc.Trades.Count; i++)
            {
                Trades[i+1] = npc.Trades.ElementAt(i).Value+"g: "+npc.Trades.ElementAt(i).Key.Name;
            }
            int choice = 0;
            while (choice != 1)
            {
                choice = Choice(Trades);
                if (choice != 1)
                {
                    Item item = npc.Trades.ElementAt(choice - 1).Key;
                    if (player.HasItem(items("coin"), npc.Trades[item]))
                    {
                        player.PickUpItem(item);
                        player.DropItem(items("coin"), npc.Trades[item]);
                        Say("You now have " + player.Inventory[items("coin")] + " coins");
                    }
                    else Say("You only have " + player.Inventory[items("coin")] + " coins");
                }
            }
        }

        #region MAPS
        static public Map TownMap()
        {
            Map map = new Map(11, 11);
            map.initialize();

            map.pieceDirection(0, 3, Direction.South, false);

            map.pieceDirection(1, 0, Direction.East, false);
            map.pieceDirection(1, 1, Direction.East, false);
            map.pieceDirection(1, 2, Direction.East, false);
            map.pieceDirection(1, 4, Direction.North, false);
            map.pieceDirection(1, 8, Direction.North, false);
            map.pieceDirection(1, 8, Direction.West, false);
            map.pieceDirection(1, 9, Direction.West, false);
            map.pieceDirection(1, 9, Direction.South, false);

            map.pieceDirection(2, 1, Direction.South, false);
            map.pieceDirection(2, 2, Direction.West, false);
            map.pieceDirection(2, 8, Direction.East, false);
            map.pieceDirection(2, 9, Direction.East, false);
            map.pieceDirection(2, 9, Direction.South, false);

            map.pieceDirection(4, 0, Direction.East, false);
            map.pieceDirection(4, 1, Direction.East, false);
            map.pieceDirection(4, 1, Direction.South, false);

            map.pieceDirection(5, 8, Direction.East, false);
            map.pieceDirection(5, 9, Direction.East, false);
            map.pieceDirection(5, 10, Direction.East, false);

            map.pieceDirection(8, 0, Direction.West, false);
            map.pieceDirection(8, 1, Direction.West, false);

            map.pieceDirection(9, 0, Direction.East, false);
            map.pieceDirection(9, 1, Direction.East, false);
            map.pieceDirection(9, 2, Direction.North, false);
            map.pieceDirection(9, 2, Direction.West, false);
            map.pieceDirection(9, 4, Direction.West, false);
            map.pieceDirection(9, 4, Direction.South, false);
            map.pieceDirection(9, 8, Direction.East, false);
            map.pieceDirection(9, 9, Direction.East, false);
            map.pieceDirection(9, 10, Direction.East, false);

            map.pieceDirection(10, 2, Direction.North, false);
            map.pieceDirection(10, 4, Direction.South, false);

            return map;
        }

        static public Map RuinsMap()
        {
            Map map = new Map(11, 11);
            map.initialize();

            map.pieceDirection(0, 1, Direction.East, false);
            map.pieceDirection(0, 2, Direction.East, false);
            map.pieceDirection(0, 3, Direction.East, false);
            map.pieceDirection(0, 4, Direction.East, false);
            map.pieceDirection(0, 5, Direction.East, false);
            map.pieceDirection(0, 6, Direction.East, false);
            map.pieceDirection(0, 7, Direction.East, false);
            map.pieceDirection(0, 8, Direction.East, false);
            map.pieceDirection(0, 9, Direction.East, false);

            map.pieceDirection(1, 0, Direction.South, false);
            map.pieceDirection(1, 2, Direction.East, false);
            map.pieceDirection(1, 3, Direction.East, false);
            map.pieceDirection(1, 4, Direction.East, false);
            map.pieceDirection(1, 5, Direction.East, false);
            map.pieceDirection(1, 6, Direction.South, false);
            map.pieceDirection(1, 8, Direction.East, false);
            map.pieceDirection(1, 8, Direction.South, false);
            map.pieceDirection(1, 9, Direction.South, false);

            map.pieceDirection(2, 0, Direction.South, false);
            map.pieceDirection(2, 1, Direction.South, false);
            map.pieceDirection(2, 2, Direction.East, false);
            map.pieceDirection(2, 4, Direction.East, false);
            map.pieceDirection(2, 5, Direction.East, false);
            map.pieceDirection(2, 7, Direction.East, false);
            map.pieceDirection(2, 9, Direction.East, false);
            map.pieceDirection(2, 9, Direction.South, false);

            map.pieceDirection(3, 0, Direction.South, false);
            map.pieceDirection(3, 1, Direction.East, false);
            map.pieceDirection(3, 4, Direction.East, false);
            map.pieceDirection(3, 5, Direction.South, false);
            map.pieceDirection(3, 6, Direction.East, false);
            map.pieceDirection(3, 7, Direction.South, false);
            map.pieceDirection(3, 8, Direction.East, false);
            map.pieceDirection(3, 9, Direction.South, false);

            map.pieceDirection(4, 0, Direction.South, false);
            map.pieceDirection(4, 1, Direction.East, false);
            map.pieceDirection(4, 2, Direction.South, false);
            map.pieceDirection(4, 2, Direction.East, false);
            map.pieceDirection(4, 3, Direction.South, false);
            map.pieceDirection(4, 6, Direction.South, false);
            map.pieceDirection(4, 8, Direction.South, false);
            map.pieceDirection(4, 8, Direction.East, false);
            map.pieceDirection(4, 9, Direction.South, false);

            map.pieceDirection(5, 0, Direction.South, false);
            map.pieceDirection(5, 2, Direction.East, false);
            map.pieceDirection(5, 3, Direction.South, false);
            map.pieceDirection(5, 3, Direction.East, false);
            map.pieceDirection(5, 6, Direction.South, false);
            map.pieceDirection(5, 7, Direction.East, false);
            map.pieceDirection(5, 8, Direction.East, false);
            map.pieceDirection(5, 9, Direction.South, false);

            map.pieceDirection(6, 0, Direction.South, false);
            map.pieceDirection(6, 2, Direction.South, false);
            map.pieceDirection(6, 3, Direction.South, false);
            map.pieceDirection(6, 4, Direction.East, false);
            map.pieceDirection(6, 5, Direction.East, false);
            map.pieceDirection(6, 6, Direction.South, false);
            map.pieceDirection(6, 6, Direction.East, false);
            map.pieceDirection(6, 8, Direction.East, false);
            map.pieceDirection(6, 9, Direction.East, false);
            map.pieceDirection(6, 9, Direction.South, false);

            map.pieceDirection(7, 0, Direction.South, false);
            map.pieceDirection(7, 1, Direction.South, false);
            map.pieceDirection(7, 1, Direction.East, false);
            map.pieceDirection(7, 3, Direction.East, false);
            map.pieceDirection(7, 4, Direction.East, false);
            map.pieceDirection(7, 5, Direction.East, false);
            map.pieceDirection(7, 7, Direction.South, false);
            map.pieceDirection(7, 7, Direction.East, false);
            map.pieceDirection(7, 8, Direction.South, false);
            map.pieceDirection(7, 9, Direction.South, false);

            map.pieceDirection(8, 0, Direction.South, false);
            map.pieceDirection(8, 2, Direction.East, false);
            map.pieceDirection(8, 3, Direction.East, false);
            map.pieceDirection(8, 4, Direction.South, false);
            map.pieceDirection(8, 5, Direction.South, false);
            map.pieceDirection(8, 6, Direction.East, false);
            map.pieceDirection(8, 7, Direction.East, false);
            map.pieceDirection(8, 8, Direction.East, false);
            map.pieceDirection(8, 9, Direction.South, false);

            map.pieceDirection(9, 0, Direction.South, false);
            map.pieceDirection(9, 1, Direction.East, false);
            map.pieceDirection(9, 2, Direction.East, false);
            map.pieceDirection(9, 3, Direction.East, false);
            map.pieceDirection(9, 3, Direction.South, false);
            map.pieceDirection(9, 4, Direction.East, false);
            map.pieceDirection(9, 6, Direction.East, false);
            map.pieceDirection(9, 7, Direction.East, false);
            map.pieceDirection(9, 8, Direction.East, false);
            map.pieceDirection(9, 9, Direction.East, false);
            map.pieceDirection(9, 9, Direction.South, false);

            map.pieceDirection(10, 4, Direction.South, false);
            map.pieceDirection(10, 5, Direction.South, false);

            for(int i = 1; i <= 9; i++) for (int j = 1; j <= 9; j++) map.cells[i, j].EnemySpawn = true;
            for (int i = 4; i <= 6; i++) for (int j = 4; j <= 6; j++) map.cells[i, j].EnemySpawn = false;
            map.cells[4, 9].EnemySpawn = false;
            map.cells[5, 8].EnemySpawn = false;
            map.cells[5, 9].EnemySpawn = false;
            map.cells[6, 9].EnemySpawn = false;

            map.Enemies = new Enemy[] { enemies("elemental"), enemies("goblin") };

            return map;
        }

        static public Map ForestMap()
        {
            Map map = new Map(11, 11);
            map.initialize();

            map.pieceDirection(0, 2, Direction.South, false);
            map.pieceDirection(0, 3, Direction.East, false);
            map.pieceDirection(0, 4, Direction.East, false);
            map.pieceDirection(0, 5, Direction.East, false);

            map.pieceDirection(1, 2, Direction.East, false);
            map.pieceDirection(1, 5, Direction.South, false);
            map.pieceDirection(1, 7, Direction.East, false);
            map.pieceDirection(1, 8, Direction.East, false);

            map.pieceDirection(2, 1, Direction.South, false);
            map.pieceDirection(2, 2, Direction.South, false);
            map.pieceDirection(2, 3, Direction.East, false);
            map.pieceDirection(2, 5, Direction.South, false);
            map.pieceDirection(2, 6, Direction.South, false);
            map.pieceDirection(2, 8, Direction.South, false);

            map.pieceDirection(3, 1, Direction.South, false);
            map.pieceDirection(3, 2, Direction.East, false);
            map.pieceDirection(3, 3, Direction.South, false);
            map.pieceDirection(3, 3, Direction.East, false);
            map.pieceDirection(3, 4, Direction.East, false);
            map.pieceDirection(3, 7, Direction.East, false);
            map.pieceDirection(3, 10, Direction.East, false);

            map.pieceDirection(4, 3, Direction.South, false);
            map.pieceDirection(4, 4, Direction.South, false);
            map.pieceDirection(4, 4, Direction.East, false);
            map.pieceDirection(4, 6, Direction.South, false);
            map.pieceDirection(4, 6, Direction.East, false);
            map.pieceDirection(4, 7, Direction.South, false);

            map.pieceDirection(5, 2, Direction.East, false);
            map.pieceDirection(5, 3, Direction.East, false);
            map.pieceDirection(5, 4, Direction.East, false);
            map.pieceDirection(5, 5, Direction.South, false);
            map.pieceDirection(5, 5, Direction.East, false);
            map.pieceDirection(5, 6, Direction.East, false);
            map.pieceDirection(5, 7, Direction.South, false);
            map.pieceDirection(5, 7, Direction.East, false);

            map.pieceDirection(6, 1, Direction.South, false);
            map.pieceDirection(6, 1, Direction.East, false);
            map.pieceDirection(6, 3, Direction.East, false);
            map.pieceDirection(6, 4, Direction.East, false);
            map.pieceDirection(6, 5, Direction.South, false);
            map.pieceDirection(6, 6, Direction.East, false);
            map.pieceDirection(6, 10, Direction.East, false);

            map.pieceDirection(7, 0, Direction.South, false);
            map.pieceDirection(7, 2, Direction.South, false);
            map.pieceDirection(7, 2, Direction.East, false);
            map.pieceDirection(7, 4, Direction.South, false);
            map.pieceDirection(7, 5, Direction.East, false);
            map.pieceDirection(7, 6, Direction.South, false);
            map.pieceDirection(7, 7, Direction.East, false);
            map.pieceDirection(7, 9, Direction.South, false);

            map.pieceDirection(8, 0, Direction.South, false);
            map.pieceDirection(8, 1, Direction.South, false);
            map.pieceDirection(8, 5, Direction.South, false);
            map.pieceDirection(8, 6, Direction.East, false);
            map.pieceDirection(8, 7, Direction.South, false);
            map.pieceDirection(8, 7, Direction.East, false);
            map.pieceDirection(8, 9, Direction.South, false);
            map.pieceDirection(8, 9, Direction.East, false);

            map.pieceDirection(9, 0, Direction.South, false);
            map.pieceDirection(9, 0, Direction.East, false);
            map.pieceDirection(9, 1, Direction.South, false);
            map.pieceDirection(9, 2, Direction.East, false);
            map.pieceDirection(9, 3, Direction.East, false);
            map.pieceDirection(9, 7, Direction.East, false);
            map.pieceDirection(9, 8, Direction.South, false);
            map.pieceDirection(9, 8, Direction.East, false);

            map.pieceDirection(10, 3, Direction.South, false);
            map.pieceDirection(10, 6, Direction.South, false);

            for (int i = 3; i <= 10; i++) for (int j = 0; j <= 5; j++) map.cells[i, j].EnemySpawn = true;
            for (int i = 5; i <= 10; i++) for (int j = 6; j <= 10; j++) map.cells[i, j].EnemySpawn = true;
            map.cells[4, 10].EnemySpawn = true;

            map.Enemies = new Enemy[] { enemies("bees"), enemies("bees"), enemies("bear") };

            return map;
        }

        static public Map LakeMap()
        {
            Map map = new Map(11, 11);
            map.initialize();

            map.pieceDirection(2, 0, Direction.South, false);
            map.pieceDirection(2, 0, Direction.West, false);
            map.pieceDirection(3, 0, Direction.South, false);
            map.pieceDirection(3, 0, Direction.East, false);

            map.pieceDirection(4, 0, Direction.East, false);
            map.pieceDirection(4, 1, Direction.South, false);
            map.pieceDirection(4, 1, Direction.East, false);
            map.pieceDirection(3, 2, Direction.East, false);
            map.pieceDirection(3, 3, Direction.East, false);
            map.pieceDirection(3, 3, Direction.South, false);
            map.pieceDirection(2, 4, Direction.East, false);
            map.pieceDirection(2, 4, Direction.South, false);
            map.pieceDirection(1, 5, Direction.East, false);
            map.pieceDirection(1, 6, Direction.East, false);
            map.pieceDirection(1, 6, Direction.South, false);
            map.pieceDirection(0, 7, Direction.East, false);
            map.pieceDirection(0, 7, Direction.South, false);

            map.pieceDirection(7, 10, Direction.West, false);
            map.pieceDirection(7, 9, Direction.West, false);
            map.pieceDirection(7, 8, Direction.West, false);
            map.pieceDirection(7, 8, Direction.North, false);
            map.pieceDirection(8, 7, Direction.West, false);
            map.pieceDirection(8, 6, Direction.West, false);
            map.pieceDirection(8, 6, Direction.North, false);
            map.pieceDirection(9, 5, Direction.West, false);
            map.pieceDirection(9, 5, Direction.North, false);
            map.pieceDirection(10, 4, Direction.West, false);
            map.pieceDirection(10, 4, Direction.North, false);

            for (int i = 8; i <= 10; i++) for (int j = 0; j <= 6; j++) map.cells[i, j].EnemySpawn = true;
            for (int i = 0; i <= 3; i++) for (int j = 5; j <= 10; j++) map.cells[i, j].EnemySpawn = true;
            for (int i = 5; i <= 7; i++) for (int j = 2; j <= 7; j++) map.cells[i, j].EnemySpawn = true;
            for (int i = 2; i <= 4; i++) for (int j = 4; j <= 9; j++) map.cells[i, j].EnemySpawn = true;
            map.cells[4, 3].EnemySpawn = true; map.cells[4, 3].EnemySpawn = true; map.cells[5, 8].EnemySpawn = true; map.cells[7, 1].EnemySpawn = true;

            map.Enemies = new Enemy[] { enemies("slime"), enemies("slime"), enemies("shark") };

            return map;
        }

        static public Map GateMap()
        {
            Map map = new Map(11, 11);
            map.initialize();

            map.pieceDirection(2, 1, Direction.South, false);
            map.pieceDirection(5, 1, Direction.South, false);
            map.pieceDirection(8, 1, Direction.South, false);
            map.pieceDirection(1, 3, Direction.South, false);
            map.pieceDirection(2, 3, Direction.South, false);
            map.pieceDirection(3, 3, Direction.South, false);
            map.pieceDirection(8, 3, Direction.East, false);
            map.pieceDirection(8, 4, Direction.East, false);
            map.pieceDirection(1, 5, Direction.East, false);
            map.pieceDirection(1, 6, Direction.East, false);
            map.pieceDirection(2, 5, Direction.South, false);
            map.pieceDirection(6, 5, Direction.South, false);
            map.pieceDirection(7, 5, Direction.South, false);
            map.pieceDirection(9, 6, Direction.South, false);
            map.pieceDirection(0, 7, Direction.South, false);
            map.pieceDirection(1, 7, Direction.South, false);
            map.pieceDirection(2, 7, Direction.South, false);
            map.pieceDirection(3, 7, Direction.South, false);
            map.pieceDirection(4, 7, Direction.South, false);
            map.pieceDirection(6, 7, Direction.South, false);
            map.pieceDirection(7, 7, Direction.South, false);
            map.pieceDirection(8, 7, Direction.South, false);
            map.pieceDirection(9, 7, Direction.South, false);
            map.pieceDirection(10, 7, Direction.South, false);

            map.Enemies = new Enemy[] { enemies("goblin"), enemies("armor") };

            return map;
        }

        static public Map Fortress1Map()
        {
            Map map = new Map(9, 9);
            map.initialize();

            map.pieceDirection(0, 1, Direction.South, false);
            map.pieceDirection(0, 1, Direction.East, false);
            map.pieceDirection(1, 0, Direction.South, false);
            map.pieceDirection(1, 0, Direction.East, false);

            map.pieceDirection(0, 7, Direction.North, false);
            map.pieceDirection(0, 7, Direction.East, false);
            map.pieceDirection(1, 8, Direction.North, false);
            map.pieceDirection(1, 8, Direction.East, false);

            map.pieceDirection(7, 0, Direction.South, false);
            map.pieceDirection(7, 0, Direction.West, false);
            map.pieceDirection(8, 1, Direction.South, false);
            map.pieceDirection(8, 1, Direction.West, false);

            map.pieceDirection(7, 8, Direction.North, false);
            map.pieceDirection(7, 8, Direction.West, false);
            map.pieceDirection(8, 7, Direction.North, false);
            map.pieceDirection(8, 7, Direction.West, false);

            map.pieceDirection(3, 2, Direction.North, false);
            map.pieceDirection(3, 2, Direction.West, false);
            map.pieceDirection(3, 2, Direction.South, false);
            map.pieceDirection(4, 2, Direction.North, false);
            map.pieceDirection(4, 2, Direction.South, false);
            map.pieceDirection(5, 2, Direction.North, false);
            map.pieceDirection(5, 2, Direction.East, false);
            map.pieceDirection(5, 2, Direction.South, false);

            map.pieceDirection(3, 6, Direction.North, false);
            map.pieceDirection(3, 6, Direction.West, false);
            map.pieceDirection(3, 6, Direction.South, false);
            map.pieceDirection(4, 6, Direction.North, false);
            map.pieceDirection(4, 6, Direction.South, false);
            map.pieceDirection(5, 6, Direction.North, false);
            map.pieceDirection(5, 6, Direction.East, false);
            map.pieceDirection(5, 6, Direction.South, false);

            map.pieceDirection(1, 4, Direction.North, false);
            map.pieceDirection(1, 4, Direction.West, false);
            map.pieceDirection(1, 4, Direction.South, false);
            map.pieceDirection(2, 4, Direction.North, false);
            map.pieceDirection(2, 4, Direction.East, false);
            map.pieceDirection(2, 4, Direction.South, false);
            map.pieceDirection(6, 4, Direction.North, false);
            map.pieceDirection(6, 4, Direction.West, false);
            map.pieceDirection(6, 4, Direction.South, false);
            map.pieceDirection(7, 4, Direction.North, false);
            map.pieceDirection(7, 4, Direction.East, false);
            map.pieceDirection(7, 4, Direction.South, false);

            map.Enemies = new Enemy[] { enemies("armor"), enemies("armor"), enemies("armor"), enemies("wyvern") };

            return map;
        }

        static public Map Fortress2Map()
        {
            Map map = Fortress1Map();

            map.Enemies = new Enemy[] { enemies("armor"), enemies("wyvern"), enemies("wyvern") };

            return map;
        }

        static public Map Fortress3Map()
        {
            Map map = new Map(9, 9);
            map.initialize();

            map.pieceDirection(0, 1, Direction.South, false);
            map.pieceDirection(0, 1, Direction.East, false);
            map.pieceDirection(1, 0, Direction.South, false);
            map.pieceDirection(1, 0, Direction.East, false);

            map.pieceDirection(0, 7, Direction.North, false);
            map.pieceDirection(0, 7, Direction.East, false);
            map.pieceDirection(1, 8, Direction.North, false);
            map.pieceDirection(1, 8, Direction.East, false);

            map.pieceDirection(7, 0, Direction.South, false);
            map.pieceDirection(7, 0, Direction.West, false);
            map.pieceDirection(8, 1, Direction.South, false);
            map.pieceDirection(8, 1, Direction.West, false);

            map.pieceDirection(7, 8, Direction.North, false);
            map.pieceDirection(7, 8, Direction.West, false);
            map.pieceDirection(8, 7, Direction.North, false);
            map.pieceDirection(8, 7, Direction.West, false);

            return map;
        }
        #endregion

        static public void Say(string inp)
        {
            foreach( char c in inp )
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(33);
            }
            Console.WriteLine();
            System.Threading.Thread.Sleep(333);
        }

        static public void Walk(ref Map map)
        {
            Console.WriteLine("\nWhich way would you like to go?");
            switch (Choice(new string[] { "North", "East", "South", "West", "Show Inventory" }))
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
                    player.PrintInv();
                    break;
                default: Say("Something went wrong! </3"); break;
            }
        }

        static void Main(string[] args)
        {
            Map[] maps = new Map[] { TownMap(), RuinsMap(), ForestMap(), LakeMap(), GateMap(), Fortress1Map(), Fortress2Map(), Fortress3Map() }; 
            Map map;

            #region INTRO
            Console.Write("press enter to start "); Console.ReadKey();

            Say("What a great morning,\" you think to yourself.");
            Say("As you sip your tea, a letter slides under your door.");
            Say("You pick it up and open it. It reads:\n");
            Say("     \"Hey, friend!");
            Say("  Training yesterday was really fun. I'm looking\n" +
                "  forward to it today! The town guard leader said \n" +
                "  that he has some exciting news for us today. I\n" +
                "  hope everything goes well. Meet me at the Training\n" +
                "  Grounds asap. See you soon!");
            Say("      Regards, Leon\"\n");
            Say("You look at the clock.");
            Say("\"Oh no, it's almost time for training to start!\" you say to yourself.");
            Say("You finish your tea and rush out the door.\n");
            System.Threading.Thread.Sleep(500);

            map = maps[0];
            map.X = 2; map.Y = 7;
            map.print();
            Say("\nYou're west of the Training Grounds.");

            while (true)
            {
                Walk(ref map);
                if (map.X > 5 && map.X < 10 && map.Y > 7) break;
            }

            Say("\nYou arrive at the training grounds.");
            Say("You whisper to Leon, \"Did I miss anything?\"");
            Say("\"You're right on time!\" he whispers back.");
            Say("\"Hello future town guards. How is everyone today?\" says a loud voice from the front of the training grounds.");
            Say("\"Good, sir,\" everyone responds.");
            Say("\"To of you who may not know, I am Konrad. I lead the town guard and this is my training class.\"");
            Say("\"Today will have the same schedule as yesterday. To start we will all partner up and practice combat.\nEveryone find a partner.\"");
            Say("He goes around the training grounds and make sure that everyone has a partner. He walks up to you and Leon.");
            Say("\"Are you two partners?\" he asks.");
            Say("\"Yes, sir,\" Leon responds.");
            Say("\"Good, I'll write that down. \'Leon and...\'\n What is your name again?\" He points to you.\n");
            foreach (char c in "Input your name: ") { Console.Write(c); System.Threading.Thread.Sleep(33); }
            player.Name = Console.ReadLine();
            Say("\n\"" + player.Name + ". My name is " + player.Name + ",\" you say.");
            Say("\"Thank you, " + player.Name + ". I believe that is everyone. Let the combat commence,\" he says.");
            Say("Both you and Leon take out your training staffs and start.");
            player.PickUpItem(items("staff"));
            player.Weapon = (Weapon)items("staff");
            Combat(enemies("leon1"));

            //PLAY LEON SOUND

            Say("You slip and you accidentally pierce Leon's chest with your training staff.");
            Say("\"OH MY GOD LEON I'M SO SORRY,\" you cry to him.");
            Say("\"QUICK, RUN TO THE ALCHEMIST'S SHOP AND BUY SOME BANDAGES AND HEALING POTIONS,\" Konrad yells at you. This makes you drop your staff.");
            player.DropItem(items("staff"));
            player.Weapon = null;
            Say("He hands you some money and you rush off the Training Grounds to the Alchemist's Shop.\n");
            player.PickUpItem(items("coin"), 15);

            System.Threading.Thread.Sleep(500);

            map.X = 6; map.Y = 7;
            map.print();
            Say("\nYou're southeast of the Alchemist's Shop.");

            while (true)
            {
                Walk(ref map);
                if (map.X == 3 && map.Y == 1) break;
            }

            Say("\nYou arrive at the Alchemist's Shop");
            Say("You run through the door and say to the Alchemist behind the counter,\n\"My friend got hurt. I need some bandages or healing potions.\"");
            Say("\"Oh I'm so sorry! Well, I have a great selection of items right here. My name is Andrea, by the way,\" she responds.");

            //Shop(npcs("alchemist"));

            Say("She gives you a Bandage and and a Lesser Healing Potion");
            Say("\"Thank you so much,\" you say.");
            Say("\"Any time!\" she responds.");
            Say("You rush back to the Training Grounds\n");

            map.X = 3; map.Y = 2;
            map.print();
            Say("\nYou're northwest of the Training Grounds.");

            while (true)
            {
                Walk(ref map);
                if (map.X > 5 && map.X < 10 && map.Y > 7) break;
            }

            Say("\nYou arrive at the training grounds.");
            Say("\"You were too late. He's gone, " + player.Name + ",\" Konrad says to you.");
            Say("\"Class is over early everyone. Head home.\"");
            Say("\"Wait! The boy! I can help the boy!\" you hear an old voice call from far behind you.");
            Say("\"Who said that?\" you turn around, confused.");
            Say("\"I did,\" the voice says now right behind you.");
            Say("You turn around, now startled. Right in front of you is the Hinter.");
            Say("\"Hello, I am Sonal, the Hinter. I can bring the boy back. Leon, I mean,\" they say.");
            Say("\"The Hin- wait you can bring him back to life?!\" you ask.");
            Say("\"Well, yes,\" they say. \"I can help him. If you trust me with him, I can assure that you will get your friend back.\"");
            Say("\"How do I know I can trust you?\" you say suspiciously.");
            Say("\"Believe me,\" they respond. \"I am the only person who can do this. I will bring your friend back.\"");
            Say("\".\b..\b..\b.Okay. I trust you. Please just help him.\" You hand Sonal Leon's lifeless body and turn away.");
            Say("\"You won't regret this. Thank you, "+player.Name+".\" they say to you.");
            Say("\"Wait I never told you my na-\" You turn around but Sonal and Leon's body have disappeared.");
            System.Threading.Thread.Sleep(500);
            Say("\nYou make your way back home and vow to yourself that you will never wield a weapon again.");
            System.Threading.Thread.Sleep(1000);
            Say("\nthe next morning you wake up with your mind on what you did to leon. You can't shake it from your conscience.");
            Say("\nAs you go downstairs and make your way to the kitchen, you notice a letter slid in under your door. It reads:\n");
            Say("     \""+player.Name+",");
            Say("  I apologise for the events of yesterday. Things got\n" +
                "  out of hand and I'm sure you need some time to take \n" +
                "  it all in, so training today has been cancelled. This\n" +
                "  being said, I need your help with something. A  \n" +
                "  mysterious storm has appeared above the Fortress near\n" +
                "  our town. I need someone to check it out, and you are\n" +
                "  are the only guard in training capable enough to make\n" +
                "  your way to the top. You'll need to stop by the\n" +
                "  Blacksmith before you head off. He will tell you more.");
            Say("      Regards, Konrad\"\n");
            Say("Cringechamp.");
            Say("\nSorry the demo is over lol");

            #endregion
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
        private bool _enemyspawn = false;
        private bool _trigger = false;
        private string _event;

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
        public bool EnemySpawn
        {
            get { return _enemyspawn; }
            set { _enemyspawn = value; }
        }
        public bool Trigger
        {
            get { return _trigger; }
            set { _trigger = value; }
        }
        public string Event
        {
            get { return _event; }
            set { _event = value; }
        }
    }
    class Map
    {
        public Cell[,] cells;
        private int x = 0;
        private int y = 0;
        bool _show = true;
        Enemy[] _enemies = { };
        //char model = '\x0D9E';
        char model = '@';
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
        public Enemy[] Enemies
            {
                get { return _enemies; }
                set { _enemies = value; }
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
                        makeMap(cells[i, j]);
                    }
                }
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
                    case Direction.West:
                        if (toggle)
                        {
                            cells[y, x].West = cells[y, x - 1];
                            cells[y, x - 1].East = cells[y, x];
                        }
                        else
                        {
                            cells[y, x].West = null;
                            cells[y, x - 1].East = null;
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
                            cells[y, x + 1].West = null;
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
                        else { Console.WriteLine("You can't go north"); }
                        break;
                    case Direction.South:
                        if (cells[y, x].South != null)
                        {
                            cells[y, x].Data = makeMap(cells[y, x]); cells[y + 1, x].Data = model; y++;
                            print();
                        }
                        else { Console.WriteLine("You can't go south"); }
                        break;
                    case Direction.East:
                        if (cells[y, x].East != null)
                        {
                            cells[y, x].Data = makeMap(cells[y, x]); cells[y, x + 1].Data = model; x++;
                            print();
                        }
                        else { Console.WriteLine("You can't go east"); }
                        break;
                    case Direction.West:
                        if (cells[y, x].West != null)
                        {
                            cells[y, x].Data = makeMap(cells[y, x]); cells[y, x - 1].Data = model; x--;
                            print();
                        }
                        else { Console.WriteLine("You can't go west"); }
                        break;
                }
                if (cells[y, x].Trigger) this.GetType().GetMethod(cells[y, x].Event).Invoke(this, null); ;
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
                        if (i == Y && j == X) Console.Write(model);
                        else Console.Write(makeMap(cells[i, j]));
                        if (cells[i, j].East != null) Console.Write('═'); else Console.Write(' ');
                    }
                    Console.WriteLine("");
                }

            }

        }
        public void print(int x)
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
        public void reveal()
            {
                cells[Y, X].Data = model;
                if (_show)
                {
                    for (int i = 0; i < cells.GetLength(0); i++)
                    {
                        for (int j = 0; j < cells.GetLength(1); j++)
                        {

                            Console.Write(makeMap(cells[i, j]));
                            if (cells[i, j].East != null) Console.Write('═'); else Console.Write(' ');
                        }
                        Console.WriteLine("");
                    }

                }

            }
    }
}
