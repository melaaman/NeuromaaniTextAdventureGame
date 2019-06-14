using NeuromaaniTextAdventureGame.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NeuromaaniTextAdventureGame.Game
{
    public abstract class PlayLocation
    {
        private bool exit = true;
        public abstract Location setUp();
        public abstract void generateSpecialActions(SpecialAction action);
        public void describeLocation(Location location)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            Console.WriteLine(location.Description);
        }

        public void playGame()
        {
            var location = setUp();
            describeLocation(location);

            while (exit)
            {
                Console.WriteLine(">\n");
                string command = Regex.Replace(Console.ReadLine().ToLower().Trim(), "[?!]", "");

                if (UserInput.IsCommandDirection(command))
                {
                    Location destination;

                    if (location.Exits.TryGetValue(UserInput.ConvertCommandToDirectionEnum(command), out destination))
                    {
                        location = destination;
                        describeLocation(location);
                        Game.currentRoom = location;
                        if (location.ExitSpace) exit = false;
                    }

                    else
                    {
                        Console.WriteLine("You can't go this way.");
                    }
                }

                else if (UserInput.IsCommandTakeItem(command))
                {
                    if (location.Item != null && command.Split(new string[] { " " }, StringSplitOptions.None)[1] == location.Item)
                    {
                        Console.WriteLine("{0} repussa.", location.Item.Remove(1).ToUpper() + location.Item.Substring(1));
                    }

                    else
                    {
                        Console.WriteLine("Tavaraa ei löydy.");
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

                else if (command == "quit")
                {
                    Game.gameOn = false;
                    return;
                }

                else
                {
                    Console.WriteLine("I don't understand");
                }
            }
        }
    }
}
