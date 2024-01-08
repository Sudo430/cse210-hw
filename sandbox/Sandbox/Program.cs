using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Sandbox World!");
        Console.Write("enter a string >>");
        string input = Console.ReadLine();
        if (input == "no"){
            Console.WriteLine("Don't tell me no");
        }
        Console.WriteLine($"\n{input}");
    }
}