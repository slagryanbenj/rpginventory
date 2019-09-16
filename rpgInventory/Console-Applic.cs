using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgInventory
{
    class Console_Applic
    {

        //gets input from the user
        public string Ask(string _val)
        {
            Console.Write(_val);
            return Console.ReadLine();
        }
    }
}
