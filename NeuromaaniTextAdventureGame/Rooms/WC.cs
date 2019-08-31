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
        private string _specialCommand = "aja parta";

        Location start = new Location()
        {
            Title = "PEILIIN TUIJOTTAMINEN MEDITAATIOKEINONA",
            File = "WC.txt",
            ChapterIndex = 0,
            FootnoteIndex = 1,
            CurrentPoint = Command.Default
        };

        Location shaving = new Location()
        {
            File = "WC.txt",
            ChapterIndex = 2,
            CurrentPoint = Command.East
        };

        public override string SpecialCommand { get { return _specialCommand; } set { _specialCommand = value; } }

        public override void GenerateSpecialActions(Frame frame, Command action, Bag bag, FileReader reader, string item)
        {
            throw new NotImplementedException();
        }

        public override Location SetUp()
        {
            start.Exits.Add(Command.RoomSpecificLocation, shaving);
            return start;
        }

    }
}
