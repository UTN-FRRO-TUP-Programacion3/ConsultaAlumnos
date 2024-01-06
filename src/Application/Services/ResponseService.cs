using AutoMapper;
using ConsultaAlumnos.API.Models.Responses;
using ConsultaAlumnosClean.Application.Interfaces;
using ConsultaAlumnosClean.Application.Models;
using ConsultaAlumnosClean.Domain.Entities;
using ConsultaAlumnosClean.Domain.Interfaces;
using System.Runtime.CompilerServices;


namespace ConsultaAlumnosClean.Application.Services;

public class ResponseService : IResponseService
{
    private readonly IMapper _mapper;
    private readonly IResponseRepository _responseRepository;
    private readonly IQuestionService _questionService;
    private readonly IUserRepository _userRepository;

    public ResponseService(IMapper mapper, IResponseRepository responseRepository, IQuestionService questionService, IUserRepository userRepository)
    {
        this._mapper = mapper;
        this._responseRepository = responseRepository;
        this._questionService = questionService;
        this._userRepository = userRepository;
    }
    public ResponseDto CreateResponse(ResponseCreateRequest newResponse, int questionId, int userId)
    {
        var user = _userRepository.GetUserById(userId)
            ?? throw new Exception("User not found");

        var response = _mapper.Map<Response>(newResponse);

        response.QuestionId = questionId;
        response.CreatorId = userId;

        _responseRepository.AddResponse(response);
        _responseRepository.SaveChanges();

        _questionService.ChangeQuestionStatus(questionId,user.UserType);

        return _mapper.Map<ResponseDto>(response);
    }

    public ResponseDto? GetResponse(int responseId)
    {
        var response = _responseRepository.GetResponse(responseId);
        return _mapper.Map<ResponseDto>(response);
    }
}
