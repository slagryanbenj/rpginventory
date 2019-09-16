using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static rpgInventory.items;
using item1 = rpgInventory.items.Item;
using System.IO;

namespace rpgInventory
{
    class store
    {
        //initializes the arrays that hold the weapon and one to hold the potions
        public static item1[] shopKeep1 = new item1[100];
        public static item1[] shopKeep2 = new item1[100];

        //initializes the store 
        public void setStore()
        {
            int count = 0;
            //reading from a file and iterating through that file
            using (StreamReader sr = new StreamReader("weapons.csv"))
            {


                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine(); 
                    string[] val = line.Split(','); // puts the current line into an array of strings seperated by the commas
                    Item tmp = new Item();//initialize a temp item
                    tmp.name = val[1]; // set the valuse of the temp item
                    tmp.type = val[2];
                    tmp.attack = Int32.Parse(val[3]);
                    tmp.cost = Int32.Parse(val[4]);

                    shopKeep1[count++] = tmp; //puts the temp item into the store array of weapons
                    

                }
               


            }
            count = 0;
            using (StreamReader sr = new StreamReader("potions.csv"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] val = line.Split(','); // seperates the line of a file by its commas and puts it into an array
                    Item tmp = new Item();//initialize a temp item
                    tmp.name = val[1];//initialize the values of the temp item
                    tmp.type = val[2];
                    tmp.attack = Int32.Parse(val[3]);
                    tmp.cost = Int32.Parse(val[4]);

                    shopKeep2[count++] = tmp;// putes the temp item into the store array of potions


                }
            }

          
        }

        public void printStore()
        {
            Console.WriteLine("Name,   Type,   Description,   Cost");
            Console.WriteLine("Weapons: ");
            for(int i = 0; i < 100; i++)
            {
                if(shopKeep1[i].cost != 0)
                {
                    //prints the current weapon to the screen in a readable format
                    Console.WriteLine($"{shopKeep1[i].name} {shopKeep1[i].type} {shopKeep1[i].attack} {shopKeep1[i].cost}");
                    

                }

                
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("Potions: ");
            for(int i = 0; i < 100; i++)
            {
                if(shopKeep2[i].cost != 0)
                {
                    //prints the current potion to the screen in a readable format
                    Console.WriteLine($"{shopKeep2[i].name} {shopKeep2[i].type} {shopKeep2[i].attack} {shopKeep2[i].cost}");

                }
            }
        }
        
        //a function that allows the user to buy a weapon
        public static void buyWeapon(int _val)
        {
            //puts the intended weapon into the players weapon array
            player.purchasedWeapon(shopKeep1[_val -1]);
            player.playerFunds -= shopKeep1[_val - 1].cost; // subtracts the cost from the users funds
            for (int i = _val; i < 100; i++)
            {
                if(i != 99)
                {
                    shopKeep1[i - 1] = shopKeep1[i];// moves the weapons in the store array forward to "Erase" the weapon that was sold

                }
            }
            int count = 0;
            //updates the csv file
            using (StreamWriter sw = new StreamWriter("weapons.csv"))
            {
                while (shopKeep1[count].type == "Weapon")
                {

                    sw.WriteLine($"{count + 1},{shopKeep1[count].name},{shopKeep1[count].type},{shopKeep1[count].attack}, {shopKeep1[count].cost}");


                    count++;
                }
                sw.Close();
            }
            
        }
        
        // a function that allows the user to buy a potion
        public static void buyPotion(int _val)
        {
            //add the potion to the players potion array
            player.purchasedPotion(shopKeep2[_val - 1]);
            player.playerFunds -= shopKeep2[_val - 1].cost; //subtracts the cost of the potion from the users funds


            for (int i = _val; i < 100; i++)
            {
                if (i != 99)
                {
                    
                    shopKeep2[i - 1] = shopKeep2[i]; // moves the potion items forward to "Erase" the intended potion

                }
            }
            int count = 0;
            //updates the potion csv
            using (StreamWriter sw = new StreamWriter("potions.csv"))
            {
                
                while (shopKeep2[count].type == "Potion")
                {

                    sw.WriteLine($"{count + 1},{shopKeep2[count].name},{shopKeep2[count].type},{shopKeep2[count].attack}, {shopKeep2[count].cost}");


                    count++;
                }
                sw.Close();
            }
            

        }


        


    }
}
