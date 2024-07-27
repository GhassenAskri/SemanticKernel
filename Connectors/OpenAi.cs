using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace EmailAgent.Connectors;

public class OpenAi
{
    private OpenAIChatCompletionService ChatCompletion { get; }
    

    public OpenAi()
    {
        ChatCompletion = new(
            modelId: "gpt-4o",
            apiKey: "sk-None-I4QK0mJurIFQJt3Aq2IXT3BlbkFJ2d9GHFqqphDANZcOY2Ix"
        );
    }

    public IAsyncEnumerable<StreamingChatMessageContent> Ask(ChatHistory chatHistory, Kernel kernel)
    {
        OpenAIPromptExecutionSettings openAiPromptExecutionSettings = new()
        {
            ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
        };

        try
        {
            return ChatCompletion.GetStreamingChatMessageContentsAsync(
                chatHistory,
                executionSettings: openAiPromptExecutionSettings,
                kernel: kernel);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}