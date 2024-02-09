class EternalGoal : Goal{
    public EternalGoal(string goal, string description, int points):base(goal, description, points){

    }

    public override string GetStringExport(){
        return  $"EternalGoal,,{base._goal},,{base._description},,{base._points}";
    }

    public override void RecordEvent(){
        return;
    }
    public override bool IsComplete()
    {
        return false;
    }
}