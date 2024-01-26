using ConsultaAlumnos.Domain.Enums;

namespace ConsultaAlumnos.Application.Models.Requests
{
    public class QuestionStatusUpdateRequest
    {
        public QuestionState Status { get; set; }
    }
}
