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
            SpecialActions = true,
            CurrentPoint = Direction.North,
            Person = "tyyppi",
        };

        Location bed = new Location()
        {
            File = "bedroom.txt",
            ChapterIndex = 1,
            SpecialActions = true,
            CurrentPoint = Direction.North,
            Person = "tyyppi"
        };

        Location wallWithPoster = new Location()
        {
            File = "bedroom.txt",
            ChapterIndex = 2,
            CurrentPoint = Direction.West,
            Item = "juliste"
        };

        Location doorWC = new Location()
        {
            File = "bedroom.txt",
            ChapterIndex = 3,
            CurrentPoint = Direction.East,
            ExitSpace = true,
        };

        Location doorLivingRoom = new Location()
        {
            File = "bedroom.txt",
            ChapterIndex = 4,
            ExitSpace = true,
        };

        public override Location setUp()
        {
            start.Exits.Add(Direction.East, doorWC);
            start.Exits.Add(Direction.South, doorLivingRoom);
            start.Exits.Add(Direction.West, wallWithPoster);

            bed.Exits.Add(Direction.East, doorWC);
            bed.Exits.Add(Direction.South, doorLivingRoom);
            bed.Exits.Add(Direction.West, wallWithPoster);

            doorWC.Exits.Add(Direction.North, bed);
            doorWC.Exits.Add(Direction.South, doorLivingRoom);
            doorWC.Exits.Add(Direction.West, wallWithPoster);

            wallWithPoster.Exits.Add(Direction.North, bed);
            wallWithPoster.Exits.Add(Direction.South, doorLivingRoom);
            wallWithPoster.Exits.Add(Direction.East, doorWC);

            doorLivingRoom.Exits.Add(Direction.North, bed);
            doorLivingRoom.Exits.Add(Direction.East, doorWC);
            doorLivingRoom.Exits.Add(Direction.West, wallWithPoster);


            return start;

        }

        public override void GenerateSpecialActions(SpecialAction action, Bag bag, FileReader reader, Location location, string item)
        {
            try
            {
                if (action == SpecialAction.UseItem && bag.IsItemInBag(item))
                {
                    if (location.CurrentPoint == Direction.North)
                    {
                        reader.DisplayText("Käytit tavaraa", GeneralUtils.GetTopCursore());
                        
                    }

                    if (location.CurrentPoint == Direction.East)
                    {
                        //
                    }

                    if (location.CurrentPoint == Direction.South)
                    {
                        //
                    }

                    if (location.CurrentPoint == Direction.West)
                    {
                        //
                    }
                }

                if (action == SpecialAction.Hit)
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
