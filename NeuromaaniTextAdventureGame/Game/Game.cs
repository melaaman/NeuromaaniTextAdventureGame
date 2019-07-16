
using NeuromaaniTextAdventureGame.FileManager;
using NeuromaaniTextAdventureGame.Rooms;
using System.Collections.Generic;

namespace NeuromaaniTextAdventureGame.Game
{
    public class PlayGame
    {
        public static bool gameOn = true;
        public static Location currentRoom = new Location();

        // General objects
        Frame _frame;
        FileReader _reader;
        Bag _bag;

        // Room objects
        BedRoom _bedRoom = new BedRoom();


        public PlayGame(Frame frame, FileReader reader, Bag bag)
        {
            _frame = frame;
            _reader = reader;
            _bag = bag;
        }

        public void Game()
        {
            while (gameOn)
            {
                _bedRoom.Play(_frame, _reader, _bag);
                gameOn = false;
            }

            System.Console.WriteLine("Hei hei");
        }

    }
}
