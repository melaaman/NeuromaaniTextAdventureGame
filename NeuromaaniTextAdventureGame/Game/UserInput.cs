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

    public enum SpecialAction
    {
        Hit,
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
        public static string[] specialActionCommands = hitCommand;

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
        public static bool IsCommandAction(string command) => hitCommand.Contains(command.ToLower().Trim()) ? true : false;

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

        public static SpecialAction ConvertActionCommandToEnum(string command)
        {
            var trimmedCommand = command.ToLower().Trim();

            if (hitCommand.Contains(trimmedCommand))
            {
                return SpecialAction.Hit;
            }

            else
            {
                return SpecialAction.Default;
            }
        }


        // Function that prints instructions how to play game

        public static void GiveInstructions() {
            Frame.ClearAndDrawFrame();
            Console.SetCursorPosition(4, 19);
            Console.WriteLine("Ohjeita");
        }

        // TO DO: Function that prints answer to "ööö" type of help

        // Functions that generate answers to general questions

        public static void GenerateAnswerFromEnum(Say say, string person)
        {

            if (say == Say.Hello)
            {
                string[] answers =  { "No hei vaan", "Terve", "Hej" };
                Console.WriteLine("{0} sanoo: {1}", person, generateRandomAnswer(answers));
            }

            if (say == Say.Stupid)
            {
                string[] answers = { "Se oli ikävästi sanottu.", "????" };
                Console.WriteLine("{0} sanoo: {1}", person, generateRandomAnswer(answers));
            }

            if (say == Say.HowAreYou)
            {
                string[] answers = { "Ihan ok", "Siinähän se" };
                Console.WriteLine("{0} sanoo: {1}", person, generateRandomAnswer(answers));
            }
        }

        // Helper functions
        public static string generateRandomAnswer(string[] answers)
        {
            Random random = new Random();
            var randomIndex = random.Next(answers.Length);
            return answers[randomIndex];
        }

    }
}
