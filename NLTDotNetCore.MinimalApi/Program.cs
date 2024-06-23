using Microsoft.EntityFrameworkCore;
using NLTDotNetCore.MinimalApi.Db;
using NLTDotNetCore.MinimalApi.Features.Blog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(
    opt => { opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")); }, ServiceLifetime.Transient,
    ServiceLifetime.Transient);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

// BlogService.MapBlogs(app);

app.MapBlogs(); // extension method

app.Run();