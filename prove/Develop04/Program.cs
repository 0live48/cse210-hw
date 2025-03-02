using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program\nChoose an activity:");
            Console.WriteLine("1. Breathing Exercise");
            Console.WriteLine("2. Reflection Exercise");
            Console.WriteLine("3. Listing Exercise");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");
            switch (Console.ReadLine())
            {
                case "1": new BreathingActivity().Run(); break;
                case "2": new ReflectionActivity().Run(); break;
                case "3": new ListingActivity().Run(); break;
                case "4": return;
                default: Console.WriteLine("Invalid choice, try again."); break;
            }
        }
    }
}
