﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Net.Mail;

namespace BigonWebUI.Helpers.Services
{
    public class EmailServices: SmtpClient , IEmailService
    {
        private readonly EmailOptions _options;

        public EmailServices(IOptions<EmailOptions> options)
        {
            _options = options.Value;

            Host = _options.SmtpServer;
            Port = _options.SmtpPort;
            EnableSsl = true;
            Credentials = new NetworkCredential(_options.FromAddress, _options.Password);
        }

        public async Task<bool> SendMailAsync(string to, string subject, string body)
        {
            try
            {
                using(MailMessage message=new MailMessage())
                {
                    message.Subject = subject;
                    message.To.Add(to);
                    message.IsBodyHtml = true;
                    message.From = new MailAddress(_options.FromAddress, _options.FromName);
                    message.Body = body;

                    await base.SendMailAsync(message);
                }
            }
            catch (Exception)
            {

                return false; 
            }

            return true;
        }
    }
}
