using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

    
        Random random = new Random();
        bool playAgain;

        do
        {
    
            int magicNumber = random.Next(1, 101);
            int userGuess = 0;
            int guessCount = 0;

            Console.WriteLine("Welcome to 'Guess My Number'!");
            Console.WriteLine("I'm thinking of a number between 1 and 100.");

            while (userGuess != magicNumber)
            {
                Console.Write("What is your guess? ");
                userGuess = Convert.ToInt32(Console.ReadLine());
                guessCount++; 

                if (userGuess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (userGuess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            
            Console.WriteLine($"You made {guessCount} guesses.");

            Console.Write("Do you want to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();
            playAgain = response == "yes";

        } while (playAgain); 

        Console.WriteLine("Thanks for playing!");
    }
}

    
