using ConsultaAlumnos.Domain.Entities;
using ConsultaAlumnos.Domain.Interfaces;

namespace ConsultaAlumnos.Infrastructure.Data;

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
