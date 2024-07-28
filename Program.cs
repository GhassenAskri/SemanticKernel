using EmailAgent;
using EmailAgent.Connectors;
using EmailAgent.Services;
using EmailAgent.Skills;


//startup app
App.Configure();
//connect openai llm with AutoInvokeKernelFunctions strategy
var openAi = new OpenAi(App.OpenAiSettings);
//define send email skill
var emailNotificationSkill = new EmailNotificationSkill(App.SmtpClientSettings);
// build kernel with send email skill
var kernel = KernelBuilder.BuildWithSkill(emailNotificationSkill);
// start chat service
var chatService = new ChatService();


//Interact with user
while (true)
{
    var fullMessage = string.Empty;
    Console.Write("User > ");
    chatService.AddUserMessage(Console.ReadLine()!);
    try
    {
        var response = openAi.Ask(chatService.Messages, kernel);
        Console.Write($"Assistant > ");
        await foreach (var content in response)
        {
            Console.Write(content.Content);
            fullMessage += content.Content;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }

    Console.WriteLine();
    chatService.AddAssistantMessage(fullMessage);
}