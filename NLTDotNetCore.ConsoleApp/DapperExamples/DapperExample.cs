using System.Data;
using System.Data.SqlClient;
using Dapper;
using NLTDotNetCore.ConsoleApp.Dtos;
using NLTDotNetCore.ConsoleApp.Services;

namespace NLTDotNetCore.ConsoleApp.DapperExamples;

public class DapperExample
{
    private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

    public DapperExample(SqlConnectionStringBuilder sqlConnectionStringBuilder)
    {
        _sqlConnectionStringBuilder = sqlConnectionStringBuilder;
    }

    public void Run()
    {
        Read();
        // Edit(1);
        // Edit(11);
        // Create("new title", "new author", "new content");
        // Update(10, "update title", "update author", "update content");
        // Delete(1002);
    }

    private void Read()
    {
        using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        List<BlogDto> lst = db.Query<BlogDto>("SELECT * FROM Tbl_Blog").ToList();

        foreach (BlogDto item in lst)
        {
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("------------------------------------");
        }
    }

    private void Edit(int id)
    {
        using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        var item = db.Query<BlogDto>("SELECT * FROM Tbl_Blog WHERE BlogId = @BlogId", new BlogDto { BlogId = id })
            .FirstOrDefault();

        if (item is null)
        {
            Console.WriteLine("No Data Found.");
            return;
        }

        Console.WriteLine(item.BlogId);
        Console.WriteLine(item.BlogTitle);
        Console.WriteLine(item.BlogAuthor);
        Console.WriteLine(item.BlogContent);
        Console.WriteLine("------------------------------------");
    }

    private void Create(string title, string author, string content)
    {
        var item = new BlogDto
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        string query = @"INSERT INTO Tbl_Blog 
                            (BlogTitle, 
                             BlogAuthor, 
                             BlogContent) 
                         VALUES 
                            (@BlogTitle, 
                             @BlogAuthor, 
                             @BlogContent)";
        using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, item);

        string message = result > 0 ? "Saving Successful." : "Saving Failed.";
        Console.WriteLine(message);
    }

    private void Update(int id, string title, string author, string content)
    {
        var item = new BlogDto
        {
            BlogId = id,
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        string query = @"UPDATE Tbl_Blog
                            SET
                                BlogTitle = @BlogTitle,
                                BlogAuthor = @BlogAuthor,
                                BlogContent = @BlogContent
                            WHERE
                                BlogId = @BlogId";
        using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, item);

        string message = result > 0 ? "Updating Successful." : "Updating Failed.";
        Console.WriteLine(message);
    }

    private void Delete(int id)
    {
        var item = new BlogDto
        {
            BlogId = id,
        };
        string query = @"DELETE FROM 
                            Tbl_Blog
                         WHERE 
                            BlogId = @BlogId";
        using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, item);

        string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
        Console.WriteLine(message);
    }
}