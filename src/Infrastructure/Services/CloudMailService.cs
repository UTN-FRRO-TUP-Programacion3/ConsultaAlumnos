

using ConsultaAlumnosClean.Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ConsultaAlumnosClean.Infrastructure.Services
{
    public class CloudMailService : IMailService
    {
        private readonly string _mailFrom = string.Empty;

        public CloudMailService(IConfiguration configuration)
        {
            _mailFrom = configuration["mailSettings:mailFromAddress"];
        }

        public void Send(string subject, string message, string mailTo)
        {
            Console.WriteLine($"Mail de {_mailFrom} a {mailTo}, " +
                $"con {nameof(CloudMailService)}.");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Mensaje: {message}");
        }
    }
}
