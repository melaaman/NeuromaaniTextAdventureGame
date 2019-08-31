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
            CurrentPoint = Command.Default
        };

        public override string SpecialCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override Location SetUp()
        {
            return start;
        }
        public override void GenerateSpecialActions(Frame frame, Command action, Bag bag, FileReader reader, string item)
        {
            throw new NotImplementedException();
        }
    }
}
