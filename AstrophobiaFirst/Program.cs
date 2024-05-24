namespace AstrophobiaFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome");
            Mainmenu();
            Intro();
        }
        static void Mainmenu()
        {
            string play = "1    Play", level = "2    Levels", help = "3    Help";



            Console.WriteLine("");
            Console.WriteLine(play.PadLeft(60));
            Console.Write("");
            Console.WriteLine(level.PadLeft(62));
            Console.Write("");
            Console.WriteLine(help.PadLeft(60));


            string temp = Console.ReadLine();
            switch (temp)
            {
                case "play":
                case "1":
                    Dorm();
                    break;
            }
        }
        static void Intro()
        {
            Console.WriteLine("");
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
