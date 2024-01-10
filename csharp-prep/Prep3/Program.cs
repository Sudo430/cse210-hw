using System;

class Program
{
    static void Main(string[] args)
    {

        Random random = new Random();

        // the main loop
        bool run = true;
        while(run){

            // gets the random number
            int magicNumber = random.Next(1, 101);
            // declaires the guess variable
            int guess = 110;
            // setting the number of guesses to 0
            int numOfGuesses = 0;

            //prints some basic instructions
            Console.WriteLine("Try to guess the number I'm thinking of.\nIt's in-between 1 and 100.");

            // the game loop. breaks when the guess is right
            while(magicNumber != guess){

                //get the guess from the user
                Console.Write("\nWhat is your guess? ");
                guess = int.Parse(Console.ReadLine());
                //adds one to guess counter
                numOfGuesses++;

                //checks if the guess is higher or lower
                if(guess > magicNumber){
                    Console.WriteLine("Lower");
                }
                else if(guess < magicNumber){
                    Console.WriteLine("Higher");
                }
            }

            // prints the number of guesses it took to guess the number
            Console.WriteLine($"You guessed it in {numOfGuesses} guesses");

            //ask if the user wants to play again
            Console.Write("\nWould you like to play again?(y/n)");
            string input = Console.ReadLine();

            //if the user enters 'n' then breaks the main loop by setting run to false.
            if (input.ToLower() == "n"){
                run = false;
            }

        }
    }
}