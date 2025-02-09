using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private List<string> _prompts = new List<string>
    {
        "What was the best part of your day?",
        "What did you learn today?",
        "What are you grateful for today?",
        "What could you have done better today?"
    };

    public void AddEntry()
    {
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        string response = Console.ReadLine();

        // Ask for rating
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
        Console.WriteLine("Entry added!\n");
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
        var filteredEntries = _entries.FindAll(e => e.Rating == rating);
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
        Console.WriteLine("Journal saved!\n");
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
        Console.WriteLine("Journal loaded!\n");
    }
}
