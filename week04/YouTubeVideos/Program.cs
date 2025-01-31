using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();
        
        // Creating videos
        Video video1 = new Video("C# Basics", "Tech Guru", 600);
        video1.AddComment("Alice", "Great explanation!");
        video1.AddComment("Bob", "Very helpful, thanks!");
        video1.AddComment("Charlie", "Loved the examples.");
        
        Video video2 = new Video("Advanced C#", "Code Master", 1200);
        video2.AddComment("Dave", "This was insightful!");
        video2.AddComment("Emma", "Can you cover more topics?");
        video2.AddComment("Frank", "Really detailed and clear.");
        
        Video video3 = new Video("LINQ Tutorial", "Dev Mentor", 800);
        video3.AddComment("Grace", "Best LINQ tutorial I have seen.");
        video3.AddComment("Henry", "Nice work, keep it up!");
        video3.AddComment("Ivy", "I finally understand LINQ now.");
        
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        
        // Display video details
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}
