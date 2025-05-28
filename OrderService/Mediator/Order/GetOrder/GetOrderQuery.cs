using MediatR;
using OrderService.DataAccess.Dtos;
using OrderService.Repository.Interfaces;

namespace OrderService.Mediator.Order.GetOrder;

public class GetOrderQuery(int id) : IRequest<OrderDto>
{
    public int Id { get; } = id;
}


public class GerOrderQueryHandler(IOrderRepository repository) : IRequestHandler<GetOrderQuery, OrderDto>
{
    public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await repository.GetByIdAsync(request.Id);

        if (order == null)
        {
            return null; // or throw an exception if you prefer
        }

        return new OrderDto()
        {
            Id = order.Id,
            ProductId = order.ProductId,
            CreatedAt = order.CreatedAt
        };

    }
}