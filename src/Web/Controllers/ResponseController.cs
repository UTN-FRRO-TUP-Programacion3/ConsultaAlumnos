﻿using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Application.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ConsultaAlumnos.Web.Controllers;

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
        _questionService = questionService;
    }

    [HttpGet("{responseId}", Name = "GetResponse")]
    public ActionResult<ResponseDto> GetResponse(int responseId)
    {
        var response = _responseService.GetResponse(responseId);

        if (response is null)
            return NotFound();

        return Ok(response);
    }

    
}
