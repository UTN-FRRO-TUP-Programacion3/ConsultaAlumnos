using AutoMapper;
using ConsultaAlumnosClean.Application.Interfaces;
using ConsultaAlumnosClean.Application.Models;
using ConsultaAlumnosClean.Application.Models.Requests;
using ConsultaAlumnosClean.Domain.Entities;
using ConsultaAlumnosClean.Domain.Interfaces;
using System.Runtime.CompilerServices;


namespace ConsultaAlumnosClean.Application.Services;

public class ResponseService : IResponseService
{
    private readonly IMapper _mapper;
    private readonly IRepositoryBase<Response> _responseRepository;
    private readonly IQuestionRepository _questionRepository;

    public ResponseService(IMapper mapper, IRepositoryBase<Response> responseRepository, IQuestionRepository questionRepository)
    {
        _mapper = mapper;
        _responseRepository = responseRepository;
        _questionRepository = questionRepository;
    }
    public ResponseDto CreateResponse(ResponseCreateRequest responseCreateRequest, int questionId, int userId)
    {
        var response = _mapper.Map<Response>(responseCreateRequest);

        response.QuestionId = questionId;
        response.CreatorId = userId;

        Question? question = _questionRepository.GetByIdAsync(questionId).Result
            ?? throw(new Exception("Question not found"));

        question.AddResponse(response, userId);

        _ = _questionRepository.SaveChangesAsync().Result;

        return _mapper.Map<ResponseDto>(response);
    }

    public ResponseDto? GetResponse(int responseId)
    {
        var response = _responseRepository.GetByIdAsync(responseId).Result;
        return _mapper.Map<ResponseDto>(response);
    }
}
