using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("Intro to C#", "Code Academy", 300);
        video1.AddComment(new Comment("Alice", "Great intro, very helpful!"));
        video1.AddComment(new Comment("Bob", "Loved the pace of the tutorial."));
        video1.AddComment(new Comment("Charlie", "Can you explain more about classes?"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Learn LINQ in 10 Minutes", "Dev Pro", 600);
        video2.AddComment(new Comment("Diana", "Awesome content!"));
        video2.AddComment(new Comment("Eric", "This really saved me for my project."));
        video2.AddComment(new Comment("Frank", "I wish I knew this earlier."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("C# Abstraction Explained", "Tech Simplified", 420);
        video3.AddComment(new Comment("Grace", "Abstraction makes sense now!"));
        video3.AddComment(new Comment("Henry", "Nice explanation."));
        video3.AddComment(new Comment("Isla", "Waiting for the next part."));
        videos.Add(video3);

        // Display videos and comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}
