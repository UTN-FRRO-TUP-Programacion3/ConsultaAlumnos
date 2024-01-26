using System.ComponentModel.DataAnnotations;

namespace ConsultaAlumnos.Application.Models.Requests
{
    public class QuestionCreateRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int ProfessorId { get; set; }
        [Required]
        public int SubjectId { get; set; }
    }
}
