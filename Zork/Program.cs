using System;
using System.Collections.Generic;

namespace Zork
{
    class Program
    {
        private static string[] Rooms = {"Forest", "West of House", "Behind House", "Clearing", "Canyon View" };
        private static int i;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");
            i = 1;
            Console.WriteLine(Rooms[i]);

            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.WriteLine(Rooms[i]);
                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());

                string outputString;
                switch (command)
                {
                    case Commands.QUIT:
                        outputString = "Thank you for playing!";
                        break;

                    case Commands.LOOK:
                        outputString = "This is an open field west of a white house, with a boarded front door. \nA rubber mat saying 'Welcome to Zork!' lies by the door.";
                        break;
                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        outputString = $"You moved {command}.";
                        if (Move(command) == false)
                        {
                            Console.WriteLine("They way is shut!");
                        }
                        break;

                    default:
                        outputString = "Unknown command.";
                        break;
                }

                Console.WriteLine(outputString);
            }
        }
        private static bool Move(Commands command)
        {

            bool isValidMove = true;
            switch (command)
            {
                case Commands.NORTH:
                    isValidMove = false;
                    break;

                case Commands.SOUTH:
                    isValidMove = false;
                    break;

                case Commands.EAST when i + 1 < Rooms.Length:
                    i++;
                    break;

                case Commands.WEST when i - 1 > 0:
                    i--;
                    break;


            }

            return isValidMove;
        }
        private static Commands ToCommand(string commandString) => Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN;

        private static bool IsDirection(Commands command) => Directions.Contains(command);

        private static readonly List<Commands> Directions = new List<Commands>
        {
            Commands.NORTH,
            Commands.SOUTH,
            Commands.EAST,
            Commands.WEST
        };

      
    }
}
