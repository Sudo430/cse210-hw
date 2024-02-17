class Event{
    protected string _description;
    protected int _startTime;
    protected int _endTime;
    protected string _title;

    public Event(string title, string description, int startTime, int endTime){
        _title = title;
        _description = description;
        _startTime = startTime;
        _endTime = endTime;
    }
        public Event(string title, string description){
        _title = title;
        _description = description;
    }

    public string RenderEvent(){
        
        return $"{_startTime, 4} -> {_endTime, 4} : {_title.ToUpper(), -15} : {_description}";
    }
    virtual public string ExportEvent(){
        return $"┌{_title}┌{_description}┌{_startTime}┌{_endTime}";
    }

    //setters
    public void SetTitle(string newTitle){
        _title = newTitle;
    }

    public void SetDescription(string newDescription){
        _description = newDescription;
    }

    public void setTimes(int newStart, int newEnd){
        _startTime = newStart;
        _endTime = newEnd;
    }
    //getters
    public int GetStartTime(){
        return _startTime;
    }


}