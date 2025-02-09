using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        
        var video1 = new Video("Learning C#", "Alice", 300);
        video1.AddComment(new Comment("Bob", "Great tutorial!"));
        video1.AddComment(new Comment("Charlie", "Very helpful, thanks."));
        video1.AddComment(new Comment("David", "Looking forward to more videos."));

        var video2 = new Video("Mastering Python", "Eve", 400);
        video2.AddComment(new Comment("Frank", "Excellent content!"));
        video2.AddComment(new Comment("Grace", "I learned a lot from this."));
        video2.AddComment(new Comment("Heidi", "Can't wait for the next one!"));

        var video3 = new Video("Java Basics", "Henry", 250);
        video3.AddComment(new Comment("Ivan", "Nice explanation."));
        video3.AddComment(new Comment("Judy", "Very clear and concise."));
        
        List<Video> videos = new List<Video> { video1, video2, video3 };

        
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Duration: {video.DurationInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Author}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}

public class Comment
{
    public string Author { get; set; }
    public string Text { get; set; }

    public Comment(string author, string text)
    {
        Author = author;
        Text = text;
    }
}

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int DurationInSeconds { get; set; }
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int durationInSeconds)
    {
        Title = title;
        Author = author;
        DurationInSeconds = durationInSeconds;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public List<Comment> GetComments()
    {
        return Comments;
    }
}