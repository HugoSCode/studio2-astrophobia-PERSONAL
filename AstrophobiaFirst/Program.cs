namespace AstrophobiaFirst
{
    public struct playerPosition
    {
        public string playerPos, items;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Mainmenu();
        }

        static void Mainmenu()
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
                    Intro();
                    break;
                case "help":
                case "2":
                case "Help":
                    Help();
                    break;
            }
        }
        static void Help()
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
                        Help();
                        break;
                    }
                default:
                    {
                        Console.Clear();
                        Mainmenu();
                        break;
                    }
            }

        }
        static void Intro()
        {
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
                        Dorm();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("This story takes place in the year 2197, humanity has advanced to and beyond the stars, developing FTL engines \n(Faster Than Light) And, as humanity does, it used this technology to expand their territory.\nTo give themselves places to go, to get away from Earth. Which, at the time was breaching a population of over \n50 billion. Earth alone was far from enough to sustain this population, and so many fled abord vast ships, heading for \nfaraway planets, for a second chance at life. You, happened to be aboard on of these ships...");
                        Console.WriteLine("Hit Enter to Begin...");
                        Console.ReadLine();
                        Dorm();
                        break;
                    }

            }
               
        }
        static void Inventory()
        {
            Console.WriteLine("Items are stored here");
            string[] inventory = new string[9999]; 

        }
        static void IGmenu()
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
                    break;
                case "2":
                    Intro();
                    break;
                case "3":
                    Mainmenu();
                    break;
                case "4":
                    //Application.Exit(0); still working on
                    break;
            }
        }
        static void LookDorm(ref int count, string room)
        {
            string currentRoom = "Dorm";
            Console.WriteLine("You have looked around the room");
            if (currentRoom == "Dorm" && count == 1)
            {

                string temp;
                do
                {
                    Console.WriteLine("It is very dark in the dorm, but you manage notice a torch lying on the ground next to you, do you pick it up? y or n");
                    temp = Console.ReadLine();
                    switch (temp)
                    {
                        case "y":
                        case "Y":
                            Console.WriteLine("You have picked up the torch and turn it on...");
                            Console.ReadLine();
                            count++;
                            break;
                        case "n":
                        case "N":
                            Console.WriteLine("You decided not to pick up the torch, But you still cannot see.\nMaybe it would be better to pick it up...");
                            break;
                    }
                } while (temp != "y");

            }
            if (currentRoom == "Dorm" && count == 2)
            {
                Console.WriteLine("There is nothing else in the room");
            }
        }

        //The methods below are all the rooms that will be found in this game.

        public static void Dorm()
        {
            string currentRoom = "Dorm";
            int count = 0;
            if (count == 0)
            {
                Console.WriteLine("You awaken in the dorm and it is dark. Maybe there is something in the room to help you see better.\nWhat would you like to do, your options are:\nLook\nLeave\nMenu");
            }
            else 
            {
                Console.WriteLine("You are in the Dorm");
            }
            string temp = Console.ReadLine();
            switch (temp)
            {
                case "look":
                    count++;
                    LookDorm(ref count, currentRoom);

                    break;
                case "leave":
                    if (count == 0)
                    {
                        Console.WriteLine("You cannot see, so you stumble around for a little bit. making no progress, you may want to see if you can find something to light the way");

                    }
                       
                    break;
                case "menu":
                    IGmenu();
                    break;
            }
            if (count == 2) 
            Console.WriteLine("You can now see around the room. \nThere are many beds but you seem to be the only one here. \nAre you alone? \nMaybe you will find answers if you explore outside of the room, through the door in front of you that seems to lead to a hallway...");
            string temp1 = Console.ReadLine();
            switch (temp1)
            {
                case "leave":
                    Hall();
                    break;
                case "look":
                    count++;
                    LookDorm(ref count, currentRoom);
                    break;
                case "menu":
                    IGmenu();
                    break;

            }
        }
        static void Hall()
        {
            string temp, playerChoice;
            Console.WriteLine("You are in the hallway, down one end of the hallway is the bridge. Or you could go back into the dorm.\nYour options are:\nLook\nGo to X (X being whatever room you want to go into)\nMenu");
            temp = Console.ReadLine();
            playerChoice = temp;

            switch (playerChoice)
            {
                case "dorm":
                case "go to dorm":
                case "Dorm":
                    {
                        Dorm();
                        break;
                    }
            }
        }
        static void Finish()
        {

        }
        static void Bridge()
        {

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

    }
}
