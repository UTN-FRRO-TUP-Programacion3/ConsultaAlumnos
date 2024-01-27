using ConsultaAlumnos.Domain.Entities;
using ConsultaAlumnos.Domain.Enums;
using ConsultaAlumnos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace ConsultaAlumnos.Infrastructure.Data;

public class QuestionRepository : EfRepository<Question>, IQuestionRepository
{
    public QuestionRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Question?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Questions
            .Include(q => q.AssignedProfessor)
            .Include(q => q.Student)
            .SingleOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public bool IsQuestionIdValid(int questionId)
    {
        return _context.Questions.Any(q => q.Id == questionId);
    }

    public IOrderedQueryable<Question> GetPendingQuestions(int userId, bool withResponses)
    {
        if (withResponses)
        {
            return _context.Questions
                .Include(q => q.Responses).ThenInclude(r => r.Creator)
                .Where(q => q.AssignedProfessor.Id == userId && q.QuestionState == QuestionState.WaitingProfessorAnwser)
                .OrderBy(q => q.LastModificationDate);
        }
        else
        { 
        return _context.Questions
            .Where(q => q.AssignedProfessor.Id == userId && q.QuestionState == QuestionState.WaitingProfessorAnwser)
            .OrderBy(q => q.LastModificationDate);
        }
    }

    public Task<Response?> GetResponseByQuestionIdAndResponseId(int questionId, int responseId, CancellationToken cancellationToken = default)
    {
        return _context.Responses
            .Include(q => q.Creator)
            .Where(q => q.Question.Id == questionId && q.Id == responseId)
            .SingleOrDefaultAsync();
    }
}
