using System;

public class Reaction
{
    public int ReactionID { get; private set; }
    public int UserID { get; set; }
    public int PostID { get; set; }
    public string Type { get; set; }
    public DateTime CreatedAt { get; private set; }

    public Reaction(int userID, int postID, string type)
    {
        UserID = userID;
        PostID = postID;
        Type = type;
        CreatedAt = DateTime.Now;
    }

    public void SetReactionID(int reactionID)
    {
        ReactionID = reactionID;
    }
}