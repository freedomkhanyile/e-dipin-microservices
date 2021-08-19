using System;

public class Post
{
    public string Id { get; set; }

    public string Type { get; set; }
    
    public string Description { get; set; }

    public int UserId { get; set; }    

    public DateTime CreateDate { get; set; }

    public int CommentCount{ get; set; }

    public int InteractionCount { get; set; }

}