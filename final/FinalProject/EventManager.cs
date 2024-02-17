class EventManager{
    List<Event> _eventList = new List<Event>();                     

    public void DisplayEvents(){
        Console.Clear();
        Console.WriteLine("START-TIME -> END-TIME : TITLE : DESCRIPTION\n");

        Console.WriteLine("==============================================");
        foreach(Event e in _eventList.OrderBy( x => x.GetStartTime()).ToList()){
            Console.WriteLine(e.RenderEvent());
        }
        Console.WriteLine("==============================================");
        Console.WriteLine();
    }
    public void SaveEvents(){

        //TODO have it make it's own file name with the date
        Console.Write("Please enter a filename to save to >> ");
        string fileName = Console.ReadLine();

        using(StreamWriter File = new StreamWriter(fileName)){
            

            foreach(Event E in _eventList){
                File.WriteLine(E.ExportEvent());
                
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
            _eventList.Add(new Event(item[1], item[2], int.Parse(item[3]), int.Parse(item[4])));
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

        //TODO add repeating events
        _eventList.Add(new Event(title, description, startTime, endTime));
        Console.Clear();

    }
    public void EditEvent(){

    }
    public void DeleteEvent(){
        
    }
}