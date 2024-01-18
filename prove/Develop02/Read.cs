using System;

public class Read{

    //Loads Journal entrys from a file of the users chosing, returns a list of lists, 
    public List<List<string>> loadFile(){

        //ask user file file to load
        Console.Write("Please enter the file name you would like to load.\n>");
        string fileName = Console.ReadLine();

        //loads the file to an array, each line is an item
        string[] lines = System.IO.File.ReadAllLines(fileName);

        //making the list to return the data in
        List<List<string>> journal = new List<List<string>>();

        //looping through each line in the file
        foreach (string line in lines){
            //spliting the data in the line apart
            string[] parts = line.Split(",,");

            //making the list to add to the other list
            List<string> entry = new List<string>();

            entry.Add(parts[0]);
            entry.Add(parts[1]);
            entry.Add(parts[2]);
            journal.Add(entry);
        }
        
        //returning the list
        return journal;

    }

    //returns a random prompt in the promptList Array
    public string newPrompt(){
        //list of promps to chose from
        string[] promptList = {"Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"};

        //picks a random one and returns it.
        Random random = new Random();
        return promptList[random.Next(promptList.Length)];
    }


    //Prints out the Journal entery that are given to it in a list of lists
    public void Display(List<List<string>> Journal){
        Console.WriteLine();

        //loop through and prints out each one
        foreach(List<string> entry in Journal){
            Console.WriteLine($"Date: {entry[0]} - Prompt: {entry[2]}\n{entry[3]}");
        }

        
    }

    
}