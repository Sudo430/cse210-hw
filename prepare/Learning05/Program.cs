using System;

class Program
{
    static void Main(string[] args)
    {

        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Red",5));
        shapes.Add(new Rectangle("Blue", 2, 5));
        shapes.Add(new Circle("green", 2));

        Console.Clear();
        foreach(Shape shape in shapes){
            Console.WriteLine($"Shape Name: {shape.GetName()}");
            Console.WriteLine($"Shape Color: {shape.GetColor()}");
            Console.WriteLine($"Shape Area: {shape.GetArea()}");
            Console.WriteLine();
        }
    }
}