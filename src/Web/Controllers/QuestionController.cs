
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
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if (!int.TryParse(userIdClaim, out int userId))
        {
            return Unauthorized();
        }

        var qustion = _questionService.GetQuestion(questionId);

        if (qustion is null)
            return NotFound();

        if (qustion.CreatorStudentId != userId)
            return Forbid();

        return Ok(qustion);
    }

    [HttpPost]
    public ActionResult<QuestionDto> CreateQuestion(QuestionCreateRequest newQuestion)
    {
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if (!int.TryParse(userIdClaim, out int userId))
        {
            return Unauthorized();
        }

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
        _questionService.ChangeQuestionStatus(questionId, newStatus.Status);

        return NoContent();
    }
}
