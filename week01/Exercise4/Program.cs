using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");

        List<double> numbers = new List<double>();
        double input;

        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        do
        {
            Console.Write("Enter number: ");
            input = Convert.ToDouble(Console.ReadLine());

            if (input != 0)
            {
                numbers.Add(input);
            }
        } while (input != 0);

        
        double sum = 0;
        double max = double.MinValue; 

        foreach (double number in numbers)
        {
            sum += number;
            if (number > max)
            {
                max = number;
            }
        }

        double average = sum / numbers.Count;

        
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        
        double smallestPositive = double.MaxValue; 
        foreach (double number in numbers)
        {
            if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;
            }
        }

        if (smallestPositive != double.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("There are no positive numbers in the list.");

            
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (double number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
    
