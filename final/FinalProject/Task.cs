class Task{
    string _title;
    string _description;
    bool _isComplete;
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
            return $"[X] {_title}";
        }
        else{
            return $"[ ] {_title}";
        }
    }

    virtual public string ExportToString(){
        return "";
    }
}