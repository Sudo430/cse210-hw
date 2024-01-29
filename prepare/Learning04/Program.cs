using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("somebody","a topic");
        Console.WriteLine(assignment.getSummary());
        Console.WriteLine();

        MathAssignment mathAssignment = new MathAssignment("somebody", "thetopic","thesections", "theproblem");
        Console.WriteLine(mathAssignment.getSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());
        Console.WriteLine();

        WritingAssignment writingAssignment = new WritingAssignment("somebody","a topic","thisIsATitle");
        Console.WriteLine(writingAssignment.getSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}