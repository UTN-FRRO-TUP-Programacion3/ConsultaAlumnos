

using AutoMapper;
using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Domain.Interfaces;

namespace ConsultaAlumnos.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _userRepository;
    private readonly IMapper _mapper;

    public StudentService(IStudentRepository studentRepository, IMapper mapper)
    {
        _userRepository = studentRepository;
        _mapper = mapper;
    }
    public ICollection<SubjectDto> GetSubjectsByStudent(int studentId)
    {
        var subjects = _userRepository.GetStudentSubjects(studentId);

        return _mapper.Map<ICollection<SubjectDto>>(subjects);
    }

    public StudentDto GetStudentById(int id)
    {
        var student = _userRepository.GetByIdAsync(id).Result;

        return _mapper.Map<StudentDto>(student);
    }


}
