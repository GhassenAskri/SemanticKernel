using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using EmailAgent.Contracts;
using Microsoft.SemanticKernel;

namespace EmailAgent.Skills;

public class EmailNotificationSkill
{
    public static SmtpClientSettings _smtpClientSettings;

    /// <summary>
    ///  Ctor for the kernel
    /// </summary>
    ///
    public EmailNotificationSkill()
    {
    }

    public EmailNotificationSkill(SmtpClientSettings smtpClientSettings)
    {
        _smtpClientSettings = smtpClientSettings;
    }


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
        mail.From = new MailAddress(_smtpClientSettings.UserName);
        mail.To.Add(recipientEmail);
        mail.Subject = subject;
        mail.Body = body;

        SmtpClient smtpClient = new SmtpClient(_smtpClientSettings.Host)
        {
            Port = _smtpClientSettings.Port,
            Credentials = new NetworkCredential(_smtpClientSettings.UserName, _smtpClientSettings.Password),
            EnableSsl = true
        };

        // Send the email
        smtpClient.Send(mail);
        Console.WriteLine("Email sent!");
    }
}