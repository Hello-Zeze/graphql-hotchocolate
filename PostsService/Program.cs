using Microsoft.EntityFrameworkCore;
using PostsService.Data;
using PostsService.Schema;

var builder = WebApplication.CreateBuilder(args);
var policyName = "corsapp";

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data Source=posts_service.db"));

builder.Services
        .AddGraphQLServer()
        .AddQueryType<Query>()
        .AddMutationType<Mutation>();

builder.Services.AddCors(p => p.AddPolicy(policyName, builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

app.UseCors(policyName);

app.UseHttpsRedirection();

app.MapGraphQL();

app.Run();
