using System.Collections.Generic;
using Bislerium;

public class BlogService
{
    private readonly BloggingData _bloggingData;

    public BlogService(BloggingData bloggingData)
    {
        _bloggingData = bloggingData;
    }

    public List<Blog> GetAllBlogs()
    {
        return _bloggingData.GetAllBlogs();
    }
}