using Microsoft.EntityFrameworkCore;
using NLTDotNetCore.ConsoleApp.Dtos;

namespace NLTDotNetCore.ConsoleApp.EFCoreExamples;

public class AppDbContext : DbContext
{
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
    // }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<BlogDto> Blogs { get; set; }
}