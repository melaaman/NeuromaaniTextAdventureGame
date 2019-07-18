using NeuromaaniTextAdventureGame.FileManager;
using System;
using System.Threading;

namespace NeuromaaniTextAdventureGame.Game
{
    public class Intro
    {
        static FileReader _reader = new FileReader();
        private Frame _frame;

        public Intro(Frame frame)
        {
            _frame = frame;
        }
        public void DisplayIntro()
        {
            //DisplayTitleText();
            //DisplayIntroText();
            //_reader.DisplayTextFromFile("intro.txt", 0, 1);
            //_reader.DisplayTextFromFile("intro.txt", 1, 23);
            //GeneralUtils.PlayEnter(26);
            //AskPlayerName();
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
        void AskPlayerName()
        {
            _frame.ClearAndDrawFrame();
            _reader.DisplayTextFromFile("start.txt", 0, 4);
            while (true)
            {
                Console.SetCursorPosition(4, 7);
                var userInput = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    _frame.GivePlayerName(userInput);
                    return;
                }

            }
        }
        void GiveInstructions()
        {
            _frame.ClearAndDrawFrame();
            _reader.DisplayTextFromFile("start.txt", 1, 4);
            Console.SetCursorPosition(4, 8);
            Console.WriteLine("Mutta Gereg ei saa yksin mitään aikaan, siksi sinä, {0}, olet tässä. ", _frame.GetPlayerName());
            _reader.DisplayTextFromFile("start.txt", 2, 10);
            _reader.DisplayTextFromFile("start.txt", 3, 15);
            Console.SetCursorPosition(4, 18);
        }
        void StartGame()
        {
            for (int i = 0; i < 5; i++)
            {
                if (Console.ReadLine().ToLower().Trim() == "aloita") return;
                GiveInstructions();
                i++;
            }

            Console.WriteLine("Anna käsky \"Aloita\"");
            Console.CursorLeft = 4;
            Console.WriteLine("(HUOM! Jos et pelin aikana tiedä, mitä tehdä, kirjoita \"Apua\")");

            while (true)
            {
                Console.SetCursorPosition(4, 20);
                if (Console.ReadLine().ToLower().Trim() == "aloita") return;
                GiveInstructions();
                Console.SetCursorPosition(4, 18);
                Console.WriteLine("Anna käsky \"Aloita\"");

            }
        }
    }
}
