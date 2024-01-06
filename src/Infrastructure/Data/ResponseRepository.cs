

using ConsultaAlumnosClean.Domain.Entities;
using ConsultaAlumnosClean.Domain.Interfaces;

namespace ConsultaAlumnosClean.Infrastructure.Data;

public class ResponseRepository : Repository, IResponseRepository
{
    public ResponseRepository(ApplicationDbContext context) : base(context)
    {
    }

    public void AddResponse(Response newResponse)
    {
        _context.Responses.Add(newResponse);
    }

    public Response? GetResponse(int responseId)
    {
        return _context.Responses.Find(responseId);
    }
}
