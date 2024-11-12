using ServiceArticles.IRepository;
using ServiceArticles.Models;

namespace ServiceArticles.Api;

public class ArticleApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet("/article", (IArticleRepository repository) =>
        {
            return Results.Ok((object?)repository.GetAll()); 
            
        });

        app.MapGet("/article/{id}",(IArticleRepository repository, int id) =>
        {
            return Results.Ok(repository.GetById(id)); 
        });

        app.MapPost("/article", (IArticleRepository repository, ArticleDto dto) =>
        {
            repository.Add(new Article()
            {
                Title = dto.Title,
                Text = dto.Text,
            });

            return Results.Ok();
        });

        app.MapPost("/articles", (IArticleRepository repository, int count) =>
        {
            var items = Enumerable.Range(1, count).Select(s => new Article()
            {
                Title = $"Article {s}",
                Text = $"Title {s}"
            }).ToList();

            repository.AddRange(items);

            return Results.Ok();
        });
    }
}