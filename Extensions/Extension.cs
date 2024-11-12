using ServiceArticles.DTO;
using ServiceArticles.IRepository;
using ServiceArticles.Models;

namespace ServiceArticles.Extensions;

public static class Extension 
{
    public static void AddMyServices(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("/article", (IArticleRepository repository ) =>
        {
            return Results.Ok((object?)repository.GetAll());
        });
        
        builder.MapGet("/article/{id}", (IArticleRepository repository, int id) =>
        {
            return Results.Ok(repository.GetById(id));
        });

        builder.MapPost("/article", (IArticleRepository repository, ArticleDto dto) =>
        { 
            repository.Add(new Article()
            {
                Title = dto.Title,
                Text = dto.Text,
            });
    
            return Results.Ok();
        });

        builder.MapPost("/articles", (IArticleRepository repository, int count) =>
        {
            var items = Enumerable.Range(1, count).Select(s => new Article()
            {
                Title = $"Article {s}",
                Text = $"Title {s}"
            }).ToList();
    
            repository.AddRange(items);
    
            return Results.Ok();
        });
        
        builder.MapGet("/comment", (ICommentRepository repository) =>
        {
            return Results.Ok(repository.GetAll());
        });

        builder.MapGet("/comment/{id}", (ICommentRepository repository, int id) =>
        {
            return Results.Ok(repository.GetById(id));
        });

        builder.MapPost("/comment", (ICommentRepository repository, CommentDto dto) =>
        {
            repository.Add(new Comment()
            {
                Text = dto.Text,
                Score = dto.Score,
                ArticleId = dto.ArticleId,
            });
    
            return Results.Ok();
        });

        builder.MapPost("/comments", (ICommentRepository repository, int count) =>
        {
            var items = Enumerable.Range(1, count).Select(s => new Comment()
            {
                Text = $"Comment {s}",
                Score = new Random().Next(1, 100),
                ArticleId = new Random().Next(1, 5),
        
            }).ToList();
            repository.AddRange(items);
            return Results.Ok();
        });
    }
}