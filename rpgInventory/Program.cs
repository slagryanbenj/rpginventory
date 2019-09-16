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
    class Program
    {

        static void Main(string[] args)
        {
            //Initialize the player class and set the player inventory
            player pl = new player();
            pl.setPlayerInventory();

            //Initialize the weapons and potions class
            weapons weapon = new weapons();
            potions potion = new potions();

            //initialize the class 
            store shop = new store();
            shop.setStore();

            
            //Initialize the strings that we will use for the user entry
            string cmd = "";
            string lCmd = "";
            //initialize the console app (used for ask function)
            Console_Applic cons = new Console_Applic();
            Console.WriteLine("For A list of Commands Enter (?)");

            //Game Loop
            while (cmd.ToLower() != "exit")
            {
                //asks the user for input
                cmd = cons.Ask("Awaiting Input: ");
                lCmd = cmd.ToLower();

                //prints list of wepons in store
                if(lCmd == ("view weapons"))
                {
                    weapons.printWeapons();
                }

                //prints list of potions in store
                if(lCmd == ("view potions"))
                {
                    potions.printPotions();
                }

                //prints the users weapons and potions
                if(lCmd == ("view my inventory"))
                {
                    pl.printPlayerInvent();
                }

                //prints the users weapons
                if(lCmd == ("view my weapons"))
                {
                    pl.printPlayerWeapon();
                }

                //prints the users potions
                if(lCmd == ("view my potions"))
                {
                    pl.printPlayerPotion();
                }

                //prints the weapons and potions in the store
                if(lCmd == ("view store"))
                {
                    shop.printStore();
                }

                //allows the player to buy a weapon 
                if(lCmd == ("buy weapon"))
                {
                    //prints the stores weapons
                    weapons.printWeapons();
                    //asks the user which weapon he/she wants to buy
                    int tmp = (Int32.Parse(cons.Ask("Which weapon: ")));
                    //checks the players funds to make sure they have enough
                    if(pl.checkFunds(store.shopKeep1[tmp - 1].cost))
                    {
                        store.buyWeapon(tmp);

                    }
                    else
                    {
                        Console.WriteLine("You do not have enough funds.");
                    }

                }
                //sells a weapon back to the store by printing the list of weapons the user ahs then asking which one
                if (lCmd == ("sell weapon"))
                {
                    pl.printPlayerWeapon();
                    int tmp = (Int32.Parse(cons.Ask("Which weapon: ")));
                    player.sellWeapon(tmp);
                }

                //allows the user to buy a potion from the store
                if (lCmd == ("buy potion"))
                {
                    //prints potions for user
                    potions.printPotions();
                    int tmp = (Int32.Parse(cons.Ask("Which potion: "))); // asks user which potion
                    if (pl.checkFunds(store.shopKeep2[tmp - 1].cost))//checks user funds
                    {
                        store.buyPotion(tmp);

                    } 

                    else
                    {
                        Console.WriteLine("You do not have enough funds.");
                    }

                }

                //sell a potion to the store by printing users potions and asking which one
                if(lCmd == ("sell potion"))
                {
                    pl.printPlayerPotion();
                    int tmp = (Int32.Parse(cons.Ask("Which potion: ")));
                    player.sellPotion(tmp);
                }
                //prints the users funds
                if(lCmd == ("my funds"))
                {
                    Console.WriteLine($"You have {player.playerFunds} gold left. ");
                }

                //a list of commands for the user
                if(lCmd == ("?") || lCmd == ("(?)"))
                {
                    Console.WriteLine("");
                    Console.WriteLine("CoMMaNds aRe NOT CaSE sEnsiTIvE");
                    Console.WriteLine("View Store --- See what the store has to offer");
                    Console.WriteLine("View Weapons --- See the Weapons in the store");
                    Console.WriteLine("View Potions --- See the Potions in the store");
                    Console.WriteLine("View My Inventory --- See what is in your inventory");
                    Console.WriteLine("View My Weapons --- See Weapons in your inventory");
                    Console.WriteLine("View My Potions --- See Potions in your inventory");
                    Console.WriteLine("My Funds --- See how much Gold you have left");
                    Console.WriteLine("Buy Weapon --- Purchase a Weapon from the Store");
                    Console.WriteLine("Buy Potion --- Purchase a Potion from the Store");
                    Console.WriteLine("Sell Weapon --- Sell a Weapon to the Store");
                    Console.WriteLine("Sell Potion --- Sell a Potion to the Store");
                    Console.WriteLine("Exit --- Close Application");
                    Console.WriteLine("");

                }

                if(lCmd == ("fuck"))
                {
                    Console.WriteLine("It will be okay, just keep going");
                }

                if(lCmd == ("clear"))
                {
                    Console.Clear();
                }

            }
        }
    }
}
