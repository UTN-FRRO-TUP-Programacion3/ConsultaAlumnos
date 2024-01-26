using AutoMapper;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Domain.Entities;

namespace ConsultaAlumnos.Application.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
    }
}