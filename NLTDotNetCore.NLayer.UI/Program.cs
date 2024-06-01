using NLTDotNetCore.NLayer.BusinessLogic.Services;

BL_Blog blBlog = new BL_Blog();

var item = blBlog.GetBlog(1);
if (item is null)
{
    Console.WriteLine("No Data Found.");
    return;
}

Console.WriteLine("Id: " + item.BlogId);
Console.WriteLine("Title: " + item.BlogTitle);
Console.WriteLine("Author: " + item.BlogAuthor);
Console.WriteLine("Content: " + item.BlogContent);