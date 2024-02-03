namespace Persistence;

public static class ConnectionStringHelper
{
    public static string Get()
    {
        var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
        var dbName = Environment.GetEnvironmentVariable("DB_NAME");
        var dbUser = Environment.GetEnvironmentVariable("DB_USER");
        var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");

        return $"Data Source={dbHost};Initial Catalog={dbName};User ID={dbUser};Password={dbPassword};TrustServerCertificate=True;";
    }
}