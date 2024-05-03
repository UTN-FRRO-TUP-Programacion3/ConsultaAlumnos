using ConsultaAlumnos.Domain.Entities;
using System.Security.Cryptography.X509Certificates;

namespace ConsultaAlumnos.Application.Models;

public class StudentDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string CompleteName
    {
        get
        {
            return Name + " " + LastName;
        }
    }
    public IList<SubjectDto> SubjectsAttended { get; set; } = new List<SubjectDto>();

    public static StudentDto Create(Student student)
    {
        var dto = new StudentDto();
        dto.Id = student.Id;
        dto.UserName = student.UserName;
        dto.Name = student.Name;
        dto.LastName = student.LastName;

        
        foreach (Subject s in student.SubjectsAttended)
        {
            dto.SubjectsAttended.Add(SubjectDto.Create(s));
        }

        return dto;
    }

}
