using Microsoft.AspNetCore.Cors.Infrastructure;
using PhotonBeam.Hubs;

var builder = WebApplication.CreateBuilder(args);

var corsPolicy = "CORS_POLICY";
var allowedOrigins = "http://localhost:3002";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicy, policy =>
    {
        policy
            .WithOrigins(allowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(corsPolicy);

app.MapHub<UserHub>("/hubs/userCount").RequireCors(builder =>
{
    builder
        .WithOrigins(allowedOrigins)
        .AllowAnyHeader()
        .AllowCredentials()
        .WithMethods("HEAD", "OPTIONS", "GET", "POST");
});

app.Run();
