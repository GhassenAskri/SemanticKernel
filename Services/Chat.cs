using Microsoft.SemanticKernel.ChatCompletion;

namespace EmailAgent.Services;

public class Chat
{
    public ChatHistory Messages { get; } = new(Introduction);

    private const string Introduction = """
                                        You are a friendly assistant who likes to follow the rules. You will complete required steps
                                        and request approval before taking any consequential actions. If the user doesn't provide
                                        enough information for you to complete a task, you will keep asking questions until you have
                                        enough information to complete the task.
                                        """;

    public void AddUserMessage(string message) => Messages.AddUserMessage(message);
    public void AddAssistantMessage(string message) => Messages.AddAssistantMessage(message);
}