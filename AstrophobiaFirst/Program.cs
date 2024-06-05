using System.Threading;
using System;
using System.ComponentModel.Design;

namespace AstrophobiaFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int oxygenLevel = 735;
            int reactorCore = 150;

            string[] inventory = new string[4]; //Reference this throughout the whole program
            int inventorySlot = '\0'; //As with this one, to help reference what slot items are in.
            string room = "\0";

            Mainmenu(ref inventory, oxygenLevel, reactorCore, inventorySlot);
        }
        static void Mainmenu(ref string[] inventory, int oxygenLevel, int reactorCore, int inventorySlot)
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
                    Intro(ref inventory, oxygenLevel, reactorCore, inventorySlot);
                    break;
                case "2":
                case "HELP":
                    Help(ref inventory, oxygenLevel, reactorCore, inventorySlot);
                    break;
            }
        }
        static void Help(ref string[] inventory, int oxygenLevel, int reactorCore, int inventorySlot)
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
                        Help(ref inventory, oxygenLevel, reactorCore, inventorySlot);
                        break;
                    }
                default:
                    {
                        Console.Clear();
                        Mainmenu(ref inventory, oxygenLevel, reactorCore, inventorySlot);
                        break;
                    }
            }
        }
        public static void Inventory()
        {
            Console.WriteLine("Items are stored here");
            //We have yet to use this, maybe a menu function that displays items?
        }
        static void IGmenu(ref string[] inventory, string currentRoom, int dormRoomCount, int oxygenLevel, int reactorCore, int inventorySlot)
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
                        Dorm(ref inventory, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                    }
                    if (currentRoom == "Hall")
                    {
                        Hall(ref inventory, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                    }
                    if (currentRoom == "Bridge")
                    {
                        Bridge(ref inventory, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                    }
                    break;
                case "2":
                    {
                        Intro(ref inventory, oxygenLevel, reactorCore, inventorySlot);
                        break;
                    }
                case "3":
                    Mainmenu(ref inventory, oxygenLevel, reactorCore, inventorySlot);
                    break;
                case "4":
                    GameEnd();
                    break;
            }
        }
        //The methods below are all the rooms that will be found in this game.

        static void Intro(ref string[] inventory, int oxygenLevel, int reactorCore, int inventorySlot)
        {
            inventory[0] = null;
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
                        Dorm(ref inventory, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("This story takes place in the year 2197, humanity has advanced to and beyond the stars, developing FTL engines \n(Faster Than Light) And, as humanity does, it used this technology to expand their territory.\nTo give themselves places to go, to get away from Earth. Which, at the time was breaching a population of over \n50 billion. Earth alone was far from enough to sustain this population, and so many fled abord vast ships, heading for \nfaraway planets, for a second chance at life. You, happened to be aboard on of these ships...");
                        Console.WriteLine("Hit Enter to Begin...");
                        Console.ReadLine();
                        Dorm(ref inventory, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                        break;
                    }

            }
        }
        //below are all the rooms
        public static void Dorm(ref string[] inventory, int dormRoomCount, int oxygenLevel, int reactorCore, int inventorySlot)
        {
            string temp = "\0";
            string currentRoom = "Dorm";

            if (currentRoom == "Dorm" && inventory[inventorySlot] == null)
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
                        LookDorm(ref inventory, oxygenLevel, reactorCore, inventorySlot);
                        break;
                    }
                case "LEAVE":
                    {
                        if (currentRoom == "Dorm" && inventory[inventorySlot] == null)
                        {
                            Console.WriteLine("You cannot see, so you stumble around for a little bit. making no progress, you may want to see if you can find something to light the way");
                            Dorm(ref inventory, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                        }
                        break;
                    }
                case "MENU":
                    {
                        IGmenu(ref inventory, currentRoom, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                        break;
                    }
            }
            if (currentRoom == "Dorm" && inventory[inventorySlot] == "Torch" && dormRoomCount > 0)
            {
                Console.WriteLine("\nYou are in the Dorm \nLook\nLeave\nMenu\n");
                temp = Console.ReadLine();
                temp = temp.ToUpper();
                switch (temp)
                {
                    case "LOOK":
                        {
                            LookDorm(ref inventory, oxygenLevel, reactorCore, inventorySlot);
                            break;
                        }
                    case "LEAVE":
                        {
                            Hall(ref inventory, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                            break;
                        }
                    case "MENU":
                        {
                            IGmenu(ref inventory, currentRoom, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                            break;
                        }
                    case "INVENTORY":
                        {
                            Console.WriteLine($"\nInventory (Press any key to continue)");
                            for (int i = 0; i < inventory.Length; i++)
                            {
                                if (inventory[i] == null)
                                {
                                    Console.WriteLine($"Slot {i+1} is empty");
                                }
                            }
                            Console.WriteLine($"{inventory[inventorySlot]}: In slot {inventorySlot + 1}.");
                            Console.ReadLine();
                            Dorm(ref inventory, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                            break;
                        }
                }
            }
            else if (currentRoom == "Dorm" && inventory[inventorySlot] == "Torch" && dormRoomCount == 0)
            {
                Console.WriteLine("You can now see around the room. \nThere are many beds but you seem to be the only one here. \nAre you alone ? \nMaybe you will find answers if you explore outside of the room, \nthrough the door in front of you that seems to lead to a hallway... \nLook\nLeave\nMenu\nInventory\n");
                temp = Console.ReadLine();
                temp = temp.ToUpper();
                switch (temp)
                {
                    case "LOOK":
                        {
                            LookDorm(ref inventory, oxygenLevel, reactorCore, inventorySlot);
                            break;
                        }
                    case "LEAVE":
                        dormRoomCount++;
                        Hall(ref inventory, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                        break;
                    case "MENU":
                        {
                            IGmenu(ref inventory, currentRoom, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                            break;
                        }
                    case "INVENTORY":
                        {
                            Console.WriteLine($"\nInventory (Press any key to continue)");
                            for (int i = 0; i < inventory.Length; i++)
                            {
                                if (inventory[i] == null)
                                {
                                    Console.WriteLine($"Slot {i + 1} is empty");
                                }
                            }
                            Console.WriteLine($"{inventory[inventorySlot]}: In slot {inventorySlot + 1}.");
                            Console.ReadLine();
                            Dorm(ref inventory, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                            break;
                        }
                }
            }
            else { }
        }
        static void Hall(ref string[] inventory, int dormRoomCount, int oxygenLevel, int reactorCore, int inventorySlot)
        {
            string currentRoom = "Hall";
            string temp, playerChoice;

            Console.WriteLine("\nYou are in the hallway, down one end of the hallway is the bridge. Or you could go back into the dorm.\nYour options are:\nLook\nEnter one of the following rooms:\n-----\nDorm\nBridge\n-----\nMenu\nInventory\n");
            temp = Console.ReadLine();
            temp = temp.ToUpper();
            playerChoice = temp;

            switch (playerChoice)
            {
                case "GO TO DORM":
                case "DORM":
                    {
                        Dorm(ref inventory, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                        break;
                    }
                case "GO TO BRIDGE":
                case "BRIDGE":
                    {
                        Bridge(ref inventory, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                        break;
                    }
                case "LOOK":
                    {
                        LookHall(ref inventory, oxygenLevel, reactorCore, inventorySlot);
                        break;
                    }
                case "MENU":
                    {
                        IGmenu(ref inventory, currentRoom, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                        break;
                    }
                case "INVENTORY":
                    {
                        Console.WriteLine($"\nInventory (Press any key to continue)");
                        for (int i = 0; i < inventory.Length; i++)
                        {
                            if (inventory[i] == null)
                            {
                                Console.WriteLine($"Slot {i + 1} is empty");
                            }
                        }
                        Console.WriteLine($"{inventory[inventorySlot]}: In slot {inventorySlot + 1}.");
                        Console.ReadLine();
                        Hall(ref inventory, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                        break;
                    }
            }
        }
        static void Bridge(ref string[] inventory, int dormRoomCount, int oxygenLevel, int reactorCore, int inventorySlot)
        {
            string currentRoom = "Bridge";
            string temp, playerChoice;

            Console.WriteLine("\nYou are in the bridge, the brain of the ship where messages are received and commands are sent throughout the rest of the vessel. There seems to be power in here as some computer lights flicker and there are beeping noises all around, it seems some parts of the ship are still working. Just like the dorm room and the hallway, the thick layer of dust on all of the controls would indicate that has not been any life here for quite some time. \nAre you truly alone floating through space… \nYour options are:\nLook\nShip Stats\nLeave\nMenu\n");
            temp = Console.ReadLine();
            temp = temp.ToUpper();
            playerChoice = temp;

            switch (playerChoice)
            {
                case "LOOK":
                    {
                        LookBridge(ref inventory, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                        break;
                    }
                case "SHIP STATS":
                case "SHIPSTATS":
                case "SHIP":
                case "STATS":
                    {
                        ShipStats(ref oxygenLevel, reactorCore);
                        ShipSystems();
                        Bridge(ref inventory, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                        break;
                    }
                case "LEAVE":
                    {
                        Hall(ref inventory, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                        break;
                    }
                case "MENU":
                    {
                        IGmenu(ref inventory, currentRoom, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                        break;
                    }
            }
        }
        static void BridgeIntro(ref string[] inventory,ref int dormRoomCount,ref int oxygenLevel,ref int reactorCore, ref int inventorySlot)
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
                ShipStats(ref oxygenLevel, reactorCore);
                BridgeIntro = true;

            }
            else
            {
                // Nest all other code in here
            }
        }
        //Below this are all the "LOOK" methods.

        static void LookDorm(ref string[] inventory, int oxygenLevel, int reactorCore, int inventorySlot)
        {
            
            string temp;
            int dormRoomCount = 0, torch = '\0';
            string currentRoom = "Dorm", playerChoice = null;

            Console.WriteLine("\nYou have looked around the room");
            if (currentRoom == "Dorm" && inventory[0] == null)
            {
                do
                {
                    Console.WriteLine("It is very dark in the dorm, but you manage notice a torch lying on the ground next to you, do you pick it up? y or n\n");
                    temp = Console.ReadLine();
                    temp = temp.ToUpper();
                    switch (temp)
                    {
                        case "Y":
                            Console.WriteLine("\nWhat Slot would you like to put the Torch in? Your free slots are:\n1: Empty\n2: Empty\n3: Empty\n4: Empty\n");
                            temp = Console.ReadLine();
                            temp = temp.ToUpper();
                            playerChoice = temp;
                            switch (playerChoice)
                            {
                                case "1":
                                case "SLOT 1":
                                    {
                                        torch = 0;
                                        inventorySlot = 0;
                                        inventory[0] = "Torch";
                                        Console.WriteLine("\nYou placed the torch in slot 1 (Press any Key)");
                                        break;
                                    }
                                case "2":
                                case "SLOT 2":
                                    {
                                        torch = 1;
                                        inventorySlot = 1;
                                        inventory[1] = "Torch";
                                        Console.WriteLine("\nYou placed the torch in slot 2 (Press any Key)");
                                        break;
                                    }
                                case "3":
                                case "SLOT 3":
                                    {
                                        torch = 2;
                                        inventorySlot = 2;
                                        inventory[2] = "Torch";
                                        Console.WriteLine("\nYou placed the torch in slot 3 (Press any Key)");
                                        break;
                                    }
                                case "4":
                                case "SLOT 4":
                                    {
                                        torch = 3;
                                        inventory[3] = "Torch";
                                        inventorySlot = 3;
                                        Console.WriteLine("\nYou placed the torch in slot 4 (Press any Key)");
                                        break;
                                    }
                            }
                            Console.ReadLine();
                            Dorm(ref inventory, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                            break;
                        case "N":
                            Console.WriteLine("\nYou decided not to pick up the torch, But you still cannot see.\nMaybe it would be better to pick it up...");
                            break;
                        default:
                            break;
                    }
                } while (temp != "Y");
            }
            else if (currentRoom == "Dorm" && inventory[torch] == "Torch")
            {
                Console.WriteLine("There is nothing else in the room \nPress any key...");
                Console.ReadLine();
                Dorm(ref inventory, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
            }
        }
        static void LookBridge(ref string[] inventory, int dormRoomCount, int oxygenLevel, int reactorCore, int inventorySlot)
        {
            string temp;
            Console.WriteLine("In front of you to your left and right are the two pilot seats, various buttons and knobs in front of each. To your left is a computer console displaying the ship's status. To your right are a few more consoles with flashing ERROR screens. \nYou spot a manual on the controls to your left. \nWhat would you like to do? \n1. Read Manual \n2. Check computer \n3. Stop looking");
            temp = Console.ReadLine();
            switch (temp)
            {
                case "1":
                    Console.WriteLine("This does nothing right now \nPress enter");
                    Console.ReadLine();
                    LookBridge(ref inventory, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                    break;
                case "2":
                    ShipComputer(ref inventory, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                    break;
                case "3":
                    Bridge(ref inventory, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                    break;
            }           
        }
        static void ShipComputer(ref string[] inventory, int dormRoomCount, int oxygenLevel, int reactorCore, int inventorySlot)
        {
            string temp;
            Console.WriteLine("You look over at the computer console, there are a couple things you can do here. \n1. Check oxygen levels and reactor core fuel \n2. Check ship health \n3. Leave computer");
            temp = Console.ReadLine();
            switch (temp)
            {
                case "1":
                    ShipStats(ref oxygenLevel, reactorCore);
                    ShipComputer(ref inventory, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                    break;
                case "2":
                    ShipSystems();
                    ShipComputer(ref inventory, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                    break;
                case "3":
                    LookBridge(ref inventory, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
                    break;
            }
        }
        static void LookHall(ref string[] inventory, int oxygenLevel, int reactorCore, int inventorySlot)
        {
            int dormRoomCount = 1;
            Console.WriteLine("\nYou are looking around the hall, looks very hall-y");
            Console.ReadLine();
            Hall(ref inventory, dormRoomCount, oxygenLevel, reactorCore, inventorySlot);
        }
        static void ShipStats(ref int oxygenLevel, int reactorCore)
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
        //Task 1 is for within the bridge/within the main computer
        public static void Task1()
        {

        }
        //Task 2 is for Engine/operation room once added
        public static void Task2()
        {

        }
        //Task 3 is for in the oxygen room once that has been made
        public static void Task3()
        {
            Console.WriteLine("You will be given a sequence of numbers to remember");
            string temp;
            char answer;
            int number = 1;
            do
            {
                Console.WriteLine("\nAre you ready: y or n");
                temp = Console.ReadLine();
                answer = Convert.ToChar(temp);
            } while ((answer != 'y') && (answer != 'n'));
            Console.WriteLine("Thank you.");
            Thread.Sleep(1000);
            Console.Clear();

            int count = 0, num1, num2;
            Random rand = new Random();
            num1 = rand.Next(1, 101);
            Console.WriteLine("\nThe code is a number between 1-100, but you can't remember it.\nYou will have to guess quickly to find the answer before you black out\nYou should get at least 6 guesses.");
            do
            {
                Console.Write("\nPlease type a number:  ");
                temp = Console.ReadLine();
                num2 = Convert.ToInt32(temp);
                if (num2 > num1)
                {
                    Console.WriteLine("The number you are looking for is smaller then this");
                }
                if (num2 < num1)
                {
                    Console.WriteLine("The number you are looking for is larger then this");
                }
                else
                {
                    Console.WriteLine("Correct code entered");
                }
                count++;
                if (count >= 6)
                {
                    Console.WriteLine("Oxygen Levels are critical");
                    Thread.Sleep(1000);
                    Lose1();

                }
                else
                {
                    Console.WriteLine("Try a different number");
                }
            } while ((num2 != num1) && (count <= 6));

            Console.ReadLine();
        }
        public static void Lose1()
        {
            Console.WriteLine("\n\nYou feel yourself starting to lose consciousness and you know the end is near.\nYou can no longer hold yourself up to the oxygen terminal and fall to the ground.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("This is the end for you...");
            Thread.Sleep(2000);
            Console.Clear();
            Console.Write("Unfortunatly you have failed this mission. Would you like to return to main menu (y or n):  ");
            string temp = Console.ReadLine();
            switch (temp)
            {
                case "y":
                    Mainmenu();
                    break;
                case "n":
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
        static void GameEnd()
        {
            Console.WriteLine("You have chosen to exit the game");
            Thread.Sleep(1000);
            Console.WriteLine("Thank you for playing, Goodbye!");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
        // Rooms not yet in game or may not be needed - Med, Reactor, Storage, Airlock
    }
}
