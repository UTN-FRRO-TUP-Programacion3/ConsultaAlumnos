using AutoMapper;
using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Application.Models.Requests;
using ConsultaAlumnos.Domain.Entities;
using ConsultaAlumnos.Domain.Interfaces;
using System.Runtime.CompilerServices;


namespace ConsultaAlumnos.Application.Services;

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
            ?? throw (new Exception("Question not found"));

        question.AddResponse(response);

        _ = _questionRepository.SaveChangesAsync().Result;

        return _mapper.Map<ResponseDto>(response);
    }

    public ResponseDto? GetResponse(int responseId)
    {
        var response = _responseRepository.GetByIdAsync(responseId).Result;
        return _mapper.Map<ResponseDto>(response);
    }
}
