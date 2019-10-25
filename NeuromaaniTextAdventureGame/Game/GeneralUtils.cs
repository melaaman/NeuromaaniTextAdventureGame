using System;

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
        public static string TruncateString(string text, int breakPoint) => text.Length > breakPoint ? text.Substring(0, breakPoint - 1) + "..." : text;
        public static int AddUntilHundred(int currentNumber, int addedNumber) => currentNumber = addedNumber < 0 ? currentNumber : currentNumber + addedNumber > 100 ? 100 : currentNumber + addedNumber;
        public static int Subtract(int currentNumber, int subtractedNumber) => currentNumber = subtractedNumber < 0 ? currentNumber + subtractedNumber : currentNumber - subtractedNumber;
        public static int GetTopCursore() => Console.CursorTop + 1;
    }
}
