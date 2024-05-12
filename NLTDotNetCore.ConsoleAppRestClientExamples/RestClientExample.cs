using Newtonsoft.Json;
using RestSharp;

namespace NLTDotNetCore.ConsoleAppRestClientExamples;

public class RestClientExample
{
    private readonly RestClient _client = new RestClient(new Uri("https://localhost:7080/"));
    private readonly string _blogEndPoint = "api/blog";

    public async Task RunAsync()
    {
        // await ReadAsync();
        // await EditAsync(1);
        // await EditAsync(100);
        // await CreateAsync("new title", "new author", "new content");
        // await UpdateAsync(5004, "update title", "update author", "update content");
        // await PatchAsync(5004, "update title 1", "", "");
        await DeleteAsync(5004);
    }

    private async Task ReadAsync()
    {
        // RestRequest restRequest = new RestRequest(_blogEndPoint);
        // var response = await _client.GetAsync(restRequest);

        RestRequest restRequest = new RestRequest(_blogEndPoint, Method.Get);
        var response = await _client.ExecuteAsync(restRequest);
        if (response.IsSuccessStatusCode)
        {
            string jsonStr = response.Content!;
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
        RestRequest restRequest = new RestRequest($"{_blogEndPoint}/{id}", Method.Get);
        var response = await _client.ExecuteAsync(restRequest);
        if (response.IsSuccessStatusCode)
        {
            string jsonStr = response.Content!;
            var item = JsonConvert.DeserializeObject<BlogDto>(jsonStr)!;
            Console.WriteLine(JsonConvert.SerializeObject(item));
            Console.WriteLine($"Title => {item.BlogTitle}");
            Console.WriteLine($"Author => {item.BlogAuthor}");
            Console.WriteLine($"Content => {item.BlogContent}");
            Console.WriteLine("------------------------------------");
        }
        else
        {
            string message = response.Content!;
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

        RestRequest restRequest = new RestRequest(_blogEndPoint, Method.Post);
        restRequest.AddJsonBody(blogDto);
        var response = await _client.PostAsync(restRequest);
        if (response.IsSuccessStatusCode)
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
        else
        {
            string message = response.Content!;
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

        RestRequest restRequest = new RestRequest($"{_blogEndPoint}/{id}", Method.Put);
        restRequest.AddJsonBody(blogDto);
        var response = await _client.PutAsync(restRequest);
        if (response.IsSuccessStatusCode)
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
        else
        {
            string message = response.Content!;
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

        RestRequest restRequest = new RestRequest($"{_blogEndPoint}/{id}", Method.Patch);
        restRequest.AddJsonBody(blogDto);
        var response = await _client.PatchAsync(restRequest);
        if (response.IsSuccessStatusCode)
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
        else
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
    }

    private async Task DeleteAsync(int id)
    {
        RestRequest restRequest = new RestRequest($"{_blogEndPoint}/{id}", Method.Delete);
        var response = await _client.ExecuteAsync(restRequest);
        if (response.IsSuccessStatusCode)
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
        else
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
    }
}