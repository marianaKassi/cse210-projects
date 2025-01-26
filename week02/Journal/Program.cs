using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }

    public override string ToString()
    {
        return $"{Date.ToString("yyyy-MM-dd HH:mm")}: {Prompt}\nResponse: {Response}\n";
    }
}

class Program
{
    static List<JournalEntry> journalEntries = new List<JournalEntry>();
    static Random random = new Random();
    static List<string> prompts = new List<string>
    {
         "If I could do one thing today, what would it be?",
        "Who is the most interesting person I've interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?"
    };

    static void Main()
    {
        Console.WriteLine("Hello World! This is the Journal Project.");
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Write ");
            Console.WriteLine("2. Display ");
             Console.WriteLine("3. Load ");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    DisplayJournal();
                    break;
                case "3":
                    SaveJournalToFile();
                    break;
                case "4":
                    LoadJournalFromFile();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

    static void WriteNewEntry()
    {
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        JournalEntry entry = new JournalEntry
        {
            Prompt = prompt,
            Response = response,
            Date = DateTime.Now
        };

        journalEntries.Add(entry);
        Console.WriteLine("Entry added to the journal.");
    }

    static void DisplayJournal()
    {
        if (journalEntries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
            return;
        }

        foreach (var entry in journalEntries)
        {
            Console.WriteLine(entry);
        }
    }

    static void SaveJournalToFile()
    {
        Console.Write("Enter the filename to save the journal: ");
        string fileName = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var entry in journalEntries)
            {
                writer.WriteLine(entry.ToString());
            }
        }

        Console.WriteLine("Journal saved successfully.");
    }

    static void LoadJournalFromFile()
    {
        Console.Write("Enter the filename to load: ");
        string fileName = Console.ReadLine();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("The file does not exist.");
            return;
        }

        journalEntries.Clear();
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
    
                var entryParts = line.Split(new[] { ": " }, 3, StringSplitOptions.None);
                DateTime date = DateTime.Parse(entryParts[0]);
                string prompt = entryParts[1];
                string response = entryParts[2].Replace("Response: ", "");

                journalEntries.Add(new JournalEntry { Date = date, Prompt = prompt, Response = response });
            }
        }

        Console.WriteLine("Journal loaded successfully.");
    }
}
