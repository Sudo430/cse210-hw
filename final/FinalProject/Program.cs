using System;


class Program{
    static void Main(string[] args){

        string input;

        EventManager eventManager = new EventManager();
        DateTime dateTime = DateTime.Now;
        Console.Clear();

        string dayOfWeek = dateTime.DayOfWeek.ToString();
        string date = dateTime.Date.ToShortDateString().Replace("/", "-");
        Console.WriteLine($"{dayOfWeek[..3]} {date}");

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
                    eventManager.SaveEvents(date);
                    break;
                case "4":
                    eventManager.LoadEvents();
                    break;
            }

        } while(input != "q");

        
    }
}