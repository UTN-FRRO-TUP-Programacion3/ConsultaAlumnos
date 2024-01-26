using ConsultaAlumnos.Application.Models;

namespace ConsultaAlumnos.Application.Interfaces;

public interface IProfessorService
{
    ICollection<QuestionDto> GetPendingQuestions(int userId, bool withResponses);
}
