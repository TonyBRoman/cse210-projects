using System;
using System.Collections.Generic;

class Program

{
    static void Main(string[] args)
    {
        Video video1 = new Video("Learn C# in 10 Minutes", "CodeAcademy", 600);
        Video video2 = new Video("What is BYU-Idaho Degree Worth?", "BYU-Idaho", 30);
        Video video3 = new Video("Introduction to Algorithms", "CS101", 1200);

        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very informative."));
        video1.AddComment(new Comment("Charlie", "Thanks for the help!"));

        video2.AddComment(new Comment("David", "Clear explanation."));
        video2.AddComment(new Comment("Eve", "Good to know!."));
        video2.AddComment(new Comment("Frank", "Awesome content!"));

        video3.AddComment(new Comment("Grace", "Excellent overview of algorithms."));
        video3.AddComment(new Comment("Hannah", "The examples were very helpful."));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
            Console.WriteLine();
        }

    }
}
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set;} 
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"- {comment.Commenter}: {comment.Text}");
        }
    }
}
class Comment
{
    public string Commenter { get; set; }
    public string Text { get; set; }

    public Comment(string commenter, string text)
    {
        Commenter = commenter;
        Text = text;
    }
}