using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Application.Models.Requests;
using ConsultaAlumnos.Domain.Enums;

namespace ConsultaAlumnos.Application.Interfaces;

public interface IQuestionService
{
    QuestionDto CreateQuestion(QuestionCreateRequest newQuestion, int userId);
    QuestionDto GetQuestion(int questionId);
    bool IsQuestionIdValid(int questionId);
    void ChangeQuestionStatus(int questionId, QuestionState status, int userId);

    ResponseDto CreateResponse(ResponseCreateRequest newResponse, int questionId, int userId);

}