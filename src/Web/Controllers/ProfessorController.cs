using ConsultaAlumnosClean.Application.Interfaces;
using ConsultaAlumnosClean.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace ConsultaAlumnosClean.Web.Controllers;

[ApiController]
[Authorize]
[Route("api/professor")]
public class ProfessorController : ControllerBase
{
    private readonly IProfessorService _professorService;

    public ProfessorController(IProfessorService professorService)
    {
        this._professorService = professorService;
    }

    [HttpGet("pendingquestions")]
    public ActionResult<ICollection<QuestionDto>> GetPendingQuestions(bool withResponses = false)
    {
        var user = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
        if (userRole != "profesor")
            return Forbid();

        return _professorService.GetPendingQuestions(int.Parse(user), withResponses).ToList();

    }
}
