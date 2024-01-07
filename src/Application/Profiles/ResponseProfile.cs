using AutoMapper;
using ConsultaAlumnos.API.Models.Responses;
using ConsultaAlumnosClean.Application.Models;
using ConsultaAlumnosClean.Domain.Entities;

namespace ConsultaAlumnosClean.Application.Profiles;

public class ResponseProfile : Profile
{
    public ResponseProfile()
    {
        CreateMap<ResponseCreateRequest, Response>();
        CreateMap<Response, ResponseDto>();
    }
}
