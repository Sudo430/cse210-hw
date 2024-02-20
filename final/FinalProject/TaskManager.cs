class TaskManager{
    private List<Task> _todaysTasks = new List<Task>();
    public void DisplayTasks(){
        Console.Clear();
        Console.WriteLine("TASK#. [ ]:TITLE :DESCRIPTION   ");
        Console.WriteLine("==============================================");
        int count = 0;
        foreach(Task e in _todaysTasks){
            Console.WriteLine($"{count}. {e.RenderTask()} : {e.GetType()}");
            count ++;
        }
        Console.WriteLine("==============================================");
        Console.WriteLine();
    }
    public void SaveTasks(string date){

        string fileName = $"{date}_Tasks.txt";

        Console.WriteLine("This will overwrite the last save today, do you want to continue? (Y/N)");
        Console.Write(">>");

        string input = Console.ReadLine();
        if(input.ToUpper() != "Y"){
            return;
        }

        using(StreamWriter File = new StreamWriter(fileName), RFile = new StreamWriter("RepeatingTasks.txt")){
            foreach(Task T in _todaysTasks){

                string type = $"{T.GetType()}";
                if(type == "Task"){
                    File.WriteLine($"{type}┌{T.ExportToString()}");
                }
                else if(type == "RepeatingTask"){
                    RFile.WriteLine($"{type}┌{T.ExportToString()}");
                }
                
            }
        }
        Console.Clear();

    }
    public void LoadTasks(int intDay,string strDay, string date){
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

        _todaysTasks.Clear();

        foreach(string line in lines){
            string[] data = line.Split("┌");
            _todaysTasks.Add(new Task(data[1],data[2],bool.Parse(data[3])));
        }

        lines = System.IO.File.ReadAllLines("RepeatingTasks.txt");
        foreach(string line in lines){
            string[] data = line.Split("┌");
            List<string> days = new List<string>();
            foreach(string day in data[4].Split(",")){
                days.Add(day);
            }
            if(days[intDay] == strDay.ToUpper()){
                _todaysTasks.Add(new RepeatingTask(data[1],data[2],bool.Parse(data[3]),days));
            }

        }

    }
    public void NewTask(){
        Console.Clear();
        Console.WriteLine("Enter a title.");
        Console.Write(">>");
        string title = Console.ReadLine();

        Console.WriteLine("Enter a description");
        Console.Write(">>");
        string description = Console.ReadLine();

        Console.WriteLine("Do you want to make this a repeating task? (Y/N)");
        Console.Write(">>");
        if(Console.ReadLine().ToUpper() == "Y"){
            _todaysTasks.Add(new RepeatingTask(title, description, false, SelectDays()));
        }
        else{
            _todaysTasks.Add(new Task(title, description, false));
        }
        Console.Clear();

    }
    public void EditTask(){
        DisplayTasks();
        Console.WriteLine("\nEnter the task# of the task you want to edit or leave blank to cancel.");
        Console.Write(">>");
        string inputStr = Console.ReadLine();

        Console.WriteLine("\nEnter a new value for each item or leave it blank to keep the current value.\n");
        
        string[] editTask = _todaysTasks[int.Parse(inputStr)].ExportToString().Split("┌");

        Console.WriteLine("Title:");
        Console.Write($"{editTask[0]} >> ");
        string input = Console.ReadLine();
        string title = editTask[0];
        if(input != ""){
            title = input;
        }

        Console.WriteLine("description:");
        Console.Write($"{editTask[1]} >> ");
        input = Console.ReadLine();
        string description = editTask[1];
        if(input != ""){
            description = input;
        }
        Console.WriteLine("Completed?:");
        Console.WriteLine("Enter 'T' to toggle.");
        Console.Write($"{editTask[2]} >> ");
        bool isComplete = bool.Parse(editTask[2]);
        if(Console.ReadLine().ToUpper() == "T"){
            isComplete = !isComplete;
        }

        if($"{_todaysTasks[int.Parse(inputStr)].GetType()}" == "RepeatingTask"){
            List<string> days = SelectDays(editTask[3]);
            _todaysTasks[int.Parse(inputStr)] = new RepeatingTask(title, description, isComplete, days);
        }
        else{
            _todaysTasks[int.Parse(inputStr)] = new Task(title, description, isComplete);
        }
        Console.Clear();



    }
    public void DeleteTask(){
        DisplayTasks();
        Console.WriteLine("\nEnter the task# of the task you want to delete or leave blank to cancel.");
        Console.Write(">>");
        string inputStr = Console.ReadLine();

        if(inputStr == ""){
            return;
        }
        _todaysTasks.Remove(_todaysTasks[int.Parse(inputStr)]);
        Console.Clear();
    }

    public void MarkComplete(){
        DisplayTasks();
        Console.WriteLine("\nEnter the task# of the task you want to mark as complete or leave blank to cancel.");
        Console.Write(">>");
        string inputStr = Console.ReadLine();

        if(inputStr == ""){
            return;
        }

        _todaysTasks[int.Parse(inputStr)].SetComplete(true);

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