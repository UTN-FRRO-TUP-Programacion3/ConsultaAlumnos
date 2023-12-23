

using AutoMapper;
using ConsultaAlumnosClean.Application.Interfaces;
using ConsultaAlumnosClean.Application.Models;
using ConsultaAlumnosClean.Domain.Interfaces;

namespace ConsultaAlumnosClean.Application.Services
{
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
            var student = _userRepository.GetStudentById(id);

            return _mapper.Map<StudentDto>(student);
        }


    }
}
