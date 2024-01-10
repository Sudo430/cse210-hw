using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> numbers = new List<int>();


        while(true){
            Console.Write("Enter number: ");
            int num = int.Parse(Console.ReadLine());

            if (num == 0){
                break;
            }
            numbers.Add(num);
        } 
        numbers.Sort();
        Console.WriteLine($"The sum is: {numbers.Sum()}");
        Console.WriteLine($"The average is: {numbers.Average()}");
        Console.WriteLine($"The largest number is: {numbers[numbers.Count() - 1]}");
        
        foreach(int num in numbers){
            if(num >= 0){
                Console.WriteLine($"The smallest positive number is: {num}");
                break;
            }
        }

        Console.WriteLine("The sorted list is:");
        foreach(int num in numbers){
            Console.WriteLine(num);
        }

        
        
    }
}