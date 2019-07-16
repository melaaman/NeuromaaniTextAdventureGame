
using NeuromaaniTextAdventureGame.FileManager;
using NeuromaaniTextAdventureGame.Game;
using System.Collections.Generic;

namespace NeuromaaniTextAdventureGame
{
    class Program
    {
        static void Main(string[] args)
        {
            FileReader _reader = new FileReader();
            List<string> _items = new List<string>();
            Bag _bag = new Bag(_items);
            Frame _frame = new Frame(_bag);


            PlayGame _game = new PlayGame(_frame, _reader, _bag);
            Intro _intro = new Intro(_frame);

            _intro.DisplayIntro();
            _game.Game();

            //FileReader reader = new FileReader();
            //UserInput userInput = new UserInput();

            //userInput.GiveInstructions();
            //Console.SetCursorPosition(4, reader.GetPositionTop());
            //Console.ReadLine();

        }
    }
}
