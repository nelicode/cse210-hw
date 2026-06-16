using System;
/*
Creativity Beyond Requirements

I added a few extra features to improve the program:

1. The program keeps track of how many activities the user has completed
   during the session and displays that number in the menu.

2. Every completed activity is saved in a file called
   mindfulness_log.txt so the user can see a history of their practice.

3. Reflection questions are not repeated until all questions have been used,
   making the activity more interesting and meaningful.
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