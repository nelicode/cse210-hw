using System;
/*
Creativity Beyond Requirements

To improve my program beyond the basic requirements, I added a few extra features.

First, I added a counter that keeps track of how many activities the user completes during the session and displays that information in the menu.

Second, I created a log file called "mindfulness_log.txt" where completed activities are saved. 
This allows the user to keep a record of their mindfulness practice.

Third, in the Reflection Activity, I made sure that reflection questions do not repeat until all available questions have been used.
I felt this would make the activity more meaningful and less repetitive for the user.
*/
class Program
{
    private static int _activitiesCompleted = 0;

    static void Main(string[] args)
    {
        string choice = "";

        while (choice != "4")
        {
            Console.Clear();

            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine();

            Console.WriteLine(
                $"Activities Completed: {_activitiesCompleted}");

            Console.WriteLine();
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");

            Console.WriteLine();

            Console.Write("Select a choice: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity activity =
                    new BreathingActivity();

                activity.Run();

                _activitiesCompleted++;
            }
            else if (choice == "2")
            {
                ReflectingActivity activity =
                    new ReflectingActivity();

                activity.Run();

                _activitiesCompleted++;
            }
            else if (choice == "3")
            {
                ListingActivity activity =
                    new ListingActivity();

                activity.Run();

                _activitiesCompleted++;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Thank you for using the Mindfulness Program!");
    }
}