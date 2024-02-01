class BreathingActivity: Activity{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing."){

    }
    public void Run(){
        base.DisplayStartingMessage();
        
        
        for(int i = base._duration; i > 0; i -= 10){
            Console.Write("\n\nBreathe in...");
            base.ShowCountDown(4);
            Console.Write("\nNow breathe out...");
            base.ShowCountDown(6);
        }

        base.DisplayEndingMessage();
    }

}