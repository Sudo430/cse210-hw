abstract class Goal{
    protected string _goal;
    protected string _description;
    protected int _points;

    public Goal(string goal, string description, int points){
        _goal = goal;
        _description = description;
        _points = points;
    }

    virtual public int getPoints(){
        return _points;
    }
    abstract public bool IsComplete();

    virtual public string GoalToString(){

        string x = " ";
        if(IsComplete()){
            x = "X";
        }
        
        return $"[{x}] {_goal} ({_description})";
    }

    abstract public void RecordEvent();

    abstract public string GetStringExport();

}