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
            // Generate a random number between 1 and 100
            int magicNumber = random.Next(1, 101);
            int userGuess = 0;
            int guessCount = 0;

            Console.WriteLine("Welcome to 'Guess My Number'!");
            Console.WriteLine("I'm thinking of a number between 1 and 100.");

            // Loop until the user guesses the magic number
            while (userGuess != magicNumber)
            {
                Console.Write("What is your guess? ");
                userGuess = Convert.ToInt32(Console.ReadLine());
                guessCount++; // Increment the guess count

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

            // Inform the user of their total guesses
            Console.WriteLine($"You made {guessCount} guesses.");

            // Ask if they want to play again
            Console.Write("Do you want to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();
            playAgain = response == "yes";

        } while (playAgain); // Repeat the game if the user wants to play again

        Console.WriteLine("Thanks for playing!");
    }
}

    
