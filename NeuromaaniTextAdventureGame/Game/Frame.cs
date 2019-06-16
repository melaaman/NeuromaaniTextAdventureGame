using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuromaaniTextAdventureGame.Game
{
    public class Frame
    {
        public static string PlayerName = "";
        public static int PointsCurrent = 0;
        public static int PointsFull = 100;

        public static void ClearAndDrawFrame()
        {
            Console.Clear();
            DrawFrame();
        }

        static string GetPlayerName() => GeneralUtils.TruncateString(PlayerName);

        public static void AddPoints(int points) => GeneralUtils.AddUntilHundred(PointsCurrent, points);

        public static void SubtractPoints(int points) => GeneralUtils.Subtract(PointsCurrent, points);

        static void DrawFrame()
        {

            // pistepalkki

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("  ============================================================================================");
            Console.ResetColor();
            Console.SetCursorPosition(5, 1);
            Console.WriteLine("Nimi: {0}", GetPlayerName());
            Console.SetCursorPosition(22, 1);
            Console.WriteLine("Tyylipisteet: {0}/{1}", PointsCurrent, PointsFull);
            Console.SetCursorPosition(50, 1);
            Console.WriteLine("Reppu: {0}", "Tähän repun sisältö");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  ============================================================================================");
            Console.ResetColor();

        }
    }
}
