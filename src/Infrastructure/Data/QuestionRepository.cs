using ConsultaAlumnosClean.Domain.Entities;
using ConsultaAlumnosClean.Domain.Enums;
using ConsultaAlumnosClean.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConsultaAlumnosClean.Infrastructure.Data
{
    public class QuestionRepository : Repository, IQuestionRepository
    {
        public QuestionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void AddQuestion(Question newQuestion)
        {
            _context.Questions.Add(newQuestion);
        }

        public Question? GetQuestion(int questionId)
        {
            return _context.Questions
                .Include(q => q.AssignedProfessor)
                .Include(q => q.Student)
                .FirstOrDefault(c => c.Id == questionId);
        }

        public bool IsQuestionIdValid(int questionId)
        {
            return _context.Questions.Any(q => q.Id == questionId);
        }

        public IOrderedQueryable<Question> GetPendingQuestions(int userId, bool withResponses)
        {
            if (withResponses)
                return _context.Questions
                    .Include(q => q.Responses).ThenInclude(r => r.Creator)
                    .Where(q => q.ProfessorId == userId && q.QuestionState == QuestionState.WaitingProfessorAnwser)
                    .OrderBy(q => q.LastModificationDate);
            return _context.Questions
                .Where(q => q.ProfessorId == userId && q.QuestionState == QuestionState.WaitingProfessorAnwser)
                .OrderBy(q => q.LastModificationDate);
        }
    }
}
