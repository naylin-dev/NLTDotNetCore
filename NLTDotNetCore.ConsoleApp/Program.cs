using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NLTDotNetCore.ConsoleApp.AdoDotNetExamples;
using NLTDotNetCore.ConsoleApp.DapperExamples;
using NLTDotNetCore.ConsoleApp.EFCoreExamples;
using NLTDotNetCore.ConsoleApp.Services;

// AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
// adoDotNetExample.Read();
// adoDotNetExample.Create("title", "author", "content");
// adoDotNetExample.Update(11,"test title", "test author", "test content");
// adoDotNetExample.Delete(11);
// adoDotNetExample.Edit(12);

// DapperExample dapperExample = new DapperExample();
// dapperExample.Run();

// EFCoreExample efCoreExample = new EFCoreExample();
// efCoreExample.Run();

var connectionString = ConnectionStrings.SqlConnectionStringBuilder.ConnectionString;
var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

var serviceProvider = new ServiceCollection()
    .AddScoped(n => new AdoDotNetExample(sqlConnectionStringBuilder))
    .AddScoped(n => new DapperExample(sqlConnectionStringBuilder))
    .AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString))
    .AddScoped<EFCoreExample>()
    .BuildServiceProvider();

// AppDbContext db = serviceProvider.GetRequiredService<AppDbContext>();

// var adoDotNetExample = serviceProvider.GetRequiredService<AdoDotNetExample>();
// adoDotNetExample.Read();

// var dapperExample = serviceProvider.GetRequiredService<DapperExample>();
// dapperExample.Run();
//
var efCoreExample = serviceProvider.GetRequiredService<EFCoreExample>();
efCoreExample.Run();

Console.ReadLine();