using ConsultaAlumnosClean.Application.Models.Requests;
using ConsultaAlumnosClean.Domain.Entities;
using ConsultaAlumnosClean.Domain.Interfaces;

namespace ConsultaAlumnosClean.Infrastructure.Data;

public class UserRepository : EfRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }

    public User? GetUserByUserName(string userName)
    {
        return _context.Users.SingleOrDefault(p => p.UserName == userName);
    }
}
