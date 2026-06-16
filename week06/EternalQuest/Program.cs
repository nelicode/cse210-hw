using System;

/*
Creativity Beyond Requirements

For this project, I added a few extra features to make the program more meaningful and encouraging for the user.

1. I personalized many of the messages so the program feels warm, friendly, and motivating while working toward goals.

2. The current score is displayed in the menu, making it easy to track progress at any time.

3. Goals and score can be saved and loaded, allowing the user to continue their progress across different sessions.

4. Checklist goals keep track of progress and provide bonus points when completed, creating an additional sense of achievement.

These additions help make the Eternal Quest experience more enjoyable while still following the principles of abstraction, encapsulation,
inheritance, and polymorphism.
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        string choice = "";

        while (choice != "6")
        {
            Console.Clear();

            Console.WriteLine("Eternal Quest");
            Console.WriteLine("------------------------------");

            manager.DisplayScore();

            Console.WriteLine("Menu");
            Console.WriteLine();
            Console.WriteLine("1. Create a New Goal");
            Console.WriteLine("2. View My Goals");
            Console.WriteLine("3. Save My Progress");
            Console.WriteLine("4. Load My Progress");
            Console.WriteLine("5. Record an Accomplishment");
            Console.WriteLine("6. Exit");

            Console.WriteLine();
            Console.Write("Please select an option: ");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.CreateGoal();
                    break;

                case "2":
                    manager.ListGoals();
                    break;

                case "3":
                    manager.SaveGoals();
                    break;

                case "4":
                    manager.LoadGoals();
                    break;

                case "5":
                    manager.RecordEvent();
                    break;

                case "6":
                    Console.WriteLine();
                    Console.WriteLine("Thank you for spending time on your Eternal Quest today.");
                    Console.WriteLine("Every small step brings you closer to your goals.");
                    Console.WriteLine("Keep believing in yourself and never stop growing.");
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Please choose a valid option.");
                    break;
            }

            if (choice != "6")
            {
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}