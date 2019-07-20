using NeuromaaniTextAdventureGame.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;


namespace NeuromaaniTextAdventureGame.Game
{
    public enum Command
    {
        North,
        South,
        West,
        East,
        Hello,
        Stupid,
        HowAreYou,
        Hit,
        UseItem,
        TakeItem,
        GetFootnote,
        AskHelp,
        ExitRoom,
        ExitGame,
        Default
    }
    public class UserInput
    {
        FileReader _reader = new FileReader();

        public static string[] moveNorth = { "pohjoiseen", "mene pohjoiseen", "liiku pohjoiseen" };
        public static string[] moveEast = { "itään", "mene itään", "liiku itään" };
        public static string[] moveSouth = { "etelään", "mene etelään", "liiku etelään" };
        public static string[] moveWest = { "länteen", "mene länteen", "liiku länteen" };

        public static string[] askHelp = { "apua", "öö", "ööö", "öööö" };
        public static string[] askInformation = { "alaviite", "alaviitteet", "av" };

        public static string[] sayHello = { "hei", "moi", "terve", "haloo", "morjes", "moro" };
        public static string[] sayStupid = { "hölmö", "idiootti", "tyhmä" };
        public static string[] askHowAreYou = { "mitä kuuluu", "miten menee" };
        public static string[] exitRoomCommands = { "astu sisään", "eteenpäin", "mene eteenpäin" };
        public static string[] exitGameCommands = { "lopeta" };
        public static bool IsCommandMoveNorth(string command) => moveNorth.Contains(command.ToLower().Trim()) ? true : false;
        public static bool IsCommandMoveEast(string command) => moveEast.Contains(command.ToLower().Trim()) ? true : false;
        public static bool IsCommandMoveSouth(string command) => moveSouth.Contains(command.ToLower().Trim()) ? true : false;
        public static bool IsCommandMoveWest(string command) => moveWest.Contains(command.ToLower().Trim()) ? true : false;
        public static bool IsCommandAskHelp(string command) => askHelp.Contains(command.ToLower().Trim()) ? true : false;
        public static bool IsCommandGetFootnote(string command) => askInformation.Contains(command.ToLower().Trim()) ? true : false;
        public static bool IsCommandHit(string command) => !string.IsNullOrEmpty(command) && command.ToLower().Trim() == "lyö" ? true : false;
        public static bool IsCommandExitRoom(string command) => !string.IsNullOrEmpty(command) && exitRoomCommands.Contains(command.ToLower().Trim()) ? true : false;
        public static bool IsCommandExitGame(string command) => !string.IsNullOrEmpty(command) && exitGameCommands.Contains(command.ToLower().Trim()) ? true : false;
        public static bool IsCommandTakeItem(string command) => (command.Split(new[] { ' ' }, 2, StringSplitOptions.None)[0].ToLower() == "ota" &&
            command.Split(' ').Length > 1) ? true : false;
        public static bool IsCommandSayHello(string command)
        {
            if (command.Contains(" "))
            {
                string[] splitCommand = command.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
                return splitCommand[0].ToLower() == "sano" && sayHello.Contains(splitCommand[1].ToLower().Trim()) ? true : false;
            }

            return false;
        }
        public static bool IsCommandSayHowAreYou(string command)
        {
            if (command.Contains(" "))
            {
                string[] splitCommand = command.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
                return splitCommand[0].ToLower() == "sano" && askHowAreYou.Contains(splitCommand[1].ToLower().Trim()) ? true : false;
            }

            return false;
        }

        public static bool IsCommandSayStupid(string command)
        {
            if (command.Contains(" "))
            {
                string[] splitCommand = command.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
                return splitCommand[0].ToLower() == "sano" && sayStupid.Contains(splitCommand[1].ToLower().Trim()) ? true : false;
            }

            return false;
        }
        public static bool IsCommandUseItem(string command)
        {
            if (command.Contains(" "))
            {
                string[] splitCommand = command.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
                return splitCommand[0].ToLower().Trim() == "käytä" ? true : false;
            }

            return false;
        }
        public static Command ConvertCommandToEnum(string command)
        {
            if (IsCommandMoveNorth(command))
            {
                return Command.North;
            }

            if (IsCommandMoveEast(command))
            {
                return Command.East;
            }

            if (IsCommandMoveSouth(command))
            {
                return Command.South;
            }

            if (IsCommandMoveWest(command))
            {
                return Command.West;
            }

            if (IsCommandSayHello(command))
            {
                return Command.Hello;
            }

            if (IsCommandSayStupid(command))
            {
                return Command.Stupid;
            }

            if (IsCommandSayHowAreYou(command))
            {
                return Command.HowAreYou;
            }

            if (IsCommandUseItem(command))
            {
                return Command.UseItem;
            }

            if (IsCommandHit(command))
            {
                return Command.Hit;
            }

            if (IsCommandGetFootnote(command))
            {
                return Command.GetFootnote;
            }

            if (IsCommandAskHelp(command))
            {
                return Command.AskHelp;
            }

            if (IsCommandTakeItem(command))
            {
                return Command.TakeItem;
            }

            if (IsCommandExitRoom(command))
            {
                return Command.ExitRoom;
            }

            if (IsCommandExitGame(command))
            {
                return Command.ExitGame;
            }

            else
            {
                return Command.Default;
            }
        }

    }
}
