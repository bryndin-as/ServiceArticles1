using ServiceArticles.IRepository;
using ServiceArticles.Repository;

namespace ServiceArticles.Extensions;

public static class ServiceExtensions
{
    public static void RepositoryExtensions(this IServiceCollection services)
    {
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
    }
}