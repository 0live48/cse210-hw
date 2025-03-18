namespace EternalQuest
{
    // Checklist goal class
    class ChecklistGoal : Goal
    {
        private int _targetCount;
        private int _currentCount;
        private int _bonusPoints;

        public ChecklistGoal(string name, int points, int targetCount, int bonusPoints) : base(name, points)
        {
            _targetCount = targetCount;
            _currentCount = 0;
            _bonusPoints = bonusPoints;
        }

        public override void RecordEvent()
        {
            _currentCount++;
            if (_currentCount == _targetCount)
            {
                _isComplete = true;
                _points += _bonusPoints; // Add bonus points when target is reached
            }
        }

        public override string GetProgress()
        {
            return $"Completed {_currentCount}/{_targetCount} times";
        }

        public override string GetGoalType() => "Checklist";
    }
}
