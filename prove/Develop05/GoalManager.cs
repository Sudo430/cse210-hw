using System.IO;
class GoalManager{
    private List<Goal> _goals = new List<Goal>();
    private int _points;

    public void NewGoal(){
        Console.Clear();
        Console.WriteLine("Select a type of goal.");
        Console.WriteLine("   1. Simple Goal");
        Console.WriteLine("   2. Eternal Goal");
        Console.WriteLine("   3. Checklist Goal");
        Console.Write(">>");
        string goalType = Console.ReadLine();

        
        Console.Write("Enter a title for your Goal: ");
        string goalTitle = Console.ReadLine();

        Console.Write("Enter a short discription for you goal: ");
        string discription = Console.ReadLine();

        Console.Write("How many points do you want this goal to be worth? :");
        int points = int.Parse(Console.ReadLine());

        switch(goalType){
            case "1":
                _goals.Add(new SimpleGoal(goalTitle, discription, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(goalTitle, discription, points));
                break;

            case "3":
                Console.Write("How many times do you want to complete this goal? :");
                int target = int.Parse(Console.ReadLine());

                Console.Write("What is the bounus for completeing the goal that many times? :");
                int bounus = int.Parse(Console.ReadLine());

                _goals.Add(new ChecklistGoal(goalTitle, discription, points, target, bounus));
                break;
        }
        

    }

    public void ListGoals(){
        Console.Clear();
        int i = 1;
        foreach(Goal goal in _goals){
            Console.WriteLine($"{i}. {goal.GoalToString()}");
            i++;
        }
    }

    public void SaveGoals(){
        Console.Write("Please enter a filename to save to: ");
        string fileName = Console.ReadLine();

        using(StreamWriter File = new StreamWriter(fileName)){
            File.WriteLine(_points);

            foreach(Goal goal in _goals){
                File.WriteLine(goal.GetStringExport());
                
            }
        }
    }

    public void LoadGoals(){
        Console.Write("Please enter a filename to load: ");
        string fileName = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(fileName);
        bool firstLine = true;

        foreach(string line in lines){
            if(!firstLine){

            }
            else{
                _points = int.Parse(line.ToString());
                firstLine = false;
                continue;
            }
            
            string[] goal = line.Split(",,");
            switch(goal[0]){
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(goal[1] ,goal[2], int.Parse(goal[3]), goal[4] == "True"));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(goal[1] ,goal[2], int.Parse(goal[3])));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(goal[1] ,goal[2], int.Parse(goal[3]), int.Parse(goal[4]),int.Parse(goal[5]), int.Parse(goal[6]) ));
                    break;
            }
        }
        Console.Clear();
        Console.WriteLine("Goals Loaded.");
    }

    public void RecordGoal(){
        Console.Clear();
        ListGoals();

        Console.Write("Which goal did you complete? :");
        int goalIndex = int.Parse(Console.ReadLine());
        Goal goal = _goals[goalIndex - 1];

        goal.RecordEvent();
        _points += goal.getPoints();

        Console.WriteLine($"Congratulations! You earned {goal.getPoints()} points!");
    }
    public int getPoints(){
        return _points;
    }
}