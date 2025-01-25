using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");


    
        Console.Write("Enter your percentage grade: ");
        int percentage = Convert.ToInt32(Console.ReadLine());


        string letter = "";
        string sign = "";

        
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        
        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("Keep trying for next time!");
        }

        
        if (letter != "F") 
        {
            int lastDigit = percentage % 10;

            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

    
        if (letter == "A" && sign == "+")
        {
            Console.WriteLine("Your grade is A.");
        }
        else if (letter == "A" && sign == "-")
        {
            Console.WriteLine("Your grade is A-.");
        }
        else if (letter == "F")
        {
            Console.WriteLine("Your grade is F.");
        }
        else
        {
            Console.WriteLine($"Your grade is {letter}{sign}.");
        }
    }
}


    
