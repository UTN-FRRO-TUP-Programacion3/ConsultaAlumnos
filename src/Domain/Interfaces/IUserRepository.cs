

using ConsultaAlumnosClean.Domain.Entities;

namespace ConsultaAlumnosClean.Domain.Interfaces;

public interface IUserRepository : IRepositoryBase<User>
{
    User? GetUserByUserName(string userName);
}