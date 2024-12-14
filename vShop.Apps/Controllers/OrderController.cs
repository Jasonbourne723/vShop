using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using vShop.Apps.Application.Commands.Orders;

namespace vShop.Apps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<Results<Ok<long>, BadRequest<string>, ProblemHttpResult>> Post(CreateOrderCommand command)
        {
            var orderId = await _mediator.Send(command);
            if (orderId == 0)
            {
                return TypedResults.Problem(detail: "Create Order failed to process", statusCode: 500);
            }
            return TypedResults.Ok(orderId);
        }
    }
}
