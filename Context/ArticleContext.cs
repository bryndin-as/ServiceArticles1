using Microsoft.EntityFrameworkCore;
using ServiceArticles.Models;

namespace ServiceArticles.Context;

public class ArticleContext : DbContext
{
    public DbSet<Article> Articles { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public ArticleContext(DbContextOptions<ArticleContext> options) : base(options)
    {
        
    }
}