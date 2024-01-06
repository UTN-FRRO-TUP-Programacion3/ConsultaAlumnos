using AutoMapper;
using ConsultaAlumnosClean.Application.Interfaces;
using ConsultaAlumnosClean.Application.Models;
using ConsultaAlumnosClean.Domain.Interfaces;


namespace ConsultaAlumnosClean.Application.Services;
public class ProfessorService : IProfessorService
{
    private readonly IMapper _mapper;
    private readonly IQuestionRepository _questionRepository;

    public ProfessorService(IMapper mapper, IQuestionRepository questionRepository)
    {
        _mapper = mapper;
        _questionRepository = questionRepository;
    }
    public ICollection<QuestionDto> GetPendingQuestions(int userId, bool withResponses)
    {
        var questions = _questionRepository.GetPendingQuestions(userId, withResponses);
        return _mapper.Map<List<QuestionDto>>(questions);
    }
}
