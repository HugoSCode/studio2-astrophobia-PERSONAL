namespace AstrophobiaFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mainmenu();
            Intro();
        }
        static void Mainmenu()
        {
            string play = "1    Play", help = "2    Help", title = "ASTROPHOBIA";


            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n");
            Console.Write("");
            Console.WriteLine(title.PadLeft(65));
            Console.Write("\n");
            Console.WriteLine(play.PadLeft(63));
            Console.Write("");
            Console.WriteLine(help.PadLeft(63));


            string temp = Console.ReadLine();
            switch (temp)
            {
                case "play":
                case "1":
                    Console.Clear();
                    Intro();
                    break;
                case "help":
                case "2":
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
        static void Menu()
        {
            Console.WriteLine("1   O2 levels\n2   Tasks");
        }
        static void Inventory()
        {
            Console.WriteLine("Items are stored here");
        }
        static void Movement()
        {
            Console.WriteLine("How we move around the ship");
            int y, n, inventory, menu, look, leave;

        }
        static void Look(ref int count)
        {
            Console.WriteLine("You have looked around the room");
            Console.ReadLine();
            if (count == 1)
            {
                string temp;
                do
                {
                    Console.WriteLine("you see a torch on the ground, do you pick it up? y or n");
                    temp = Console.ReadLine();
                    switch (temp)
                    {
                        case "y":
                            Console.WriteLine("You have picked up the tourch and turn it on...\n");
                            Console.ReadLine();
                            break;
                        case "n":
                            Console.WriteLine("You desided not to pick up the tourch, but you still can't see.\nMaybe it would be better to pick it up.");
                            break;
                    }
                } while (temp != "y");

            }
            if (count == 2)
            {
                Console.WriteLine("There is nothing else in the room");
            }

        }
        public static void Dorm()
        {
            int count = 0;
            Console.WriteLine("You awaken in the dorm and it is dark. Maybe there is something in the room to help you see better.\nWhat would you like to do, your options are:\nlook\nleave");
            string temp = Console.ReadLine();
            switch (temp)
            {
                case "look":
                    count++;
                    Look(ref count);
                    break;
                case "leave":
                    Hall();
                    break;
            }
            Console.WriteLine("You can now see around the room. \nThere are many beds but you seem to be the only one here. \nAre you alone? \nMaybe you will find answers if you explore outside of the room, through the door in front of you...");
            string temp1 = Console.ReadLine();
            switch (temp1)
            {
                case "leave":
                    Hall();
                    break;
                case "look":
                    count++;
                    Look(ref count);
                    break;
            }
        }
        static void Med()
        {

        }
        static void Hall()
        {
            Console.WriteLine("You are in the hallway");
            Console.ReadLine();
        }
        static void Reactor()
        {

        }
        static void Bridge()
        {

        }
        static void Storage()
        {

        }
        static void Air()
        {

        }
        static void Finish()
        {

        }
    }
}
