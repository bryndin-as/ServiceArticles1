using Microsoft.EntityFrameworkCore;
using ServiceArticles.Context;
using ServiceArticles.DTO;
using ServiceArticles.IRepository;
using ServiceArticles.Models;

namespace ServiceArticles.Repository;

public class CommentRepository : ICommentRepository
{
    private readonly ArticleContext _articleContext;

    public CommentRepository(
        ArticleContext articleContext)
    {
        _articleContext = articleContext;
    }
    
    public async Task<Comment> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _articleContext.Comments.FindAsync(id, cancellationToken);

        if (result is null)
            return new Comment
            {
                Text = "Нужно обрабатывать ошибки, ебобо",
                Score = 1,
                ArticleId = 1
            };

        return result;
    }

    public async Task<IList<Comment>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _articleContext.Comments.ToListAsync(cancellationToken);
    }
    
    public async Task AddAsync(CommentDto itemDto, CancellationToken cancellationToken)
    {
        var item = new Comment
        {
            Text = itemDto.Text,
            Score = itemDto.Score,
            ArticleId = itemDto.ArticleId
        };

        await _articleContext.Comments.AddAsync(item, cancellationToken);
        await _articleContext.SaveChangesAsync(cancellationToken);
    }

    public async Task AddRangeAsync(List<CommentDto> itemDtos, CancellationToken cancellationToken)
    {
        var items = itemDtos.Select(dto => new Comment
        {
            Text = dto.Text,
            Score = dto.Score,
            ArticleId = dto.ArticleId
        }).ToList();
        
        await _articleContext.Comments.AddRangeAsync(items, cancellationToken);
        await _articleContext.SaveChangesAsync(cancellationToken);
    }
}