using NeuromaaniTextAdventureGame.FileManager;
using System;
using System.Threading;

namespace NeuromaaniTextAdventureGame.Game
{
    public static class Intro
    {
        static FileReader _reader = new FileReader();
        public static void DisplayIntro()
        {
            DisplayTitleText();
            DisplayIntroText();
            _reader.DisplayTextFromFile("intro.txt", 0, 1);
            _reader.DisplayTextFromFile("intro.txt", 1, 23);
            GeneralUtils.PlayEnter(_reader.GetPositionTop());
            AskPlayerName();
            GiveInstructions();
            StartGame();
        }
        static void DisplayIntroText()
        {
            string text = @"
  ███┼██┼┼┼┼┼██┼████████┼███████┼┼█████
  ███┼██┼┼┼┼┼██┼┼┼┼██┼┼┼┼██┼┼┼┼█┼┼██┼┼█
  ███┼███┼┼┼┼██┼┼┼┼██┼┼┼┼██┼┼┼┼█┼┼██┼┼█
  ███┼███┼┼┼┼██┼┼┼┼██┼┼┼┼██┼┼┼██┼┼██┼┼█
  ███┼████┼┼┼██┼┼┼┼██┼┼┼┼██┼┼┼█┼┼┼██┼┼█
  ███┼██┼█┼┼┼██┼┼┼┼██┼┼┼┼██┼┼██┼┼┼██┼┼█
  ███┼██┼██┼┼██┼┼┼┼██┼┼┼┼██┼┼█┼┼┼┼██┼┼█
  ███┼██┼┼██┼██┼┼┼┼██┼┼┼┼█████┼┼┼┼█┼┼┼█
  ███┼██┼┼██┼██┼┼┼┼██┼┼┼┼██┼┼┼█┼┼┼██┼┼█
  ██┼┼██┼┼┼████┼┼┼┼██┼┼┼┼██┼┼┼█┼┼┼██┼┼█
  ██┼┼██┼┼┼████┼┼┼┼██┼┼┼┼██┼┼┼█┼┼┼██┼┼█
  ███┼██┼┼┼████┼┼┼┼██┼┼┼┼██┼┼┼█┼┼┼██┼┼█
  ┼ ██┼██┼┼┼┼███┼┼┼┼██┼┼┼┼██┼┼┼██┼┼██┼┼█
  ┼██┼██┼┼┼┼███┼┼┼┼██┼┼┼┼██┼┼┼┼█┼┼██┼┼█
  ┼██┼██┼┼┼┼┼██┼┼┼┼██┼┼┼┼██┼┼┼┼█┼┼██┼┼█
  ┼██┼██┼┼┼┼┼██┼┼┼┼█┼┼┼┼┼██┼┼┼┼█┼┼█████
  ┼┼█┼██┼┼┼┼┼┼█┼┼┼┼┼┼┼█┼┼┼┼┼┼┼┼█┼┼█████
  █┼┼┼██┼┼┼┼┼┼█┼┼┼┼██┼┼┼┼┼┼┼┼█┼█┼┼┼┼┼┼┼
  ┼┼┼█┼┼┼┼┼┼┼┼┼┼██┼█┼┼┼┼┼██┼┼┼█┼┼┼█┼┼┼┼
";

            string[] introRivit = text.Split('\n');
            foreach (var item in introRivit)
            {
                Console.WriteLine(item);
                Thread.Sleep(150);
            }
            Console.Clear();
        }
        static void DisplayTitleText()
        {
            string text = @"
   ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█░░░░░░░░░░░░░░░░░░░░░
   ███░░░██░░░░░░░░░░░░░░█████░░░░░░░██░░███░░░░░░░░░░░░░█░░░░░░░░░░░░░░████░░░░░░░░
   ███░░░██░░░░░░░░░░░░░░██░░█░░░░░░░███░███░░░░░░░░░░░░░██░░░█░░██░░░░██░░░░░░░░░░░
   ████░░██░████░██░░░█░░██░░█░░░░░░░███░███░░░░░░░░░░░░░███░░█░░░░░░███░░░█░░░░░░░░
   ████░░██░█░░░░██░░░█░░██░░█░█████░█████░█░░░░░░░░░░░░░█░███░█░░░░░░░░░░░░██░░░░░░
   ██░░█░██░█░░░░██░░░█░░█████░██░░█░██░██░██░▐██░░████░░██░░███░███░░░██████░░░░░░░
   ██░░█░██░███░░███░░█░░██░░░░██░░█░██░█░░██░▐░░█░█░░█░░██░░░░░░█░███░██░░░░░░░░░░░
   ██░░░███░█░░░░███░░█░░█░██░░██░░█░██░░░░██░▐███░████░░██░░░█░░░█░██░░░░░░█░░██░█░
   ██░░░███░█░░░░███░░█░░█░░██░██░░█░██░░░░██░▐░░█░█░░█░░██░░██░░░░█░█░█░░░█░░░░░░░░
   ██░░░███░████░██████░░█░░░█░█████░██░░░░██░▐░░█░█░░█░░██░░░█░░░░░░█░░█░░░██░░░░░░
   ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█░█░░░░░
";
            Console.CursorTop = 2;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(text);
            Console.CursorLeft = 3;
            Console.WriteLine("Tekstiseikkailupeli");
            Console.ResetColor();
            Console.WriteLine();
            GeneralUtils.PlayEnter(17, 3);
            Console.Clear();
        }
        static void AskPlayerName()
        {
            Frame.ClearAndDrawFrame();
            _reader.DisplayTextFromFile("start.txt", 0, 4);
            while (true)
            {
                Console.SetCursorPosition(4, 7);
                var userInput = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    Frame.PlayerName = userInput;
                    return;
                }

            }
        }
        static void GiveInstructions()
        {
            Frame.ClearAndDrawFrame();
            _reader.DisplayTextFromFile("start.txt", 1, 4);
            Console.SetCursorPosition(4, 8);
            Console.WriteLine("Mutta Gereg ei saa yksin mitään aikaan, siksi sinä, {0}, olet tässä. ", Frame.PlayerName);
            _reader.DisplayTextFromFile("start.txt", 2, 10);
            _reader.DisplayTextFromFile("start.txt", 3, 15);
            Console.SetCursorPosition(4, _reader.GetPositionTop());
        }
        static void StartGame()
        {
            for (int i = 0; i < 5; i++)
            {
                if (Console.ReadLine().ToLower().Trim() == "aloita") return;
                GiveInstructions();
                i++;
            }

            Console.WriteLine("Anna käsky \"Aloita\"");

            while (true)
            {
                Console.SetCursorPosition(4, _reader.GetPositionTop() + 2);
                if (Console.ReadLine().ToLower().Trim() == "aloita") return;
                GiveInstructions();
                Console.SetCursorPosition(4, _reader.GetPositionTop());
                Console.WriteLine("Anna käsky \"Aloita\"");

            }
        }
    }
}
