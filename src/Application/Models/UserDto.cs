namespace ConsultaAlumnos.Application.Models;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string CompleteName { get => Name + " " + LastName; }
}