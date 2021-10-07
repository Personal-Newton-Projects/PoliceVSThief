using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceVSThief
{
    class Police : Person
    {

        public override string Action(Person victim)
        {

            if(victim is Thief)
            {
                string collectedItems;
                if (victim.InventorySize > 0)
                {
                    collectedItems = "A Police Officer has taken ";
                    foreach (var item in victim.Inventory)
                    {
                        collectedItems += $"{item}, ";
                        if (item == victim.Inventory.Last()) collectedItems += $"{item} from a Thief and arrested them";

                    }
                    TakeFromInventory(victim);
                    GameManager.RemoveThief(victim);
                    return collectedItems;
                }
                else
                {
                    GameManager.RemoveThief(victim);
                    return "A Police Officer has arrested a Thief";
                }
            }
            if(victim is Citizen)
            {
                return "A Police Officer greeted a Citizen!";
            }
            return "";
        }

        public override ConsoleColor PersonColor { get { return ConsoleColor.Cyan; } }

        public Police()
        {
            chIdentifier = 'P';
            
            RandomizePosition();
            RandomizeDirection();
        }
    }
}
