using System;

namespace EternalQuest
{
    // Base class for all goals
    abstract class Goal
    {
        protected string _name;
        protected int _points;
        protected bool _isComplete;

        public Goal(string name, int points)
        {
            _name = name;
            _points = points;
            _isComplete = false;
        }

        public abstract void RecordEvent();
        public abstract string GetProgress();
        public int GetPoints() => _points;
        public string GetName() => _name;
        public bool IsComplete() => _isComplete;

        public virtual string GetGoalType() => "Base";
    }
}
