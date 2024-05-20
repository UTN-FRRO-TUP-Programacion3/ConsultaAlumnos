using ConsultaAlumnos.Domain.Entities;

namespace ConsultaAlumnos.Application.Models;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string CompleteName { get => Name + " " + LastName; }

    public static UserDto Create(User user)
    {
        var dto = new UserDto();
        dto.Id = user.Id;
        dto.Name = user.Name;
        dto.LastName = user.LastName;

        return dto;
    }

}