using System;

class Program
{
    static void Main(string[] args)
    {
        // asks for the users first name and writes it the 'firstName' variable
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // asks for the users last name and writes it the 'lastName' variable
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();
        
        // prints the users name
        Console.WriteLine($"\nYour name is {lastName}, {firstName} {lastName}.");
    }
}