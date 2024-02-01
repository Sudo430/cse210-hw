class Activity{
    private string _name;
    private string _description;
    protected int _duration = 0;

    public Activity(string name, string description){
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage(){
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine(_description);
        Console.Write("\nHow long, in seconds, would you like for your session to be?");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        
    }

    public void DisplayEndingMessage(){
        Console.WriteLine("\n\nWell Done");
        ShowSpinner(5);
        Console.WriteLine($"You have completed another {_duration} seconds of {_name}");
        ShowSpinner(5);

    }

    public void ShowSpinner(int seconds){

        string[] spinner = {"\\","-","/","|"};
        for(int i = seconds * 2; i > 0; i--){

            Console.Write(spinner[i % 4]);
            Thread.Sleep(500);
            Console.Write("\b \b");
        }
        
    }

    public void ShowCountDown(int seconds){
        for(int i = seconds; i > 0; i--){

            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}