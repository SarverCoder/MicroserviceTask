using MediatR;
using ProductService.DataAccess.Dtos;
using ProductService.Repository.Interfaces;

namespace ProductService.Mediator.Product.CreateProduct;

public class CreateProductCommand(ProductDto product) : IRequest
{
    public ProductDto Product { get; } = product;
}


public class CreateProductCommandHandler(IProductRepository repository) : IRequestHandler<CreateProductCommand>
{
    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new DataAccess.Entities.Product
        {
            Name = request.Product.Name,
            Stock = request.Product.Stock
        };

        await repository.AddAsync(product);

        await repository.SaveChangesAsync();

    }
}
