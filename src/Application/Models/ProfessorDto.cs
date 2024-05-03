using ConsultaAlumnos.Domain.Entities;
using System.Runtime.InteropServices;

namespace ConsultaAlumnos.Application.Models;

public class ProfessorDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string CompleteName { get => Name + " " + LastName; }

    public static ProfessorDto Create(Professor professor)
    {
        var dto = new ProfessorDto();
        dto.Id = professor.Id;
        dto.UserName = professor.UserName;
        dto.Name = professor.Name;
        dto.LastName = professor.LastName;

        return dto;

    }

}