using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people you appreciate?",
        "What are your personal strengths?",
        "Who have you helped this week?",
        "Who are your heroes?",
        "What blessings have you received recently?"
    };

    public ListingActivity()
        : base(
            "Listing",
            "List as many positive things as you can.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Random random = new Random();

        Console.WriteLine();
        Console.WriteLine("Take a moment to think about the following question:");
        Console.WriteLine();

        Console.WriteLine(
            _prompts[random.Next(_prompts.Count)]);

        Console.WriteLine();

        Console.WriteLine(
            "Take a few seconds to gather your thoughts...");

        ShowCountDown(5);

        Console.WriteLine();

        int count = 0;

        DateTime endTime =
            DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine();
        Console.WriteLine(
            $"Wonderful! You identified {count} meaningful items.");

        DisplayEndingMessage();
    }
}