using AutoMapper;
using ConsultaAlumnosClean.Application.Models;
using ConsultaAlumnosClean.Domain.Entities;

namespace ConsultaAlumnosClean.Application.Profiles;

public class ProfessorProfile : Profile
{
    public ProfessorProfile()
    {
        CreateMap<Professor, ProfessorDto>();
    }
}
