using NeuromaaniTextAdventureGame.FileManager;
using NeuromaaniTextAdventureGame.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuromaaniTextAdventureGame.Rooms
{
    public class WC: PlayRoom
    {

        Location start = new Location()
        {
            File = "WC.txt",
            ChapterIndex = 0,
            InfoIndex = 1,
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
