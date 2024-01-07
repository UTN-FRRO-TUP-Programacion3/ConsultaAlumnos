using AutoMapper;
using ConsultaAlumnosClean.Application.Models;
using ConsultaAlumnosClean.Application.Models.Requests;
using ConsultaAlumnosClean.Domain.Entities;


namespace ConsultaAlumnosClean.Application.Profiles;

public class QuestionProfile : Profile
{
    public QuestionProfile()
    {
        CreateMap<QuestionCreateRequest, Question>();
        CreateMap<Question, QuestionDto>();
    }
}
