
using NeuromaaniTextAdventureGame.FileManager;
using NeuromaaniTextAdventureGame.Rooms;
using System;

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
        WC _wc = new WC();
        LivingRoom _livingRoom = new LivingRoom();


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
                if (currentRoom == _bedRoom.doorWC) _wc.Play(_frame, _reader, _bag);
                if (currentRoom == _bedRoom.doorLivingRoom) _livingRoom.Play(_frame, _reader, _bag);
                gameOn = false;
            }

            _frame.ClearAndDrawFrame();
            GeneralUtils.GetTopCursore();
            Console.WriteLine("GAME OVER");
        }

    }
}
