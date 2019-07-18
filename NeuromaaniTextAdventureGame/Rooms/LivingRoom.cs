using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuromaaniTextAdventureGame.FileManager;
using NeuromaaniTextAdventureGame.Game;

namespace NeuromaaniTextAdventureGame.Rooms
{
    public class LivingRoom : PlayRoom
    {
        Location start = new Location()
        {
            File = "livingRoom.txt",
            ChapterIndex = 0,
            InfoIndex = 4,
            CurrentPoint = Direction.Default
        };
        public override Location setUp()
        {
            return start;
        }
        public override void GenerateSpecialActions(SpecialAction action, Bag bag, FileReader reader, Location location, string item)
        {
            throw new NotImplementedException();
        }
    }
}
