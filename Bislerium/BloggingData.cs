using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Bislerium;

public class BloggingData
{
    private const string ConnectionString = "Data Source=MARK1\\SQLEXPRESS;Initial Catalog=Coffeeblog;User ID=sa;Password=admin1234;";

    public List<Blog> GetAllBlogs()
    {
        var blogs = new List<Blog>();

        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            string query = "SELECT BlogId, Title, Content, CreatedAt, ImageUrl FROM BlogPosts";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int blogId = reader.GetInt32(0);
                    string title = reader.GetString(1);
                    string content = reader.GetString(2);
                    DateTime createdAt = reader.GetDateTime(3);
                    string imageUrl = reader.IsDBNull(4) ? null : reader.GetString(4);

                    Blog blog = new Blog(blogId, title, content, createdAt, imageUrl);
                    blogs.Add(blog);
                }

                connection.Close();
            }
        }

        return blogs;
    }
}