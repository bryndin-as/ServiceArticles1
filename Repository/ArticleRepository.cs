using Microsoft.EntityFrameworkCore;
using ServiceArticles.Context;
using ServiceArticles.IRepository;
using ServiceArticles.Models;

namespace ServiceArticles.Repository;

public class ArticleRepository : IArticleRepository 
{
    private readonly ArticleContext _articleContext;

    public ArticleRepository(
        ArticleContext articleContext)
    {
        _articleContext = articleContext;
    }
    
    public async Task<Article> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _articleContext.Articles.FindAsync(id, cancellationToken);

        if (result is null)
            return new Article
            {
                Title = "Нужно обрабатывать ошибки, ебобо",
                Text = "Нужно обрабатывать ошибки, ебобо"
            };

        return result;
    }

    public async Task<IList<Article>> GetAllAsync(CancellationToken cancellationToken)
    {
         return await _articleContext.Articles.ToListAsync(cancellationToken);
    }

    public async Task AddAsync(ArticleDto itemDto, CancellationToken cancellationToken)
    {
        var item = new Article
        {
            Title = itemDto.Title,
            Text = itemDto.Text,
        };

        await _articleContext.Articles.AddAsync(item, cancellationToken);
        await _articleContext.SaveChangesAsync(cancellationToken);  
    }

    public async Task AddRangeAsync(List<ArticleDto> itemDtos, CancellationToken cancellationToken)
    {
        var items = itemDtos.Select(dto => new Article
        {
            Title = dto.Title,
            Text = dto.Text
        }).ToList();
        
        await _articleContext.Articles.AddRangeAsync(items, cancellationToken);
        await _articleContext.SaveChangesAsync(cancellationToken);
    }
}