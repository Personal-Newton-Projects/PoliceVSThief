using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceVSThief
{
    static class LogBox
    {
        // Data Members
        const int maxLog = 5;
        static int LogStartingLine = GameManager.GameWorldMaxHeight + maxLog;
        static int currentLine = 1;

        /// <summary>
        /// Prints out text beneath the Map.
        /// </summary>
        /// <param name="text">The text to print out.</param>
        public static void Log(string text)
        {
            ClearLine();
            Console.WriteLine(text + string.Empty);
            if (currentLine > maxLog) currentLine = 1; // Resets the position of the log to the start.
            else currentLine++;
        }

        /// <summary>
        /// Allows for full overwriting of a line. Replaces a line with blank text.
        /// </summary>
        static void ClearLine()
        {
            Console.SetCursorPosition(0, LogStartingLine + currentLine);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, LogStartingLine + currentLine);
        }

        /// <summary>
        /// Log all the existing people in the GameWorld.
        /// </summary>
        /// <param name="people"></param>
        public static void LogPeopleCount()
        {
            int citizenAmount = 0;
            int thiefAmount = 0;
            int policeAmount = 0;
            for (int i = 0; i < GameManager.people.Count; i++)
            {

                if (GameManager.people[i] is Citizen) citizenAmount++;
                if (GameManager.people[i] is Thief) thiefAmount++;
                if (GameManager.people[i] is Police) policeAmount++;

                Console.SetCursorPosition(0, LogStartingLine + 10);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"Citizen amount: {citizenAmount}, Thief amount: {thiefAmount}, Police amount: {policeAmount}");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
