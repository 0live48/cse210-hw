using System;

class ReflectionActivity : MindfulnessActivity
{
    private static readonly string[] Prompts =
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] Questions =
    {
        "Why was this experience meaningful to you?",
        "How did you feel when it was complete?",
        "What did you learn from this experience?",
        "How can you apply this lesson to your life?"
    };

    public void Run()
    {
        StartActivity("Reflection Exercise", "This activity helps you reflect on moments of strength.");
        Console.WriteLine(Prompts[new Random().Next(Prompts.Length)]);
        AnimatedPause(3);
        for (int i = 0; i < duration; i += 5)
        {
            Console.WriteLine(Questions[new Random().Next(Questions.Length)]);
            AnimatedPause(5);
        }
        EndActivity("Reflection Exercise");
    }
}
