using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    class Entry
    {
        public string Prompt { get; set; }
        public string Response { get; set; }
        public string Date { get; set; }

        public Entry(string prompt, string response, string date)
        {
            Prompt = prompt;
            Response = response;
            Date = date;
        }

        public override string ToString()
        {
            return $"Date: {Date}\nPrompt: {Prompt}\n{Response}\n";
        }

        public string ToFileFormat()
        {
            return $"{Date}|{Prompt}|{Response}";
        }
    }

    class Program 
    {
        static List<Entry> journal = new List<Entry>();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to your Journal App!");
            
            while (true)
            {        
                Console.WriteLine("Please select one of following choices:");
                Console.WriteLine("1. Write");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Load");
                Console.WriteLine("4. Save");
                Console.WriteLine("5. Quit");

                Console.Write("What would you like to do? ");

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
                        LoadJournalFromFile();
                        break;
                    case "4":
                        SaveJournalToFile();
                        break;
                    case "5": 
                        return;
                    default:
                        Console.WriteLine("Please choose a valid option.");
                        break;
                }
            }
        }

        static void WriteNewEntry()
        {
            List<string> prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?", 
                "If I had one thing I could do over today, what would it be?", 
                "What is something new I learned today?", 
                "What is one small thing I am grateful for today?", 
                "What is something I could improve on tomorrow?", 
                "How did I practice kindness today?", 
                "What did I do today that I'm proud of?", 
                "How did I take care of myself today?", 
                "What moment today made me smile or laugh?" 
            };

            Random rand = new Random();
            string selectedPrompt = prompts[rand.Next(prompts.Count)];

            Console.WriteLine($"{selectedPrompt}");
            string response = Console.ReadLine();

            Entry newEntry = new Entry(selectedPrompt, response, DateTime.Now.ToShortDateString());

            journal.Add(newEntry);
            
        }

        static void DisplayJournal()
        {
            if (journal.Count == 0)
            {
                Console.WriteLine("No entries found in your journal.");
            }
            else
            {
                Console.WriteLine("\nYour Journal Entries:");
                foreach (var entry in journal)
                {
                    Console.WriteLine(entry.ToString());
                }
            }
        }

        static void SaveJournalToFile()
        {
            Console.WriteLine("What is the filename? ");
            string filename = Console.ReadLine();

            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    foreach (var entry in journal)
                    {
                        writer.WriteLine(entry.ToFileFormat());
                    }
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while saving the journal: {e.Message}");
            }
        }

        static void LoadJournalFromFile()
        {
            Console.WriteLine("Enter the filename to load the journal from: ");
            string filename = Console.ReadLine();

            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    journal.Clear();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length == 3)
                        {
                            Entry entry = new Entry(parts[1], parts[2], parts[0]);
                            journal.Add(entry);
                        }
                    }
                }
                Console.WriteLine($"File successfully loaded");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error ocurred loading the journal: {e.Message}");
            }

        }
    }
}