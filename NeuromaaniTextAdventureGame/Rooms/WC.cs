using NeuromaaniTextAdventureGame.FileManager;
using NeuromaaniTextAdventureGame.Game;
using System;

namespace NeuromaaniTextAdventureGame.Rooms
{
    public class WC: PlayRoom
    {
        private string _specialCommand = "aja parta";

        Location start = new Location()
        {
            Title = "PEILIIN TUIJOTTAMINEN MEDITAATIOKEINONA",
            File = "WC.txt",
            ChapterIndex = 0,
            FootnoteIndex = 1,
            CurrentPoint = Command.South
        };

        Location mirror = new Location()
        {
            File = "WC.txt",
            ChapterIndex = 2,
            CurrentPoint = Command.North
        };

        Location toiletSeat = new Location()
        {
            File = "WC.txt",
            ChapterIndex = 3,
            CurrentPoint = Command.South
        };

        public Location doorToBedroom = new Location()
        {
            File = "WC.txt",
            ChapterIndex = 4,
            CurrentPoint = Command.West,
            ExitRoom = true
        };

        Location wall = new Location()
        {
            File = "WC.txt",
            ChapterIndex = 5,
            CurrentPoint = Command.East,
        };
        public override Location SetUp()
        {
            start.Exits.Add(Command.North, mirror);
            start.Exits.Add(Command.East, wall);
            start.Exits.Add(Command.West, doorToBedroom);

            toiletSeat.Exits.Add(Command.North, mirror);
            toiletSeat.Exits.Add(Command.East, wall);
            toiletSeat.Exits.Add(Command.West, doorToBedroom);

            wall.Exits.Add(Command.North, mirror);
            wall.Exits.Add(Command.West, doorToBedroom);
            wall.Exits.Add(Command.South, toiletSeat);

            doorToBedroom.Exits.Add(Command.North, mirror);
            doorToBedroom.Exits.Add(Command.East, wall);
            doorToBedroom.Exits.Add(Command.South, toiletSeat);

            mirror.Exits.Add(Command.East, wall);
            mirror.Exits.Add(Command.West, doorToBedroom);
            mirror.Exits.Add(Command.South, toiletSeat);

            return start;
        }

        public override string SpecialCommand { get { return _specialCommand; } set { _specialCommand = value; } }

        public override void GenerateSpecialActions(Frame frame, Command action, Bag bag, FileReader reader, string item)
        {
            try
            {
                if (action == Command.Hit) return;
                if (action == Command.UseItem && bag.IsItemInBag(item))
                {
                    reader.DisplayText("Ehkäpä tavaralla on käyttöä jossain muussa tilanteessa.", GeneralUtils.GetTopCursore());

                }
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public override void ClearLocationDictionaries()
        {
            start.Exits.Clear();
            mirror.Exits.Clear();
            toiletSeat.Exits.Clear();
            doorToBedroom.Exits.Clear();
            wall.Exits.Clear();
        }
    }
}
