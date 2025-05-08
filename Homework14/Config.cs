namespace Homework14
{
    public static class Config
    {
        public static string ConnectionString =
            Environment.GetEnvironmentVariable("CONNECTION_STRING") ??
            "User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=Shop;";
    }
}
