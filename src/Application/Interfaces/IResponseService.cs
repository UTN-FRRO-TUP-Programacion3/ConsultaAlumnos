

using ConsultaAlumnos.API.Models.Responses;
using ConsultaAlumnosClean.Application.Models;

namespace ConsultaAlumnosClean.Application.Interfaces;

public interface IResponseService
{
    ResponseDto CreateResponse(ResponseCreateRequest newResponse, int questionId, int userId);
    ResponseDto? GetResponse(int responseId);
}