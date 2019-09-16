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
    class player
    {
        //initializes the player funds and the arrays to store the weapons and potions
        public static int playerFunds;
        public static int playerHealth = 100;
        public static item1[] playerInvent1 = new item1[10];
        public static item1[] playerInvent2 = new item1[10];

        //initializes the players inventory by reading from the csv files 
        public void setPlayerInventory()
        {
            int count = 0;
            using (StreamReader sr = new StreamReader("plWeapons.csv"))
            {

                try
                {
                    while (!sr.EndOfStream)
                    {
                        //splits the line into an array seperated by commas.
                        string line = sr.ReadLine();
                        string[] val = line.Split(',');
                        Item tmp = new Item();//temp item that we set the different values from the line it read
                        tmp.name = val[1];
                        tmp.type = val[2];
                        tmp.attack = Int32.Parse(val[3]); 
                        tmp.cost = Int32.Parse(val[4]);

                        playerInvent1[count++] = tmp;//sets the weapon array at count to the tmp item & +1 count

                        sr.Close();//closes the text file
                    }

                }
                catch (Exception)
                {

                  
                }

                

            }
            count = 0;
            using (StreamReader sr = new StreamReader("plPotions.csv"))
            {
                try
                {

                    while (!sr.EndOfStream)
                    {
                        //splits the line into an array seperated by commas.
                        string line = sr.ReadLine();
                        string[] val = line.Split(',');
                        Item tmp = new Item(); //temp item that we set the different values from the line it read
                        tmp.name = val[1];
                        tmp.type = val[2];
                        tmp.attack = Int32.Parse(val[3]);
                        tmp.cost = Int32.Parse(val[4]);

                        playerInvent2[count++] = tmp; //sets the potion array at count to the tmp item & +1 count
                        sr.Close();//closes the text file


                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("You havent bought any potions yet. You should do so soon");
                    
                }
            }

            using (StreamReader sr = new StreamReader("gold.txt"))
            {
                string line = sr.ReadLine();
                playerFunds = Int32.Parse(line);//gets saved funds from a text file
                sr.Close();//closes the text file
            }

        }

        public bool checkFunds( int _val)//a method to check if the player has enough funds
        {
             if(playerFunds >= _val)
            {
                return true;
            }

             if(playerFunds <= _val)
            {
                return false;
            }
            else
            {
                return false;
            }
        }

        public void printPlayerInvent()//a method to print the player inventory
        {
            Console.WriteLine("");
            Console.WriteLine("Weapons: ");
            Console.WriteLine("Name,   Type,   Damage,   Cost");//Formatting to make it look nice & readable.
            for (int i = 0; i < 10; i++)
            {
                if (playerInvent1[i].cost != 0)
                {
                    //goes through the weapon array and prints out each value, with commas inbetween.
                    Console.WriteLine($"{playerInvent1[i].name} {playerInvent1[i].type} {playerInvent1[i].attack} {playerInvent1[i].cost}");
                    

                }

                
            }
            Console.WriteLine("");
            Console.WriteLine("Name,   Type,   Health,   Cost");
            Console.WriteLine("Potions: ");//formatting for more readable text
            for(int i = 0; i < 10; i++)
            {
                if (playerInvent2[i].cost != 0)
                {
                    //goes through the potions array and prints the values seperated by commas
                    Console.WriteLine($"{playerInvent2[i].name} {playerInvent2[i].type} {playerInvent2[i].attack} {playerInvent2[i].cost}");
                }
            }

            Console.WriteLine("");
        }

        public void printPlayerWeapon()//method to print player weapons
        {
            using (StreamReader sr = new StreamReader("plWeapons.csv"))
            {
                
                string line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                Console.WriteLine("Name,   Type,   Damage,   Cost");
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
                sr.Close();//closes the text file

            }
        }

        public void printPlayerPotion()//method to print player potions
        {
            using (StreamReader sr = new StreamReader("plPotions.csv"))
            {
                string line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
                sr.Close();//closes the text file

            }
        }

        public static void purchasedWeapon(item1 _val)//method to add the bought weapon to player inventory(weapon)
        {
            int tmp = 0;
            for(int i = 0; i < 10; i++)
            {
                if(playerInvent1[i].name != null)
                {
                    tmp++;
                    //ticks up a tmp int until an empty item in the weapons array is found
                }
            }
            //sets that item to the one bought
            playerInvent1[tmp] = _val;

            int count = 0;
            using (StreamWriter sw = new StreamWriter("plWeapons.csv"))
            {
                while (playerInvent1[count].type == "Weapon")
                {

                    sw.WriteLine($"{count + 1},{playerInvent1[count].name},{playerInvent1[count].type},{playerInvent1[count].attack}, {playerInvent1[count].cost}");
                    //writes the updated players weapons to the wepaon file

                    count++;
                }
                sw.Close();//closes the text file
            }
        }

        public static void purchasedPotion(item1 _val)//adds a purchased potion to the players potions
        {
            int tmp = 0;
            for(int i = 0; i < 10; i++)
            {
                if(playerInvent2[i].name != null)
                {
                    tmp++;
                    //ticks up a tmp array until a blank item is found in the potions array
                }
            }
            playerInvent2[tmp] = _val;
            //sets that item to the one that wasw bought
            int count = 0;
            using (StreamWriter sw = new StreamWriter("plPotions.csv"))
            {

                while (playerInvent2[count].type == "Potion")
                {

                    sw.WriteLine($"{count + 1},{playerInvent2[count].name},{playerInvent2[count].type},{playerInvent2[count].attack}, {playerInvent2[count].cost}");

                    //adds the updated array to the player potions file
                    count++;
                }
                sw.Close();//closes the text file
            }
        }

        public static void sellWeapon(int _val)//method to sell weapon
        {
            //adds to your funds
            playerFunds += playerInvent1[_val - 1].cost;
            int tmp = 0;
            for(int i = 0; i < 100; i++)
            {
                if(store.shopKeep1[i].name != null)
                {
                    tmp++;//increment until a blank itam in the shop is found
                }

            }

            store.shopKeep1[tmp + 1] = playerInvent1[_val];//puts the sold wepaon into the store array 

            for (int i = _val; i < 10; i++)
            {
                if (i != 99)
                {
                    //moves all of the player inventory forward effecively eraasing the bought weapon
                    playerInvent1[i - 1] = playerInvent1[i];

                }
            }

            int count = 0;
            using (StreamWriter sw = new StreamWriter("plWeapons.csv"))
            {
                while (playerInvent1[count].type == "Weapon")
                {
                    //updates the weapons foile with the new array
                    sw.WriteLine($"{count + 1},{playerInvent1[count].name},{playerInvent1[count].type},{playerInvent1[count].attack}, {playerInvent1[count].cost}");


                    count++;
                }
                sw.Close();//closes the text file
            }

            count = 0;
            using (StreamWriter sw = new StreamWriter("weapons.csv"))
            {
                while (store.shopKeep1[count].type == "Weapon")
                {
                    //updates the stores weapons file with the new array
                    sw.WriteLine($"{count + 1},{store.shopKeep1[count].name},{store.shopKeep1[count].type},{store.shopKeep1[count].attack}, {store.shopKeep1[count].cost}");


                    count++;
                }
                sw.Close();//closes the text file
            }

        }

        public static void sellPotion(int _val)//a method to sell a potion
        {
            playerFunds += playerInvent2[_val - 1].cost;
            int tmp = 0;
            for (int i = 0; i < 100; i++)
            {
                if (store.shopKeep2[i].name != null)
                {
                    tmp++;// finds where the next empty item is in the store potions array
                }

            }


            store.shopKeep2[tmp] = playerInvent2[_val - 1];
            //sets the value to be in that empty position

            for (int i = _val; i < 10; i++)
            {
                if (i != 99)
                {
                    playerInvent2[i - 1] = playerInvent2[i];//starting at the item it will move all of the items forward in the array effectively erasing the item

                }
            }

            int count = 0;
            using (StreamWriter sw = new StreamWriter("plPotions.csv"))
            {

                while (playerInvent2[count].type == "Potion")
                {
                    //updates the player potions with the new array
                    sw.WriteLine($"{count + 1},{playerInvent2[count].name},{playerInvent2[count].type},{playerInvent2[count].attack}, {playerInvent2[count].cost}");


                    count++;
                }
                sw.Close();//closes the text file
            }

            count = 0;
            using (StreamWriter sw = new StreamWriter("potions.csv"))
            {

                while (store.shopKeep2[count].type == "Potion")
                {
                    //updates the store potions with the new array
                    sw.WriteLine($"{count + 1},{store.shopKeep2[count].name},{store.shopKeep2[count].type},{store.shopKeep2[count].attack}, {store.shopKeep2[count].cost}");


                    count++;
                }
                sw.Close();//closes the text file
            }
        }
    }
}
  