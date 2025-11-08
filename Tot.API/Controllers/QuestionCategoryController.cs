using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tot.Application.Dtos.Queries;
using Tot.Application.Dtos.Responses;
using Tot.Shared.BaseControllers;
using Tot.Shared.Reponses;

namespace Tot.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class QuestionCategoryController : BaseController
{
    private readonly IMediator _mediator;

    public QuestionCategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    [ProducesResponseType(typeof(ServiceResponse<List<QuestionPoolCategoriesResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllActive()
    {
        var result = await _mediator.Send(new QuestionPoolCategoriesListActiveQuery());
        return Response(result);
    }
}
