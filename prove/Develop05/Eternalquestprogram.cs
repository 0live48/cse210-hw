using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EternalQuest
{
    // Program class to manage goals and user score
    class EternalQuestProgram
    {
        private List<Goal> _goals;
        private int _score;

        public EternalQuestProgram()
        {
            _goals = new List<Goal>();
            _score = 0;
        }

        public void AddGoal(Goal goal)
        {
            _goals.Add(goal);
        }

        public void RecordEvent(int goalIndex)
        {
            if (goalIndex >= 0 && goalIndex < _goals.Count)
            {
                _goals[goalIndex].RecordEvent();
                _score += _goals[goalIndex].GetPoints();
                Console.WriteLine($"Event recorded for goal: {_goals[goalIndex].GetName()}");
            }
            else
            {
                Console.WriteLine("Invalid goal index.");
            }
        }

        public void DisplayGoals()
        {
            Console.WriteLine("\nYour Goals:");
            var rankedGoals = _goals.OrderByDescending(g => g.GetPoints()).ToList(); // Rank goals by points
            for (int i = 0; i < rankedGoals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {rankedGoals[i].GetProgress()} {rankedGoals[i].GetName()} ({rankedGoals[i].GetPoints()} points)");
            }
        }

        public void DisplayScore()
        {
            Console.WriteLine($"\nYour current score: {_score} points\n");
        }

        public void SaveProgress(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(_score);
                foreach (var goal in _goals)
                {
                    writer.WriteLine($"{goal.GetGoalType()}|{goal.GetName()}|{goal.GetPoints()}|{goal.IsComplete()}");
                }
            }
            Console.WriteLine("Progress saved successfully!");
        }

        public void LoadProgress(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    _score = int.Parse(reader.ReadLine());
                    _goals.Clear();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');
                        string goalType = parts[0];
                        string name = parts[1];
                        int points = int.Parse(parts[2]);
                        bool isComplete = bool.Parse(parts[3]);

                        switch (goalType)
                        {
                            case "Simple":
                                var simpleGoal = new SimpleGoal(name, points);
                                if (isComplete) simpleGoal.RecordEvent();
                                _goals.Add(simpleGoal);
                                break;
                            case "Eternal":
                                _goals.Add(new EternalGoal(name, points));
                                break;
                            case "Checklist":
                                // For checklist goals, additional logic is needed to load progress
                                // This is a simplified version
                                _goals.Add(new ChecklistGoal(name, points, 5, 500)); // Example values
                                break;
                        }
                    }
                }
                Console.WriteLine("Progress loaded successfully!");
            }
            else
            {
                Console.WriteLine("No saved progress found.");
            }
        }
    }
}
