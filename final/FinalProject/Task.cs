class Task{
    protected string _title;
    protected string _description;
    protected bool _isComplete;
    public Task(string title, string description, bool isComplete){
        _title = title;
        _description = description;
        _isComplete = isComplete;
    }

    //setters
    public void SetTitle(string title){
        _title = title;
    }

    public void SetDescription(string description){
        _description = description;
    }
    public void SetComplete(bool x){
        _isComplete = x;
    }

    //getters
    public string GetTitle(){
        return _title;
    }
    public string GetDescription(){
        return _description;
    }
    public bool IsComplete(){
        return _isComplete;
    }

    public string RenderTask(){
        if(IsComplete()){
            return $"[X] : {_title, -15} : {_description}";
        }
        else{
            return $"[ ] : {_title, -15} : {_description}";
        }
    }

    virtual public string ExportToString(){
        return $"{_title}┌{_description}┌{_isComplete}";
    }
}