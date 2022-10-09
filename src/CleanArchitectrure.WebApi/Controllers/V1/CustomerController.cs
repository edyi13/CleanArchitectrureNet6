using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using CleanArchitectrure.Application.UseCases.Customers.Queries.GetAllCustomerQuery;

namespace CleanArchitectrure.WebApi.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _mediator.Send(new GetAllCustomerQuery());
            if (response.succcess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

    }
}
