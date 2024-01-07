using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaAlumnosClean.Infrastructure.Data;

public class EfRepository<T> : RepositoryBase<T> where T : class
{
    protected readonly ApplicationDbContext _context;
    public EfRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _context = dbContext;
    }
}
