using System.ComponentModel.DataAnnotations;

namespace ConsultaAlumnos.API.Models.Responses
{
    public class ResponseCreateRequest
    {
        [Required]
        [MaxLength(2000)]
        public string Message { get; set; } = string.Empty;
    }
}
