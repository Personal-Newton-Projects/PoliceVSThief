using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceVSThief
{
    class Citizen : Person
    {
        public override string Action(Person victim)
        {
            if (victim is Citizen) return "A Citizen greets another Citizen!";
            return "";
        }

        public override ConsoleColor PersonColor { get { return ConsoleColor.Yellow; } }

        public Citizen()
        {
            chIdentifier = 'C';
            
            l_szInventory.Add("a Wallet");
            l_szInventory.Add("a Phone");
            l_szInventory.Add("a Watch");
            l_szInventory.Add("Keys");

            RandomizePosition();
            RandomizeDirection();
        }
    }
}
