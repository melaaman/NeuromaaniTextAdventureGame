using NeuromaaniTextAdventureGame.FileManager;
using NeuromaaniTextAdventureGame.Game;
using System;
using System.Collections.Generic;

namespace NeuromaaniTextAdventureGame.Rooms
{
    public class BedRoom : PlayRoom
    {
        Location start = new Location()
        {
            File = "bedroom.txt",
            ChapterIndex = 0,
            InfoIndex = 1,
            CurrentPoint = Command.Default
        };

        Location bed = new Location()
        {
            File = "bedroom.txt",
            ChapterIndex = 2,
            InfoIndex = 3,
            CurrentPoint = Command.North,
            Person = "Tyyppi",
            Item = "tavara"
        };

        Location wallWithPoster = new Location()
        {
            File = "bedroom.txt",
            ChapterIndex = 4,
            InfoIndex = 5,
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

        public override Location setUp()
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

        public override void GenerateSpecialActions(Command action, Bag bag, FileReader reader, Location location, string item)
        {
            try
            {
                if (action == Command.UseItem && bag.IsItemInBag(item))
                {
                    if (location.CurrentPoint == Command.North)
                    {
                        reader.DisplayText("Käytit tavaraa", GeneralUtils.GetTopCursore());
                        
                    }

                    if (location.CurrentPoint == Command.East)
                    {
                        reader.DisplayText("Käytit tavaraa", GeneralUtils.GetTopCursore());
                    }

                    if (location.CurrentPoint == Command.South)
                    {
                        //
                    }

                    if (location.CurrentPoint == Command.West)
                    {
                        //
                    }
                }

                if (action == Command.Hit)
                {
                    reader.DisplayText("Not nice", GeneralUtils.GetTopCursore());
                }
            }

            catch {
                throw new NotImplementedException();
            }
        }
    }

}
