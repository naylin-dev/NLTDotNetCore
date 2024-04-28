// See https://aka.ms/new-console-template for more information

using NLTDotNetCore.ConsoleApp;
using NLTDotNetCore.ConsoleApp.EFCoreExamples;

// AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
// adoDotNetExample.Read();
// adoDotNetExample.Create("title", "author", "content");
// adoDotNetExample.Update(11,"test title", "test author", "test content");
// adoDotNetExample.Delete(11);
// adoDotNetExample.Edit(12);

// DapperExample dapperExample = new DapperExample();
// dapperExample.Run();

EFCoreExample efCoreExample = new EFCoreExample();
efCoreExample.Run();

Console.ReadLine();