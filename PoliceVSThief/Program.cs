using System;
using System.Collections.Generic;

namespace PoliceVSThief
{
    class Program
    {   
        static void Main()
        {
            
            GameManager.GeneratePeople(20, 10, 5); // Generate 20 Citizen, 10 Thieves, 5 Police
            while (true)
            {
                Console.CursorVisible = false;       // Keep the cursor invisible
                GameManager.MoveAllPeople();         // Keep everyone moving!
                System.Threading.Thread.Sleep(63);   // Don't goo too fast.
                GameManager.FlipEveryone();          // Randomize the direction every iteration
                GameManager.RemoveEmptyCitizen();    // Remove all empty Citizen!
                LogBox.LogPeopleCount();             // Log the amount of people
            }
        }
    }
}
