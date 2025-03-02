using System;
using System.Threading;

abstract class MindfulnessActivity
{
    protected int duration;

    public void StartActivity(string name, string description)
    {
        Console.Clear();
        Console.WriteLine($"{name}\n{description}\n");
        Console.Write("Enter duration in seconds: ");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...");
        AnimatedPause(3);
    }

    public void EndActivity(string name)
    {
        Console.WriteLine("\nGreat job!");
        Console.WriteLine($"You have completed the {name} for {duration} seconds.");
        AnimatedPause(3);
    }

    protected void AnimatedPause(int seconds)
    {
        string[] animationFrames = { ".", "*", "o", "O", "o", "*", "." };
        for (int i = 0; i < seconds * 2; i++)
        {
            Console.Write($"\r{animationFrames[i % animationFrames.Length]} ");
            Thread.Sleep(500);
        }
        Console.WriteLine();
    }
}
