

using ConsultaAlumnosClean.Application.Models.Requests;
using ConsultaAlumnosClean.Domain.Entities;

namespace ConsultaAlumnosClean.Application.Interfaces;

public interface ICustomAuthenticationService
{
    string Autenticar(AuthenticationRequest authenticationRequest);
}