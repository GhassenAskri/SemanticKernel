using EmailAgent;
using EmailAgent.Connectors;
using EmailAgent.Services;
using EmailAgent.Skills;


var skill = new SendEmail();
var kernel = KernelBuilder.BuildWithSkill(skill);
var chat = new Chat();
var openAi = new OpenAi();


while (true)
{
    var fullMessage = string.Empty;
    Console.Write("User > ");
    chat.AddUserMessage(Console.ReadLine()!);
    var response = openAi.Ask(chat.Messages, kernel);
    Console.Write($"Assistant > ");
    await foreach (var content in response)
    {
        Console.Write(content.Content);
        fullMessage += content.Content;
    }
    Console.WriteLine();
    chat.AddAssistantMessage(fullMessage);
}