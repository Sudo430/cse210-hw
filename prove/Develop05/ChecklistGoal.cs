class ChecklistGoal : Goal{
    private int _target;
    private int _amountCompleted;
    private int _bounus;
    public ChecklistGoal(string goal, string description, int points, int target, int bounus):base(goal, description, points){
        _target = target;
        _bounus = bounus;
    }

    public ChecklistGoal(string goal, string description, int points, int target, int bounus, int amountCompleted):base(goal, description, points){
        _target = target;
        _bounus = bounus;
        _amountCompleted = amountCompleted;
    }

    public override string GetStringExport(){
        return  $"ChecklistGoal,,{base._goal},,{base._description},,{base._points},,{_target},,{_bounus},,{_amountCompleted}";
    }

    public override void RecordEvent(){
        _amountCompleted++;
    }
    public override bool IsComplete()
    {
        if(_amountCompleted >= _target){
            return true;
        }
        else{
            return false;
        }
    }

    override public string GoalToString(){

        string x = " ";
        if(IsComplete()){
            x = "X";
        }
        
        return $"[{x}] {_goal} ({_description}) -- Currently Completed: {_amountCompleted}/{_target}";
    }

    public override int getPoints()
    {   
        if(IsComplete()){
            return _bounus + base._points;
        } else{
            return base._points;
        }
    }
}