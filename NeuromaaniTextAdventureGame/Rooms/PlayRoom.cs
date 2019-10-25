using NeuromaaniTextAdventureGame.FileManager;
using NeuromaaniTextAdventureGame.Game;
using System;
using System.Linq;
using System.Threading;

namespace NeuromaaniTextAdventureGame.Rooms
{
    public abstract class PlayRoom
    {
        // The following methdos are overridden in each room
        public abstract Location SetUp();
        public abstract void GenerateSpecialActions(Frame frame, Command action, Bag bag, FileReader reader, string item);

        public abstract void ClearLocationDictionaries();
        public abstract string SpecialCommand { get; set; }

        // Play room
        public void Play(Frame frame, FileReader reader, Bag bag)
        {
            var location = SetUp();
            GetChapterTitle(location, frame);
            DescribeLocation(location, frame, reader);
            var exit = false;

            while (!exit)
            {
                Console.SetCursorPosition(4, GeneralUtils.GetTopCursore());
                var command = Console.ReadLine();
                var commandEnum = UserInput.ConvertCommandToEnum(command, SpecialCommand);

                switch (commandEnum)
                {
                    case Command.North:
                    case Command.East:
                    case Command.South:
                    case Command.West:
                    case Command.RoomSpecificLocation:
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
                        GetResponseToSpecialAction(frame, commandEnum, command, bag, reader, location);
                        break;
                    case Command.TakeItem:
                        TakeItem(command, location, bag, frame, reader);
                        break;
                    case Command.GetFootnote:
                        GetFootnote(location.File, location.FootnoteIndex, reader, location);
                        break;
                    case Command.ExitRoom:
                        if (location.ExitRoom)
                        {
                            ClearLocationDictionaries();
                            exit = true;
                        }
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

        void GetChapterTitle(Location location, Frame frame)
        {
            if (string.IsNullOrEmpty(location.Title)) return;
            else
            {
                frame.ClearAndDrawFrame();
                Console.SetCursorPosition(20, 10);
                location.Title.ToCharArray().ToList().ForEach(c =>
                {
                    Console.Write(c + " ");
                    Thread.Sleep(80);
                });
                Thread.Sleep(1500);
                frame.ClearAndDrawFrame();
            }
        }
        public void DescribeLocation(Location location, Frame frame, FileReader reader)
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

        void GetResponseToSpecialAction(Frame frame, Command command, string userInput, Bag bag, FileReader reader, Location location)
        {
            switch (command)
            {
                case Command.UseItem:
                    string item = userInput.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries)[1].ToLower().Trim();
                    if (bag.IsItemInBag(item)) GenerateSpecialActions(frame, command, bag, reader, item);
                    return;
                case Command.Hit:
                    Hit();
                    GenerateSpecialActions(frame, command, bag, reader, "");
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
            if (location.FootnoteIndex == 0) CreateAnswer("Ei alaviitteitä", reader);
            else reader.DisplayTextFromFile(file, chapterIndex, GeneralUtils.GetTopCursore());
        }
        public static string GenerateRandomAnswer(string[] answers)
        {
            Random random = new Random();
            var randomIndex = random.Next(answers.Length);
            return answers[randomIndex];
        }

    }
}
