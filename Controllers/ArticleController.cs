using ServiceArticles.IRepository;

namespace ServiceArticles.Controllers;

public static class ArticleController
{
    public static async Task<IResult> ArticleGetByIdAsync(
        IArticleRepository repository,
        int id,
        CancellationToken cancellationToken)
    {
        var result = await repository.GetByIdAsync(id, cancellationToken);
        return Results.Ok(result);
    }
    
    public static async Task<IResult> ArticleGetAllAsync(
        IArticleRepository repository,
        CancellationToken cancellationToken)
    {
        var result = await repository.GetAllAsync(cancellationToken);
        return Results.Ok(result);
    }
    
    public static async Task<IResult> ArticleAddAsync(
        IArticleRepository repository,
        ArticleDto itemDto,
        CancellationToken cancellationToken)
    {
        await repository.AddAsync(itemDto, cancellationToken);
        return Results.Ok("Все по кайфу");
    }
    
    public static async Task<IResult> ArticleAddRangeAsync(
        IArticleRepository repository,
        List<ArticleDto> itemDtos,
        CancellationToken cancellationToken)
    {
        await repository.AddRangeAsync(itemDtos, cancellationToken);
        return Results.Ok("Все по кайфу");
    }
}