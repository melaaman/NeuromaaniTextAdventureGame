
using NeuromaaniTextAdventureGame.Game;

namespace NeuromaaniTextAdventureGame
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayGame _game = new PlayGame();
            Intro.DisplayIntro();
            _game.Game();

            //FileReader reader = new FileReader();
            //UserInput userInput = new UserInput();

            //userInput.GiveInstructions();
            //Console.SetCursorPosition(4, reader.GetPositionTop());
            //Console.ReadLine();

        }
    }
}
