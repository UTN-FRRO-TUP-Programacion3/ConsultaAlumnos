using AutoMapper;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Application.Models.Requests;
using ConsultaAlumnos.Domain.Entities;

namespace ConsultaAlumnos.Application.Profiles;

public class QuestionProfile : Profile
{
    public QuestionProfile()
    {
        CreateMap<QuestionCreateRequest, Question>();
        CreateMap<Question, QuestionDto>();
    }
}
