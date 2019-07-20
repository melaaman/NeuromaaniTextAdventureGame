using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuromaaniTextAdventureGame.Game
{
    public class Bag
    {
        private List<string> _bag;
        public Bag(List<string> bag) => _bag = bag;
        public void AddItemToBag(string item)
        {
            if (!_bag.Exists(i => i == item) == false) return;
            _bag.Add(item);
        }
        public bool IsItemInBag(string item)
        {
            if (_bag.Contains(item)) return true;
            return false;
        }
        public void RemoveItemFromBag(string item)
        {

            if (!_bag.Exists(i => i == item) || _bag.Count == 0) return;
            _bag.Remove(item);
        }
        public string GetVisibleBag()
        {
            if (_bag == null) return "";
            return string.Join(", ", _bag);
        }
        public string GetTruncatedVisibleBag()
        {
            if (_bag == null) return "";
            return GeneralUtils.TruncateString(string.Join(", ", _bag), 30);
        }
    }
}
