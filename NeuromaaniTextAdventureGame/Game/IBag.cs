using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuromaaniTextAdventureGame.Game
{
    public interface IBag
    {
        string GetVisibleBag();
        string GetTruncatedVisibleBag();
        bool IsItemInBag(string item);
        void AddItemToBag(string item);
        void RemoveItemFromBag(string item);
    }
}
