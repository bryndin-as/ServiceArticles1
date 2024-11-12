using ServiceArticles.Controllers;
using ServiceArticles.Models;

namespace ServiceArticles.Extensions;

public static class ApiExtension 
{
    public static void UseArticleApi(this IEndpointRouteBuilder endpoint)
    {
        endpoint.MapGet("/article/{id}", ArticleController.ArticleGetByIdAsync)
            .WithTags("Article")
            .Produces<Article>();
        
        endpoint.MapGet("/article", ArticleController.ArticleGetAllAsync)
            .WithTags("Article")
            .Produces<List<Article>>();
        
        endpoint.MapPost("/article", ArticleController.ArticleAddAsync)
            .WithTags("Article")
            .Produces<List<Article>>();
        
        endpoint.MapPost("/articles", ArticleController.ArticleAddRangeAsync)
            .WithTags("Article")
            .Produces<List<Article>>();
    }
    
    public static void UseCommentApi(this IEndpointRouteBuilder endpoint)
    {
        endpoint.MapGet("/comment/{id}", CommentController.CommentGetByIdAsync)
            .WithTags("Comment")
            .Produces<Comment>();
        
        endpoint.MapGet("/comment", CommentController.CommentGetAllAsync)
            .WithTags("Comment")
            .Produces<List<Comment>>();
        
        endpoint.MapPost("/comment", CommentController.CommentAddAsync)
            .WithTags("Comment")
            .Produces<List<Comment>>();
        
        endpoint.MapPost("/comments", CommentController.CommentAddRangeAsync)
            .WithTags("Comment")
            .Produces<List<Comment>>();
    }
}