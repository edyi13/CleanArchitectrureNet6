using CleanArchitectrure.Application.UseCases.Users.Commands.CreateUserCommand;
using CleanArchitectrure.Application.UseCases.Users.Queries.AuthUserQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectrure.WebApi.Controllers.V1
{
    //[Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    //[ApiVersion("1.0", Deprecated = true)]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Insert")]
        public async Task<ActionResult> InsertAsync([FromBody] CreateUserCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPost("Auth")]
        public async Task<ActionResult> AuthAsycn([FromBody] AuthUserQuery query)
        {
            var response = await _mediator.Send(query);
            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }
    }
}
