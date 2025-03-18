namespace EternalQuest
{
    // Simple goal class
    class SimpleGoal : Goal
    {
        public SimpleGoal(string name, int points) : base(name, points) { }

        public override void RecordEvent()
        {
            _isComplete = true;
        }

        public override string GetProgress()
        {
            return _isComplete ? "[X]" : "[ ]";
        }

        public override string GetGoalType() => "Simple";
    }
}
