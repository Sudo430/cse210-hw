class EventManager{
    List<Event> _eventList = new List<Event>();                     

    public void DisplayEvents(){
        Console.Clear();
        Console.WriteLine("START-TIME -> END-TIME : TITLE : DESCRIPTION\n");

        Console.WriteLine("==============================================");
        foreach(Event e in _eventList.OrderBy( x => x.GetStartTime()).ToList()){
            Console.WriteLine(e.RenderEvent() +" :" + e.GetType());
        }
        Console.WriteLine("==============================================");
        Console.WriteLine();
    }
    public void SaveEvents(string date){

        //TODO have it make it's own file name with the date
        //Console.Write("Please enter a filename to save to >> ");
        string fileName = $"{date}_Planer.txt";

        try{
            string[] lines = System.IO.File.ReadAllLines(fileName);
            Console.WriteLine("Do you want to OVERRIDE you current save? (Y/N)");
            Console.Write(">>");
            string input = Console.ReadLine().ToUpper();

            if(input != "Y"){
                return;
            }


        }catch(Exception e){
            
        }

        using(StreamWriter File = new StreamWriter(fileName)){
                foreach(Event E in _eventList){
                    File.WriteLine(E.GetType() + E.ExportEvent());
                }
            }
    }
    public void LoadEvents(){
        Console.Write("Please enter a filename to load: ");
        string fileName = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(fileName);

        _eventList.Clear();
        foreach(string line in lines){
            string[] item = line.Split("┌");
            if (item[0] == "Event"){
                _eventList.Add(new Event(item[1], item[2], int.Parse(item[3]), int.Parse(item[4])));
            }
            else if(item[0] == "RepeatingEvent"){
                List<string> days = new List<string>();
                foreach(string day in item[5].Split(",")){
                    days.Add(day);
                }

                _eventList.Add(new RepeatingEvent(item[1], item[2], int.Parse(item[3]), int.Parse(item[4]), days));
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
            List<string> days = new List<string>(){"sun","mon","tue","wed","thu","fri","sat"};
            

            do{
                Console.Clear();
                Console.WriteLine("Enter a number (0-6) to select which days you want the event to repeat on.");
                Console.WriteLine("Enter a number greater then 6 to continue");
                
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
                int input = int.Parse(Console.ReadLine());
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

                
                if(input > 6 ){
                    break;
                }
            }while(true);

            _eventList.Add(new RepeatingEvent(title,description, startTime, endTime, days));
        }
        else{
            _eventList.Add(new Event(title, description, startTime, endTime));
        }

        //TODO add repeating events
        //_eventList.Add(new Event(title, description, startTime, endTime));
        Console.Clear();

    }
    public void EditEvent(){

    }
    public void DeleteEvent(){
        
    }
}