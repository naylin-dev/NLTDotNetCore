using Microsoft.EntityFrameworkCore;
using NLTDotNetCore.NLayer.DataAccess.Models;

namespace NLTDotNetCore.NLayer.DataAccess.Db;

internal class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
    }

    public DbSet<BlogModel> Blogs { get; set; }
}