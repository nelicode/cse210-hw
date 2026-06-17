using System;

/*
Creativity Beyond Requirements

For this project, I added several features beyond the core requirements to make the Eternal Quest program more engaging, motivating, and rewarding for users.

I personalized many of the messages throughout the program so the experience feels warm, encouraging, and supportive while users work toward their goals.
The current score is displayed directly in the menu, allowing users to easily monitor their progress at any time.
Goals and scores can be saved and loaded from a file, enabling users to continue their progress across multiple sessions.
Checklist goals track completion progress and award bonus points when the target number of completions is reached, creating an additional sense of accomplishment.
I implemented a Level System where users automatically gain a new level every 1000 points earned. This adds long-term progression and encourages continued participation.
I added Achievement Badges that unlock when users reach important milestones, such as completing goals or earning a large number of points. These badges provide additional motivation and a sense of achievement.
Levels and badges are also saved and loaded with the rest of the user's data so that all progress persists between sessions.

These enhancements introduce gamification elements that make the program more interactive and enjoyable while further demonstrating the use of abstraction, encapsulation, inheritance, polymorphism, file persistence, and object-oriented design principles.
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