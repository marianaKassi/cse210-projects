using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");

        DisplayWelcome();
        
        string userName = PromptUserName();
        int favoriteNumber = PromptUserNumber();
        
        int squaredNumber = SquareNumber(favoriteNumber);
        
        DisplayResult(userName, squaredNumber);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        int favoriteNumber;
        while (true)
        {
            Console.Write("Please enter your favorite number: ");
            if (int.TryParse(Console.ReadLine(), out favoriteNumber))
            {
                return favoriteNumber;
            }
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}