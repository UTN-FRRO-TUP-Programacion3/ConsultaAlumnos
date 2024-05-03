
using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Domain.Entities;
using ConsultaAlumnos.Domain.Interfaces;


namespace ConsultaAlumnos.Application.Services;

public class ResponseService : IResponseService
{
    private readonly IRepositoryBase<Response> _responseRepository;

    public ResponseService(IRepositoryBase<Response> responseRepository)
    {
        _responseRepository = responseRepository;
    }
   

    public ResponseDto? GetResponse(int responseId)
    {
        var response = _responseRepository.GetByIdAsync(responseId).Result;
        return ResponseDto.Create(response);

    }
}
