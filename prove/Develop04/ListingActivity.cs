class ListingActivity: Activity{
    private int _count = 0;
    private List<string> _prompts = new List<string>(){
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("List Activity","This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."){

    }

    public void Run(){
        base.DisplayStartingMessage();
        Console.WriteLine("\nList as many responses you can to the following prompt:");
        Console.WriteLine($"   --- {GetRandomPrompt()} ---");
        Console.Write("You may begain in: ");
        base.ShowCountDown(5);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(base._duration);

        _count = 0;
        while(DateTime.Now < endTime){
            Console.Write(">");
            Console.ReadLine();
            _count += 1;
        }
        Console.Write($"You Listed {_count} items");
        base.DisplayEndingMessage();

    }
    public string GetRandomPrompt(){
        Random random = new Random();
        int num = random.Next(0, _prompts.Count);
        return _prompts[num];
    }
}