
using NeuromaaniTextAdventureGame.FileManager;
using NeuromaaniTextAdventureGame.Rooms;
using System;

namespace NeuromaaniTextAdventureGame.Game
{
    public class PlayGame
    {
        public static bool gameOn = true;
        public static bool gameOver = false;
        public static Location currentRoom = new Location();

        Frame _frame;
        FileReader _reader;
        Bag _bag;

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
            _bedRoom.Play(_frame, _reader, _bag);

            while (gameOn)
            {
                if (currentRoom == _bedRoom.doorWC) _wc.Play(_frame, _reader, _bag);
                if (currentRoom == _bedRoom.doorLivingRoom) _livingRoom.Play(_frame, _reader, _bag);
                if (currentRoom == _wc.doorToBedroom) _bedRoom.Play(_frame, _reader, _bag);
                if (currentRoom == _livingRoom.bedroomDoor) _bedRoom.Play(_frame, _reader, _bag);
                if (currentRoom == _livingRoom.hallwayDoor) gameOn = false;
            }

            _frame.ClearAndDrawFrame();

            if (gameOver) GameOver();
            else
            {
                Console.SetCursorPosition(10, 7);
                Console.WriteLine("Demo päättyy tähän. Onnistuit saamaan {0} pistettä.", _frame.GetPoints());
                Console.SetCursorPosition(0, 15);
            };
        }

        void GameOver()
        {
            string text = @"
  _______      ___      .___  ___.  _______      ______   ____    ____  _______ .______      
 /  _____|    /   \     |   \/   | |   ____|    /  __  \  \   \  /   / |   ____||   _  \     
|  |  __     /  ^  \    |  \  /  | |  |__      |  |  |  |  \   \/   /  |  |__   |  |_)  |    
|  | |_ |   /  /_\  \   |  |\/|  | |   __|     |  |  |  |   \      /   |   __|  |      /     
|  |__| |  /  _____  \  |  |  |  | |  |____    |  `--'  |    \    /    |  |____ |  |\  \----.
 \______| /__/     \__\ |__|  |__| |_______|    \______/      \__/     |_______|| _| `._____|
";
            Console.SetCursorPosition(4, 8);
            Console.WriteLine(text);
        }

    }
}
