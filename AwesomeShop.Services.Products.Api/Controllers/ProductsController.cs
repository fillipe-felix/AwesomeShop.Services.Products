using System;
using System.Threading.Tasks;
using AwesomeShop.Services.Products.Application.Commands;
using AwesomeShop.Services.Products.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeShop.Services.Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var query = new GetAllProductsQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id) {
            var query = new GetProductByIdQuery(id);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddProductCommand command) {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateProductCommand command) {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}