using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuromaaniTextAdventureGame.Game
{
    public class Frame
    {
        private string _playerName = "";
        private int _pointsCurrent = 0;
        private int _pointsFull = 100;
        private List<string> _bag = new List<string>();
        public void ClearAndDrawFrame()
        {
            Console.Clear();
            DrawFrame();
        }

        public string GetPlayerName() => GeneralUtils.TruncateString(_playerName, 7);

        public void GivePlayerName(string playerName) {
            _playerName = playerName;
        }

        public void AddPoints(int points) => GeneralUtils.AddUntilHundred(_pointsCurrent, points);

        public void SubtractPoints(int points) => GeneralUtils.Subtract(_pointsCurrent, points);

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
        private void DrawFrame()
        {

            // pistepalkki

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("  ============================================================================================");
            Console.ResetColor();
            Console.SetCursorPosition(5, 1);
            Console.WriteLine("Nimi: {0}", GetPlayerName());
            Console.SetCursorPosition(22, 1);
            Console.WriteLine("Tyylipisteet: {0}/{1}", _pointsCurrent, _pointsFull);
            Console.SetCursorPosition(50, 1);
            Console.WriteLine("Reppu: {0}", GetTruncatedVisibleBag());
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  ============================================================================================");
            Console.ResetColor();

        }
    }
}
