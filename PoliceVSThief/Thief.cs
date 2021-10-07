using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceVSThief
{
    class Thief : Person
    {
        int itemIndex;
        readonly Random random = new Random();

        public override string Action(Person victim)
        {
            itemIndex = random.Next(0, victim.InventorySize);
            if (victim is Citizen)
            {
                if(victim.InventorySize > 0)
                {
                    string collectedItem = victim.Inventory[itemIndex];
                    TakeFromInventory(victim, itemIndex);
                    return $"A Thief has stolen {collectedItem} from a Citizen";
                }
                else
                {
                    return $"A Thief found nothing to steal from a Citizen";
                }

            }
            return "";
        }

        public override ConsoleColor PersonColor { get { return ConsoleColor.Red; } }

        public Thief()
        {
            chIdentifier = 'T';
            
            RandomizePosition();
            RandomizeDirection();
            itemIndex = 0;
        }
    }
}
