using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


public class QuackContext : DbContext
{
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public string DbPath { get; }

    public QuackContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "quack.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
public class Review
{
    public int ReviewId { get; set; }
    public string Body { get; set; }

    public List<Comment> Comments { get; } = new();
}

public class Comment
{
    public int CommentId { get; set; }
    public string Author { get; set; }
    public string Content { get; set; }

    public int ReviewId { get; set; }
    public Review Review { get; set; }
}