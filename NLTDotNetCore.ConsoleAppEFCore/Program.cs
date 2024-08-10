// See https://aka.ms/new-console-template for more information

using NLTDotNetCore.ConsoleAppEFCore.Databases.Models;

Console.WriteLine("Hello, World!");

AppDbContext db = new AppDbContext();
db.TblPieCharts.ToList();