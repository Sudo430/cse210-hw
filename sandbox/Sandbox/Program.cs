using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Sandbox World!");
        Console.Write("enter an intager >>");
        string input = Console.ReadLine();

        Console.WriteLine($"{input} + 5 = {int.Parse(input) + 5}");

    }
}