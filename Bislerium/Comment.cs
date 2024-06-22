using System;

public class Comment
{
    public int CommentID { get; private set; }
    public int UserID { get; set; }
    public int PostID { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; private set; }

    public Comment(int userID, int postID, string content)
    {
        UserID = userID;
        PostID = postID;
        Content = content;
        CreatedAt = DateTime.Now;
    }

    public void SetCommentID(int commentID)
    {
        CommentID = commentID;
    }
}