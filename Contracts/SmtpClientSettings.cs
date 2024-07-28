namespace EmailAgent.Contracts;

public sealed class SmtpClientSettings
{
    public string Host { get; init; }
    public string UserName { get; init; }
    public string Password { get; init; }
    public int Port { get; init; }
}