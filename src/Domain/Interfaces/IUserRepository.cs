

using ConsultaAlumnosClean.Domain.Entities;

namespace ConsultaAlumnosClean.Domain.Interfaces;

public interface IUserRepository : IRepository
{
    User? GetUserById(int userId);

    User? GetUserByUserName(string userName);
}