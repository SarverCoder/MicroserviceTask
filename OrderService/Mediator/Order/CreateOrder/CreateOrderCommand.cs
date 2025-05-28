using MediatR;
using OrderService.Repository.Interfaces;

namespace OrderService.Mediator.Order.CreateOrder;

public class CreateOrderCommand(int productId) : IRequest
{
    public int ProductId { get; } = productId;
}


public class CreateOrderCommandHandler(IOrderRepository repository) : IRequestHandler<CreateOrderCommand>
{
    public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new DataAccess.Entities.Order
        {
            ProductId = request.ProductId
        };
        await repository.AddAsync(order);
        await repository.SaveChangesAsync();


    }
}