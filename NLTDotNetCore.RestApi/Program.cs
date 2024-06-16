using Microsoft.EntityFrameworkCore;
using NLTDotNetCore.RestApi.Db;
using NLTDotNetCore.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("DbConnection")!;

// Add AppDbContext to the services with SQL Server as the database provider
builder.Services.AddDbContext<AppDbContext>(opt => { opt.UseSqlServer(connectionString); },
    ServiceLifetime.Transient,
    ServiceLifetime.Transient);

// Register AdoDotNetService for dependency injection
builder.Services.AddScoped(n => new AdoDotNetService(connectionString));

// Register DapperService for dependency injection
builder.Services.AddScoped(n => new DapperService(connectionString));

// builder.Services.AddScoped<AdoDotNetService>(n => new AdoDotNetService(connectionString));
// builder.Services.AddScoped<DapperService>(n => new DapperService(connectionString));

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

app.Run();