class RepeatingTask : Task{
    List<string> _repeatDays;

    public RepeatingTask(string title, string description, bool isComplete, List<string> days): base(title, description,isComplete){
        _repeatDays = days;
    }

    public override string ExportToString()
    {
        return "";
    }

    public List<string> GetRepeatingDays(){
    return _repeatDays;
    }

    public void SetRepeatingDays(List<string> days){
        _repeatDays = days;
    }
}