using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using vShop.Apps.Application.Commands.Products;
using vShop.Apps.Application.DTOs;

namespace vShop.Apps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<Results<Ok<ProductDto>, BadRequest<string>, ProblemHttpResult>> Post(CreateProductCommand command)
        {
            var product = await _mediator.Send(command);
            if (product == null)
            {
                return TypedResults.Problem(detail: "Create Product failed to process", statusCode: 500);
            }
            return TypedResults.Ok(product);
        }

        [HttpPut]
        public async Task<Results<Ok<ProductDto>, BadRequest<string>, ProblemHttpResult>> Put(UpdateProductCommand command)
        {
            var product = await _mediator.Send(command);
            if (product == null)
            {
                return TypedResults.Problem(detail: "Update Product failed to process", statusCode: 500);
            }
            return TypedResults.Ok(product);
        }
    }
}
