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
    private readonly IRepositoryBase<Response> _responseRepository;
    private readonly IQuestionService _questionService;
    private readonly IUserRepository _userRepository;

    public ResponseService(IMapper mapper, IRepositoryBase<Response> responseRepository, IQuestionService questionService, IUserRepository userRepository)
    {
        this._mapper = mapper;
        this._responseRepository = responseRepository;
        this._questionService = questionService;
        this._userRepository = userRepository;
    }
    public ResponseDto CreateResponse(ResponseCreateRequest newResponse, int questionId, int userId)
    {
        var user = _userRepository.GetByIdAsync(userId).Result
            ?? throw new Exception("User not found");

        var response = _mapper.Map<Response>(newResponse);

        response.QuestionId = questionId;
        response.CreatorId = userId;

        _ = _responseRepository.AddAsync(response).Result;
        _ = _responseRepository.SaveChangesAsync().Result;

        _questionService.ChangeQuestionStatus(questionId,user.UserType);

        return _mapper.Map<ResponseDto>(response);
    }

    public ResponseDto? GetResponse(int responseId)
    {
        var response = _responseRepository.GetByIdAsync(responseId).Result;
        return _mapper.Map<ResponseDto>(response);
    }
}
