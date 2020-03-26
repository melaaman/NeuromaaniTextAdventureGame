using NeuromaaniTextAdventureGame.FileManager;
using NeuromaaniTextAdventureGame.Game;
using System.Collections.Generic;

namespace NeuromaaniTextAdventureGame.Rooms
{
    public class Location
    {
        private Dictionary<Command, Location> _exits = new Dictionary<Command, Location>();

        FileReader _reader = new FileReader();
        public string Item { get; set; }
        public string Person { get; set; }
        public bool ExitRoom { get; set; }
        public string File { get; set; }
        public int ChapterIndex { get; set; }
        public int FootnoteIndex { get; set; }
        public Command CurrentPoint { get; set; }
        public Dictionary<Command, Location> Exits { get { return _exits; } set { _exits = value; } }

    }
}
