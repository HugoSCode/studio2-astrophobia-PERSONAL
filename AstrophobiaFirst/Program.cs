using System.ComponentModel.Design;
using System.Threading;

namespace AstrophobiaFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int oxygenLevel = 735;
            int reactorCore = 150;
            // Uncomment the below method to test the bridge intro
            Bridge(oxygenLevel, reactorCore);
            string[] inventory = new string[99]; //Reference this throughout the whole program
            string room = "\0";
            int dormRoomCount = 0;
            Mainmenu(ref inventory);
        }

        static void Mainmenu(ref string[] inventory)
        {
            Console.Clear();
            Console.WriteLine("Astrophobia");
            Console.WriteLine("1    Play");
            Console.WriteLine("2    Help");
            Console.WriteLine("3    Options");
            Console.WriteLine("4    Exit");

            string temp = Console.ReadLine();
            switch (temp)
            {
                case "play":
                case "Play":
                case "1":
                    Console.Clear();
                    Intro(ref inventory);
                    break;
                case "help":
                case "2":
                case "Help":
                    Help(ref inventory);
                    break;
            }
        }
        static void Help(ref string[] inventory)
        {
            string playerChoice;
            Console.Clear();
            Console.WriteLine("This is the help section, where everything you may need as you play through this game. Below you will find the Help options, which goes into specifics about the specified topic.");
            Console.WriteLine("\n1    Commands");
            Console.WriteLine("\nHit Enter to Go back to the Main Menu");
            playerChoice = Console.ReadLine();

            switch (playerChoice)
            {
                case "1":
                case "commands":
                case "Commands":
                    {
                        Console.Clear();
                        Console.WriteLine("This page will specify globally used commands within the game:");
                        Console.WriteLine("\nlook: This command is used to look around the room you are currently in, to help you with your surroundings, it may also show any items found in said room.");
                        Console.WriteLine("\nleave: Used to leave the current room you are in, assuming said room is linked to the hallway.");
                        Console.WriteLine("\npick up X: Used to pick up any items that can be found in the room you are currently in, said item is denoted by X.");
                        Console.WriteLine("\nmenu: this command will bring up up the ingame menu, and with it, a few more options for the player, such as restarting exiting the game, going to the main menu etc...");
                        Console.WriteLine("\nHit Enter to go back to the Help Options page.");
                        Console.ReadLine();
                        Help(ref inventory);
                        break;
                    }
                default:
                    {
                        Console.Clear();
                        Mainmenu(ref inventory);
                        break;
                    }
            }

        
               
        }
        public static void Inventory()
        {
            Console.WriteLine("Items are stored here");
            //We have yet to use this, maybe a menu function that displays items?
        }
        static void IGmenu(ref string[] inventory, string room, int dormRoomCount)
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
                    if (room == "Dorm")
                    {
                        Dorm(ref inventory, dormRoomCount);
                    }
                    if (room == "Hall") 
                    {
                        Hall(ref inventory, dormRoomCount);
                    }
                    break;
                case "2":
                    {
                        Intro(ref inventory);
                        break;
                    }
                case "3":
                    Mainmenu(ref inventory);
                    break;
                case "4":
                    GameEnd();
                    break;
            }
        }

        //The methods below are all the rooms that will be found in this game.

        static void Intro(ref string[] inventory)
        {
            int dormRoomCount = 0;
            string playerChoice;

            Console.WriteLine("There is a little bit of story, type skip if you wish to skip it, otherwise just hit enter to begin...");
            playerChoice = Console.ReadLine();

            switch (playerChoice)
            {
                case "skip":
                case "SKIP":
                case "Skip":
                    {
                        Console.WriteLine("You have Chosen to skip, skipping...");
                        Thread.Sleep(1500);
                        Console.Clear();
                        Dorm(ref inventory, dormRoomCount);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("This story takes place in the year 2197, humanity has advanced to and beyond the stars, developing FTL engines \n(Faster Than Light) And, as humanity does, it used this technology to expand their territory.\nTo give themselves places to go, to get away from Earth. Which, at the time was breaching a population of over \n50 billion. Earth alone was far from enough to sustain this population, and so many fled abord vast ships, heading for \nfaraway planets, for a second chance at life. You, happened to be aboard on of these ships...");
                        Console.WriteLine("Hit Enter to Begin...");
                        Console.ReadLine();
                        Dorm(ref inventory, dormRoomCount);
                        break;
                    }

            }
        }

        public static void Dorm(ref string[] inventory, int dormRoomCount)
        {
            string temp = "\0";
            string currentRoom = "Dorm";
            if (currentRoom == "Dorm" && inventory[0] == null)
            {
                Console.WriteLine("You awaken in the dorm and it is dark. Maybe there is something in the room to help you see better.\nWhat would you like to do, your options are:\nLook\nLeave\nMenu\n");
                temp = Console.ReadLine();
            }
            else { }

            switch (temp)
            {
                case "look":
                case "Look":
                {
                    LookDorm(ref inventory);
                    break;
                }

                case "leave":
                {
                    if (currentRoom == "Dorm" && inventory[0] == null)
                    {
                        Console.WriteLine("You cannot see, so you stumble around for a little bit. making no progress, you may want to see if you can find something to light the way");
                        Dorm(ref inventory, dormRoomCount);
                    }
                    break;
                }
                case "menu":
                { 
                    IGmenu(ref inventory, currentRoom, dormRoomCount);
                    break;
                }

            }
            if (currentRoom == "Dorm" && inventory[0] == "Torch" && dormRoomCount > 0)
            {
                Console.WriteLine("\nYou are in the Dorm \nLook\nLeave\nMenu\n");
                temp = Console.ReadLine();

                switch (temp)
                {
                    case "look":
                    case "Look":
                        {
                            LookDorm(ref inventory);
                            break;
                        }
                    case "leave":
                        {
                            Hall(ref inventory, dormRoomCount);
                            break;
                        }
                    case "menu":
                        {
                            IGmenu(ref inventory, currentRoom, dormRoomCount);
                            break;
                        }
                }
            }
            else if (currentRoom == "Dorm" && inventory[0] == "Torch" && dormRoomCount == 0)
            {
                Console.WriteLine("You can now see around the room. \nThere are many beds but you seem to be the only one here. \nAre you alone ? \nMaybe you will find answers if you explore outside of the room, through the door in front of you that seems to lead to a hallway... \nLook\nLeave\nMenu\n");
                temp = Console.ReadLine();

                switch (temp)
                {
                    case "look":
                    case "Look":
                        {
                            LookDorm(ref inventory);
                            break;
                        }
                    case "leave":
                        dormRoomCount++;
                        Hall(ref inventory, dormRoomCount);
                        break;
                    case "menu":
                        {
                            IGmenu(ref inventory, currentRoom, dormRoomCount);
                            break;
                        }
                }

                
            }
            else { }
        }
        static void Hall(ref string[] inventory, int dormRoomCount)
        {
            string currentRoom = "Hall";
            string temp, playerChoice;

            Console.WriteLine("You are in the hallway, down one end of the hallway is the bridge. Or you could go back into the dorm.\nYour options are:\nLook\nGo to X (X being whatever room you want to go into)\nMenu\n");
            temp = Console.ReadLine();
            playerChoice = temp;

                switch (playerChoice)
                {
                    case "dorm":
                    case "go to dorm":
                    case "Dorm":
                        {
                            Dorm(ref inventory, dormRoomCount);
                            break;
                        }
                    case "look":
                    case "Look":
                        {
                            LookHall(ref inventory);
                            break;
                        }
                    case "menu":
                        {
                            IGmenu(ref inventory, currentRoom, dormRoomCount);
                            break;
                        }
                }
        }

        static void Finish()
        {

        }
        static void Bridge(int oxygenLevel, int reactorCore)
        {
            bool BridgeIntro = false;
            if (BridgeIntro == false)
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
                ShipStats(oxygenLevel, reactorCore);
                BridgeIntro = true;

            }
            else
            {
                



            }
        }



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

        static void LookDorm(ref string[] inventory)
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
                    switch (temp)
                    {
                        case "y":
                        case "Y":
                            inventory[0] = "Torch";
                            Console.WriteLine("You have picked up the torch and turn it on...(Press any Key)");
                            Console.ReadLine();
                            Dorm(ref inventory, dormRoomCount);
                            break;
                        case "n":
                        case "N":
                            Console.WriteLine("You decided not to pick up the torch, But you still cannot see.\nMaybe it would be better to pick it up...");
                            break;
                        default:
                            break;
                    }
                } while (temp != "y");
            }
            else if (currentRoom == "Dorm" && inventory[0] == "Torch")
            {
                Console.WriteLine("There is nothing else in the room \nPress any key...");
                Console.ReadLine();
                Dorm(ref inventory, dormRoomCount);
            }
        }

        static void LookHall(ref string[] inventory)
        {
            int dormRoomCount = 1;
            Console.WriteLine("You are looking around the hall, looks very hall-y");
            Console.ReadLine();
            Hall(ref inventory, dormRoomCount);
        }
        static void ShipStats(int oxygenLevel, int reactorCore)
        {
            string Border = new string('*', 25);

            Thread.Sleep(100);
            Console.WriteLine(Border);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"*  OXYGEN = {oxygenLevel}/999     *");
            Thread.Sleep(100);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"*  ENERGY = {reactorCore}/1500    *");
            Console.ResetColor();
            Console.WriteLine(Border);
            Console.WriteLine("Press Enter To Exit");
            Console.ReadLine();
            Console.Clear();
        }
        static void GameEnd()
        {
            Console.WriteLine("You have chosen to exit the game");
            Thread.Sleep(1000);
            Console.WriteLine("Thank you for playing, Good Bye!");
            Thread.Sleep(1000);
        }
    }
}
