using ConsultaAlumnosClean.Application.Interfaces;
using ConsultaAlumnosClean.Application.Models;
using ConsultaAlumnosClean.Application.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ConsultaAlumnosClean.Web.Controllers;

[ApiController]
[Authorize]
[Route("api/question/{questionId}/response")]
public class ResponseController : ControllerBase
{
    private readonly IResponseService _responseService;
    private readonly IQuestionService _questionService;

    public ResponseController(IResponseService responseService, IQuestionService questionService)
    {
        _responseService = responseService;
        this._questionService = questionService;
    }

    [HttpGet("{responseId}", Name = "GetResponse")]
    public ActionResult<ResponseDto> GetResponse(int responseId)
    {
        var response = _responseService.GetResponse(responseId);

        if (response is null)
            return NotFound();

        return Ok(response);
    }

    [HttpPost]
    public IActionResult CreateResponse(int questionId, ResponseCreateRequest responseCreateRequest)
    {
      
        int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");

        var newResponse = _responseService.CreateResponse(responseCreateRequest, questionId, userId);

        return CreatedAtRoute(
            "GetResponse",
            new { questionId = questionId, responseId = newResponse.Id },
            newResponse);
    }
}
