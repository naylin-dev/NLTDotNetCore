using System.Data.SqlClient;

namespace NLTDotNetCore.ConsoleApp;

internal static class ConnectionStrings
{
    public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = ".", // server name
        InitialCatalog = "DotNetTrainingBatch4", // database name
        UserID = "sa", // username
        Password = "sasa@123", // password
        TrustServerCertificate = true,
    };
}