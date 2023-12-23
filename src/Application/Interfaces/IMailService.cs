namespace ConsultaAlumnosClean.Application.Interfaces;

public interface IMailService
{
    void Send(string subject, string message, string mailTo);
}