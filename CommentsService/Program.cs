using CommentsService.Data;
using CommentsService.Schema;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var allowedOrigins = "AllowedOrigins";

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data Source=comments_service.db"));

builder.Services
        .AddGraphQLServer()
        .AddQueryType<Query>()
        .AddMutationType<Mutation>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedOrigins, policy =>
    {
        policy
            .WithOrigins("*")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors(allowedOrigins);

app.UseHttpsRedirection();

app.MapGraphQL();

app.Run();
