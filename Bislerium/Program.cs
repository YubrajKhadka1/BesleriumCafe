using System;
using System.Collections.Generic;
using Bislerium;


namespace Bislerium
{
    class Program
    {
        static void Main(string[] args)
        {
            BloggingData bloggingData = new BloggingData();
            BlogService blogService = new BlogService(bloggingData);

            List<Blog> blogs = blogService.GetAllBlogs();

            foreach (Blog blog in blogs)
            {
                Console.WriteLine($"Blog ID: {blog.BlogId}");
                Console.WriteLine($"Title: {blog.Title}");
                Console.WriteLine($"Content: {blog.Content}");
                Console.WriteLine($"Created At: {blog.CreatedAt}");
                Console.WriteLine($"Image URL: {blog.ImageUrl}");
                Console.WriteLine();
            }
        }
    }
}