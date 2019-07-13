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
        public void ClearAndDrawFrame()
        {
            Console.Clear();
            DrawFrame();
        }

        public string GetPlayerName() => GeneralUtils.TruncateString(_playerName);

        public void GivePlayerName(string playerName) {
            _playerName = playerName;
        }

        public void AddPoints(int points) => GeneralUtils.AddUntilHundred(_pointsCurrent, points);

        public void SubtractPoints(int points) => GeneralUtils.Subtract(_pointsCurrent, points);

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
            Console.WriteLine("Reppu: {0}", "Tähän repun sisältö");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  ============================================================================================");
            Console.ResetColor();

        }
    }
}
