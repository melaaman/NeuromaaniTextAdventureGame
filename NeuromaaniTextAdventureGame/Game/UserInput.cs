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
        RoomSpecific,
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
        public static string[] hitCommands = { "lyö" };
        public static string[] exitRoomCommands = { "astu sisään", "eteenpäin", "mene eteenpäin" };
        public static string[] exitGameCommands = { "lopeta" };
        public static bool IsCommandMoveNorth(string command) => IsCommandInCommandArray(command, moveNorth);
        public static bool IsCommandMoveEast(string command) => IsCommandInCommandArray(command, moveEast);
        public static bool IsCommandMoveSouth(string command) => IsCommandInCommandArray(command, moveSouth);
        public static bool IsCommandMoveWest(string command) => IsCommandInCommandArray(command, moveWest);
        public static bool IsCommandAskHelp(string command) => IsCommandInCommandArray(command, askHelp);
        public static bool IsCommandGetFootnote(string command) => IsCommandInCommandArray(command, askInformation);
        public static bool IsCommandHit(string command) => IsCommandInCommandArray(command, hitCommands);
        public static bool IsCommandExitRoom(string command) => IsCommandInCommandArray(command, exitRoomCommands);
        public static bool IsCommandExitGame(string command) => IsCommandInCommandArray(command, exitGameCommands);
        public static bool IsCommandTakeItem(string command) => IsCommandTakeOrUseItem(command, "ota");
        public static bool IsCommandUseItem(string command) => IsCommandTakeOrUseItem(command, "käytä");
        public static bool IsCommandSayHello(string command) => IsSayCommand(command, sayHello);
        public static bool IsCommandSayHowAreYou(string command) => IsSayCommand(command, askHowAreYou);
        public static bool IsCommandSayStupid(string command) => IsSayCommand(command, sayStupid);
        static bool IsCommandInCommandArray(string command, string[] possibleCommands) => possibleCommands.Contains(command.ToLower().Trim()) ? true : false;
        static bool IsCommandTakeOrUseItem(string command, string verb)
        {
            if (command.Contains(" "))
            {
                string[] splitCommand = command.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
                return splitCommand[0].ToLower().Trim() == verb ? true : false;
            }

            return false;
        }
        static bool IsSayCommand(string command, string[] possibleCommands)
        {
            if (command.Contains(" "))
            {
                string[] splitCommand = command.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
                return splitCommand[0].ToLower() == "sano" && possibleCommands.Contains(splitCommand[1].ToLower().Trim()) ? true : false;
            }
            return false;
        }


        public static Command ConvertCommandToEnum(string command, string roomSpecificCommand)
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

            if (command == roomSpecificCommand)
            {
                return Command.RoomSpecific;
            }

            else
            {
                return Command.Default;
            }
        }

    }
}
