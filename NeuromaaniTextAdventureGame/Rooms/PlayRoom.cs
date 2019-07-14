using NeuromaaniTextAdventureGame.FileManager;
using NeuromaaniTextAdventureGame.Game;
using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace NeuromaaniTextAdventureGame.Rooms
{
    public abstract class PlayRoom
    {
        public abstract Location setUp();
        public abstract void GenerateSpecialActions(SpecialAction action, Frame frame);

        void describeLocation(Location location, Frame frame, FileReader reader)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            frame.ClearAndDrawFrame();
            reader.DisplayTextFromFile(location.File, location.ChapterIndex, 4);
        }

        void GenerateAnswer(string answer, FileReader reader)
        {
            reader.DisplayText(answer, GetTopCursore());
        }

        int GetTopCursore()
        {
            return Console.CursorTop + 1;
        }
        void Hit()
        {
            string pam = @"
______  ___ ___  ____ 
| ___ \/ _ \|  \/  | |
| |_/ / /_\ \ .  . | |
|  __/|  _  | |\/| | |
| |   | | | | |  | |_|
\_|   \_| |_|_|  |_(_)";

            string[] pamRivit = pam.Split(new string[] { "\n" }, StringSplitOptions.None);
            var top = GetTopCursore();

            Console.SetCursorPosition(4, top);

            foreach (var item in pamRivit)
            {
                //kysyUudelleen = false;
                Console.SetCursorPosition(4, top);
                Console.WriteLine(item);
                top++;
            }

            Thread.Sleep(500);
        }

        void GenerateAnswerFromEnum(Say say, string person, FileReader reader)
        {

            if (say == Say.Hello)
            {
                string[] answers = { "No hei vaan", "Terve", "Hej" };
                GenerateAnswer(person + " sanoo: " + GenerateRandomAnswer(answers), reader);
            }

            if (say == Say.Stupid)
            {
                string[] answers = { "Se oli ikävästi sanottu.", "????" };
                GenerateAnswer(person + " sanoo: " + GenerateRandomAnswer(answers), reader);
            }

            if (say == Say.HowAreYou)
            {
                string[] answers = { "Ihan ok", "Siinähän se" };
                GenerateAnswer(person + " sanoo: " + GenerateRandomAnswer(answers), reader);
            }
        }

        public static string GenerateRandomAnswer(string[] answers)
        {
            Random random = new Random();
            var randomIndex = random.Next(answers.Length);
            return answers[randomIndex];
        }

        // Play room
        public void Play(Frame frame, FileReader reader)
        {

            // Rooms

            var location = setUp();
            describeLocation(location, frame, reader);

            while (true)
            {

                Console.SetCursorPosition(4, GetTopCursore());
                var command = Regex.Replace(Console.ReadLine().ToLower().Trim(), "[?!]", "");

                // Go to
                if (UserInput.IsCommandDirection(command))
                {
                    Location destination;

                    if (location.CurrentPoint == UserInput.ConvertCommandToDirectionEnum(command))
                    {
                        GenerateAnswer("Olet jo siellä", reader);

                    }

                    else if (location.Exits.TryGetValue(UserInput.ConvertCommandToDirectionEnum(command), out destination))
                    {
                        location = destination;
                        describeLocation(location, frame, reader);
                        PlayGame.currentRoom = location;

                        if (location.ExitSpace)
                        {
                            bool exitLoop = false;

                            while (!exitLoop)
                            {
                                Console.SetCursorPosition(4, GetTopCursore());
                                var answer = Regex.Replace(Console.ReadLine().ToLower().Trim(), "[?!]", "");

                                if (answer == "kyllä")
                                {
                                    return;
                                }

                                else if (answer == "ei")
                                {
                                    exitLoop = true;
                                }

                                else
                                {
                                    GenerateAnswer("Kyllä vai ei?", reader);
                                }
                            }

                        };
                    }

                    else
                    {
                        GenerateAnswer("Et pääse sinne.", reader);
                    }
                }

                // Take an item

                else if (UserInput.IsCommandTakeItem(command))
                {
                    if (location.Item != null && command.Split(new string[] { " " }, StringSplitOptions.None)[1] == location.Item)
                    {
                        frame.AddItemToBag(location.Item);
                        describeLocation(location, frame, reader);
                    }

                    else
                    {
                        GenerateAnswer("Et voi ottaa tavaraa.", reader);
                    }
                }

                // Use an item
                // Code here

                // Say something

                else if (UserInput.IsCommandSay(command))
                {
                    Say commandEnum = UserInput.ConvertGeneralSayCommandEnum(command);

                    if (location.Person != null)
                    {
                        if (commandEnum == Say.Hello)
                        {
                            GenerateAnswerFromEnum(commandEnum, location.Person, reader);
                        }

                        if (commandEnum == Say.Stupid)
                        {
                            GenerateAnswerFromEnum(commandEnum, location.Person, reader);
                        }

                        if (commandEnum == Say.HowAreYou)
                        {
                            GenerateAnswerFromEnum(commandEnum, location.Person, reader);
                        }
                    }

                }

                // Ask for help

                else if (UserInput.IsCommandAskHelp(command))
                {
                    GenerateAnswer("Ohjeita", reader);
                }

                // Special Actions

                else if (UserInput.IsCommandHit(command))
                {
                    Hit();
                    GenerateAnswer("Se oli ikävästi tehty.", reader);
                }

                else if (UserInput.IsCommandSpecialAction(command) && location.SpecialActions)
                {
                    //
                }

                // Stop playing

                else if (command == "lopeta")
                {

                }

                else
                {
                    reader.DisplayText("Gereg ei ymmärrä käskyäsi.", GetTopCursore());
                }
            }
        }
    }
}
