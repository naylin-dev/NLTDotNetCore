using Microsoft.EntityFrameworkCore;
using NLTDotNetCore.ConsoleApp.Dtos;
using NLTDotNetCore.ConsoleApp.Services;

namespace NLTDotNetCore.ConsoleApp.EFCoreExamples;

internal class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
    }

    public DbSet<BlogDto> Blogs { get; set; }
}