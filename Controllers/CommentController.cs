using ServiceArticles.DTO;
using ServiceArticles.IRepository;

namespace ServiceArticles.Controllers;

public static class CommentController
{
    public static async Task<IResult> CommentGetByIdAsync(
        ICommentRepository repository,
        int id,
        CancellationToken cancellationToken)
    {
        var result = await repository.GetByIdAsync(id, cancellationToken);
        return Results.Ok(result);
    }
    
    public static async Task<IResult> CommentGetAllAsync(
        ICommentRepository repository,
        CancellationToken cancellationToken)
    {
        var result = await repository.GetAllAsync(cancellationToken);
        return Results.Ok(result);
    }
    
    public static async Task<IResult> CommentAddAsync(
        ICommentRepository repository,
        CommentDto itemDto,
        CancellationToken cancellationToken)
    {
        await repository.AddAsync(itemDto, cancellationToken);
        return Results.Ok("Все по кайфу");
    }
    
    public static async Task<IResult> CommentAddRangeAsync(
        ICommentRepository repository,
        List<CommentDto> itemDtos,
        CancellationToken cancellationToken)
    {
        await repository.AddRangeAsync(itemDtos, cancellationToken);
        return Results.Ok("Все по кайфу");
    }
}