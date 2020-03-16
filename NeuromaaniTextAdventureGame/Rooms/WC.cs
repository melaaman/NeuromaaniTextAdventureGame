using NeuromaaniTextAdventureGame.FileManager;
using NeuromaaniTextAdventureGame.Game;
using System;

namespace NeuromaaniTextAdventureGame.Rooms
{
    public class WC: PlayRoom
    {

        Location start = new Location()
        {
            Title = "PEILIIN TUIJOTTAMINEN MEDITAATIOKEINONA",
            File = "WC.txt",
            ChapterIndex = 0,
            FootnoteIndex = 6,
            CurrentPoint = Command.Default
        };

        Location toiletSeat = new Location()
        {
            File = "WC.txt",
            ChapterIndex = 1,
            CurrentPoint = Command.East
        };

        Location mirror = new Location()
        {
            File = "WC.txt",
            ChapterIndex = 2,
            CurrentPoint = Command.North,
        };

        public Location doorToBedroom = new Location()
        {
            File = "WC.txt",
            ChapterIndex = 3,
            CurrentPoint = Command.West,
            ExitRoom = true
        };

        Location wall = new Location()
        {
            File = "WC.txt",
            ChapterIndex = 4,
            CurrentPoint = Command.South,
            Item = "kivi"
        };

        Location loop = new Location()
        {
            File = "WC.txt",
            ChapterIndex = 5,
            CurrentPoint = Command.North,
        };
        public override Location SetUp()
        {
            start.Exits.Add(Command.East, toiletSeat);
            start.Exits.Add(Command.North, mirror);
            start.Exits.Add(Command.South, wall);
            start.Exits.Add(Command.West, doorToBedroom);

            toiletSeat.Exits.Add(Command.North, mirror);
            toiletSeat.Exits.Add(Command.South, wall);
            toiletSeat.Exits.Add(Command.West, doorToBedroom);

            wall.Exits.Add(Command.North, mirror);
            wall.Exits.Add(Command.West, doorToBedroom);
            wall.Exits.Add(Command.East, toiletSeat);

            doorToBedroom.Exits.Add(Command.North, mirror);
            doorToBedroom.Exits.Add(Command.South, wall);
            doorToBedroom.Exits.Add(Command.East, toiletSeat);

            mirror.Exits.Add(Command.South, loop);
            mirror.Exits.Add(Command.West, loop);
            mirror.Exits.Add(Command.East, loop);

            loop.Exits.Add(Command.South, loop);
            loop.Exits.Add(Command.West, loop);
            loop.Exits.Add(Command.East, loop);

            return start;
        }
        public override void GenerateSpecialActions(Frame frame, Command action, Bag bag, FileReader reader, string item)
        {
            try
            {
                if (action == Command.Hit && PlayGame.currentRoom == mirror) {
                    frame.SubtractPoints(1000);
                    frame.ClearAndDrawFrame();
                    reader.DisplayTextFromFile("WC.txt", 7, GeneralUtils.GetTopCursore());
                    PlayGame.gameOn = false;
                    GeneralUtils.PlayEnter(GeneralUtils.GetTopCursore());
                    PlayGame.gameOn = false;
                    PlayGame.gameOver = true;
                }
                if (action == Command.UseItem && bag.IsItemInBag(item) && item == "kivi")
                {
                    if (PlayGame.currentRoom == mirror)
                    {
                        frame.AddPoints(53);
                        frame.ClearAndDrawFrame();
                        reader.DisplayTextFromFile("WC.txt", 8, GeneralUtils.GetTopCursore());
                        GeneralUtils.PlayEnter(GeneralUtils.GetTopCursore());
                        PlayGame.gameOn = false;
                    }
                    else
                    {
                        reader.DisplayText("Ehkäpä tavaralla on käyttöä jossain muussa tilanteessa.", GeneralUtils.GetTopCursore());
                    }
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
