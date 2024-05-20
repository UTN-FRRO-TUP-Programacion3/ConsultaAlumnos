
using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Application.Models.Requests;
using ConsultaAlumnos.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ConsultaAlumnos.Web.Controllers;

[Route("api/question")]
[ApiController]
[Authorize]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService _questionService;

    public QuestionController(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    [HttpGet("{questionId}", Name = "GetQuestion")]
    public ActionResult<QuestionDto> GetQuestion(int questionId)
    {
        int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");

        var question = _questionService.GetQuestion(questionId);

        if (question is null)
            return NotFound();

        if (question.Student.Id != userId && question.AssignedProfessor.Id != userId)
            return Forbid();

        return Ok(question);
    }

    [HttpPost]
    public ActionResult<QuestionDto> CreateQuestion(QuestionCreateRequest newQuestion)
    {
        int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");

        var createdQuestion = _questionService.CreateQuestion(newQuestion, userId);

        return CreatedAtRoute(//CreatedAtRoute es para q devuelva 201, el 200 de post.
            "GetQuestion", //El primer parámetro es el Name del endpoint que hace el Get
            new //El segundo los parametros q necesita ese endpoint
            {
                questionId = createdQuestion.Id
            },
            createdQuestion);//El tercero es el objeto creado. 
    }

    [HttpPut("{questionId}/changestatus")]
    public ActionResult<QuestionDto> ChangeQuestionStatus(int questionId, QuestionStatusUpdateRequest questionStatusUpdateRequest)
    {
        int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");

        _questionService.ChangeQuestionStatus(questionId, questionStatusUpdateRequest.Status, userId);

        return NoContent();
    }

    [HttpPost("{questionId}/CreateResponse")]
    public IActionResult CreateResponse(int questionId,ResponseCreateRequest responseCreateRequest)
    {

        int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");

        var newResponse = _questionService.CreateResponse(responseCreateRequest, questionId, userId);

        return CreatedAtRoute(
            "GetResponse",
            new { questionId, responseId = newResponse.Id },
            newResponse);
    }
}
