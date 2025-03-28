using System;
using System.Collections.Generic;

namespace BookExample
{
    // Book class demonstrating Abstraction
    public class Book
    {
        // Properties (public interface)
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public List<string> Comments { get; } = new List<string>();

        // Method to display book details
        public void DisplayDetails()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Pages: {Pages}");
            Console.WriteLine("Comments:");
            foreach (var comment in Comments)
            {
                Console.WriteLine($"- {comment}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a book instance
            Book myBook = new Book
            {
                Title = "The C# Programming Language",
                Author = "Anders Hejlsberg",
                Pages = 500
            };

            // Add some comments
            myBook.Comments.Add("Great book for beginners!");
            myBook.Comments.Add("Very comprehensive.");

            // Display book details
            myBook.DisplayDetails();
        }
    }
}
