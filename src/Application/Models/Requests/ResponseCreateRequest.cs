using System.ComponentModel.DataAnnotations;

namespace ConsultaAlumnos.Application.Models.Requests
{
    public class ResponseCreateRequest
    {
        [Required]
        [MaxLength(2000)]
        public string Message { get; set; } = string.Empty;
    }
}
