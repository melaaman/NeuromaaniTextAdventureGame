using NeuromaaniTextAdventureGame.FileManager;
using NeuromaaniTextAdventureGame.Game;
using System;
using System.Collections.Generic;

namespace NeuromaaniTextAdventureGame.Rooms
{
    public class BedRoom: PlayRoom
    {
        Location bed = new Location()
        {
            Name = "bed",
            DescriptionFile = "bedroom.txt",
            ChapterIndex = 0,
            Person = null,
            ExitSpace = false,
            Exits = new Dictionary<Direction, Location>()
        };

        Location wall = new Location()
        {
            Name = "bed",
            DescriptionFile = "bedroom.txt",
            ChapterIndex = 1,
            Person = null,
            ExitSpace = false,
            Exits = new Dictionary<Direction, Location>()
        };

        Location door = new Location()
        {
            Name = "startDoor",
            ExitSpace = true
        };

        public override Location setUp()
        {
            bed.Exits.Add(Direction.East, wall);
            return bed;

        }

        public override void generateSpecialActions(SpecialAction action)
        {
            throw new NotImplementedException();
        }
    }
}
