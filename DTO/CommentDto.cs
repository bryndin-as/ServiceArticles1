namespace ServiceArticles.DTO;

public class CommentDto
{
    public string Text { get; set; } = string.Empty;
    public decimal Score { get; set; }
    public int ArticleId { get; set; }  
}