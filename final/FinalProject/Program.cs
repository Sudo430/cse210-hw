using System;

using System.Text.Json;

class Program{
    static void Main(string[] args){

        string input;

        EventManager eventManager = new EventManager();

        do{
            Console.WriteLine("1. Display Events");
            Console.WriteLine("2. New Event");


            Console.Write("Please select an option. >>");
            input = Console.ReadLine();

            switch(input){
                case "1":
                    eventManager.DisplayEvents();
                    break;
                case "2":
                    eventManager.NewEvent();
                    break;
            }

        } while(input != "q");

        
    }
}