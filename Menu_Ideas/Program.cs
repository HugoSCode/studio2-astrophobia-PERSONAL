using System;
using System.Threading;

namespace GameHud
{
    internal class O2Meter
    {
        static void Main(string[] args)
        {

            bool Play = true;
            
            while (Play = true)
            {
                Console.WriteLine("- MENU - ");
                Console.WriteLine();
                Console.WriteLine("1. Ship Status");
                Console.WriteLine("2. Damage Ship");
                Console.WriteLine("3. Option 3");
                Console.WriteLine();
                Console.Write("Select an option: ");

                string temp = Console.ReadLine();
                int Input = Convert.ToInt32(temp);
                Console.WriteLine();

                int oxygenLevel = 999;
                int reactorCore = 1500;

                switch (Input)
                {
                    case 1:
                        ShipStats(oxygenLevel, reactorCore);
                        break;
                    case 2:
                        oxygenLevel = Damage(oxygenLevel);
                        ShipStats(oxygenLevel, reactorCore);
                        break;
                    case 3:
                        Console.WriteLine("Option 3 ");
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Wrong Input!");
                        break;




                }
            } 
        }
            
        static void ShipStats(int oxygenLevel,int reactorCore)
        {
            
            Thread.Sleep(100);
            Console.WriteLine("*************************");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"*  OXYGEN = {oxygenLevel}/999     *");
            Thread.Sleep(100);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"*  REACTOR = {reactorCore}/1500  *");
            Console.ResetColor();
            Console.WriteLine("*************************");
            Console.WriteLine("Press Enter");
            Console.ReadLine();
           
        }

        static int Damage(int oxygenLevel)
        {

            oxygenLevel -= 500;
            Console.WriteLine("OH NO!");
            Console.WriteLine();
            Thread.Sleep(1000);
            Console.WriteLine("Your Loosing Oxygen...");
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine($"You have lost 500 Oxygen!!!");
            Thread.Sleep(3000);
            Console.WriteLine();
            return oxygenLevel;
            

        }
    }
}
