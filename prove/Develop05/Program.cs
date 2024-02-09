using System;
using System.Runtime.InteropServices.Marshalling;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        string input;
        GoalManager goalManager = new GoalManager();

        do{
            //print Menu
            Console.WriteLine($"\nYou have {goalManager.getPoints()} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("   1. Create New Goal");
            Console.WriteLine("   2. List Goals");
            Console.WriteLine("   3. Save Goals");
            Console.WriteLine("   4. Load Goals");
            Console.WriteLine("   5. Record Events");
            Console.WriteLine("   6. Quit");
            Console.Write("Select an Option from the menu: ");


            //do what the user selects
            input = Console.ReadLine();

            switch(input){
                case "1":
                    goalManager.NewGoal();
                    break;
                case "2":
                    goalManager.ListGoals();
                    break;
                case "3":
                    goalManager.SaveGoals();
                    break;
                case "4":
                    goalManager.LoadGoals();
                    break;
                case "5":
                    goalManager.RecordGoal();
                    break;
                
            }
            

        }while(input != "6");
    }
}