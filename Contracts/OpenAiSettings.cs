namespace EmailAgent.Contracts;

public sealed class OpenAiSettings
{
    public string ModelId { get; init; }
    public string ApiKey { get; init; }
}