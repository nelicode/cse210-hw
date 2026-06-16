using System;

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