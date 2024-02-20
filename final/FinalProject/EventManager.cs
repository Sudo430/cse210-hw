using System.Globalization;
using System.Reflection.Metadata;
using System.Security.Cryptography;

class EventManager{
    List<Event> _eventList = new List<Event>();
    private string _repeatingEventFilename = "repeatingEvents.txt";



    public void DisplayEvents(){
        Console.Clear();
        Console.WriteLine("EVENT#. START-TIME -> END-TIME : TITLE : DESCRIPTION\n");

        Console.WriteLine("==============================================");
        int count = 0;
        _eventList = _eventList.OrderBy( x => x.GetStartTime()).ToList();
        foreach(Event e in _eventList){
            Console.WriteLine($"{count}. {e.RenderEvent()} : {e.GetType()}");
            count ++;
        }
        Console.WriteLine("==============================================");
        Console.WriteLine();
    }
    public void SaveEvents(string date){

        //TODO have it make it's own file name with the date
        //Console.Write("Please enter a filename to save to >> ");
        string fileName = $"{date}_Planer.txt";
        

        Console.WriteLine("This will overwrite the last save today, do you want to continue? (Y/N)");
        Console.Write(">>");

        string input = Console.ReadLine();
        if(input.ToUpper() != "Y"){
            return;
        }

        //write Normal events to file with date
        using(StreamWriter File = new StreamWriter(fileName), RFile = new StreamWriter(_repeatingEventFilename)){
            foreach(Event E in _eventList){

                string type = $"{E.GetType()}";
                if(type == "Event"){
                    File.WriteLine(type + E.ExportEvent());
                }
                else if(type == "RepeatingEvent"){
                    File.WriteLine(type + E.ExportEvent());
                }
                
            }
        }
    }
    public void LoadEvents(int intDay, string strDay, string date){

        Console.Clear();
        Console.WriteLine("Leave blank to load default filename or enter filename to load.");
        Console.WriteLine("This will also overwrite any unsaved changes. Enter 'A' to abort.");
        Console.Write(">>");
        string fileName = Console.ReadLine();

        if(fileName == ""){
            fileName = $"{date}_Planer.txt";  
        }
        else if(fileName.ToUpper() =="A"){
            return;
        }
        string[] lines = System.IO.File.ReadAllLines(fileName);
        
        _eventList.Clear();

        foreach(string line in lines){
            string[] item = line.Split("┌");
            if (item[0] == "Event"){
                _eventList.Add(new Event(item[1], item[2], int.Parse(item[3]), int.Parse(item[4])));
            }
        }

        //load repeatining events
        lines = System.IO.File.ReadAllLines(_repeatingEventFilename);
        foreach(string line in lines){
            string[] item = line.Split("┌");
            List<string> days = new List<string>();

            if(item[0] == "RepeatingEvent"){
                
                foreach(string day in item[5].Split(",")){
                    days.Add(day);
                }

                if(days[intDay] == strDay.ToUpper()){
                    _eventList.Add(new RepeatingEvent(item[1], item[2], int.Parse(item[3]), int.Parse(item[4]), days));
                }
            }
            
        }
    }
    public void NewEvent(){
        Console.Clear();
        //TODO add a length limit
        Console.WriteLine("Please enter a title.");
        Console.Write(">>");
        string title = Console.ReadLine();

        Console.WriteLine("\nPlease enter a description.");
        Console.Write(">>");
        string description = Console.ReadLine();

        //TODO add input validation
        Console.WriteLine("\nPlease enter a starting time in millitary time without a ':' (i.e. 9:00 AM would be 900 and 1:00 PM would be 1300).");
        Console.Write(">>");
        int startTime = int.Parse(Console.ReadLine());

        Console.WriteLine("\nPlease enter an ending time in millitary time without a ':' (i.e. 9:00 AM would be 900 and 1:00 PM would be 1300).");
        Console.Write(">>");
        int endTime = int.Parse(Console.ReadLine());


        Console.WriteLine("Do you want to make this event repeat?(Y/N)");
        string repeat = Console.ReadLine();

        if(repeat.ToUpper() == "Y"){
            _eventList.Add(new RepeatingEvent(title,description, startTime, endTime, SelectDays()));
        }
        else{
            _eventList.Add(new Event(title, description, startTime, endTime));
        }
        Console.Clear();

    }
    public void EditEvent(){
        DisplayEvents();

        Console.WriteLine("Enter the EVENT# of the event you want to Edit.");
        Console.WriteLine("Just press enter to abort.");
        Console.Write(">>");
        string strInput = Console.ReadLine();
        if(strInput == ""){
            return;
        }
        int input = int.Parse(strInput);
        string[] editEvent = _eventList[input].ExportEvent().Split("┌");
        editEvent[0] = $"{_eventList[input].GetType()}";
        Console.WriteLine("Enter a new value for each item or leave it blank to keep the current value.\n");
        Console.WriteLine("Current Title: " + editEvent[1]);
        Console.Write(">>");
        strInput = Console.ReadLine();
        string title = strInput;
        if(strInput == ""){
            title = editEvent[1];
        }
        
        Console.WriteLine("Current Description: " + editEvent[2]);
        Console.Write(">>");
        strInput = Console.ReadLine();
        string description = strInput;
        if(strInput == ""){
            description = editEvent[2];
        }
        Console.WriteLine("Current Start Time: " + editEvent[3]);
        Console.Write(">>");
        strInput = Console.ReadLine();
        string startTime = strInput;
        if(strInput == ""){
            startTime = editEvent[3];
        }

        Console.WriteLine("Current End Time: " + editEvent[4]);
        Console.Write(">>");
        strInput = Console.ReadLine();
        string endTime = strInput;
        if(strInput == ""){
            endTime = editEvent[4];
        }

        if(editEvent[0] == "RepeatingEvent"){
            List<string> days = SelectDays(editEvent[5]);
            _eventList[input] = new RepeatingEvent(title,description,int.Parse(startTime), int.Parse(endTime),days);
        }
        else if(editEvent[0] == "Event"){
            _eventList[input] = new Event(title,description,int.Parse(startTime), int.Parse(endTime));
        }

    }
    public void DeleteEvent(){
        DisplayEvents();

        Console.WriteLine("Enter the EVENT# of the event you want to delete.");
        Console.WriteLine("Just press enter to abort.");
        Console.Write(">>");
        string strInput = Console.ReadLine();
        if(strInput == ""){
            return;
        }
        int input = int.Parse(strInput);

        _eventList.Remove(_eventList[input]);


    }

    private List<string> SelectDays(string stringDays = "sun,mon,tue,wed,thu,fri,sat")
    {       

        List<string> days = new List<string>();
        foreach(string x in stringDays.Split(",")){
            days.Add(x);
        }
            

        do{
            Console.Clear();
            Console.WriteLine("Enter a number (0-6) to select which days you want the event to repeat on.");
            Console.WriteLine("Press enter to continue");
            
            foreach(string day in days){
                if(day == day.ToUpper()){
                    Console.Write($"[{day}] ");
                }
                else{
                    Console.Write($" {day}  ");
                }
            }
            Console.Write("\n>>");
            //TODO input validation
            string strInput = Console.ReadLine();

            if(strInput == ""){
                break;
            }

            int input = int.Parse(strInput);

            for(int i = 0; i < 7; i++){
                if(input == i){
                    if(days[i] == days[i].ToUpper()){
                        days[i] = days[i].ToLower();
                    }
                    else{
                        days[i] = days[i].ToUpper();
                    }
                }
            }
        }while(true);
        return days;
    }
}