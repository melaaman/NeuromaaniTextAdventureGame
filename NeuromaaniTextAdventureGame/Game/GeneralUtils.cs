using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuromaaniTextAdventureGame.Game
{
    public static class GeneralUtils
    {
        public static void PlayEnter(int top, int left = 4)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(left, top);
            Console.WriteLine("(Paina enter)");
            Console.ResetColor();
            while (Console.ReadKey().Key != ConsoleKey.Enter) ;
        }

        public static string TruncateString(string text) => text.Length > 8 ? text.Substring(0, 7) + "..." : text;

        public static int AddUntilHundred(int currentNumber, int addedNumber) => currentNumber = addedNumber < 0 ? currentNumber : currentNumber + addedNumber > 100 ? 100 : currentNumber + addedNumber;

        public static int Subtract(int currentNumber, int subtractedNumber) => currentNumber = subtractedNumber < 0 ? currentNumber + subtractedNumber : currentNumber - subtractedNumber;
    }
}
