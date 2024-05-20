using ConsultaAlumnos.Domain.Entities;

namespace ConsultaAlumnos.Application.Models;

public class ResponseDto
{
    public int Id { get; set; }
    public string Message { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public UserDto Creator { get; set; }


    public static ResponseDto Create(Response response)
    {
        var dto = new ResponseDto();
        dto.Id = response.Id;
        dto.Message = response.Message;
        dto.CreationDate = response.CreationDate;
        dto.Creator = UserDto.Create(response.Creator);

        return dto;
    }

}
