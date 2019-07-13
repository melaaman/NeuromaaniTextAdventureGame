
using NeuromaaniTextAdventureGame.FileManager;
using NeuromaaniTextAdventureGame.Game;

namespace NeuromaaniTextAdventureGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Frame _frame = new Frame();
            FileReader _reader = new FileReader();


            PlayGame _game = new PlayGame(_frame, _reader);
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
