using ConsultaAlumnos.Application.Services;
using ConsultaAlumnos.Domain.Entities;

namespace ConsultaAlumnos.Application.Models;


public class SubjectDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<ProfessorDto> Professors { get; set; } = new List<ProfessorDto>();

    public static SubjectDto Create(Subject subject)
    {
        var dto = new SubjectDto();
        dto.Id = subject.Id;
        dto.Name = subject.Name;

        foreach (Professor p in subject.Professors)
        {
            dto.Professors.Add(ProfessorDto.Create(p));
        }

        return dto;
    }


    public static List<SubjectDto> CreateList(IEnumerable<Subject> subjects)
    {
        List<SubjectDto> listDto = [];
        foreach (var s in subjects)
        {
            listDto.Add(Create(s));
        }

        return listDto;
    }
}

