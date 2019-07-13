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

        public void describeLocation(Location location, Frame frame, FileReader reader)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            frame.ClearAndDrawFrame();

            reader.DisplayTextFromFile(location.File, location.ChapterIndex, 4);
        }

        static void Hit()
        {
            string pam = @"
______  ___ ___  ____ 
| ___ \/ _ \|  \/  | |
| |_/ / /_\ \ .  . | |
|  __/|  _  | |\/| | |
| |   | | | | |  | |_|
\_|   \_| |_|_|  |_(_)";

            string[] pamRivit = pam.Split(new string[] { "\n" }, StringSplitOptions.None);
            var top = 6;

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
        public void playGame(Frame frame, FileReader reader)
        {

            // Rooms

            var location = setUp();
            describeLocation(location, frame, reader);

            while (true)
            {
                // Cursore position
                var getCursoreTop = FileReader.cursoreTop + 2;


                Console.SetCursorPosition(4, getCursoreTop);
                var command = Regex.Replace(Console.ReadLine().ToLower().Trim(), "[?!]", "");

                // Go to commandse
                frame.ClearAndDrawFrame();
                if (UserInput.IsCommandDirection(command))
                {
                    Location destination;

                    if (location.CurrentPoint == UserInput.ConvertCommandToDirectionEnum(command))
                    {
                        reader.DisplayText("Olet jo siellä", 4);
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
                                Console.SetCursorPosition(4, getCursoreTop);
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
                                    frame.ClearAndDrawFrame();
                                    reader.DisplayText("Kyllä vai ei?", 4);
                                }
                            }

                        };
                    }

                    else
                    {
                        frame.ClearAndDrawFrame();
                        reader.DisplayText("Et pääse sinne.", 4);
                    }
                }

                // Take an item

                else if (UserInput.IsCommandTakeItem(command))
                {
                    if (location.Item != null && command.Split(new string[] { " " }, StringSplitOptions.None)[1] == location.Item)
                    {

                    }

                    else
                    {

                    }
                }

                // Say something

                else if (UserInput.IsCommandSay(command))
                {
                    Say commandEnum = UserInput.ConvertGeneralSayCommandEnum(command);

                    if (location.Person != null)
                    {
                        if (commandEnum == Say.Hello)
                        {

                        }

                        if (commandEnum == Say.Stupid)
                        {

                        }

                        if (commandEnum == Say.HowAreYou)
                        {

                        }
                    }

                }

                // Ask for help

                else if (UserInput.IsCommandAskHelp(command))
                {
                    UserInput.GiveInstructions(frame);
                }

                // Special Actions

                else if (UserInput.IsCommandAction(command) && location.SpecialActions)
                {

                    if (UserInput.ConvertActionCommandToEnum(command) == SpecialAction.Hit)
                    {
                        frame.ClearAndDrawFrame();
                        Hit();
                    }
                }

                // Stop playing

                else if (command == "lopeta")
                {

                }

                else
                {
                    frame.ClearAndDrawFrame();
                    reader.DisplayText("Gereg ei ymmärrä käskyäsi.", 4);
                }
            }
        }
    }
}
