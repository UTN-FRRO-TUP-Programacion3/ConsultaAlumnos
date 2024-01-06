

using ConsultaAlumnosClean.Domain.Entities;

namespace ConsultaAlumnosClean.Domain.Interfaces;

public interface IResponseRepository : IRepository
{
    void AddResponse(Response newResponse);
    Response? GetResponse(int responseId);
}