namespace ServiceArticles.Models;

public class Comment
{
    public int Id { get; set; } 
    public string Text { get; set; } = string.Empty;
    public decimal  Score { get; set; }
    public int ArticleId { get; set; }
    public Article Article { get; set; } = default!;
}