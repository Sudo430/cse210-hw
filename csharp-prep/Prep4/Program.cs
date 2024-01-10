using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        // makes a list to store the numbers in
        List<int> numbers = new List<int>();

        //ask the user for numbers to put in the list. keeps asking untill the user enters 0
        while(true){
            Console.Write("Enter number: ");
            int num = int.Parse(Console.ReadLine());

            if (num == 0){
                break;
            }
            numbers.Add(num);
        } 

        //sorts the list and prints out some values
        numbers.Sort();
        Console.WriteLine($"The sum is: {numbers.Sum()}");
        Console.WriteLine($"The average is: {numbers.Average()}");
        Console.WriteLine($"The largest number is: {numbers[numbers.Count() - 1]}");
        
        //finds the smallest positive number and prints it
        foreach(int num in numbers){
            if(num >= 0){
                Console.WriteLine($"The smallest positive number is: {num}");
                break;
            }
        }

        //prints the list
        Console.WriteLine("The sorted list is:");
        foreach(int num in numbers){
            Console.WriteLine(num);
        }
    }
}