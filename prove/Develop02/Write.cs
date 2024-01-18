using System;
using System.IO;
using System.IO.Enumeration;
public class Write{
    
    //makes a new entry, retruns list [date, prompt, entery]
    public List<string> newEntry(){
        //making a list to store the entery in
        List<String> output = new List<string>();

        //geting the time
        DateTime theTime = DateTime.Now;

        //bring in the read class to use the newPromt method
        Read read = new Read();

        //adding the date
        output.Add(theTime.ToShortDateString());
        //adding the prompt
        output.Add(read.newPrompt());
        //printing the prompt
        Console.Write($"{output[1]}\n>");
        //getting the entry form the user
        output.Add(Console.ReadLine());

        return output;
        
    }

    //saves the list of journal entrys a file of the users choseing
    public void saveFile(List<List<string>> journal){
        //geting the file name from user
        Console.Write("Please enter the file name.\nWARNING! if you enter a file that already exists it WILL be overwritten.\n>");
        string fileName = Console.ReadLine();

        //opening file
        using (StreamWriter outputFile = new StreamWriter(fileName)){
            //looping through each entry and saving it to a line in the file
            foreach(List<string> entery in journal){
                //each data point is seperated by ',,'
                outputFile.WriteLine($"{entery[0]},,{entery[1]},,{entery[2]}");
            }
        }
    }
}