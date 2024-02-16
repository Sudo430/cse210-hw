class EventManager{
    List<Event> _eventList = new List<Event>();                     

    public void DisplayEvents(){
        Console.Clear();
        foreach(Event e in _eventList.OrderBy( x => x.GetStartTime()).ToList()){
            Console.WriteLine(e.renderEvent());
        }
    }
    public void SaveEvents(){

    }
    public void LoadEvents(){

    }
    public void NewEvent(){
        Console.Clear();
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