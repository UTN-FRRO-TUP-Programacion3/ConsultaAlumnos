using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ConsultaAlumnosClean.Web.Controllers;

[Route("api/subject")]
[ApiController]
[Authorize]
public class SubjectController : ControllerBase
{
}
