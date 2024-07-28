using System.Reflection;
using EmailAgent.Contracts;
using Microsoft.Extensions.Configuration;

namespace EmailAgent;

public static class App
{
    private static IConfiguration config;

    public static void Configure()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        config = builder.Build();
        OpenAiSettings = config.GetSection("openai_settings").Get<OpenAiSettings>();
        SmtpClientSettings = config.GetSection("smtp_client_settings").Get<SmtpClientSettings>();
    }

    public static OpenAiSettings OpenAiSettings { get; private set; }
    public static SmtpClientSettings SmtpClientSettings { get; private set; }
}