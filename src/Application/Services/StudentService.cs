

using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Domain.Interfaces;

namespace ConsultaAlumnos.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _userRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _userRepository = studentRepository;
    }
    public ICollection<SubjectDto> GetSubjectsByStudent(int studentId)
    {
        var subjects = _userRepository.GetStudentSubjects(studentId);

        return SubjectDto.CreateList(subjects); 

    }

    public StudentDto GetStudentById(int id)
    {
        var student = _userRepository.GetByIdAsync(id).Result;

        return StudentDto.Create(student);

    }


}
