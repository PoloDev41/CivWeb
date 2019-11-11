using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCiv.Areas
{
#pragma warning disable CS1591 // Commentaire XML manquant pour le type ou le membre visible publiquement
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
	
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
	
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
#pragma warning restore CS1591 // Commentaire XML manquant pour le type ou le membre visible publiquement
}
