using NLTDotNetCore.ConsoleApp.Dtos;

namespace NLTDotNetCore.ConsoleApp.EFCoreExamples;

internal class EFCoreExample
{
    private readonly AppDbContext _db = new AppDbContext();

    public void Run()
    {
        // Read();
        // Edit(1);
        // Edit(11);
        // Create("new title", "new author", "new content");
        // Update(1003, "update title", "update author", "update content");
        Delete(1003);
    }

    private void Read()
    {
        var lst = _db.Blogs.ToList();

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
        var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
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

        _db.Blogs.Add(item);
        int result = _db.SaveChanges();

        string message = result > 0 ? "Saving Successful." : "Saving Failed.";
        Console.WriteLine(message);
    }

    private void Update(int id, string title, string author, string content)
    {
        var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            Console.WriteLine("No Data Found.");
            return;
        }

        item.BlogTitle = title;
        item.BlogAuthor = author;
        item.BlogContent = content;

        int result = _db.SaveChanges();

        string message = result > 0 ? "Updating Successful." : "Updating Failed.";
        Console.WriteLine(message);
    }

    private void Delete(int id)
    {
        var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            Console.WriteLine("No Data Found.");
            return;
        }

        _db.Blogs.Remove(item);
        int result = _db.SaveChanges();

        string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
        Console.WriteLine(message);
    }
}