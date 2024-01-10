using System.ComponentModel.DataAnnotations;

namespace ConsultaAlumnosClean.Application.Models.Requests
{
    public class ResponseCreateRequest
    {
        [Required]
        [MaxLength(2000)]
        public string Message { get; set; } = string.Empty;
    }
}
