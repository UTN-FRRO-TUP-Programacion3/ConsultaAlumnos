using ConsultaAlumnos.Application.Models;

namespace ConsultaAlumnos.Application.Interfaces
{
    public interface IStudentService
    {
        ICollection<SubjectDto> GetSubjectsByStudent(int studentId);
        StudentDto GetStudentById(int id);
    }
}