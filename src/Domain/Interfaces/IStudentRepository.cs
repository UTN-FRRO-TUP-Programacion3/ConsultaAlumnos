using ConsultaAlumnos.Domain.Entities;

namespace ConsultaAlumnos.Domain.Interfaces;

public interface IStudentRepository : IRepositoryBase<Student>
{
    ICollection<Subject> GetStudentSubjects(int studentId);
}