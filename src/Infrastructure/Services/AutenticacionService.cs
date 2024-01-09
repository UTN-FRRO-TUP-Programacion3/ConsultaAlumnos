

using ConsultaAlumnosClean.Application.Interfaces;
using ConsultaAlumnosClean.Application.Models.Requests;
using ConsultaAlumnosClean.Domain.Entities;
using ConsultaAlumnosClean.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConsultaAlumnosClean.Infrastructure.Services
{
    public class AutenticacionService : ICustomAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AutenticacionService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User? ValidateUser(AuthenticationRequest authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.UserName) || string.IsNullOrEmpty(authenticationRequest.Password))
                return null;

            var user = _userRepository.GetUserByUserName(authenticationRequest.UserName);

            if (user == null) return null;

            if (authenticationRequest.UserType == typeof(Student).Name || authenticationRequest.UserType == typeof(Professor).Name )
            {
                if (user.UserType == authenticationRequest.UserType && user.Password == authenticationRequest.Password) return user;
            }
            
            return null;

        }

    }
}
