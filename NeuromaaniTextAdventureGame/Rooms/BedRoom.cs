using NeuromaaniTextAdventureGame.FileManager;
using NeuromaaniTextAdventureGame.Game;
using System;
using System.Collections.Generic;

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
            FootnoteIndex = 1,
            CurrentPoint = Command.North
        };

        Location bed = new Location()
        {
            File = "bedroom.txt",
            ChapterIndex = 2,
            FootnoteIndex = 3,
            CurrentPoint = Command.North,
            Item = "kivi"
        };

        Location wallWithPoster = new Location()
        {
            File = "bedroom.txt",
            ChapterIndex = 4,
            FootnoteIndex = 5,
            CurrentPoint = Command.West
        };

        public Location doorWC = new Location()
        {
            File = "bedroom.txt",
            ChapterIndex = 6,
            CurrentPoint = Command.East,
            ExitRoom = true
        };

        public Location doorLivingRoom = new Location()
        {
            File = "bedroom.txt",
            ChapterIndex = 7,
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
                if (action == Command.UseItem && bag.IsItemInBag(item))
                {
                    reader.DisplayText("Ehkäpä tavaralla on käyttöä jossain muussa tilanteessa.", GeneralUtils.GetTopCursore());

                }
            }

            catch {
                throw new NotImplementedException();
            }
        }
    }

}
