using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceVSThief
{
    abstract class Person
    {
        // Inherited Data Members
        protected int nX;
        protected int nY;
        protected char chIdentifier;
        protected List<string> l_szInventory = new List<string>();
        protected int nCurrentDirection;


        // Private members
        /// <summary>
        /// All possible Direction states.
        /// </summary>
        enum Direction
        {
            UP = 1,
            UPRIGHT,
            RIGHT,
            DOWNRIGHT,
            DOWN,
            DOWNLEFT,
            LEFT,
            UPLEFT
        }

        readonly Random random = new Random();

        // Properties
        public int X { get { return nX; } }
        public int Y { get { return nY; } }

        /// <summary>
        /// The character identifier for the Person. Used when printing out.
        /// </summary>
        public char Identifier { get { return chIdentifier; } }

        public abstract ConsoleColor IdentifierColor { get; }
        
        public List<string> Inventory { get { return l_szInventory; } }
        /// <summary>
        /// The length of the Inventory in int.
        /// </summary>
        public int InventorySize { get { return l_szInventory.Count; } }

        /// <summary>
        /// Action Method that is called whenever the Person interacts with a victim.
        /// </summary>
        /// <param name="victim">The victim that gets interacted with by the Person</param>
        /// <returns>A string to be printed.</returns>
        public abstract string Action(Person victim);

        /// <summary>
        /// Handles each case of movement for each direction in Enum Direction.
        /// </summary>
        /// <returns>Returns the new position of the Person</returns>
        public virtual void MoveInDirection()
        {
            switch ((Direction)nCurrentDirection)
            {
                case Direction.UP:
                    MoveY();
                    break;
                case Direction.UPRIGHT:
                    MoveY();
                    MoveX();
                    break;
                case Direction.RIGHT:
                    MoveX();
                    break;
                case Direction.DOWNRIGHT:
                    MoveX();
                    MoveY();
                    break;
                case Direction.DOWN:
                    MoveY();
                    break;
                case Direction.DOWNLEFT:
                    MoveY();
                    MoveX();
                    break;
                case Direction.LEFT:
                    MoveX();
                    break;
                case Direction.UPLEFT:
                    MoveX();
                    MoveY();
                    break;
            }
        }

        /// <summary>
        /// Handle X Axis movement
        /// </summary>
        /// <returns>Increases the X axis by 1 if it's inside of bounds and Enum Direction is positive (RIGHT), otherwise returns X--</returns>
        int MoveX()
        {
            if ((Direction)nCurrentDirection == Direction.RIGHT ||
                (Direction)nCurrentDirection == Direction.DOWNRIGHT ||
                (Direction)nCurrentDirection == Direction.UPRIGHT)
            {
                if (nX < GameManager.GameWorldMaxWidth) return nX++;
                else return nX = GameManager.GameWorldMinWidth;
            }
            else
            {
                if (nX > GameManager.GameWorldMinWidth) return nX--;
                else return nX = GameManager.GameWorldMaxWidth;
            }
        }
        /// <summary>
        /// Handle Y Axis movement
        /// </summary>
        /// <returns>Increases the Y axis by 1 if it's inside of bounds and Enum Direction is positive (UP), otherwise returns y--</returns>
        int MoveY()
        {

            if ((Direction)nCurrentDirection == Direction.UP ||
                (Direction)nCurrentDirection == Direction.UPRIGHT ||
                (Direction)nCurrentDirection == Direction.UPLEFT)
            {
                if (nY < GameManager.GameWorldMaxHeight) return nY++;
                else return nY = GameManager.GameWorldMinHeight;
            }
            else
            {
                if (nY > GameManager.GameWorldMinHeight) return nY--;
                else return nY = GameManager.GameWorldMaxHeight;
            }
            
        }

        /// <summary>
        /// Randomize the direction of the Person
        /// </summary>
        public void RandomizeDirection()
        {
            nCurrentDirection = random.Next(1, 9);
        }

        /// <summary>
        /// Randomize the X and Y axis of the Person
        /// </summary>
        protected void RandomizePosition()
        {
            nX = random.Next(GameManager.GameWorldMinWidth, GameManager.GameWorldMaxWidth);
            nY = random.Next(GameManager.GameWorldMinHeight, GameManager.GameWorldMaxHeight);
        }

        /// <summary>
        /// Copies the item at the index from the victim and adds it to the Person, then removes it from the inventory of the victim.
        /// </summary>
        /// <param name="victim">The Person who is giving the item</param>
        /// <param name="index">The index to Add of the item</param>
        public void TakeFromInventory(Person victim, int index)
        {
            l_szInventory.Add(victim.Inventory[index]);
            victim.l_szInventory.RemoveAt(Math.Clamp(index, 0, InventorySize));
        }

        /// <summary>
        /// Copies all items from the victim and adds it to the Person, then removes all items from the inventory of the victim
        /// </summary>
        /// <param name="victim">The Person who is giving the item</param>
        public void TakeFromInventory(Person victim)
        {
            l_szInventory = victim.Inventory;
            victim.l_szInventory.Clear();
        }

    }
}
