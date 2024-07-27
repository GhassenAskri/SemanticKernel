using Microsoft.Extensions.Configuration;

namespace EmailAgent;

public static class AppBuilder
{
    public static IConfiguration LoadConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        return builder.Build();
    }
}