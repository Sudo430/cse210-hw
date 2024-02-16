
class RepeatingEvent : Event{
    List<string> _repeatDays;

    public RepeatingEvent(string title, string description, int startTime, int endTime, List<string> days) : base(title, description, startTime,endTime){
        _repeatDays = days;
    }

    public List<string> GetRepeatingDays(){
        return _repeatDays;
    }

    public void SetRepeatingDays(List<string> days){
        _repeatDays = days;
    }

}