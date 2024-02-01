using System;

class Program
{
    static void Main(string[] args)
    {
        BreathingActivity breathingActivity = new BreathingActivity();
        ReflectingActivity reflectingActivity = new ReflectingActivity();
        ListingActivity listingActivity = new ListingActivity();

        string input = "";
        do{
            switch(input){
                case "1":
                    breathingActivity.Run();
                    break;
                case "2":
                    reflectingActivity.Run();
                    break;
                case "3":
                    listingActivity.Run();
                    break;
            }

            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("   1. Start breathing activity");
            Console.WriteLine("   2. Start reflecting activity");
            Console.WriteLine("   3. Start listing activity");
            Console.WriteLine("   4. Quit");
            Console.Write("Select a choice from the menu: ");

            input = Console.ReadLine();
        } while(input != "4");
    }
}