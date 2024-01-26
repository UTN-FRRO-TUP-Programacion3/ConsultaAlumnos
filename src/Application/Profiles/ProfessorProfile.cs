using AutoMapper;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Domain.Entities;

namespace ConsultaAlumnos.Application.Profiles;

public class ProfessorProfile : Profile
{
    public ProfessorProfile()
    {
        CreateMap<Professor, ProfessorDto>();
    }
}
