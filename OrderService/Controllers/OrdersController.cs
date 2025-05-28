using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderService.DataAccess.Dtos;
using OrderService.Mediator.Order.GetOrder;
using System.Text;
using OrderService.Examples;
using OrderService.Mediator.Order.CreateOrder;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace OrderService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{

    private readonly IMediator _mediator;
    private readonly HttpClient _httpClient;

    public OrdersController(IMediator mediator,IHttpClientFactory httpClientFactory)
    { 
        _mediator = mediator;
        _httpClient = httpClientFactory.CreateClient("ProductService");
    }


    [HttpPost]
    [SwaggerOperation("Create Order")]
    [SwaggerResponseExample(201,typeof(GetOrderExample))]
    [SwaggerResponse(404, "Product not found")]
    [SwaggerResponse(400, "Out of stock")]
    public async Task<IActionResult> CreateOrder([FromBody] int productId)
    {
        var res = await _httpClient.GetAsync($"api/Products/{productId}");
        if (!res.IsSuccessStatusCode) return NotFound("Product not found");

        var product = JsonConvert.DeserializeObject<ProductDto>(await res.Content.ReadAsStringAsync());
        if (product.Stock < 1) return BadRequest("Out of stock");


        var stockUpdate = new StringContent(product.Stock - 1 + "", Encoding.UTF8, "application/json");
        var putRes = await _httpClient.PutAsync($"api/Products/{productId}/stock", stockUpdate);
        if (!putRes.IsSuccessStatusCode) return StatusCode(500, "Stock update failed");

        await _mediator.Send(new CreateOrderCommand(productId));

        return Ok("Order created successfully");


    }




    [HttpGet("{id}")]
    [SwaggerOperation("Get Order by Id")]
    [SwaggerResponseExample(200, typeof(GetOrderExample))]
    [SwaggerResponse(404, "Order not found")]
    [SwaggerResponse(200, "Order found", typeof(OrderDto))]
    public async Task<IActionResult> GetOrder(int id)
    {

        var order = await _mediator.Send(new GetOrderQuery(id));

        return Ok(order);

    }


}
