

using ConsultaAlumnosClean.Domain.Entities;

namespace ConsultaAlumnosClean.Domain.Interfaces;

public interface IStudentRepository : IRepositoryBase<Student>
{
    ICollection<Subject> GetStudentSubjects(int studentId);
}