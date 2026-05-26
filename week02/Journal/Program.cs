using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");

            Console.Write("Select a choice from the menu: ");

            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
        {
            string prompt = promptGenerator.GetRandomPrompt();

            Console.WriteLine();
            Console.WriteLine("Take your time and keep writing :)");
            Console.WriteLine();

            Console.WriteLine(prompt);
            Console.Write("> ");

            string answer = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Amazing! Keep expressing your thoughts :)");
            Console.WriteLine();

            DateTime currentTime = DateTime.Now;

            Entry entry = new Entry();

            entry._date = currentTime.ToShortDateString();
            entry._promptText = prompt;
            entry._entryText = answer;

            journal.AddEntry(entry);

            Console.WriteLine("Thank you for sharing your experience today. You did excellent 🌟");
            Console.WriteLine();
        }

            else if (choice == 2)
            {
                journal.DisplayAll();
            }

            else if (choice == 3)
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();

                journal.SaveToFile(filename);
            }

            else if (choice == 4)
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();

                journal.LoadFromFile(filename);
            }

            else if (choice == 5)
            {
                Console.WriteLine("Goodbye!");
            }
        }
    }
}