using ConsultaAlumnos.Application.Models.Requests;

namespace ConsultaAlumnos.Application.Interfaces;

public interface ICustomAuthenticationService
{
    string Autenticar(AuthenticationRequest authenticationRequest);
}