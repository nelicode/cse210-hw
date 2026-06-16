using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time you stood up for someone.",
        "Think of a time you did something difficult.",
        "Think of a time you helped someone.",
        "Think of a time you acted selflessly."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this meaningful to you?",
        "Have you ever done something like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What did you learn about yourself?",
        "What made this experience special?",
        "What lessons can you apply in the future?"
    };

    public ReflectingActivity()
        : base(
            "Reflecting",
            "Reflect on times when you showed strength and resilience.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Random random = new Random();

        Console.WriteLine();
        Console.WriteLine("Take a moment to think about the following experience:");
        Console.WriteLine();

        Console.WriteLine(
            _prompts[random.Next(_prompts.Count)]);

        Console.WriteLine();
        Console.WriteLine(
            "Allow yourself to thoughtfully reflect on each question.");

        ShowSpinner(5);

        List<string> availableQuestions =
            new List<string>(_questions);

        DateTime endTime =
            DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            if (availableQuestions.Count == 0)
            {
                availableQuestions =
                    new List<string>(_questions);
            }

            int index =
                random.Next(availableQuestions.Count);

            string question =
                availableQuestions[index];

            availableQuestions.RemoveAt(index);

            Console.WriteLine();
            Console.Write($"> {question}");

            ShowSpinner(5);
        }

        DisplayEndingMessage();
    }
}