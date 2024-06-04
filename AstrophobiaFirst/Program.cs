using System.Threading;
using System;

namespace AstrophobiaFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int oxygenLevel = 735;
            int reactorCore = 150;
            // Uncomment the below method to test the bridge intro or Systems
            //Bridge(oxygenLevel, reactorCore);
            //ShipSystems();
            string[] inventory = new string[99]; //Reference this throughout the whole program
            string room = "\0";
            int dormRoomCount = 0;
            Mainmenu(ref inventory, oxygenLevel, reactorCore);
        }

        static void Mainmenu(ref string[] inventory, int oxygenLevel, int reactorCore)
        {
            Console.Clear();
            Console.WriteLine("Astrophobia");
            Console.WriteLine("1    Play");
            Console.WriteLine("2    Help");
            Console.WriteLine("3    Options");
            Console.WriteLine("4    Exit");

            string temp = Console.ReadLine();
            temp = temp.ToUpper();
            switch (temp)
            {
                case "PLAY":
                case "1":
                    Console.Clear();
                    Intro(ref inventory, oxygenLevel, reactorCore);
                    break;
                case "2":
                case "HELP":
                    Help(ref inventory, oxygenLevel, reactorCore);
                    break;
            }
        }
        static void Help(ref string[] inventory, int oxygenLevel, int reactorCore)
        {
            string playerChoice;
            Console.Clear();
            Console.WriteLine("This is the help section, where everything you may need as you play through this game. Below you will find the Help options, which goes into specifics about the specified topic.");
            Console.WriteLine("\n1    Commands");
            Console.WriteLine("\nHit Enter to Go back to the Main Menu");
            playerChoice = Console.ReadLine();
            playerChoice = playerChoice.ToUpper();

            switch (playerChoice)
            {
                case "1":
                case "COMMANDS":
                    {
                        Console.Clear();
                        Console.WriteLine("This page will specify globally used commands within the game:");
                        Console.WriteLine("\nlook: This command is used to look around the room you are currently in, to help you with your surroundings, it may also show any items found in said room.");
                        Console.WriteLine("\nleave: Used to leave the current room you are in, assuming said room is linked to the hallway.");
                        Console.WriteLine("\npick up X: Used to pick up any items that can be found in the room you are currently in, said item is denoted by X.");
                        Console.WriteLine("\nmenu: this command will bring up up the ingame menu, and with it, a few more options for the player, such as restarting exiting the game, going to the main menu etc...");
                        Console.WriteLine("\nHit Enter to go back to the Help Options page.");
                        Console.ReadLine();
                        Help(ref inventory, oxygenLevel, reactorCore);
                        break;
                    }
                default:
                    {
                        Console.Clear();
                        Mainmenu(ref inventory, oxygenLevel, reactorCore);
                        break;
                    }
            }



        }
        public static void Inventory()
        {
            Console.WriteLine("Items are stored here");
            //We have yet to use this, maybe a menu function that displays items?
        }
        static void IGmenu(ref string[] inventory, string currentRoom, int dormRoomCount, int oxygenLevel, int reactorCore)
        {
            string Border = new string('*', 42);
            Console.WriteLine();
            Console.WriteLine(Border);
            Console.WriteLine("*\t\t  <Press>\t\t *");
            Console.WriteLine("* (1) To Resume   \t\t\t *\n* (2) If you wish to Restart\t\t *\n* (3) To go to the Main Menu\t\t *\n* (4) If you would like to Exit the game *");
            Console.WriteLine(Border);
            string Input = Console.ReadLine();
            Console.WriteLine();

            switch (Input)
            {
                case "1":
                    if (currentRoom == "Dorm")
                    {
                        Dorm(ref inventory, dormRoomCount, oxygenLevel, reactorCore);
                    }
                    if (currentRoom == "Hall")
                    {
                        Hall(ref inventory, dormRoomCount, oxygenLevel, reactorCore);
                    }
                    if (currentRoom == "Bridge")
                    {
                        Bridge(ref inventory, dormRoomCount, oxygenLevel, reactorCore);
                    }
                    break;
                case "2":
                    {
                        Intro(ref inventory, oxygenLevel, reactorCore);
                        break;
                    }
                case "3":
                    Mainmenu(ref inventory, oxygenLevel, reactorCore);
                    break;
                case "4":
                    GameEnd();
                    break;
            }
        }

        //The methods below are all the rooms that will be found in this game.

        static void Intro(ref string[] inventory, int oxygenLevel, int reactorCore)
        {
            int dormRoomCount = 0;
            string playerChoice;

            Console.WriteLine("There is a little bit of story, type skip if you wish to skip it, otherwise just hit enter to begin...");
            playerChoice = Console.ReadLine();
            playerChoice = playerChoice.ToUpper();
            switch (playerChoice)
            {
                case "SKIP":
                    {
                        Console.WriteLine("You have Chosen to skip, skipping...");
                        Thread.Sleep(1500);
                        Console.Clear();
                        Dorm(ref inventory, dormRoomCount, oxygenLevel, reactorCore);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("This story takes place in the year 2197, humanity has advanced to and beyond the stars, developing FTL engines \n(Faster Than Light) And, as humanity does, it used this technology to expand their territory.\nTo give themselves places to go, to get away from Earth. Which, at the time was breaching a population of over \n50 billion. Earth alone was far from enough to sustain this population, and so many fled abord vast ships, heading for \nfaraway planets, for a second chance at life. You, happened to be aboard on of these ships...");
                        Console.WriteLine("Hit Enter to Begin...");
                        Console.ReadLine();
                        Dorm(ref inventory, dormRoomCount, oxygenLevel, reactorCore);
                        break;
                    }

            }
        }

        public static void Dorm(ref string[] inventory, int dormRoomCount, int oxygenLevel, int reactorCore)
        {
            string temp = "\0";
            string currentRoom = "Dorm";
            if (currentRoom == "Dorm" && inventory[0] == null)
            {
                Console.WriteLine("You awaken in the dorm and it is dark. Maybe there is something in the room to help you see better.\nWhat would you like to do, your options are:\nLook\nLeave\nMenu\n");
                temp = Console.ReadLine();
                temp = temp.ToUpper();
            }
            else { }

            switch (temp)
            {
                case "LOOK":
                    {
                        LookDorm(ref inventory, oxygenLevel, reactorCore);
                        break;
                    }

                case "LEAVE":
                    {
                        if (currentRoom == "Dorm" && inventory[0] == null)
                        {
                            Console.WriteLine("You cannot see, so you stumble around for a little bit. making no progress, you may want to see if you can find something to light the way");
                            Dorm(ref inventory, dormRoomCount, oxygenLevel, reactorCore);
                        }
                        break;
                    }
                case "MENU":
                    {
                        IGmenu(ref inventory, currentRoom, dormRoomCount, oxygenLevel, reactorCore);
                        break;
                    }
            }
            if (currentRoom == "Dorm" && inventory[0] == "Torch" && dormRoomCount > 0)
            {
                Console.WriteLine("\nYou are in the Dorm \nLook\nLeave\nMenu\n");
                temp = Console.ReadLine();
                temp = temp.ToUpper();
                switch (temp)
                {
                    case "LOOK":
                        {
                            LookDorm(ref inventory, oxygenLevel, reactorCore);
                            break;
                        }
                    case "LEAVE":
                        {
                            Hall(ref inventory, dormRoomCount, oxygenLevel, reactorCore);
                            break;
                        }
                    case "MENU":
                        {
                            IGmenu(ref inventory, currentRoom, dormRoomCount, oxygenLevel, reactorCore);
                            break;
                        }

                }
            }
            else if (currentRoom == "Dorm" && inventory[0] == "Torch" && dormRoomCount == 0)
            {
                Console.WriteLine("You can now see around the room. \nThere are many beds but you seem to be the only one here. \nAre you alone ? \nMaybe you will find answers if you explore outside of the room, through the door in front of you that seems to lead to a hallway... \nLook\nLeave\nMenu\n");
                temp = Console.ReadLine();
                temp = temp.ToUpper();
                switch (temp)
                {
                    case "LOOK":
                        {
                            LookDorm(ref inventory, oxygenLevel, reactorCore);
                            break;
                        }
                    case "LEAVE":
                        dormRoomCount++;
                        Hall(ref inventory, dormRoomCount, oxygenLevel, reactorCore);
                        break;
                    case "MENU":
                        {
                            IGmenu(ref inventory, currentRoom, dormRoomCount, oxygenLevel, reactorCore);
                            break;
                        }

                }


            }
            else { }
        }
        static void Hall(ref string[] inventory, int dormRoomCount, int oxygenLevel, int reactorCore)
        {
            string currentRoom = "Hall";
            string temp, playerChoice;

            Console.WriteLine("You are in the hallway, down one end of the hallway is the bridge. Or you could go back into the dorm.\nYour options are:\nLook\nEnter one of the following rooms:\n-----\nDorm\nBridge\n-----\nMenu\n");
            temp = Console.ReadLine();
            temp = temp.ToUpper();
            playerChoice = temp;

            switch (playerChoice)
            {
                case "GO TO DORM":
                case "DORM":
                    {
                        Dorm(ref inventory, dormRoomCount, oxygenLevel, reactorCore);
                        break;
                    }
                case "GO TO BRIDGE":
                case "BRIDGE":
                    {
                        Bridge(ref inventory, dormRoomCount, oxygenLevel, reactorCore);
                        break;
                    }
                case "LOOK":
                    {
                        LookHall(ref inventory, oxygenLevel, reactorCore);
                        break;
                    }
                case "MENU":
                    {
                        IGmenu(ref inventory, currentRoom, dormRoomCount, oxygenLevel, reactorCore);
                        break;
                    }
            }
        }
        static void Bridge(ref string[] inventory, int dormRoomCount, int oxygenLevel, int reactorCore)
        {
            string currentRoom = "Bridge";
            string temp, playerChoice;

            Console.WriteLine("You are in the bridge, the brain of the ship where messages are received and commands are sent throughout the rest of the vessel. There seems to be power in here as all the lights and computer systems are still running. \nIf you want to know what's wrong with the ship, the answer will surely be here.\nYour options are:\nLook\nShip Stats\nLeave\nMenu\n");
            temp = Console.ReadLine();
            temp = temp.ToUpper();
            playerChoice = temp;

            switch (playerChoice)
            {
                case "LOOK":
                    {
                        Console.WriteLine("In front of you to your left and right are the two pilot seats, various buttons and knobs in front of each. To your left is a computer console displaying the ship's status. To your right are a few more consoles with flashing ERROR screens.\nPress enter to continue...");
                        Console.ReadLine();
                        Bridge(ref inventory, dormRoomCount, oxygenLevel, reactorCore);
                        break;
                    }
                case "SHIP STATS":
                case "SHIPSTATS":
                case "SHIP":
                case "STATS":
                    {
                        ShipStats(ref inventory, dormRoomCount, oxygenLevel, reactorCore);
                        break;
                    }
                case "LEAVE":
                    {
                        Hall(ref inventory, dormRoomCount, oxygenLevel, reactorCore);
                        break;
                    }
                case "MENU":
                    {
                        IGmenu(ref inventory, currentRoom, dormRoomCount, oxygenLevel, reactorCore);
                        break;
                    }

                    /*int BridgeIntro;
                    if (BridgeIntro < 1)
                    {
                        Console.WriteLine("You have now entered what looks to be the main Bridge --");
                        Thread.Sleep(3000);
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                        Thread.Sleep(2000);
                        Console.WriteLine();
                        Console.WriteLine("There seems to be power in here as all the lights and computer systems are still running");
                        Thread.Sleep(4000);
                        Console.WriteLine();
                        Console.WriteLine("You notice a console screen to your left showing information about the ships vitals... ");
                        Thread.Sleep(3000);
                        Console.WriteLine("Press Enter to Inspect");
                        Console.ReadLine();
                        ShipStats(ref inventory, dormRoomCount, oxygenLevel, reactorCore);
                        BridgeIntro = BridgeIntro + 1;

                    }
                    else
                    {
                        string currentRoom = "Bridge";
                        string temp, playerChoice;

                        Console.WriteLine("You are in the bridge, the brain of the ship where messages are received and commands are sent throughout the rest of the vessel. If you want to know what's wrong with the ship, surely answer lie here.\nYour options are:\nLook\nShip Stats\nLeave\nMenu\n");
                        temp = Console.ReadLine();
                        temp = temp.ToUpper();
                        playerChoice = temp;

                        switch (playerChoice)
                        {
                            case "LOOK":
                                {
                                    LookHall(ref inventory, oxygenLevel, reactorCore);
                                    break;
                                }
                            case "SHIP STATS":
                            case "SHIPSTATS":
                            case "SHIP":
                            case "STATS":
                                {
                                    ShipStats(ref inventory, dormRoomCount, oxygenLevel, reactorCore);
                                    break;
                                }
                            case "LEAVE":
                                {
                                    Hall(ref inventory, dormRoomCount, oxygenLevel, reactorCore);
                                    break;
                                }
                            case "MENU":
                                {
                                    IGmenu(ref inventory, currentRoom, dormRoomCount, oxygenLevel, reactorCore);
                                    break;
                                }
                        }*/
            }
        }

        static void Finish()
        {

        }
        static void Bridge(ref string[] inventory, ref int dormRoomCount, ref int oxygenLevel, ref int reactorCore)
        {
            bool BridgeIntro = false;
            if (BridgeIntro == false)
            {
                Console.WriteLine("You have now entered what looks to be the main Bridge --");
                //Thread.Sleep(3000);
                Console.WriteLine("Press Enter to Continue");
                Console.ReadLine();
                //Thread.Sleep(2000);
                Console.WriteLine();
                Console.WriteLine("There seems to be power in here as all the lights and computer systems are still running");
                //Thread.Sleep(4000);
                Console.WriteLine();
                Console.WriteLine("You notice a console screen to your left showing information about the ships vitals... ");
                //Thread.Sleep(3000);
                Console.WriteLine("Press Enter to Inspect");
                Console.ReadLine();
                ShipStats(ref inventory, dormRoomCount, oxygenLevel, reactorCore);
                BridgeIntro = true;

            }
            else
            {

                // Nest all other code in here


            }
        }
        //b11a83b (Added padding to ship stats)
        /*static void Med()
        {

        }
        static void Reactor()
        {

        }
        
        static void Storage()
        {

        }
        static void Air()
        {

        }*/

        static void LookDorm(ref string[] inventory, int oxygenLevel, int reactorCore)
        {
            int dormRoomCount = 0;
            string currentRoom = "Dorm";
            Console.WriteLine("\nYou have looked around the room");
            if (currentRoom == "Dorm" && inventory[0] == null)
            {
                string temp;
                do
                {
                    Console.WriteLine("It is very dark in the dorm, but you manage notice a torch lying on the ground next to you, do you pick it up? y or n\n");
                    temp = Console.ReadLine();
                    temp = temp.ToUpper();
                    switch (temp)
                    {
                        case "Y":
                            inventory[0] = "Torch";
                            Console.WriteLine("You have picked up the torch and turn it on...(Press any Key)");
                            Console.ReadLine();
                            Dorm(ref inventory, dormRoomCount, oxygenLevel, reactorCore);
                            break;
                        case "N":
                            Console.WriteLine("You decided not to pick up the torch, But you still cannot see.\nMaybe it would be better to pick it up...");
                            break;
                        default:
                            break;
                    }
                } while (temp != "Y");
            }
            else if (currentRoom == "Dorm" && inventory[0] == "Torch")
            {
                Console.WriteLine("There is nothing else in the room \nPress any key...");
                Console.ReadLine();
                Dorm(ref inventory, dormRoomCount, oxygenLevel, reactorCore);
            }
        }

        static void LookHall(ref string[] inventory, int oxygenLevel, int reactorCore)
        {
            int dormRoomCount = 1;
            Console.WriteLine("You are looking around the hall, looks very hall-y");
            Console.ReadLine();
            Hall(ref inventory, dormRoomCount, oxygenLevel, reactorCore);
        }
        static void ShipStats(ref string[] inventory, int dormRoomCount, int oxygenLevel, int reactorCore)
        {
            string Border = new string('*', 25);

            Thread.Sleep(100);
            Console.WriteLine(Border);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"*  OXYGEN = {oxygenLevel}/999".PadRight(24) + "*");
            Thread.Sleep(100);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"*  ENERGY = {reactorCore}/1500".PadRight(24) + "*");
            Console.ResetColor();
            Console.WriteLine(Border);
            Console.WriteLine("Press Enter To Exit");
            Console.ReadLine();

            Bridge(ref inventory, dormRoomCount, oxygenLevel, reactorCore);

        }
        static void ShipSystems()
        {
            string Border = new string('-', 44);

            Console.WriteLine(Border);

            Console.Write($"|  Long Ranged Comms".PadRight(31));
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[Disabled]".PadRight(12));
            Console.ResetColor();
            Console.WriteLine("|");

            Console.Write($"|  Thrusters".PadRight(31));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[Damaged]".PadRight(12));
            Console.ResetColor();
            Console.WriteLine("|");

            Console.Write($"|  Reactor Core".PadRight(31));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[Damaged]".PadRight(12));
            Console.ResetColor();
            Console.WriteLine("|");

            Console.Write($"|  Ai System".PadRight(31));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[Active]".PadRight(12));
            Console.ResetColor();
            Console.WriteLine("|");

            Console.WriteLine(Border);
            Console.WriteLine("Press Enter To Exit");
            Console.ReadLine();
        }
        static void GameEnd()
        {

            Console.WriteLine("You have chosen to exit the game");
            Thread.Sleep(1000);
            Console.WriteLine("Thank you for playing, Goodbye!");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
    }
}
