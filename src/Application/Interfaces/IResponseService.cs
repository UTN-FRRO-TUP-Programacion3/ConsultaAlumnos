using ConsultaAlumnosClean.Application.Models;
using ConsultaAlumnosClean.Application.Models.Requests;

namespace ConsultaAlumnosClean.Application.Interfaces;

public interface IResponseService
{
    ResponseDto CreateResponse(ResponseCreateRequest newResponse, int questionId, int userId);
    ResponseDto? GetResponse(int responseId);
}