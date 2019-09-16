using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace rpgInventory
{
    public class items
    {
        // a struct to hold the item and all its data.
        public struct Item
        {
            public string name;
            public string type;
            public int attack;
            public int cost;
            //a constructor to create each individual item
            public Item(string a, string b, int c, int d)
            {
                name = a;
                type = b;
                attack = c;
                cost = d;

            }
        }
    }

    //a class holding all the weapons
    public class weapons : items
    {

        //weapons class:child class of items
        public static void printWeapons()
        {
            Console.WriteLine("Weapons: ");
            using (StreamReader sr = new StreamReader("weapons.csv"))
            {
                string line;
                //reads and displays all the weapons in the store that have data 
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
                sr.Close();
                
            }
        }


    }
    public class potions : items
    {
        //potions class:child class of items
        public static void printPotions()
        {
            Console.WriteLine("Potions: ");
            //reads and displays all the potions in the store
            using (StreamReader sr = new StreamReader("potions.csv"))
            {
                string line;
               
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
                sr.Close();
                
            }
        }

    }

    



    
}
