using AutoMapper;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Application.Models.Requests;
using ConsultaAlumnos.Domain.Entities;

namespace ConsultaAlumnos.Application.Profiles;

public class ResponseProfile : Profile
{
    public ResponseProfile()
    {
        CreateMap<ResponseCreateRequest, Response>();
        CreateMap<Response, ResponseDto>();
    }
}
