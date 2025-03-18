namespace EternalQuest
{
    // Eternal goal class
    class EternalGoal : Goal
    {
        public EternalGoal(string name, int points) : base(name, points) { }

        public override void RecordEvent()
        {
            // Eternal goals are never complete
        }

        public override string GetProgress()
        {
            return "[∞]";
        }

        public override string GetGoalType() => "Eternal";
    }
}
