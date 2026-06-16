using System;
class Program
{
    static void Main(string[] args)
    {
        GoalManager manager =
            new GoalManager();

        string choice = "";

        while (choice != "6")
        {
            Console.Clear();

            Console.WriteLine("Eternal Quest");
            Console.WriteLine("══════════════════════════════");

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
            Console.Write("✨ Please select an option: ");

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