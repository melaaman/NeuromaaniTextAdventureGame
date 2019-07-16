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
        private Bag _bag;

        public Frame(Bag bag, int pointsCurrent)
        {
            _bag = bag;
            _pointsCurrent = pointsCurrent;
        }
        public void ClearAndDrawFrame()
        {
            Console.Clear();
            DrawFrame();
        }

        public void AddPoints(int points) => _pointsCurrent = GeneralUtils.AddUntilHundred(_pointsCurrent, points);

        public string GetPlayerName() => GeneralUtils.TruncateString(_playerName, 7);

        public void GivePlayerName(string playerName) {
            _playerName = playerName;
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
            Console.WriteLine("Pisteet: {0}/{1}", _pointsCurrent, _pointsFull);
            Console.SetCursorPosition(50, 1);
            Console.WriteLine("Reppu: {0}", _bag.GetTruncatedVisibleBag());
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  ============================================================================================");
            Console.ResetColor();

        }
    }
}
