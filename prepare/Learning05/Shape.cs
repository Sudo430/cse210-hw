abstract class Shape{
    protected string _color;
    protected string _shapeName;

    public Shape(string color){
        _color = color;
    }


    public string GetColor(){
        return _color;
    }
    public void SetColor(string color){
        _color = color;

    }
    public string GetName(){
        return _shapeName;
    }
    abstract public double GetArea();
}