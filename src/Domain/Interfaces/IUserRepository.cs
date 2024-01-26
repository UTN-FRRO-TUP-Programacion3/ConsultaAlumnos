using ConsultaAlumnos.Domain.Entities;

namespace ConsultaAlumnos.Domain.Interfaces;

public interface IUserRepository : IRepositoryBase<User>
{
    User? GetUserByUserName(string userName);
}