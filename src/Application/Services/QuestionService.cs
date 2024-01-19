

using AutoMapper;
using ConsultaAlumnosClean.Application.Interfaces;
using ConsultaAlumnosClean.Application.Models;
using ConsultaAlumnosClean.Application.Models.Requests;
using ConsultaAlumnosClean.Domain.Entities;
using ConsultaAlumnosClean.Domain.Enums;
using ConsultaAlumnosClean.Domain.Exceptions;
using ConsultaAlumnosClean.Domain.Interfaces;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace ConsultaAlumnosClean.Application.Services;

public class QuestionService : IQuestionService
{
    private readonly IMapper _mapper;
    private readonly IQuestionRepository _questionRepository;
    private readonly IMailService _mailService;
    private readonly IStudentRepository _studentRepository;
    private readonly IRepositoryBase<Professor> _professorRepository;
    

    public QuestionService(IMapper mapper,
        IQuestionRepository questionRepository,
        IMailService mailService,
        IStudentRepository studentRepository,
        IRepositoryBase<Professor> professorRepository)
    {
        _mapper = mapper;
        _questionRepository = questionRepository;
        _mailService = mailService;
        _studentRepository = studentRepository;
        _professorRepository = professorRepository;
    }

    public QuestionDto CreateQuestion(QuestionCreateRequest newQuestionDto, int userId)
    {
        var newQuestion = _mapper.Map<Question>(newQuestionDto);

        newQuestion.CreatorStudentId = userId;

        var student = _studentRepository.GetByIdAsync(userId).Result ?? throw new NotFoundException(typeof(Student).ToString(), userId);
        var professor = _professorRepository.GetByIdAsync(newQuestionDto.ProfessorId).Result ?? throw new NotFoundException(typeof(Professor).ToString(), newQuestionDto.ProfessorId);

        _ = _questionRepository.AddAsync(newQuestion).Result;
        if (_questionRepository.SaveChangesAsync().Result > 0)
            _mailService.Send("Se creó una nueva consulta",
                $"Usted tiene una nueva consulta asignada por parte del alumno: {student.Name} {student.LastName} ",
                professor.Email);

        return _mapper.Map<QuestionDto>(newQuestion);
    }

    public QuestionDto? GetQuestion(int questionId)
    {
        var question = _questionRepository.GetByIdAsync(questionId).Result;

        return _mapper.Map<QuestionDto?>(question);
    }

    public bool IsQuestionIdValid(int questionId)
    {
        return _questionRepository.IsQuestionIdValid(questionId);
    }

    public void ChangeQuestionStatus(int questionId, QuestionState newStatus,int userId)
    {
        var question = _questionRepository.GetByIdAsync(questionId).Result
            ?? throw new Exception("Question not found");

        question.ChangeQuestionStatus(newStatus, userId);

        if (_questionRepository.SaveChangesAsync().Result > 0)
            NotifyStatusChange(question);
    }

    private void NotifyStatusChange(Question question)
    {
        _mailService.Send("Se modificó el estado de una consulta",
            $"Usted tiene una notificación de su consulta: {question.Title}",
            question.Student.Email);

        _mailService.Send("Se modificó el estado de una consulta",
            $"La siguiente pregunta '{question.Title}' pasó a estado: {question.QuestionState.ToString()}",
            question.AssignedProfessor.Email);
    }

}
