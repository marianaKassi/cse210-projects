using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ScriptureMemorizer
{

    public class BibleReference
    {
        public string Reference { get; private set; }

        public BibleReference(string reference)
        {
            Reference = reference;
        }

        public BibleReference(string book, int chapter, int verse)
        {
            Reference = $"{book} {chapter}:{verse}";
        }

        public BibleReference(string book, int chapter, int startVerse, int endVerse)
        {
            Reference = $"{book} {chapter}:{startVerse}-{endVerse}";
        }
    }

    public class BibleWord
    {
        public string Word { get; private set; }
        public bool IsHidden { get; private set; }

        public BibleWord(string word)
        {
            Word = word;
            IsHidden = false;
        }

        public string GetDisplay()
        {
            return IsHidden ? new string('_', Word.Length) : Word;
        }

        public void Hide()
        {
            IsHidden = true;
        }
    }

    public class BiblePassage
    {
        public BibleReference Reference { get; private set; }
        private List<BibleWord> Words { get; set; }

        public BiblePassage(string reference, string text)
        {
            Reference = new BibleReference(reference);
            Words = text.Split(' ').Select(w => new BibleWord(w)).ToList();
        }

        public void Display()
        {
            Console.WriteLine($"{Reference.Reference}\n{string.Join(" ", Words.Select(w => w.GetDisplay()))}");
        }

        public bool AllWordsHidden()
        {
            return Words.All(w => w.IsHidden);
        }

        public void HideRandomWord()
        {
            var visibleWords = Words.Where(w => !w.IsHidden).ToList();
            if (visibleWords.Count > 0)
            {
                Random rand = new Random();
                int index = rand.Next(visibleWords.Count);
                visibleWords[index].Hide();
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");
            var passage = new BiblePassage("John 3:16", "For God so loved the world that He gave His one and only Son");
            string input;

            do
            {
                Console.Clear();
                passage.Display();
                Console.WriteLine("Press Enter to hide a word or type 'quit' to exit.");
                input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    break;
                }
                else
                {
                    passage.HideRandomWord();
                }

                Thread.Sleep(500); 

            } while (!passage.AllWordsHidden());

            Console.Clear();
            passage.Display();
            Console.WriteLine("All words are hidden. Thank you for playing!");
        }
    }
}