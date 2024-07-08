// See https://aka.ms/new-console-template for more information
using System;
using System.Linq;
using EFGetStarted.Models;
using Microsoft.EntityFrameworkCore;

using var db = new BlogContext();

Console.WriteLine($"Database path: {db.DbPath}.");

//Create
Console.WriteLine("Inserting a new blog");
db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
db.SaveChanges();

//Read
Console.WriteLine("Quereying for blog");
var blog = db.Blogs.OrderBy(b => b.BlogId).First();

//Update
Console.WriteLine("Updating the blog and adding a post");
blog.Url = "https://devblogs.microsoft.com/dotnet";
blog.Posts.Add(new Post
{
    Title = "Hello World",
    Content = " I worte an app using EntityFrameworkCore"
});
db.SaveChanges();

//Delete
Console.WriteLine("Delete a blog");
db.Remove(blog);
db.SaveChanges();