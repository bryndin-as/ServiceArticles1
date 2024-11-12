using ServiceArticles.Context;
using Microsoft.EntityFrameworkCore;using ServiceArticles.Api;
using ServiceArticles.DTO;
using ServiceArticles.Extensions;
using ServiceArticles.IRepository;
using ServiceArticles.Models;
using ServiceArticles.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddTransient<IApi, ArticleApi>();
builder.Services.AddTransient<IApi, CommentApi>();


builder.Services.AddDbContext<ArticleContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DockerConnection");
    options.UseNpgsql(connectionString);
});

var app = builder.Build();

//Update db
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ArticleContext>();
    if (context.Database.GetPendingMigrations().Any())
        context.Database.Migrate();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.AddMyServices();

var apis = app.Services.GetServices<IApi>();
foreach (var api in apis)
{
    if(api is null) throw new InvalidProgramException("Api is null");
    api.Register(app);
}

// app.MapGet("/article", (IArticleRepository repository ) =>
// {
//      return Results.Ok((object?)repository.GetAll());
// });
//
// app.MapGet("/article/{id}", (IArticleRepository repository, int id) =>
// {
//     return Results.Ok(repository.GetById(id));
// });
//
// app.MapPost("/article", (IArticleRepository repository, ArticleDto dto) =>
// { 
//     repository.Add(new Article()
//     {
//         Title = dto.Title,
//         Text = dto.Text,
//     });
//     
//     return Results.Ok();
// });
//
// app.MapPost("/articles", (IArticleRepository repository, int count) =>
// {
//     var items = Enumerable.Range(1, count).Select(s => new Article()
//     {
//         Title = $"Article {s}",
//         Text = $"Title {s}"
//     }).ToList();
//     
//     repository.AddRange(items);
//     
//     return Results.Ok();
// });





// app.MapGet("/comment", (ICommentRepository repository) =>
// {
//     return Results.Ok(repository.GetAll());
// });
//
// app.MapGet("/comment/{id}", (ICommentRepository repository, int id) =>
// {
//     return Results.Ok(repository.GetById(id));
// });
//
// app.MapPost("/comment", (ICommentRepository repository, CommentDto dto) =>
// {
//     repository.Add(new Comment()
//     {
//         Text = dto.Text,
//         Score = dto.Score,
//         ArticleId = dto.ArticleId,
//     });
//     
//     return Results.Ok();
// });
//
// app.MapPost("/comments", (ICommentRepository repository, int count) =>
// {
//     var items = Enumerable.Range(1, count).Select(s => new Comment()
//     {
//         Text = $"Comment {s}",
//         Score = new Random().Next(1, 100),
//         ArticleId = new Random().Next(1, 5),
//         
//     }).ToList();
//     repository.AddRange(items);
//     return Results.Ok();
// });

app.Run();

