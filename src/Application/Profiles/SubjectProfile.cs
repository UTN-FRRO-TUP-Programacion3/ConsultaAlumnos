using AutoMapper;
using ConsultaAlumnosClean.Application.Models;


namespace ConsultaAlumnosClean.Application.Profiles;

public class SubjectProfile : Profile
{
    public SubjectProfile()
    {
        CreateMap<ConsultaAlumnosClean.Domain.Entities.Subject, SubjectDto>();
    }
}
