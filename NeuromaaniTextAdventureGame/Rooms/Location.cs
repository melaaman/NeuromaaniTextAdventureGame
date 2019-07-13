using NeuromaaniTextAdventureGame.FileManager;
using NeuromaaniTextAdventureGame.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuromaaniTextAdventureGame.Rooms
{
    public class Location
    {
        private Dictionary<Direction, Location> _exits = new Dictionary<Direction, Location>();


        FileReader _reader = new FileReader();
        //public string Name { get; set; }
        public string Item { get; set; }
        public string Person { get; set; }
        public bool ExitSpace { get; set; }
        public bool SpecialActions { get; set; }
        public string File { get; set; }
        public int ChapterIndex { get; set; }
        public Direction CurrentPoint { get; set; }
        public Dictionary<Direction, Location> Exits { get { return _exits; } set { _exits = value; } }

    }
}
