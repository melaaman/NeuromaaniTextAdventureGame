
using NeuromaaniTextAdventureGame.FileManager;
using NeuromaaniTextAdventureGame.Rooms;

namespace NeuromaaniTextAdventureGame.Game
{
    public class PlayGame
    {
        public static bool gameOn = true;
        public static Location currentRoom = new Location();

        // General objects
        Frame _frame = new Frame();
        FileReader _reader = new FileReader();

        // Room objects
        BedRoom _bedRoom = new BedRoom();


        public PlayGame(Frame frame, FileReader reader)
        {
            _frame = frame;
            _reader = reader;
        }

        public void Game()
        {
            while (gameOn)
            {
                _bedRoom.playGame(_frame, _reader);
                gameOn = false;
            }

            System.Console.WriteLine("Hei hei");
        }

    }
}
