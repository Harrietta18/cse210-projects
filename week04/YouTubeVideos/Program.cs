using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos and store them in a list
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Learning C# Basics", "Code Academy", 600);
        video1.AddComment(new Comment("Alice", "This was so helpful, thank you!"));
        video1.AddComment(new Comment("Bob", "Great explanation of classes."));
        video1.AddComment(new Comment("Charlie", "Can you make one about loops?"));
        videos.Add(video1);

        Video video2 = new Video("Cooking the Perfect Pasta", "Chef Maria", 480);
        video2.AddComment(new Comment("Diana", "Tried this recipe and it was amazing."));
        video2.AddComment(new Comment("Ethan", "How long do I boil the noodles?"));
        video2.AddComment(new Comment("Fiona", "My family loved it!"));
        videos.Add(video2);

        Video video3 = new Video("Travel Vlog: Visiting Japan", "Wander With Jake", 900);
        video3.AddComment(new Comment("George", "Adding this to my bucket list."));
        video3.AddComment(new Comment("Hannah", "The food looks incredible."));
        video3.AddComment(new Comment("Ian", "What month did you visit?"));
        videos.Add(video3);

        // Display each video's details and comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetCommenterName()}: {comment.GetCommentText()}");
            }

            Console.WriteLine(new string('-', 50));
            Console.WriteLine();
        }
    }
}