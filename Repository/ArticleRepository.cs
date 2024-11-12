using Microsoft.EntityFrameworkCore;
using ServiceArticles.Context;
using ServiceArticles.IRepository;
using ServiceArticles.Models;

namespace ServiceArticles.Repository;

public class ArticleRepository : IArticleRepository 
{
    private readonly ArticleContext _articleContext;

    public ArticleRepository(ArticleContext articleContext)
    {
        _articleContext = articleContext;
    }
    
    public Article GetById(int id)
    {
        return _articleContext.Articles.Find(id);
    }

    public IList<Article> GetAll()
    {
         return _articleContext.Articles.ToList();
    }

    public void Add(Article item)
    {
        _articleContext.Articles.Add(item);
        _articleContext.SaveChanges();  
    }

    public void AddRange(IList<Article> items)
    {
        _articleContext.Articles.AddRange(items);
        _articleContext.SaveChanges();
    }
}