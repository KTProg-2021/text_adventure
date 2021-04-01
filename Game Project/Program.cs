using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Project
{
    class Program
    {
        //PLAYER    
        static public Player player = new Player();

        //ITEM BANK
        static public Item items(string item)
        {
            Dictionary<string, Item> itemArray = new Dictionary<string, Item>();
            itemArray.Add("staff", new Weapon("Training Staff", "A strong sword with high attack and low defense", 8, 8, 8));
            itemArray.Add("wood_axe", new Weapon("Woodcutter's Axe", "A small axe with high defense and low speed", 8, 12, 3));
            itemArray.Add("sword", new Weapon("Sword", "A strong sword with high attack and low defense", 15, 5, 10));
            itemArray.Add("axe", new Weapon("Axe", "A large axe with high defense and low speed", 10, 15, 5));
            itemArray.Add("spear", new Weapon("Spear", "A long spear with high speed and low attack", 5, 10, 15));
            itemArray.Add("blade", new Weapon("Water Blade", "A strong sword with high attack and low defense", 25, 15, 20));
            itemArray.Add("labrys", new Weapon("Minotaur's Labrys", "A double headed axe with high defense and low speed", 20, 25, 15));
            itemArray.Add("branch", new Weapon("Branch Staff", "A long spear with high speed and low attack", 15, 20, 25));
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
            enemyArray.Add("shark", new Enemy("Shark", "A hungry, hostile shark with high attack and low defense", 15, 5, 10, 2, "lake"));
            enemyArray.Add("bees", new Enemy("Swarm of Bees", "A cluster of angry bees with high speed and low attack", 5, 10, 15, 2, "forest"));
            enemyArray.Add("bear", new Enemy("Bear", "A large brown bear with high attack and low speed", 15, 10, 5, 2, "forest"));
            enemyArray.Add("elemental", new Enemy("Elemental", "A ruined elemental with high defense and low speed", 10, 15, 5, 2, "ruins"));
            enemyArray.Add("goblin", new Enemy("Goblin", "A ruffian goblin with high speed and low defense", 10, 5, 15, 2, "ruins"));
            enemyArray.Add("armor", new Enemy("Haunted Armor", "A possessed set of knight's armor with high attack and low defense", 15, 5, 10, 2, "fortress"));
            enemyArray.Add("wyvern", new Enemy("Wyvern", "A large angry wyvern with high defense and low attack", 5, 15, 10, 2, "fortress"));
            enemyArray.Add("spirit", new Enemy("Water Spirit", "The sassy and mischevious spirit haunting the lake who has high attack and low defense", 5, 15, 10, 2, "lake"));
            enemyArray.Add("ent", new Enemy("Ent", "The telepathic and wise tree creature residing in the forest who has high speed and low attack", 5, 15, 10, 2, "forest"));
            enemyArray.Add("minotaur", new Enemy("Minotaur", "The gruff and angry man bull lost in the ruins who has high defense and low speed", 5, 15, 10, 2, "ruins"));
            enemyArray.Add("leon2", new Enemy("Leon", "lelon dead lol", 10, 10, 10, 2, "fortress"));

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
                            break;
                        case 3:
                            Console.WriteLine("{0}: {1}", enemy.Name, enemy.Description);
                            break;
                        case 4:
                            ran = true;
                            Console.WriteLine("{0} ran away", player.Name);
                            break;
                    }
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
            player.Weapon = (Weapon)items("blade");
            Combat(enemies("bear"));
        }
    }
}
