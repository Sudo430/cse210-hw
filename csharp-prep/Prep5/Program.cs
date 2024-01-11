using System;

class Program
{
    static void Main(string[] args)
    {
        // calls all the functions
        DisplayWelcome();
        DisplayResult(PromptUserName(),SquareNumber(PromptUserNumber()));
    }

    // Prints a welcome message to the console
    static void DisplayWelcome(){
        Console.WriteLine("Welcome to the program!");
    }

    // asks the user for a name and returns it as a string
    static string PromptUserName(){
        Console.Write("Please enter your name: ");
        return(Console.ReadLine());
    }

    // asks the user for a number and returns it as an int
    static int PromptUserNumber(){
        Console.Write("Please enter your favorite number: ");
        return(int.Parse(Console.ReadLine()));
    }

    //returns the square of the number it's given
    static int SquareNumber(int num){
        return(num * num);
    }

    //print's the resoults in the console. takes the name and the square of the number given
    static void DisplayResult(string name, int sqrNum){
        Console.WriteLine($"{name}, the square of your number is {sqrNum}");

    }
}