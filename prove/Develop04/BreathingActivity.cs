using System;

class BreathingActivity : MindfulnessActivity
{
    public void Run()
    {
        StartActivity("Breathing Exercise", "This activity helps you relax by guiding your breathing.");
        for (int i = 0; i < duration; i += 4)
        {
            Console.Write("Breathe in... "); AnimatedPause(2);
            Console.Write("Breathe out... "); AnimatedPause(2);
        }
        EndActivity("Breathing Exercise");
    }
}
