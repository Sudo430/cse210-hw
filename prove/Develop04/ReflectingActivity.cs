class ReflectingActivity : Activity{
    
    private List<string> _prompts = new List<string>{
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
        };
    private List<string> _questions = new List<string>{
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
        };

    public ReflectingActivity() : base("Reflecting activity","This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."){
    }

    public void Run(){
        base.DisplayStartingMessage();

        Console.WriteLine("Consider the follwing prompt:\n");
        Console.WriteLine($"   --- {GetRandomStringFromList(_prompts)} ---\n");
        Console.Write("when you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("\n\nNow ponder on each of the following questions.");
        Console.Write("you may begin in: ");
        base.ShowCountDown(5);

        Console.Clear();


        for(int i = base._duration; i > 0; i -= 15){
            Console.Write($"\n> {GetRandomStringFromList(_questions)} ");
            base.ShowSpinner(15);
        }

        base.DisplayEndingMessage();
    }

    private string GetRandomStringFromList(List<string> list){
        Random random = new Random();
        int num = random.Next(0, list.Count);
        return list[num];
    }

}