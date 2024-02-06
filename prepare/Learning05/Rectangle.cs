class Rectangle : Shape{
    private double _side1;
    private double _side2;
    public Rectangle(string color,double side1, double side2): base(color){
        _side1 = side1;
        _side2 = side2;
        base._shapeName = "Rectangle";
    }

    public override double GetArea()
    {
        return _side1 * _side2;
    }
}