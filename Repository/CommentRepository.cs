using ServiceArticles.Context;
using ServiceArticles.IRepository;
using ServiceArticles.Models;

namespace ServiceArticles.Repository;

public class CommentRepository : ICommentRepository
{
    private readonly ArticleContext _articleContext;

    public CommentRepository(ArticleContext articleContext)
    {
        _articleContext = articleContext;
    }
    
    public Comment GetById(int id)
    {
        return _articleContext.Comments.Find(id);
    }

    public IList<Comment> GetAll()
    {
        return _articleContext.Comments.ToList();
    }

    public void Add(Comment item)
    {
        _articleContext.Comments.Add(item);
        _articleContext.SaveChanges();
    }

    public void AddRange(IList<Comment> items)
    {
        _articleContext.Comments.AddRange(items);
        _articleContext.SaveChanges();
    }
}