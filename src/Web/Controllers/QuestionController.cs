
using ConsultaAlumnosClean.Application.Interfaces;
using ConsultaAlumnosClean.Application.Models;
using ConsultaAlumnosClean.Application.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ConsultaAlumnosClean.Web.Controllers;

[Route("api/question")]
[ApiController]
[Authorize]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService _questionService;

    public QuestionController(IQuestionService questionService)
    {
        this._questionService = questionService;
    }

    [HttpGet("{questionId}", Name = "GetQuestion")]
    public ActionResult<QuestionDto> GetQuestion(int questionId)
    {
        int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");

        var question = _questionService.GetQuestion(questionId);

        if (question is null)
            return NotFound();

        if (question.CreatorStudentId  != userId && question.ProfessorId != userId)
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
    public ActionResult<QuestionDto> ChangeQuestionStatus(int questionId, QuestionStatusUpdateRequest newStatus)
    {
        int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");

        _questionService.ChangeQuestionStatus(questionId, newStatus.Status, userId);

        return NoContent();
    }
}
