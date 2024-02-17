using System;

using System.Text.Json;

class Program{
    static void Main(string[] args){

        string input;

        EventManager eventManager = new EventManager();
        Console.Clear();

        do{
            Console.WriteLine("1. Display Events");
            Console.WriteLine("2. New Event");
            Console.WriteLine("3. Save Events");
            Console.WriteLine("4. Load Events");


            Console.Write("Please select an option.(q to quit) >>");
            input = Console.ReadLine();

            switch(input){
                case "1":
                    eventManager.DisplayEvents();
                    break;
                case "2":
                    eventManager.NewEvent();
                    break;
                case "3":
                    eventManager.SaveEvents();
                    break;
                case "4":
                    eventManager.LoadEvents();
                    break;
            }

        } while(input != "q");

        
    }
}