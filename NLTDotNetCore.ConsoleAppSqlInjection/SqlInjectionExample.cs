using NLTDotNetCore.Shared;

namespace NLTDotNetCore.ConsoleAppSqlInjection;

public class SqlInjectionExample
{
    private readonly DapperService _dapperService;

    public SqlInjectionExample()
    {
        _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
    }

    public void Run()
    {
        Console.WriteLine("Provide Email and Password to login");

        Console.WriteLine("Email: ");
        string email = Console.ReadLine()!; // "test";

        Console.WriteLine("Password: ");
        string password = Console.ReadLine()!; // "test' or 1=1 +'";

        string query = $"SELECT * FROM Tbl_User WHERE Email = '{email}' AND Password = '{password}'";

        var model = _dapperService.QueryFirstOrDefault<UserModel>(query);

        if (model is null)
        {
            Console.WriteLine("Invalid Email or Password.");
            return;
        }

        Console.WriteLine("Is Admin: " + model.Email);
    }

    public class UserModel
    {
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}