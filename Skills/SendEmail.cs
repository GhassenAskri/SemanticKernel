using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using Microsoft.SemanticKernel;

namespace EmailAgent.Skills;

public class SendEmail
{
    [KernelFunction("send_email")]
    [Description("Sends an email to a recipient.")]
    public async Task SendEmailAsync(
        Kernel kernel,
        string recipientEmail,
        string subject,
        string body
    )
    {
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("");
        mail.To.Add(recipientEmail);
        mail.Subject = subject;
        mail.Body = body;

        SmtpClient smtpClient = new SmtpClient("")
        {
            Port = 587,
            Credentials = new NetworkCredential("", ""),
            EnableSsl = true
        };

        // Send the email
        smtpClient.Send(mail);
        Console.WriteLine("Email sent!");
    }
}