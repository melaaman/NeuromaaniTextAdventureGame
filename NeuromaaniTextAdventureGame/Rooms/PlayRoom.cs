using NeuromaaniTextAdventureGame.FileManager;
using NeuromaaniTextAdventureGame.Game;
using System;
using System.Text.RegularExpressions;

namespace NeuromaaniTextAdventureGame.Rooms
{
    public abstract class PlayRoom
    {
        FileReader _reader = new FileReader();

        private bool exit = true;
        public abstract Location setUp();
        public abstract void generateSpecialActions(SpecialAction action);

        // Handle PositionTop:

        int PositionTop = 12;

        void IncreasePositionTop() => PositionTop += 2;

        int GetPositionTop() => PositionTop;

        public int ResetPositionTop() => PositionTop = 12;

        // Play

        public void describeLocation(Location location)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }
            ResetPositionTop();
            Frame.ClearAndDrawFrame();
            _reader.DisplayTextFromFile(location.DescriptionFile, location.ChapterIndex, 4);
        }

        public void playGame()
        {
            var location = setUp();
            describeLocation(location);

            while (exit)
            {
                Console.SetCursorPosition(4, GetPositionTop());
                string command = Regex.Replace(Console.ReadLine().ToLower().Trim(), "[?!]", "");
                IncreasePositionTop();

                if (UserInput.IsCommandDirection(command))
                {
                    Location destination;

                    if (location.Exits.TryGetValue(UserInput.ConvertCommandToDirectionEnum(command), out destination))
                    {
                        location = destination;
                        describeLocation(location);
                        PlayGame.currentRoom = location;
                        if (location.ExitSpace) exit = false;
                    }

                    else
                    {
                        Console.SetCursorPosition(3, GetPositionTop());
                        Console.WriteLine("Täällä ei ole mitään.");
                        IncreasePositionTop();

                    }
                }

                else if (UserInput.IsCommandTakeItem(command))
                {
                    if (location.Item != null && command.Split(new string[] { " " }, StringSplitOptions.None)[1] == location.Item)
                    {
                        Console.SetCursorPosition(4, GetPositionTop() + 2);
                        Console.WriteLine("{0} repussa.", location.Item.Remove(1).ToUpper() + location.Item.Substring(1));
                        IncreasePositionTop();
                    }

                    else
                    {
                        Console.SetCursorPosition(4, GetPositionTop() + 2);
                        Console.WriteLine("Tavaraa ei löydy.");
                        IncreasePositionTop();
                    }
                }

                else if (UserInput.IsCommandSay(command))
                {
                    Say commandEnum = UserInput.ConvertGeneralSayCommandEnum(command);

                    if (location.Person != null)
                    {
                        if (commandEnum == Say.Hello)
                        {
                            UserInput.GenerateAnswerFromEnum(commandEnum, location.Person);
                        }

                        if (commandEnum == Say.Stupid)
                        {
                            UserInput.GenerateAnswerFromEnum(commandEnum, location.Person);
                        }

                        if (commandEnum == Say.HowAreYou)
                        {
                            UserInput.GenerateAnswerFromEnum(commandEnum, location.Person);
                        }
                    }

                }

                else if (UserInput.IsCommandAskHelp(command))
                {
                    UserInput.GiveInstructions();
                }

                else if (UserInput.IsCommandAction(command) && location.SpecialActions)
                {
                    var action = UserInput.ConvertActionCommandToEnum(command);
                    generateSpecialActions(action);

                }

                else if (command == "lopeta")
                {
                    PlayGame.gameOn = false;
                    return;
                }

                else
                {
                    Console.SetCursorPosition(4, GetPositionTop());
                    Console.WriteLine("En ymmärrä.");
                    IncreasePositionTop();
                }
            }
        }
    }
}
