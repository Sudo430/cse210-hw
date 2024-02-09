class SimpleGoal : Goal{

    private bool _complete = false;

    public SimpleGoal(string goal, string description, int points): base(goal, description, points){

    }
    public SimpleGoal(string goal, string description, int points, bool complete): base(goal, description, points){
        _complete = complete;
    }

    public override bool IsComplete(){
        return _complete;
    }

    public override void RecordEvent()
    {
        _complete = true;
    }

    public override string GetStringExport()
    {
        return  $"SimpleGoal,,{base._goal},,{base._description},,{base._points},,{_complete}";
    }
}
