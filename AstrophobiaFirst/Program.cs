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
        static void Look()
        {
            Console.WriteLine("You have looked around the room");
            Console.ReadLine();
            int count = 0;
            if (count == 0)
            {
                Console.WriteLine("you see a torch on the ground, do you pick it up?");
                count++;

            }
            if (count == 1)
            {
                Console.WriteLine("HI");
            }
        }
        public static void Dorm()
        {
            Console.WriteLine("You awaken in the dorm and it is dark. Maybe there is something in the room to help you see better.\nWhat would you like to do, your options are:\nlook\nleave");
            string temp = Console.ReadLine();
            switch (temp)
            {
                case "look":
                    Look();
                    break;
                case "leave":
                    Hall();
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
