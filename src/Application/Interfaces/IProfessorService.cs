

using ConsultaAlumnosClean.Application.Models;

namespace ConsultaAlumnosClean.Application.Interfaces;

public interface IProfessorService
{
    ICollection<QuestionDto> GetPendingQuestions(int userId, bool withResponses);
}
