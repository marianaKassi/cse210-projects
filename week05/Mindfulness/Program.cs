using System;
using System.Collections.Generic;
using System.Threading;

public abstract class MindfulnessActivity
{
    protected int Duration { get; set; }

    public void StartActivity()
    {
        Console.WriteLine($"Starting activity: {GetType().Name}");
        Console.WriteLine("Duration (in seconds): ");
        Duration = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Get ready to start...");
        Pause(3);
    }

    protected void Pause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\rPausing for {i} seconds... ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public abstract void RunActivity();

    public void EndActivity()
    {
        Console.WriteLine("Good job! You've completed the activity.");
        Pause(3);
        Console.WriteLine($"Activity duration: {Duration} seconds.");
        Pause(3);
    }
}

public class BreathingActivity : MindfulnessActivity
{
    public override void RunActivity()
    {
        Console.WriteLine("This activity will help you relax by inhaling and exhaling slowly. Clear your mind and focus on your breathing.");
        Pause(2);
        
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Inhale...");
            Pause(4);
            Console.WriteLine("Exhale...");
            Pause(4);
        }
        EndActivity();
    }
}

public class ReflectionActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something really selfless."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience significant for you?",
        "Have you done something like this before?",
        "How did you begin?",
        "How did you feel once the project was completed?",
        "What made this time different from other times?",
        "What do you like most about this experience?",
        "What can you learn from this experience that could apply to other situations?",
        "What did you learn about yourself from this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public override void RunActivity()
    {
        Console.WriteLine("This activity will help you reflect on moments of strength and resilience in your life.");
        Pause(2);
        
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(prompt);
        Pause(3);
        
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            string question = questions[rand.Next(questions.Count)];
            Console.WriteLine(question);
            Pause(4);
        }
        EndActivity();
    }
}

public class ListingActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "What are the people you appreciate?",
        "What are your personal strengths?",
        "Who are the people you've helped this week?",
        "When did you feel the Holy Spirit this month?",
        "Who are some of your personal heroes?"
    };

    public override void RunActivity()
    {
        Console.WriteLine("This activity will help you think of the good things in your life.");
        Pause(2);
        
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(prompt);
        Pause(3);
        
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Please list as many items as you can (type 'done' to finish):");
            string item = Console.ReadLine();
            if (item.ToLower() == "done") break;
            items.Add(item);
        }
        Console.WriteLine($"You listed {items.Count} items.");
        EndActivity();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");

        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            string choice = Console.ReadLine();

            MindfulnessActivity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    Console.WriteLine("Exiting the program. Thank you!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }

            activity.StartActivity();
            activity.RunActivity();
        }
    }
}