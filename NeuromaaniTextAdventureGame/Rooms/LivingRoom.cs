using NeuromaaniTextAdventureGame.FileManager;
using NeuromaaniTextAdventureGame.Game;

namespace NeuromaaniTextAdventureGame.Rooms
{
    public class LivingRoom : PlayRoom
    {

        Location start = new Location()
        {
            Title = "HIRVIÖ HERÄÄ ELOON",
            File = "livingRoom.txt",
            ChapterIndex = 0,
            CurrentPoint = Command.Default
        };

        Location iron = new Location()
        {
            File = "livingRoom.txt",
            ChapterIndex = 1,
            CurrentPoint = Command.West,
            Item = "silitysrauta"
        };

        Location chair = new Location()
        {
            File = "livingRoom.txt",
            ChapterIndex = 2,
            CurrentPoint = Command.East
        };

        public Location hallwayDoor = new Location()
        {
            File = "livingRoom.txt",
            ChapterIndex = 3,
            CurrentPoint = Command.South,
            ExitRoom = true
        };

        public Location bedroomDoor = new Location()
        {
            File = "livingRoom.txt",
            ChapterIndex = 4,
            CurrentPoint = Command.North,
            ExitRoom = true
        };
        public override Location SetUp()
        {
            start.Exits.Add(Command.East, chair);
            start.Exits.Add(Command.North, bedroomDoor);
            start.Exits.Add(Command.South, hallwayDoor);
            start.Exits.Add(Command.West, iron);

            iron.Exits.Add(Command.North, bedroomDoor);
            iron.Exits.Add(Command.South, hallwayDoor);
            iron.Exits.Add(Command.East, chair);

            chair.Exits.Add(Command.North, bedroomDoor);
            chair.Exits.Add(Command.South, hallwayDoor);
            chair.Exits.Add(Command.West, iron);

            hallwayDoor.Exits.Add(Command.North, bedroomDoor);
            hallwayDoor.Exits.Add(Command.West, iron);
            hallwayDoor.Exits.Add(Command.East, chair);

            bedroomDoor.Exits.Add(Command.South, hallwayDoor);
            bedroomDoor.Exits.Add(Command.West, iron);
            bedroomDoor.Exits.Add(Command.East, chair);

            return start;
        }
        public override void GenerateSpecialActions(Frame frame, Command action, Bag bag, FileReader reader, string item)
        {
            if (action == Command.Hit) return;
            if (action == Command.UseItem && bag.IsItemInBag(item))
            {
                if (item == "silitysrauta")
                {
                    frame.SubtractPoints(850);
                    frame.ClearAndDrawFrame();
                    reader.DisplayTextFromFile("livingRoom.txt", 5, GeneralUtils.GetTopCursore());
                    GeneralUtils.PlayEnter(GeneralUtils.GetTopCursore());
                    PlayGame.gameOn = false;
                    PlayGame.gameOver = true;
                }
                else
                {
                    reader.DisplayText("Ehkäpä tavaralla on käyttöä jossain muussa tilanteessa.", GeneralUtils.GetTopCursore());
                }
            }
        }

        public override void ClearLocationDictionaries()
        {
            start.Exits.Clear();
            iron.Exits.Clear();
            chair.Exits.Clear();
            bedroomDoor.Exits.Clear();
            hallwayDoor.Exits.Clear();
        }
    }
}
