using NeuromaaniTextAdventureGame.FileManager;
using System;
using System.Linq;


namespace NeuromaaniTextAdventureGame.Game
{
    public enum Direction
    {
        North,
        South,
        West,
        East,
        Default

    }
    public enum Say
    {
        Hello,
        Stupid,
        HowAreYou,
        Default
    }

    public enum Hit
    {
        Hit,
        Default
    }

    public enum SpecialAction
    {
        Default
    }
    public class UserInput
    {
        FileReader _reader = new FileReader();

        // User input possibilities

        public static string[] moveNorth = { "pohjoiseen", "mene pohjoiseen", "liiku pohjoiseen" };
        public static string[] moveEast = { "itään", "mene itään", "liiku itään" };
        public static string[] moveSouth = { "etelään", "mene etelään", "liiku etelään" };
        public static string[] moveWest = { "länteen", "mene länteen", "liiku länteen" };
        public static string[] directionCommands = moveNorth.Concat(moveEast).Concat(moveSouth).Concat(moveWest).ToArray();

        public static string[] askHelp = { "apua", "öö", "ööö", "öööö" };

        public static string[] sayHello = { "hei", "moi", "terve", "haloo", "morjes", "moro" };
        public static string[] sayStupid = { "hölmö", "idiootti", "tyhmä" };
        public static string[] askHowAreYou = { "mitä kuuluu", "miten menee" };
        public static string[] sayCommands = sayHello.Concat(sayStupid).Concat(askHowAreYou).ToArray();

        public static string[] hitCommand = { "lyö" };
        public static string[] specialActionCommands = { };

        // Functions to check that user inputs are correct
        public static bool IsCommandDirection(string command) => directionCommands.Contains(command.ToLower().Trim()) ? true : false;
        public static bool IsCommandAskHelp(string command) => askHelp.Contains(command.ToLower().Trim()) ? true : false;
        public static bool IsCommandTakeItem(string command) => (command.Split(new[] { ' ' }, 2, StringSplitOptions.None)[0].ToLower() == "ota" &&
            command.Split(' ').Length > 1) ? true : false;
        public static bool IsCommandSay(string command)
        {
            if (!string.IsNullOrEmpty(command) && command.Contains(" "))
            {
                string[] splitCommand = command.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
                return splitCommand[0].ToLower() == "sano" && sayCommands.Contains(splitCommand[1].ToLower().Trim()) ? true : false;
            }

            return false;
        }
        public static bool IsCommandHit(string command) => hitCommand.Contains(command.ToLower().Trim()) ? true : false;

        public static bool IsCommandSpecialAction(string command) => specialActionCommands.Contains(command.ToLower().Trim()) ? true : false;
        // Functions that convert user inputs to Enums

        public static Direction ConvertCommandToDirectionEnum(string command)
        {
            if (moveEast.Contains(command))
            {
                return Direction.East;
            }

            else if (moveWest.Contains(command))
            {
                return Direction.West;
            }

            else if (moveSouth.Contains(command))
            {
                return Direction.South;
            }

            else if (moveNorth.Contains(command))
            {
                return Direction.North;
            }

            else
            {
                return Direction.Default;
            }
        }

        public static Say ConvertGeneralSayCommandEnum(string command)
        {
            var phrase = command.Split(new string[] { " " }, 2, StringSplitOptions.RemoveEmptyEntries)[1].ToLower().Trim();

            if (sayHello.Contains(phrase))
            {
                return Say.Hello;
            }

            else if (sayStupid.Contains(phrase))
            {
                return Say.Stupid;
            }

            else if (askHowAreYou.Contains(phrase))
            {
                return Say.HowAreYou;
            }

            else
            {
                return Say.Default;
            }
        }

        public static Hit ConvertHitCommandToEnum(string command)
        {
            var trimmedCommand = command.ToLower().Trim();

            if (hitCommand.Contains(trimmedCommand))
            {
                return Hit.Hit;
            }

            else
            {
                return Hit.Default;
            }
        }
        public static SpecialAction ConvertActionCommandToEnum(string command)
        {
            var trimmedCommand = command.ToLower().Trim();
            return SpecialAction.Default;
        }

    }
}
