using AutoMapper;
using ConsultaAlumnosClean.Application.Models;
using ConsultaAlumnosClean.Domain.Entities;

namespace ConsultaAlumnosClean.Application.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
    }
}