using Microsoft.EntityFrameworkCore;
using ServiceArticles.Context;
using ServiceArticles.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RepositoryExtensions();

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

app.UseArticleApi();
app.UseCommentApi();

app.Run();