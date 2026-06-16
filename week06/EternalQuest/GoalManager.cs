using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public void DisplayScore()
    {
        Console.WriteLine();
        Console.WriteLine($"You currently have {_score} points on your Eternal Quest journey.");
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

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");

            string goalType = parts[0];

            string[] data = parts[1].Split(",");

            if (goalType == "SimpleGoal")
            {
                _goals.Add(
                    new SimpleGoal(
                        data[0],
                        data[1],
                        int.Parse(data[2])));
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
                _goals.Add(
                    new ChecklistGoal(
                        data[0],
                        data[1],
                        int.Parse(data[2]),
                        int.Parse(data[4]),
                        int.Parse(data[5])));
            }
        }

        Console.WriteLine();
        Console.WriteLine("Your goals have been loaded successfully.");
    }
}