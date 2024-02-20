using System;


class Program{
    static void Main(string[] args){

        string input = "0";

        EventManager eventManager = new EventManager();
        TaskManager taskManager = new TaskManager();
        DateTime dateTime = DateTime.Now;
        Console.Clear();

        int intDay = (int)dateTime.DayOfWeek;
        string dayStr = dateTime.DayOfWeek.ToString()[..3];

        string date = dateTime.Date.ToShortDateString().Replace("/", "-");


        string tasksOrEvents = "Events";
        do{
            if(tasksOrEvents == "Events" ){
                Console.WriteLine("1. Display Events");
                Console.WriteLine("2. New Event");
                Console.WriteLine("3. Delete Event");
                Console.WriteLine("4. Edit Event");
                Console.WriteLine("5. Save Events");
                Console.WriteLine("6. Load Events");

                Console.WriteLine("Press enter without inputting anything to togle between events and tasks");
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
                        eventManager.DeleteEvent();
                        break;
                    case "4":
                        eventManager.EditEvent();
                        break;
                    case "5":
                        eventManager.SaveEvents(date);
                        break;
                    case "6":
                        eventManager.LoadEvents(intDay, dayStr, date);
                        break;
                    case "":
                        tasksOrEvents = "Tasks";
                        Console.Clear();
                        break;
                    
                }
            }
            else if(tasksOrEvents == "Tasks"){
                Console.WriteLine("1. Display Tasks");
                Console.WriteLine("2. New Task");
                Console.WriteLine("3. Delete Task");
                Console.WriteLine("4. Edit Task");
                Console.WriteLine("5. Save Tasks");
                Console.WriteLine("6. Load Tasks");
                Console.WriteLine("7. Mark Task Complete");
                Console.WriteLine("Press enter without inputting anything to togle between events and tasks");
                Console.Write("Please select an option.(q to quit) >>");
                input = Console.ReadLine();

                switch(input){
                    case "1":
                        taskManager.DisplayTasks();
                        break;
                    case "2":
                        taskManager.NewTask();
                        break;
                    case "3":
                        taskManager.DeleteTask();
                        break;
                    case "4":
                        taskManager.EditTask();
                        break;
                    case "5":
                        taskManager.SaveTasks(date);
                        break;
                    case "6":
                        taskManager.LoadTasks(intDay, dayStr, date);
                        break;
                    case "7":
                        taskManager.MarkComplete();
                        break;
                    case "":
                        tasksOrEvents = "Events";
                        Console.Clear();
                        break;
                    
                }
            }
        } while(input != "q");
    }
}