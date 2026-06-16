using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();

        Console.WriteLine($"--- {_name} Activity ---");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Take a deep breath and prepare for a peaceful moment...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Wonderful job! You took time to care for yourself today.");

        ShowSpinner(3);

        Console.WriteLine();
        Console.WriteLine(
            $"You spent {_duration} seconds nurturing your well-being through the {_name} Activity.");

        ShowSpinner(3);

        SaveActivity();
    }

    private void SaveActivity()
    {
        using (StreamWriter output =
               new StreamWriter("mindfulness_log.txt", true))
        {
            output.WriteLine(
                $"{DateTime.Now}: {_name} - {_duration} seconds");
        }
    }

    public void ShowSpinner(int seconds)
    {
        List<string> animation = new List<string>()
        {
            "|",
            "/",
            "-",
            "\\"
        };

        DateTime futureTime = DateTime.Now.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < futureTime)
        {
            Console.Write(animation[i]);

            Thread.Sleep(250);

            Console.Write("\b \b");

            i++;

            if (i >= animation.Count)
            {
                i = 0;
            }
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);

            Thread.Sleep(1000);

            Console.Write("\b \b");
        }
    }
}