
class RepeatingEvent : Event{
    private List<string> _repeatDays;

    public RepeatingEvent(string title, string description, int startTime, int endTime, List<string> days) : base(title, description, startTime,endTime){
        _repeatDays = days;
    }

    override public string ExportEvent(){
        string daysInString = string.Join(",", _repeatDays);
        return $"┌{_title}┌{_description}┌{_startTime}┌{_endTime}┌{daysInString}";
    }

    public List<string> GetRepeatingDays(){
        return _repeatDays;
    }

    public void SetRepeatingDays(List<string> days){
        _repeatDays = days;
    }

}