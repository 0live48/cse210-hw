using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            EternalQuestProgram quest = new EternalQuestProgram();
            bool running = true;

            while (running)
            {
                Console.WriteLine("Eternal Quest Program");
                Console.WriteLine("1. Create a new goal");
                Console.WriteLine("2. Record an event");
                Console.WriteLine("3. View goals");
                Console.WriteLine("4. View score");
                Console.WriteLine("5. Save progress");
                Console.WriteLine("6. Load progress");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateGoal(quest);
                        break;
                    case "2":
                        RecordEvent(quest);
                        break;
                    case "3":
                        quest.DisplayGoals();
                        break;
                    case "4":
                        quest.DisplayScore();
                        break;
                    case "5":
                        quest.SaveProgress("progress.txt");
                        break;
                    case "6":
                        quest.LoadProgress("progress.txt");
                        break;
                    case "7":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void CreateGoal(EternalQuestProgram quest)
        {
            Console.WriteLine("\nCreate a New Goal");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Choose a goal type: ");
            string typeChoice = Console.ReadLine();

            Console.Write("Enter the name of the goal: ");
            string name = Console.ReadLine();
            Console.Write("Enter the points for the goal: ");
            int points = int.Parse(Console.ReadLine());

            switch (typeChoice)
            {
                case "1":
                    quest.AddGoal(new SimpleGoal(name, points));
                    Console.WriteLine("Simple goal created successfully!");
                    break;
                case "2":
                    quest.AddGoal(new EternalGoal(name, points));
                    Console.WriteLine("Eternal goal created successfully!");
                    break;
                case "3":
                    Console.Write("Enter the target count for the checklist goal: ");
                    int targetCount = int.Parse(Console.ReadLine());
                    Console.Write("Enter the bonus points for completing the checklist goal: ");
                    int bonusPoints = int.Parse(Console.ReadLine());
                    quest.AddGoal(new ChecklistGoal(name, points, targetCount, bonusPoints));
                    Console.WriteLine("Checklist goal created successfully!");
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    break;
            }
        }

        static void RecordEvent(EternalQuestProgram quest)
        {
            quest.DisplayGoals();
            Console.Write("Enter the number of the goal to record an event: ");
            int goalIndex = int.Parse(Console.ReadLine()) - 1;
            quest.RecordEvent(goalIndex);
        }
    }
}
