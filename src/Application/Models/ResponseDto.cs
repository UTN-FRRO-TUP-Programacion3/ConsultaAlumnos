

using ConsultaAlumnosClean.Domain.Entities;

namespace ConsultaAlumnosClean.Application.Models
{
    public class ResponseDto
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public UserDto Creator { get; set; }
    }
}
