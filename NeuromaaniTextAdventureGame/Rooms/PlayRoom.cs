using NeuromaaniTextAdventureGame.FileManager;
using NeuromaaniTextAdventureGame.Game;
using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace NeuromaaniTextAdventureGame.Rooms
{
    public abstract class PlayRoom
    {
        // The following methdos are overridden in each room
        public abstract Location setUp();
        public abstract void GenerateSpecialActions(Command action, Bag bag, FileReader reader, Location location, string item);

        // Play room
        public void Play(Frame frame, FileReader reader, Bag bag)
        {
            var location = setUp();
            DescribeLocation(location, frame, reader);
            var exit = false;

            while (!exit)
            {
                Console.SetCursorPosition(4, GeneralUtils.GetTopCursore());
                var command = Console.ReadLine();
                var commandEnum = UserInput.ConvertCommandToEnum(command);

                switch (commandEnum)
                {
                    case Command.North:
                    case Command.East:
                    case Command.South:
                    case Command.West:
                        Location destination;
                        if (location.CurrentPoint == commandEnum) CreateAnswer("Olet jo siellä", reader);
                        else if (location.Exits.TryGetValue(commandEnum, out destination))
                        {
                            location = destination;
                            DescribeLocation(location, frame, reader);
                            PlayGame.currentRoom = location;
                        }
                        else CreateAnswer("Et pääse sinne.", reader);
                        break;
                    case Command.Hello:
                    case Command.HowAreYou:
                    case Command.Stupid:
                        if (location.Person != null) GetAnswerToSaycommand(commandEnum, location.Person, reader);
                        break;
                    case Command.AskHelp:
                        reader.DisplayTextFromFile("ohjeita.txt", 0, GeneralUtils.GetTopCursore());
                        break;
                    case Command.UseItem:
                    case Command.Hit:
                        GetResponseToSpecialAction(commandEnum, command, bag, reader, location);
                        break;
                    case Command.TakeItem:
                        TakeItem(command, location, bag, frame, reader);
                        break;
                    case Command.GetFootnote:
                        GetFootnote(location.File, location.InfoIndex, reader, location);
                        break;
                    case Command.ExitRoom:
                        if (location.ExitRoom) exit = true;
                        else CreateAnswer("Ei poistumiskäyntiä", reader);
                        break;
                    case Command.ExitGame:
                        exit = true;
                        break;
                    default:
                        CreateAnswer("Gereg ei ymmärrä käskyäsi.", reader);
                        break;
                }
            }
        }

        void DescribeLocation(Location location, Frame frame, FileReader reader)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            frame.ClearAndDrawFrame();
            reader.DisplayTextFromFile(location.File, location.ChapterIndex, 4);
        }

        void CreateAnswer(string answer, FileReader reader)
        {
            reader.DisplayText(answer, GeneralUtils.GetTopCursore());
        }
        public static string GenerateRandomAnswer(string[] answers)
        {
            Random random = new Random();
            var randomIndex = random.Next(answers.Length);
            return answers[randomIndex];
        }
        void Hit()
        {
            string pam = @"
 _____  ___ ___  ____ 
| ___ \/ _ \|  \/  | |
| |_/ / /_\ \ .  . | |
|  __/|  _  | |\/| | |
| |   | | | | |  | |_|
\_|   \_| |_|_|  |_(_)";

            string[] rows = pam.Split(new string[] { "\n" }, StringSplitOptions.None);
            var top = GeneralUtils.GetTopCursore();

            foreach (var row in rows)
            {
                Console.SetCursorPosition(4, top);
                Console.WriteLine(row);
                top++;
            }

            Thread.Sleep(500);
        }

        void GetAnswerToSaycommand(Command command, string person, FileReader reader)
        {
            switch (command)
            {
                case Command.Hello:
                    string[] answersToHello = { "No hei vaan", "Terve", "Hej" };
                    CreateAnswer(person + " sanoo: " + GenerateRandomAnswer(answersToHello), reader);
                    return;
                case Command.HowAreYou:
                    string[] answersToHowAreYou = { "Ihan ok", "Siinähän se" };
                    CreateAnswer(person + " sanoo: " + GenerateRandomAnswer(answersToHowAreYou), reader);
                    return;
                case Command.Stupid:
                    string[] answersToCallingNames = { "Se oli ikävästi sanottu.", "????" };
                    CreateAnswer(person + " sanoo: " + GenerateRandomAnswer(answersToCallingNames), reader);
                    return;
                default:
                    return;
            }
        }

        void GetResponseToSpecialAction(Command command, string userInput, Bag bag, FileReader reader, Location location)
        {
            switch (command)
            {
                case Command.UseItem:
                    string item = userInput.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries)[1].ToLower().Trim();
                    if (bag.IsItemInBag(item)) GenerateSpecialActions(command, bag, reader, location, item);
                    return;
                case Command.Hit:
                    Hit();
                    GenerateSpecialActions(command, bag, reader, location, "");
                    return;
                default:
                    return;
            }
        }

        void TakeItem(string command, Location location, Bag bag, Frame frame, FileReader reader)
        {
            if (command.Split(new string[] { " " }, StringSplitOptions.None)[1] == location.Item)
            {
                bag.AddItemToBag(location.Item);
                DescribeLocation(location, frame, reader);
            }

            else CreateAnswer("Et voi ottaa tavaraa.", reader);
        }

        void GetFootnote(string file, int chapterIndex, FileReader reader, Location location)
        {
            // If location doesn't have InfoIndex, the index is 0 by default
            if (location.InfoIndex == 0) CreateAnswer("Ei alaviitteitä", reader);
            else reader.DisplayTextFromFile(file, chapterIndex, GeneralUtils.GetTopCursore());
        }

    }
}
