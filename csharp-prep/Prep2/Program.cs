using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter the grade% >>");
        int grade = int.Parse(Console.ReadLine());
        
        char letterGrade = 'F';

        if(grade >= 90){
            letterGrade = 'A';
        }

        else if(grade >= 80){
            letterGrade = 'B';
        }

        else if(grade >= 70){
            letterGrade = 'C';
        }

        else if(grade >= 60){
            letterGrade = 'D';
        }
        
        Console.WriteLine($"A grade of {grade}% is a {letterGrade}");

        if(grade < 70 ){
            Console.WriteLine("You didn't didn't pass the class. Keep trying and you will get there.");
        }
        else{
            Console.WriteLine("Congratulations! You passed the class.");
        }

    }
}