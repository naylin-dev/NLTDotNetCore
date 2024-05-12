using NLTDotNetCore.ConsoleAppHttpClient;

Console.WriteLine("Hello, World!");

// Console App - Client
// ASP.Net Core Web API - Server

HttpClientExample httpClientExample = new HttpClientExample();
await httpClientExample.RunAsync();

Console.ReadLine();