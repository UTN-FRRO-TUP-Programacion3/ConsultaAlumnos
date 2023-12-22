namespace ConsultaAlumnosClean.Application.Models;


public class SubjectDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<ProfessorDto> Professors { get; set; } = new List<ProfessorDto>();

}

