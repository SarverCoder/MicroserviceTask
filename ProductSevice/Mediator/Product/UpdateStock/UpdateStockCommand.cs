using MediatR;
using ProductService.Repository.Interfaces;

namespace ProductService.Mediator.Product.UpdateStock;

public class UpdateStockCommand(int id, int stock) : IRequest
{
    public int Id { get; } = id;
    public int Stock { get; } = stock;
}


public class UpdateStockCommandHandler(IProductRepository repository) : IRequestHandler<UpdateStockCommand>
{
    public async Task Handle(UpdateStockCommand request, CancellationToken cancellationToken)
    {
        var product = await repository.GetByIdAsync(request.Id);

        product.Stock = request.Stock;

        await repository.SaveChangesAsync();

    }
}