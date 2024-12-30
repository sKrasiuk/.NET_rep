using System;
using System.Net;
using System.Net.Mail;
using Restoranas.Interfaces;

namespace Restoranas.Services;

public class EmailService : IEmailService
{
    private readonly SmtpClient smtpClient;
    private readonly string fromEmail;

    public EmailService()
    {
        smtpClient = new SmtpClient("smtp.office365.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("sergej.krasiukov@codeacademylt.onmicrosoft.com", ""),
            EnableSsl = true
        };
        fromEmail = "sergej.krasiukov@codeacademylt.onmicrosoft.com";
    }

    public void SendEmail(string to, string subject, string content)
    {
        var message = new MailMessage(fromEmail, to)
        {
            Subject = subject,
            Body = content,
            IsBodyHtml = false
        };
        smtpClient.Send(message);
    }
}
