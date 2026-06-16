using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing",
            "This gentle breathing exercise will help you relax, slow your thoughts, and reconnect with the present moment.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime =
            DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();

            Console.Write("Slowly breathe in... ");
            ShowCountDown(4);

            Console.WriteLine();

            Console.Write("Slowly breathe out... ");
            ShowCountDown(6);

            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}