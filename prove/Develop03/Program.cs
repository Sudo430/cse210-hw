using System;

// add the option to show the scripture mid way through the program. 

class Program
{
    static void Main(string[] args)
    {
        //storing the verse reference in reference class
        Reference reference = new Reference("D&C","6","36");

        //storing the scripture in the scripture class
        Scripture scripture = new Scripture("Look unto me in every thought; doubt not, fear not.");

        //main loop
        bool run = true;
        bool hidden = true;
        while (!scripture.allHidden() && run){
            //clearing and writing the scripture to the console
            Console.Clear();
            Console.Write(reference.getReference() + " ");
            Console.WriteLine(scripture.getScripture(hidden));

            //break the main loop if the user types 'q'
            Console.Write("Press enter to contine, type 'q' to quit, or 's' to show the scripture.");
            string input = Console.ReadLine();
            switch(input){
                case "q":
                    run = false;
                    break;
                case "s":
                    hidden = false;
                    break;
                default:
                    //hids some of the words in the scripture
                    
                    if(hidden){scripture.hidWords(3);}
                    hidden = true;
                    break;
                
            }
            
            // scripture.hidWords(3);
        }
        
    }
}