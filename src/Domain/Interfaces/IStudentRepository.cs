

using ConsultaAlumnosClean.Domain.Entities;

namespace ConsultaAlumnosClean.Domain.Interfaces;

public interface IStudentRepository
{
    Student? GetStudentById(int userId);
    ICollection<Subject> GetStudentSubjects(int studentId);
}