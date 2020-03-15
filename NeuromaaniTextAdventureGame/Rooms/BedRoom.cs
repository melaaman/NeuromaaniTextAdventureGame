using NeuromaaniTextAdventureGame.FileManager;
using NeuromaaniTextAdventureGame.Game;
using System;

namespace NeuromaaniTextAdventureGame.Rooms
{
    public class BedRoom : PlayRoom
    {
        private string _specialCommand = "";

        Location start = new Location()
        {
            Title = "HERÄÄMINEN",
            File = "bedroom.txt",
            ChapterIndex = 0,
            FootnoteIndex = 5,
            CurrentPoint = Command.Default
        };

        Location bed = new Location()
        {
            File = "bedroom.txt",
            ChapterIndex = 1,
            FootnoteIndex = 6,
            CurrentPoint = Command.North
        };

        Location wallWithPoster = new Location()
        {
            File = "bedroom.txt",
            ChapterIndex = 2,
            CurrentPoint = Command.West
        };

        public Location doorWC = new Location()
        {
            File = "bedroom.txt",
            ChapterIndex = 3,
            CurrentPoint = Command.East,
            ExitRoom = true
        };

        public Location doorLivingRoom = new Location()
        {
            File = "bedroom.txt",
            ChapterIndex = 4,
            CurrentPoint = Command.South,
            ExitRoom = true
        };

        public override string SpecialCommand { get { return _specialCommand; } set { _specialCommand = value; } }

        public override Location SetUp()
        {
            start.Exits.Add(Command.East, doorWC);
            start.Exits.Add(Command.North, bed);
            start.Exits.Add(Command.South, doorLivingRoom);
            start.Exits.Add(Command.West, wallWithPoster);

            bed.Exits.Add(Command.East, doorWC);
            bed.Exits.Add(Command.South, doorLivingRoom);
            bed.Exits.Add(Command.West, wallWithPoster);

            doorWC.Exits.Add(Command.North, bed);
            doorWC.Exits.Add(Command.South, doorLivingRoom);
            doorWC.Exits.Add(Command.West, wallWithPoster);

            wallWithPoster.Exits.Add(Command.North, bed);
            wallWithPoster.Exits.Add(Command.South, doorLivingRoom);
            wallWithPoster.Exits.Add(Command.East, doorWC);

            doorLivingRoom.Exits.Add(Command.North, bed);
            doorLivingRoom.Exits.Add(Command.East, doorWC);
            doorLivingRoom.Exits.Add(Command.West, wallWithPoster);

            return start;

        }

        public override void GenerateSpecialActions(Frame frame, Command action, Bag bag, FileReader reader, string item)
        {
            try
            {
                if (action == Command.Hit) return;
            }

            catch
            {
                throw new NotImplementedException();
            }
        }

        public override void ClearLocationDictionaries()
        {
            start.Exits.Clear();
            bed.Exits.Clear();
            doorWC.Exits.Clear();
            wallWithPoster.Exits.Clear();
            doorLivingRoom.Exits.Clear();
        }
    }

}
