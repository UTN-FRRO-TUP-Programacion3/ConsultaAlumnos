using ConsultaAlumnosClean.Domain.Interfaces;

namespace ConsultaAlumnosClean.Infrastructure.Data;

public class Repository : IRepository
{
    internal readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public bool SaveChanges()
    {
        return _context.SaveChanges() >= 0;
    }
}
