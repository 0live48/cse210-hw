using System;

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
            Console.WriteLine("4. Save journal to file");
            Console.WriteLine("5. Load journal from file");
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
                    journal.SaveToFile(Console.ReadLine());
                    break;
                case "5":
                    Console.Write("Enter filename to load: ");
                    journal.LoadFromFile(Console.ReadLine());
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.\n");
                    break;
            }
        }
    }
}
