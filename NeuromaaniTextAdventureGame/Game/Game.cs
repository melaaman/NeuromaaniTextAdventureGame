
using NeuromaaniTextAdventureGame.Rooms;

namespace NeuromaaniTextAdventureGame.Game
{
    public class PlayGame
    {
        public static bool gameOn = true;
        public static Location currentRoom = new Location();

        BedRoom _bedRoom = new BedRoom();

        public void Game()
        {
            while (gameOn)
            {
                _bedRoom.playGame();
                gameOn = false;
            }

            System.Console.WriteLine("Hei hei");
        }

    }
}
