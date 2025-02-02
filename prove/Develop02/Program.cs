using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
    public int Rating { get; set; }

    public Entry(string prompt, string response, string date, int rating)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
        Rating = rating;
    }

    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\nRating: {Rating}/5\n";
    }
}

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void AddEntry()
    {
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        string response = Console.ReadLine();

        int rating;
        while (true)
        {
            Console.Write("Rate your day (1 to 5): ");
            if (int.TryParse(Console.ReadLine(), out rating) && rating >= 1 && rating <= 5)
            {
                break;
            }
            Console.WriteLine("Invalid rating. Please enter a number between 1 and 5.");
        }

        string date = DateTime.Now.ToString("yyyy-MM-dd");
        _entries.Add(new Entry(prompt, response, date, rating));
        Console.WriteLine("Entry added successfully!\n");
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found.\n");
            return;
        }

        foreach (var entry in _entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void DisplayEntriesByRating(int rating)
    {
        var filteredEntries = _entries.Where(e => e.Rating == rating).ToList();
        if (filteredEntries.Count == 0)
        {
            Console.WriteLine($"No entries found with rating {rating}.\n");
            return;
        }

        Console.WriteLine($"Entries with rating {rating}:\n");
        foreach (var entry in filteredEntries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}|{entry.Rating}");
            }
        }
        Console.WriteLine("Journal saved successfully!\n");
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                _entries.Add(new Entry(parts[1], parts[2], parts[0], int.Parse(parts[3])));
            }
        }
        Console.WriteLine("Journal loaded successfully!\n");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Display entries by rating");
            Console.WriteLine("4. Save the journal to a file");
            Console.WriteLine("5. Load the journal from a file");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter rating (1 to 5): ");
                    if (int.TryParse(Console.ReadLine(), out int rating) && rating >= 1 && rating <= 5)
                    {
                        journal.DisplayEntriesByRating(rating);
                    }
                    else
                    {
                        Console.WriteLine("Invalid rating. Please enter a number between 1 and 5.\n");
                    }
                    break;
                case "4":
                    Console.Write("Enter filename to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;
                case "5":
                    Console.Write("Enter filename to load: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.\n");
                    break;
            }
        }
    }
}