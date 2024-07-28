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
// start chat context management class
var chat = new Chat();
// build kernel with send email skill
var kernel = KernelBuilder.BuildWithSkill(emailNotificationSkill);


//Interact with user
while (true)
{
    var fullMessage = string.Empty;
    Console.Write("User > ");
    chat.AddUserMessage(Console.ReadLine()!);
    try
    {
        var response = openAi.Ask(chat.Messages, kernel);
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
    chat.AddAssistantMessage(fullMessage);
}