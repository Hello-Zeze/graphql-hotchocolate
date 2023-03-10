using Gateway.Stitching.Schema;

var builder = WebApplication.CreateBuilder(args);
var commentsServiceUrl = "https://localhost:7083/graphql";
var postsServiceUrl = "https://localhost:7103/graphql";
var usersServiceUrl = "https://localhost:7231/graphql";

builder.Services
        .AddGraphQLServer()
        .AddRemoteSchema(WellKnownSchemaNames.Posts)
        .AddRemoteSchema(WellKnownSchemaNames.Users)
        .AddRemoteSchema(WellKnownSchemaNames.Comments)
        .AddTypeExtensionsFromFile("./Stitching.graphql");

builder.Services.AddHttpClient(WellKnownSchemaNames.Posts, c => c.BaseAddress = new Uri(postsServiceUrl));
builder.Services.AddHttpClient(WellKnownSchemaNames.Comments, c => c.BaseAddress = new Uri(commentsServiceUrl));
builder.Services.AddHttpClient(WellKnownSchemaNames.Users, c => c.BaseAddress = new Uri(usersServiceUrl));

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGraphQL();

app.Run();
