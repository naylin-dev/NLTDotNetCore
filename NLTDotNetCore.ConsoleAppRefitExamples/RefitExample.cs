using NLTDotNetCore.ConsoleAppRefitExamples.Models;
using Refit;

namespace NLTDotNetCore.ConsoleAppRefitExamples;

public class RefitExample
{
    private readonly IBlogApi _service = RestService.For<IBlogApi>("https://localhost:7088");

    public async Task RunAsync()
    {
        // await ReadAsync();
        // await EditAsync(1);
        // await EditAsync(100);
        // await CreateAsync("new title", "new author", "new content");
        // await UpdateAsync(6003, "update title", "update author", "update content");
        await PatchAsync(6003, "update title 1", "", "");
    }

    private async Task ReadAsync()
    {
        var lst = await _service.GetBlogs();
        foreach (var item in lst)
        {
            Console.WriteLine($"Id => {item.BlogId}");
            Console.WriteLine($"Title => {item.BlogTitle}");
            Console.WriteLine($"Author => {item.BlogAuthor}");
            Console.WriteLine($"Content => {item.BlogContent}");
            Console.WriteLine("------------------------------------");
        }
    }

    private async Task EditAsync(int id)
    {
        try
        {
            var item = await _service.GetBlog(id);

            Console.WriteLine($"Id => {item.BlogId}");
            Console.WriteLine($"Title => {item.BlogTitle}");
            Console.WriteLine($"Author => {item.BlogAuthor}");
            Console.WriteLine($"Content => {item.BlogContent}");
            Console.WriteLine("------------------------------------");
        }
        catch (ApiException ex)
        {
            Console.WriteLine(ex.StatusCode.ToString());
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task CreateAsync(string title, string author, string content)
    {
        BlogModel blog = new BlogModel()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        var message = await _service.CreateBlog(blog);
        Console.WriteLine(message);
    }

    private async Task UpdateAsync(int id, string title, string author, string content)
    {
        try
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            var message = await _service.UpdateBlog(id, blog);
            Console.WriteLine(message);
        }
        catch (ApiException ex)
        {
            Console.WriteLine(ex.StatusCode.ToString());
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task PatchAsync(int id, string title, string author, string content)
    {
        try
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            var message = await _service.PatchBlog(id, blog);
            Console.WriteLine(message);
        }
        catch (ApiException ex)
        {
            Console.WriteLine(ex.StatusCode.ToString());
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task DeleteAsync(int id)
    {
        try
        {
            var message = await _service.DeleteBlog(id);
            Console.WriteLine(message);
        }
        catch (ApiException ex)
        {
            Console.WriteLine(ex.StatusCode.ToString());
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}