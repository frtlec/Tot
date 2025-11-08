using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tot.Application.Dtos.Commands;
using Tot.Application.Dtos.Queries;
using Tot.Application.Dtos.Responses;
using Tot.Shared.BaseControllers;
using Tot.Shared.Reponses;

namespace Tot.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class QuestionController : BaseController
{
    private readonly IMediator _mediator;

    public QuestionController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    [ProducesResponseType(typeof(ServiceResponse<List<QuestionPoolResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new QuestionPoolGetAllQuery());
        return Response(result);
    }
    [HttpPost]
    [ProducesResponseType(typeof(ServiceResponse<QuestionPoolResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody] CreateQuestionPoolCommand command)
    {
        var result = await _mediator.Send(command);
        return Response(result);
    }
}
