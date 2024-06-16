using Microsoft.AspNetCore.Mvc;
using NLTDotNetCore.RestApi.Models;
using NLTDotNetCore.Shared;

namespace NLTDotNetCore.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogDapper2Controller : ControllerBase
{
    // private readonly DapperService _dapperService =
    //     new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

    private readonly DapperService _dapperService;

    public BlogDapper2Controller(DapperService dapperService)
    {
        _dapperService = dapperService;
    }

    [HttpGet]
    public IActionResult GetBlogs()
    {
        string query = "SELECT * FROM Tbl_Blog";
        var lst = _dapperService.Query<BlogModel>(query);

        return Ok(lst);
    }

    [HttpGet("{id}")]
    public IActionResult GetBlog(int id)
    {
        var item = FindById(id);

        if (item is null)
        {
            return NotFound("No Data Found.");
        }

        return Ok(item);
    }

    [HttpPost]
    public IActionResult CreateBlog(BlogModel blog)
    {
        var query = @"INSERT INTO Tbl_Blog 
                            (BlogTitle, 
                             BlogAuthor, 
                             BlogContent) 
                         VALUES 
                            (@BlogTitle, 
                             @BlogAuthor, 
                             @BlogContent)";

        var result = _dapperService.Execute(query, blog);

        var message = result > 0 ? "Saving Successful." : "Saving Failed.";
        return Ok(message);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBlog(int id, BlogModel blog)
    {
        var item = FindById(id);

        if (item is null)
        {
            return NotFound("No Data Found.");
        }

        blog.BlogId = id;

        string query = @"UPDATE Tbl_Blog
                            SET
                                BlogTitle = @BlogTitle,
                                BlogAuthor = @BlogAuthor,
                                BlogContent = @BlogContent
                            WHERE
                                BlogId = @BlogId";

        var result = _dapperService.Execute(query, blog);

        string message = result > 0 ? "Updating Successful." : "Updating Failed.";
        return Ok(message);
    }

    [HttpPatch("{id}")]
    public IActionResult PatchBlog(int id, BlogModel blog)
    {
        var item = FindById(id);

        if (item is null)
        {
            return NotFound("No data found.");
        }

        string conditions = string.Empty;

        if (!string.IsNullOrEmpty(blog.BlogTitle))
        {
            conditions += "BlogTitle = @BlogTitle, ";
        }

        if (!string.IsNullOrEmpty(blog.BlogAuthor))
        {
            conditions += "BlogAuthor = @BlogAuthor, ";
        }

        if (!string.IsNullOrEmpty(blog.BlogContent))
        {
            conditions += "BlogContent = @BlogContent, ";
        }

        if (conditions.Length == 0)
        {
            return NotFound("No data to update.");
        }

        conditions = conditions.Substring(0, conditions.Length - 2);
        blog.BlogId = id;

        string query = $@"UPDATE Tbl_Blog
                            SET 
                                {conditions}
                            WHERE
                                BlogId = @BlogId";

        var result = _dapperService.Execute(query, blog);

        string message = result > 0 ? "Updating Successful." : "Updating Failed.";
        return Ok(message);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBlog(int id)
    {
        var item = FindById(id);

        if (item is null)
        {
            return NotFound("No Data Found.");
        }

        string query = @"DELETE FROM 
                            Tbl_Blog
                         WHERE 
                            BlogId = @BlogId";

        var result = _dapperService.Execute(query, new BlogModel { BlogId = id });

        string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";

        return Ok(message);
    }

    private BlogModel? FindById(int id)
    {
        var query = "SELECT * FROM Tbl_Blog WHERE BlogId = @BlogId";
        var item = _dapperService.QueryFirstOrDefault<BlogModel>(query, new BlogModel { BlogId = id });

        return item;
    }
}