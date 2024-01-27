
using ConsultaAlumnos.Domain.Entities;

namespace ConsultaAlumnos.Domain.Interfaces;

public interface IQuestionRepository : IRepositoryBase<Question>
{

    IOrderedQueryable<Question> GetPendingQuestions(int userId, bool withResponses);

    bool IsQuestionIdValid(int questionId);

    Task<Question?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<Response?> GetResponseByQuestionIdAndResponseId(int questionId, int  responseId, CancellationToken cancellationToken = default);

}