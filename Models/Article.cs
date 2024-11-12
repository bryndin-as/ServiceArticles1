namespace ServiceArticles.Models;

public class Article
{
    public int Id { get; set; } 
    public string Title { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public List<Comment> Comments { get; set; } = new();
}