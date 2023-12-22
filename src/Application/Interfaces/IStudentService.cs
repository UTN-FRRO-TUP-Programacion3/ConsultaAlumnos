

using ConsultaAlumnosClean.Application.Models;

namespace ConsultaAlumnosClean.Application.Interfaces
{
    public interface IStudentService
    {
        ICollection<SubjectDto> GetSubjectsByStudent(int studentId);
        StudentDto GetStudentById(int id);
    }
}