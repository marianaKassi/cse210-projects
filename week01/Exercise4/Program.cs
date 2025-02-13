using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        int input;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        do
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());

            if (input != 0)
            {
                numbers.Add(input);
            }
        } while (input != 0);

        if (numbers.Count > 0)
        {
            int sum = CalculateSum(numbers);
            double average = CalculateAverage(numbers);
            int max = FindMaximum(numbers);

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {max}");

            int? smallestPositive = FindSmallestPositive(numbers);
            if (smallestPositive.HasValue)
            {
                Console.WriteLine($"The smallest positive number is: {smallestPositive.Value}");
            }

            numbers.Sort();
            Console.WriteLine("The sorted list is:");
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }

    static int CalculateSum(List<int> numbers)
    {
        int sum = 0;
        foreach (var number in numbers)
        {
            sum += number;
        }
        return sum;
    }

    static double CalculateAverage(List<int> numbers)
    {
        return (double)CalculateSum(numbers) / numbers.Count;
    }

    static int FindMaximum(List<int> numbers)
    {
        int max = numbers[0];
        foreach (var number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        return max;
    }

    static int? FindSmallestPositive(List<int> numbers)
    {
        int? smallestPositive = null;

        foreach (var number in numbers)
        {
            if (number > 0)
            {
                if (!smallestPositive.HasValue || number < smallestPositive.Value)
                {
                    smallestPositive = number;
                }
            }
        }
  return smallestPositive;
    }
}