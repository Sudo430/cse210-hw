
class RepeatingEvent : Event{
    List<string> _repeatDays;

    public RepeatingEvent(string title, string description, int startTime, int endTime, List<string> days) : base(title, description, startTime,endTime){
        _repeatDays = days;
    }

    override public string ExportEvent(){

        string daysInString = "";
        foreach(string day in _repeatDays){
            daysInString += $"{day},";
        }
        daysInString = daysInString.Remove(daysInString.Length);
        return $"┌{_title}┌{_description}┌{_startTime}┌{_endTime}┌{daysInString}";
    }

    public List<string> GetRepeatingDays(){
        return _repeatDays;
    }

    public void SetRepeatingDays(List<string> days){
        _repeatDays = days;
    }

}