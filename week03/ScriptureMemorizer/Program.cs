using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
    

        List<Scripture> scriptures = new List<Scripture>();

        scriptures.Add(
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son"
            )
        );

        scriptures.Add(
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding In all thy ways acknowledge him and he shall direct thy paths"
            )
        );

        scriptures.Add(
            new Scripture(
                new Reference("Articles of Faith", 1, 13),
                "We believe in being honest true chaste benevolent virtuous and in doing good to all men"
            )
        );

        Random random = new Random();

        int index = random.Next(scriptures.Count);

        Scripture scripture = scriptures[index];

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine();
            Console.WriteLine("Press Enter to continue or type quit to finish:");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());

        Console.WriteLine();
        Console.WriteLine("Program finished.");
    }
}