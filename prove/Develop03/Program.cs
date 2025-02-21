using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture("Nephi 3:7", "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.");

        while (!scripture.AllWordsHidden)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords();
        }

        if (scripture.AllWordsHidden)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetFullyHiddenText());
            Console.WriteLine("\nAll words are now hidden. Program ending.");
        }
    }
}
