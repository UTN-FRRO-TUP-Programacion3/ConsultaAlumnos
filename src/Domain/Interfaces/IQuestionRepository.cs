
using ConsultaAlumnosClean.Domain.Entities;

namespace ConsultaAlumnosClean.Domain.Interfaces
{
    public interface IQuestionRepository : IRepository
    {
        void AddQuestion(Question newQuestion);
        IOrderedQueryable<Question> GetPendingQuestions(int userId, bool withResponses);
        Question? GetQuestion(int questionId);
        bool IsQuestionIdValid(int questionId);
    }
}