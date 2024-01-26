using AutoMapper;
using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Domain.Interfaces;

namespace ConsultaAlumnos.Application.Services;
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
