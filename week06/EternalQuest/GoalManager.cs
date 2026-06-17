using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    private int _level = 1;
    private List<string> _badges = new List<string>();

    public void DisplayScore()
{
    Console.WriteLine("--------------------------------");
    Console.WriteLine($"Score: {_score}");
    Console.WriteLine($"Level: {_level}");
    Console.WriteLine();

    if (_badges.Count > 0)
    {
        Console.WriteLine("Badges Earned:");

        foreach (string badge in _badges)
        {
            if (badge == "First Achievement")
            {
                Console.WriteLine("🏆 First Achievement");
            }
            else if (badge == "Goal Master")
            {
                Console.WriteLine("⭐ Goal Master");
            }
            else if (badge == "Legend")
            {
                Console.WriteLine("👑 Legend");
            }
            else
            {
                Console.WriteLine($"• {badge}");
            }
        }
    }
    else
    {
        Console.WriteLine("No badges earned yet.");
    }

    Console.WriteLine("--------------------------------");
    Console.WriteLine();
}

    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("You haven't created any goals yet.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Here are your current goals:");
        Console.WriteLine();

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }
    private void CheckLevelUp()
{
    int newLevel = (_score / 1000) + 1;

    if (newLevel > _level)
    {
        _level = newLevel;

        Console.WriteLine();
        Console.WriteLine("************************************************");
        Console.WriteLine($"LEVEL UP! You reached Level {_level}!");
        Console.WriteLine("************************************************");
    }
}

    private void CheckBadges()
{
    int completedGoals = 0;

    foreach (Goal goal in _goals)
    {
        if (goal.IsComplete())
        {
            completedGoals++;
        }
    }

    if (completedGoals >= 1 &&
        !_badges.Contains("First Achievement"))
    {
        _badges.Add("First Achievement");

        Console.WriteLine();
        Console.WriteLine("Badge Unlocked: First Achievement");
    }

    if (completedGoals >= 5 &&
        !_badges.Contains("Goal Master"))
    {
        _badges.Add("Goal Master");

        Console.WriteLine();
        Console.WriteLine("Badge Unlocked: Goal Master");
    }

    if (_score >= 5000 &&
        !_badges.Contains("Legend"))
    {
        _badges.Add("Legend");

        Console.WriteLine();
        Console.WriteLine("Badge Unlocked: Legend");
    }
}
    public void CreateGoal()
    {
        Console.WriteLine();
        Console.WriteLine("Choose the type of goal you would like to create:");
        Console.WriteLine();
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.WriteLine();
        Console.Write("Your choice: ");
        string choice = Console.ReadLine();

        Console.Write("Goal name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Points earned: ");
        int points = int.Parse(Console.ReadLine());

        if (choice == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));

            Console.WriteLine();
            Console.WriteLine("Your Simple Goal has been added successfully!");
        }

        else if (choice == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));

            Console.WriteLine();
            Console.WriteLine("Your Eternal Goal has been added successfully!");
        }

        else if (choice == "3")
        {
            Console.Write("How many times must it be completed? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus points upon completion: ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(
                new ChecklistGoal(
                    name,
                    description,
                    points,
                    target,
                    bonus));

            Console.WriteLine();
            Console.WriteLine("Your Checklist Goal has been added successfully!");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("Create a goal first before recording progress.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Which goal would you like to record today?");
        Console.WriteLine();

        ListGoals();

        Console.WriteLine();
        Console.Write("Select goal number: ");

        int choice = int.Parse(Console.ReadLine());

        int pointsEarned =
            _goals[choice - 1].RecordEvent();

        _score += pointsEarned;

        CheckLevelUp();
        CheckBadges();

        Console.WriteLine();

        if (pointsEarned > 0)
        {
            Console.WriteLine($"Wonderful work! You earned {pointsEarned} points.");
        }
        else
        {
            Console.WriteLine("This goal has already been completed.");
        }

        Console.WriteLine($"Your current score is {_score} points.");
    }

    public void SaveGoals()
    {
        Console.WriteLine();
        Console.Write("Enter a filename to save your progress: ");

        string filename = Console.ReadLine();

        using (StreamWriter output =
               new StreamWriter(filename))
        {
            output.WriteLine(_score);
            output.WriteLine(_level);
            output.WriteLine(string.Join("|", _badges));

            foreach (Goal goal in _goals)
            {
                output.WriteLine(
                    goal.GetStringRepresentation());
            }
        }

        Console.WriteLine();
        Console.WriteLine("Your progress has been saved successfully.");
    }

    public void LoadGoals()
    {
        Console.WriteLine();
        Console.Write("Enter the filename to load: ");

        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine();
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        _goals.Clear();

        _score = int.Parse(lines[0]);
        _level = int.Parse(lines[1]);

        _badges.Clear();

        if (lines[2] != "")
        {
            _badges.AddRange(lines[2].Split('|'));
        }

        for (int i = 3; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");

            string goalType = parts[0];

            string[] data = parts[1].Split(",");

            if (goalType == "SimpleGoal")
            {
                SimpleGoal goal =
                    new SimpleGoal(
                        data[0],
                        data[1],
                        int.Parse(data[2]));

                goal.SetCompleted(
                    bool.Parse(data[3]));

                _goals.Add(goal);
            }

            else if (goalType == "EternalGoal")
            {
                _goals.Add(
                    new EternalGoal(
                        data[0],
                        data[1],
                        int.Parse(data[2])));
            }

           else if (goalType == "ChecklistGoal")
            {
                ChecklistGoal goal =
                    new ChecklistGoal(
                        data[0],
                        data[1],
                        int.Parse(data[2]),
                        int.Parse(data[4]),
                        int.Parse(data[5]));

                goal.SetAmountCompleted(
                    int.Parse(data[3]));

                _goals.Add(goal);
            }
        }

        Console.WriteLine();
        Console.WriteLine("Your goals have been loaded successfully.");
    }
}