using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace ConsultaAlumnos.Web.Controllers;

[ApiController]
[Authorize]
[Route("api/professor")]
public class ProfessorController : ControllerBase
{
    private readonly IProfessorService _professorService;

    public ProfessorController(IProfessorService professorService)
    {
        _professorService = professorService;
    }

    [HttpGet("pendingquestions")]
    public ActionResult<ICollection<QuestionDto>> GetPendingQuestions(bool withResponses = false)
    {
        int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
        var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

        if (userRole != typeof(Professor).Name)
            return Forbid();

        return _professorService.GetPendingQuestions(userId, withResponses).ToList();

    }
}
