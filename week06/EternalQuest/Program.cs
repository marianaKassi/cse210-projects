using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    abstract class Goal
    {
        protected string _name;
        protected string _description;
        protected int _points;
        protected bool _isCompleted;

        public Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
            _isCompleted = false;
        }

        public abstract void RecordEvent();
        public abstract string GetStatus();
        public abstract string GetGoalType();

        public string GetName() => _name;
        public int GetPoints() => _points;
        public bool IsCompleted() => _isCompleted;

        public virtual string GetDetails() => $"{_name}: {_description}";
    }

    class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points) : base(name, description, points) { }

        public override void RecordEvent()
        {
            if (!_isCompleted)
            {
                _isCompleted = true;
            }
        }

        public override string GetStatus() => _isCompleted ? "[X]" : "[ ]";
        public override string GetGoalType() => "SimpleGoal";
    }

    class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points) : base(name, description, points) { }

        public override void RecordEvent()
        {
        }

        public override string GetStatus() => "[ ]";
        public override string GetGoalType() => "EternalGoal";
    }

    class ChecklistGoal : Goal
    {
        private int _targetCount;
        private int _currentCount;
        private int _bonusPoints;

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
            : base(name, description, points)
        {
            _targetCount = targetCount;
            _currentCount = 0;
            _bonusPoints = bonusPoints;
        }

        public override void RecordEvent()
        {
            if (_currentCount < _targetCount)
            {
                _currentCount++;
                if (_currentCount == _targetCount)
                {
                    _isCompleted = true;
                    _points += _bonusPoints; 
                }
            }
        }

        public override string GetStatus() => $"Completed {_currentCount}/{_targetCount} times";
        public override string GetGoalType() => "ChecklistGoal";

        public override string GetDetails() => $"{base.GetDetails()} (Bonus: {_bonusPoints} points after {_targetCount} times)";
    }
    class NegativeGoal : Goal
    {
        public NegativeGoal(string name, string description, int points) : base(name, description, points) { }

        public override void RecordEvent()
        {
        }

        public override string GetStatus() => "[ ]";
        public override string GetGoalType() => "NegativeGoal";
    }

    class GoalManager
    {
        private List<Goal> _goals;
        private int _score;
        private int _level;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
            _level = 1;
        }

        public void AddGoal(Goal goal) => _goals.Add(goal);

        public void RecordEvent(string goalName)
        {
            var goal = _goals.Find(g => g.GetName() == goalName);
            if (goal != null)
            {
                goal.RecordEvent();
                _score += goal.GetPoints();

                if (goal is ChecklistGoal checklistGoal && checklistGoal.IsCompleted())
                {
                    _score += checklistGoal.GetPoints(); 
                }

                UpdateLevel();
            }
        }

        public void DisplayGoals()
        {
            Console.WriteLine("\nCurrent Goals:");
            foreach (var goal in _goals)
            {
                Console.WriteLine($"{goal.GetStatus()} {goal.GetDetails()}");
            }
        }

        public void DisplayScore() => Console.WriteLine($"\nCurrent Score: {_score} (Level {_level})");

        private void UpdateLevel()
        {
            _level = 1 + (_score / 1000); 
        }

        public void SaveGoals(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(_score);
                foreach (var goal in _goals)
                {
                    writer.WriteLine($"{goal.GetGoalType()}|{goal.GetName()}|{goal.GetDetails()}|{goal.GetPoints()}|{goal.IsCompleted()}");
                }
            }
        }

        public void LoadGoals(string filename)
        {
            if (File.Exists(filename))
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    _score = int.Parse(reader.ReadLine());
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');
                        string goalType = parts[0];
                        string name = parts[1];
                        string description = parts[2];
                        int points = int.Parse(parts[3]);
                        bool isCompleted = bool.Parse(parts[4]);

                        Goal goal = null;
                        switch (goalType)
                        {
                            case "SimpleGoal":
                                goal = new SimpleGoal(name, description, points);
                                break;
                            case "EternalGoal":
                                goal = new EternalGoal(name, description, points);
                                break;
                            case "ChecklistGoal":
                                goal = new ChecklistGoal(name, description, points, 5, 500); 
                                break;
                            case "NegativeGoal":
                                goal = new NegativeGoal(name, description, points);
                                break;
                        }

                        if (goal != null)
                        {
                            if (isCompleted) goal.RecordEvent();
                            _goals.Add(goal);
                        }
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! This is the EternalQuest Project.\n");

            GoalManager manager = new GoalManager();

            manager.AddGoal(new SimpleGoal("Run a Marathon", "Complete a marathon", 1000));
            manager.AddGoal(new EternalGoal("Read Scriptures", "Read scriptures daily", 100));
            manager.AddGoal(new ChecklistGoal("Attend Temple", "Attend the temple 10 times", 50, 10, 500));
            manager.AddGoal(new NegativeGoal("Eat Junk Food", "Avoid eating junk food", -50));

            manager.RecordEvent("Run a Marathon");
            manager.RecordEvent("Read Scriptures");
            manager.RecordEvent("Attend Temple");
            manager.RecordEvent("Eat Junk Food");

            manager.DisplayGoals();
            manager.DisplayScore();

            manager.SaveGoals("goals.txt");
            manager.LoadGoals("goals.txt");

            manager.DisplayGoals();
            manager.DisplayScore();
        }
    }
}