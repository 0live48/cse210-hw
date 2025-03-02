using System;

class ListingActivity : MindfulnessActivity
{
    private static readonly string[] Prompts =
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public void Run()
    {
        StartActivity("Listing Exercise", "This activity helps you list positive things in your life.");
        Console.WriteLine(Prompts[new Random().Next(Prompts.Length)]);
        AnimatedPause(3);
        int count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("Enter an item: ");
            Console.ReadLine();
            count++;
        }
        Console.WriteLine($"You listed {count} items!");
        EndActivity("Listing Exercise");
    }
}
