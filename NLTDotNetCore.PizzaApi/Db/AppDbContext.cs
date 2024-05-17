using Microsoft.EntityFrameworkCore;
using NLTDotNetCore.PizzaApi.Models.Pizza;

namespace NLTDotNetCore.PizzaApi.Db;

internal class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
    }

    public DbSet<PizzaModel> Pizzas { get; set; }
    public DbSet<PizzaExtraModel> PizzaExtras { get; set; }

    public DbSet<PizzaOrderModel> PizzaOrders { get; set; }

    public DbSet<PizzaOrderDetailModel> PizzaOrderDetails { get; set; }
}