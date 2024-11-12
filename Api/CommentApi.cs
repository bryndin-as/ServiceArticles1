using ServiceArticles.DTO;
using ServiceArticles.IRepository;
using ServiceArticles.Models;

namespace ServiceArticles.Api;

public class CommentApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet("/comment", (ICommentRepository repository) =>
        {
            return Results.Ok(repository.GetAll());
        });

        app.MapGet("/comment/{id}", (ICommentRepository repository, int id) =>
        {
            return Results.Ok(repository.GetById(id));
        });

        app.MapPost("/comment", (ICommentRepository repository, CommentDto dto) =>
        {
            repository.Add(new Comment()
            {
                Text = dto.Text,
                Score = dto.Score,
                ArticleId = dto.ArticleId,
            });
    
            return Results.Ok();
        });

        app.MapPost("/comments", (ICommentRepository repository, int count) =>
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