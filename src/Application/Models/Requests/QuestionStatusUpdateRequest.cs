using ConsultaAlumnosClean.Domain.Enums;

namespace ConsultaAlumnosClean.Application.Models.Requests
{
    public class QuestionStatusUpdateRequest
    {
        public QuestionState Status { get; set; }
    }
}
