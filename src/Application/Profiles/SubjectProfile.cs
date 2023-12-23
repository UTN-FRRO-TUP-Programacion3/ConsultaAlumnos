using AutoMapper;
using ConsultaAlumnosClean.Application.Models;


namespace ConsultaAlumnos.API.Profiles
{
    public class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            CreateMap<ConsultaAlumnosClean.Domain.Entities.Subject, SubjectDto>();
        }
    }
}
