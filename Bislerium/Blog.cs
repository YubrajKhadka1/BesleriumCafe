using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bislerium
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ImageUrl { get; set; }

        public Blog(int blogId, string title, string content, DateTime createdAt, string imageUrl)
        {
            BlogId = blogId;
            Title = title;
            Content = content;
            CreatedAt = createdAt;
            ImageUrl = imageUrl;
        }
    }
}