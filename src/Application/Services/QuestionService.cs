

using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Application.Models.Requests;
using ConsultaAlumnos.Domain.Entities;
using ConsultaAlumnos.Domain.Enums;
using ConsultaAlumnos.Domain.Exceptions;
using ConsultaAlumnos.Domain.Interfaces;

namespace ConsultaAlumnos.Application.Services;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMailService _mailService;
    private readonly IStudentRepository _studentRepository;
    private readonly IRepositoryBase<Professor> _professorRepository;
    private readonly IUserRepository _userRepository;
    private readonly IRepositoryBase<Subject> _subjectRepository;


    public QuestionService(
        IQuestionRepository questionRepository,
        IMailService mailService,
        IStudentRepository studentRepository,
        IRepositoryBase<Professor> professorRepository,
        IUserRepository userRepository,
        IRepositoryBase<Subject> subjectRepository)
    {
        _questionRepository = questionRepository;
        _mailService = mailService;
        _studentRepository = studentRepository;
        _professorRepository = professorRepository;
        _userRepository = userRepository;
        _subjectRepository = subjectRepository;
    }

    public QuestionDto CreateQuestion(QuestionCreateRequest questionCreateRequest, int userId)
    {
        var student = _studentRepository.GetByIdAsync(userId).Result ?? throw new NotFoundException(typeof(Student).ToString(), userId);
        var professor = _professorRepository.GetByIdAsync(questionCreateRequest.ProfessorId).Result 
            ?? throw new NotFoundException(typeof(Professor).ToString(), questionCreateRequest.ProfessorId);
        var subject = _subjectRepository.GetByIdAsync(questionCreateRequest.SubjectId).Result
            ?? throw new NotFoundException(typeof(Subject).ToString(), questionCreateRequest.SubjectId);

        var newQuestion = new Question(student,subject,professor);
        
        newQuestion.Title = questionCreateRequest.Title;
        newQuestion.Description = questionCreateRequest.Description;
  
        _questionRepository.AddAsync(newQuestion).Wait();
        if (_questionRepository.SaveChangesAsync().Result > 0)
            _mailService.Send("Se creó una nueva consulta",
                $"Usted tiene una nueva consulta asignada por parte del alumno: {student.Name} {student.LastName} ",
                professor.Email);

  
        return QuestionDto.Create(newQuestion);
    }

    public QuestionDto GetQuestion(int questionId)
    {
        var question = _questionRepository.GetByIdAsync(questionId).Result
            ?? throw new NotFoundException($"Question {questionId} not found");

        return QuestionDto.Create(question);
      
    }

    public ResponseDto GetResponse(int questionId, int responseId)
    {
        var response = _questionRepository.GetResponseByQuestionIdAndResponseId(questionId, responseId).Result
            ?? throw new NotFoundException($"Response {responseId} from question {questionId} not found");

        return ResponseDto.Create(response);
       
    }

    public bool IsQuestionIdValid(int questionId)
    {
        return _questionRepository.IsQuestionIdValid(questionId);
    }

    public void ChangeQuestionStatus(int questionId, QuestionState newStatus, int userId)
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

    public ResponseDto CreateResponse(ResponseCreateRequest responseCreateRequest, int questionId, int creatorUserId)
    {
        
        Question? question = _questionRepository.GetByIdAsync(questionId).Result
            ?? throw (new Exception("Question not found"));

        var responseCreator = _userRepository.GetByIdAsync(creatorUserId).Result
            ?? throw new NotFoundException("Response creator not found");

        Response response = new Response(question,responseCreator, responseCreateRequest.Message);

        question.AddResponse(response);
        _questionRepository.SaveChangesAsync().Wait();

        return ResponseDto.Create(response);

    }

}
