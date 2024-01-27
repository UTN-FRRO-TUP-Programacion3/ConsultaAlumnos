using AutoMapper;
using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Domain.Entities;
using ConsultaAlumnos.Domain.Interfaces;


namespace ConsultaAlumnos.Application.Services;

public class ResponseService : IResponseService
{
    private readonly IMapper _mapper;
    private readonly IRepositoryBase<Response> _responseRepository;

    public ResponseService(IMapper mapper, IRepositoryBase<Response> responseRepository)
    {
        _mapper = mapper;
        _responseRepository = responseRepository;
    }
   

    public ResponseDto? GetResponse(int responseId)
    {
        var response = _responseRepository.GetByIdAsync(responseId).Result;
        return _mapper.Map<ResponseDto>(response);
    }
}
