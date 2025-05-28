using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductService.DataAccess.Dtos;
using ProductService.Examples;
using ProductService.Mediator.Product.CreateProduct;
using ProductService.Mediator.Product.GetProduct;
using ProductService.Mediator.Product.UpdateStock;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace ProductService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    [SwaggerOperation("Get Product")]
    [SwaggerResponseExample((int)HttpStatusCode.OK,typeof(GetProductExample))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "Product not found")]
    [SwaggerResponse((int)HttpStatusCode.OK, "Product found", typeof(ProductDto))]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await mediator.Send(new GetProductQuery(id));

        if (product is null)
        {
            return NotFound(product);
        }
        

        return Ok(product);

    }

    [HttpPost]
    [SwaggerOperation("Create Product")]
    [SwaggerRequestExample(typeof(ProductDto), typeof(CreateProductExample))]
    [SwaggerResponseExample(201,typeof(GetProductExample))]
    [SwaggerResponse((int)HttpStatusCode.Created, "Product created", typeof(ProductDto))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "Invalid product data")]
    [SwaggerResponse(400,"Bad Request")]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDto dto)
    {
        await mediator.Send(new CreateProductCommand(dto));

        return Ok();
    }

    [HttpPut("{id}/stock")]
    [SwaggerOperation("Update Product Stock")]
    [SwaggerResponse(400,"Bad Request")]
    public async Task<IActionResult> UpdateStock(int id, [FromBody] int stock)
    {
        await mediator.Send(new UpdateStockCommand(id, stock));

        return NoContent();
    }


}
