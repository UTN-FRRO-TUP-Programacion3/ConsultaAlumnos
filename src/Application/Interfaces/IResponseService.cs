using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Application.Models.Requests;

namespace ConsultaAlumnos.Application.Interfaces;

public interface IResponseService
{
    ResponseDto CreateResponse(ResponseCreateRequest newResponse, int questionId, int userId);
    ResponseDto? GetResponse(int responseId);
}