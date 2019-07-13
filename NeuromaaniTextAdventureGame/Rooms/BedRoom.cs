using NeuromaaniTextAdventureGame.FileManager;
using NeuromaaniTextAdventureGame.Game;
using System;
using System.Collections.Generic;

namespace NeuromaaniTextAdventureGame.Rooms
{
    public class BedRoom: PlayRoom
    {
        Location start = new Location()
        {
            File = "bedroom.txt",
            ChapterIndex = 0,
            SpecialActions = true,
            CurrentPoint = Direction.North,
        };

        Location bed = new Location()
        {
            File = "bedroom.txt",
            ChapterIndex = 1,
            CurrentPoint = Direction.North,
        };

        Location wallWithPoster = new Location()
        {
            File = "bedroom.txt",
            ChapterIndex = 2,
            CurrentPoint = Direction.West,
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

        public override void GenerateSpecialActions(SpecialAction action, Frame frame)
        {
            if (action == SpecialAction.Hit)
            {

            }
        }
    }
}
