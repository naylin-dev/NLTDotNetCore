using Microsoft.EntityFrameworkCore;
using NLTDotNetCore.MvcApp2.Models;

namespace NLTDotNetCore.MvcApp2.Db;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
    // }

    public DbSet<BlogModel> Blogs { get; set; }
}