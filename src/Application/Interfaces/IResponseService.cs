using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Application.Models.Requests;

namespace ConsultaAlumnos.Application.Interfaces;

public interface IResponseService
{
    ResponseDto? GetResponse(int responseId);
}