using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();


        Video video1 = new Video();
        video1._title = "Doing my first show with my friend";
        video1._author = "Programming Academy";
        video1._length = 600;

        video1._comments.Add(
            new Comment("Nelida", "Amazing video, please do it more")
        );

        video1._comments.Add(
            new Comment("Rocio", "Thanks for sharing.")
        );

        video1._comments.Add(
            new Comment("Ana", "I learned a lot, I love your video.")
        );

        videos.Add(video1);


        Video video2 = new Video();
        video2._title = "Learning English for Medical Interpreters";
        video2._author = "Language Academy";
        video2._length = 850;

        video2._comments.Add(
            new Comment("Pedro", "Excellent explanation.")
        );

        video2._comments.Add(
            new Comment("Lucia", "Thank you, I really needed it.")
        );

        video2._comments.Add(
            new Comment("Miguel", "This helped me understand.")
        );

        videos.Add(video2);


        Video video3 = new Video();
        video3._title = "Understanding Abstraction";
        video3._author = "Tech by Nelida";
        video3._length = 720;

        video3._comments.Add(
            new Comment("Sofia", "Great lesson!")
        );

        video3._comments.Add(
            new Comment("Daniel", "Simple and easy to follow.")
        );

        video3._comments.Add(
            new Comment("Valeria", "Thank you for this video.")
        );

        videos.Add(video3);


        foreach (Video video in videos)
        {
            Console.WriteLine("------------------------------------");

            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._length} seconds");

            Console.WriteLine(
                $"Number of Comments: {video.GetNumberOfComments()}"
            );

            Console.WriteLine();

            foreach (Comment comment in video._comments)
            {
                Console.WriteLine(
                    $"{comment._commenterName}: {comment._commentText}"
                );
            }

            Console.WriteLine();
        }
    }
}