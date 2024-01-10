using AutoMapper;
using ConsultaAlumnosClean.Application.Models;
using ConsultaAlumnosClean.Application.Models.Requests;
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
