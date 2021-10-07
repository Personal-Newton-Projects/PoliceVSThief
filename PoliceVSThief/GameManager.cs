using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceVSThief
{
    static class GameManager
    {
       
        // Global Data Members
        /// <summary>
        /// The main List that contains all Person's.
        /// </summary>
        public static List<Person> people = new List<Person>();
        
        public readonly static int GameWorldMinWidth = 0;
        public readonly static int GameWorldMinHeight = 0;

        public readonly static int GameWorldMaxWidth = 100;
        public readonly static int GameWorldMaxHeight = 25;


        public static void GeneratePeople(int Citizen, int Thieves, int Police)
        {
            for (int cz = 0; cz < Citizen; cz++)
            {
                people.Add(new Citizen());
            }
            for (int tf = 0; tf < Thieves; tf++)
            {
                people.Add(new Thief());
            }
            for (int po = 0; po < Police; po++)
            {
                people.Add(new Police());
            }
        }

        /// <summary>
        /// Compares the referenced Person's Position with every other Person starting on the X axis then the Y, afterwards call HandleAction()
        /// </summary>
        /// <param name="person">The Person's position to compare with every other Person</param>
        static void ComparePosition(Person person)
        {
            int x = person.X;
            int y = person.Y;
            for (int currentPerson = 0; currentPerson < people.Count; currentPerson++) // Loopa igenom alla Personer
            {
                // Om jag (person).x == people[i].x OCH jag (person) är inte lika med mig själv
                if (x == people[currentPerson].X && person != people[currentPerson]) 
                {
                    // Om (person).x == people[i].x
                    if (y == people[currentPerson].Y)
                    {
                        HandleAction(person, people[currentPerson]); // Action!
                    }
                }
            }
            
        }
        /// <summary>
        /// Handles the Action event used by Person and Logs it with LogBox
        /// </summary>
        /// <param name="person">Person to act</param>
        /// <param name="target">Target or Victim of the Action</param>
        static void HandleAction(Person person, Person target)
        {
            LogBox.Log(person.Action(target)); // Logging
        }

        /// <summary>
        /// Draws the Person and overwrites the previous step the Person took.
        /// </summary>
        /// <param name="person">Person to draw. Using it's X and Y coordinates and Identifier to Draw the Person.</param>
        static void DrawPerson(Person person)
        {
            int x = person.X;
            int y = person.Y;
            Console.SetCursorPosition(x, y);
            Console.Write(' '); // Remove previous position

            person.MoveInDirection(); // (x++ or y++) or (x++ and y++)
            x = person.X;
            y = person.Y;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = person.PersonColor;
            Console.Write(person.Identifier); // New position
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Main Method that iterates every existing Person in people and Draws the Person then compares it's position.
        /// </summary>
        public static void MoveAllPeople()
        {
            for (int currentPerson = 0; currentPerson < people.Count; currentPerson++)
            {
                DrawPerson(people[currentPerson]);
                ComparePosition(people[currentPerson]);
            }
        }

        /// <summary>
        /// Flips the Direction of all Person's in people.
        /// </summary>
        public static void FlipEveryone()
        {
            for (int currentPerson = 0; currentPerson < people.Count; currentPerson++)
            {
                people[currentPerson].RandomizeDirection();
            }
        }


        /// <summary>
        /// Removes the Person if it is a Thief
        /// </summary>
        /// <param name="person">Person to evalidate</param>
        public static void RemoveThief(Person person)
        {
            if (person is Thief)
            {
                people.Remove(person);
            }
        }

        /// <summary>
        /// Remove all existing Citizens with an empty Inventory
        /// </summary>
        public static void RemoveEmptyCitizen()
        {
            for (int i = 0; i < people.Count; i++)
            {
                if (people[i] is Citizen)
                {
                    if ((people[i].InventorySize == 0))
                    {
                        people.RemoveAt(i);
                    }
                }
            }
        }
    }
}
