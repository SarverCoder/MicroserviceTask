using OrderService.DataAccess.Dtos;
using Swashbuckle.AspNetCore.Filters;

namespace OrderService.Examples;

public class GetOrderExample : IExamplesProvider<OrderDto>
{
    public OrderDto GetExamples()
    {
        return new OrderDto()
        {
            CreatedAt = DateTime.UtcNow,
            ProductId = 8
        };
    }
}
