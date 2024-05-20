
using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Domain.Interfaces;

namespace ConsultaAlumnos.Application.Services;
public class ProfessorService : IProfessorService
{

    private readonly IQuestionRepository _questionRepository;

    public ProfessorService(IQuestionRepository questionRepository)
    {

        _questionRepository = questionRepository;
    }
    public ICollection<QuestionDto> GetPendingQuestions(int userId, bool withResponses)
    {
        var questions = _questionRepository.GetPendingQuestions(userId, withResponses);
 
        return QuestionDto.CreateList(questions);
    }
}
