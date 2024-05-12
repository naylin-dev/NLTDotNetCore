using System.Text;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace NLTDotNetCore.ConsoleAppHttpClient;

public class HttpClientExample
{
    private readonly HttpClient _client = new HttpClient() { BaseAddress = new Uri("https://localhost:7080/") };
    private readonly string _blogEndPoint = "api/blog";

    public async Task RunAsync()
    {
        // await ReadAsync();
        // await EditAsync(1);
        // await EditAsync(100);
        // await CreateAsync("new title", "new author", "new content");
        // await UpdateAsync(5003, "update title", "update author", "update content");
        // await PatchAsync(5003, "update title 1", "", "");
        await DeleteAsync(5003);
    }

    private async Task ReadAsync()
    {
        var response = await _client.GetAsync(_blogEndPoint);
        if (response.IsSuccessStatusCode)
        {
            string jsonStr = await response.Content.ReadAsStringAsync();
            List<BlogDto> lst = JsonConvert.DeserializeObject<List<BlogDto>>(jsonStr)!;
            foreach (var item in lst)
            {
                Console.WriteLine(JsonConvert.SerializeObject(item));
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author => {item.BlogAuthor}");
                Console.WriteLine($"Content => {item.BlogContent}");
                Console.WriteLine("------------------------------------");
            }
        }
    }

    private async Task EditAsync(int id)
    {
        var response = await _client.GetAsync($"{_blogEndPoint}/{id}");
        if (response.IsSuccessStatusCode)
        {
            string jsonStr = await response.Content.ReadAsStringAsync();
            var item = JsonConvert.DeserializeObject<BlogDto>(jsonStr)!;
            Console.WriteLine(JsonConvert.SerializeObject(item));
            Console.WriteLine($"Title => {item.BlogTitle}");
            Console.WriteLine($"Author => {item.BlogAuthor}");
            Console.WriteLine($"Content => {item.BlogContent}");
            Console.WriteLine("------------------------------------");
        }
        else
        {
            string message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
        }
    }

    private async Task CreateAsync(string title, string author, string content)
    {
        // C# Object
        BlogDto blogDto = new BlogDto()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };

        // JSON string
        string blogJson = JsonConvert.SerializeObject(blogDto);

        HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);
        var response = await _client.PostAsync(_blogEndPoint, httpContent);
        if (response.IsSuccessStatusCode)
        {
            string message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
        }
        else
        {
            string message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
        }
    }

    private async Task UpdateAsync(int id, string title, string author, string content)
    {
        // C# Object
        BlogDto blogDto = new BlogDto()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };

        // JSON string
        string blogJson = JsonConvert.SerializeObject(blogDto);

        HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);
        var response = await _client.PutAsync($"{_blogEndPoint}/{id}", httpContent);
        if (response.IsSuccessStatusCode)
        {
            string message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
        }
        else
        {
            string message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
        }
    }

    private async Task PatchAsync(int id, string title, string author, string content)
    {
        // C# Object
        BlogDto blogDto = new BlogDto();

        if (!string.IsNullOrEmpty(title))
        {
            blogDto.BlogTitle = title;
        }

        if (!string.IsNullOrEmpty(author))
        {
            blogDto.BlogAuthor = author;
        }

        if (!string.IsNullOrEmpty(content))
        {
            blogDto.BlogContent = content;
        }

        // JSON string
        string blogJson = JsonConvert.SerializeObject(blogDto);

        HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);
        var response = await _client.PatchAsync($"{_blogEndPoint}/{id}", httpContent);
        if (response.IsSuccessStatusCode)
        {
            string message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
        }
        else
        {
            string message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
        }
    }

    private async Task DeleteAsync(int id)
    {
        var response = await _client.DeleteAsync($"{_blogEndPoint}/{id}");
        if (response.IsSuccessStatusCode)
        {
            string message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
        }
        else
        {
            string message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
        }
    }
}