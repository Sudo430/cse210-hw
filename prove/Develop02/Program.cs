using System;

class Program
{
    static void Main(string[] args)
    {
        //variable for storing the selected menu
        string userInput = "";

        //the list of lists that the journal enterys or stored in
        List<List<string>> Journal = new List<List<string>>();

        //the Write class has methods that invalve writing. newEnter and saveFile
        Write write = new Write();
        //the read class has methods that invalve reading. loadFile, Display, and newPrompt
        Read read = new Read();
        
        //the main loop, repeats until the user enters 5
        while(userInput != "5"){

            //display menu
            Console.WriteLine("Welcome to the Journal Program!\nPlease select one of the following choices");
            Console.WriteLine("1. Write\n2. Display\n3. Load\n4. Save\n5. Quit");
            Console.Write("What would you like to do?");
            //get the menu selection from the user
            userInput = Console.ReadLine();

            //do the thing the user wants
            switch(userInput){
                
                //addes a new Journal entry list [date, prompt, entery]
                case "1":
                    Journal.Add(write.newEntry());
                    break;
                
                //displays all the journal entrys that are loaded
                case "2":
                    read.Display(Journal);
                    break;

                //loads journal enterys from a file, the file name is entered in by the user
                case "3":
                    Journal = read.loadFile();
                    break;

                //saves the loaded journal enterys to a file that the user entered
                case "4":
                    write.saveFile(Journal);
                    break;

                
            }

        }
    }
}