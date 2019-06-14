using NeuromaaniTextAdventureGame.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuromaaniTextAdventureGame.Locations
{
    public class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Item { get; set; }
        public string Person { get; set; }
        public bool ExitSpace { get; set; }
        public bool SpecialActions { get; set; }
        public Dictionary<Direction, Location> Exits { get; set; }

    }
}
