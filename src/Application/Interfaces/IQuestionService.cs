

using ConsultaAlumnosClean.Application.Models;
using ConsultaAlumnosClean.Application.Models.Requests;
using ConsultaAlumnosClean.Domain.Enums;

namespace ConsultaAlumnosClean.Application.Interfaces;

public interface IQuestionService
{
    QuestionDto CreateQuestion(QuestionCreateRequest newQuestion, int userId);
    QuestionDto GetQuestion(int questionId);
    bool IsQuestionIdValid(int questionId);
    void ChangeQuestionStatus(int questionId, QuestionState status, int userId);

}