using Microsoft.EntityFrameworkCore;

namespace NLTDotNetCore.ConsoleApp;

internal class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
    }

    public DbSet<BlogDto> Blogs { get; set; }
}