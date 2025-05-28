using MediatR;
using ProductService.DataAccess.Dtos;
using ProductService.Repository.Interfaces;

namespace ProductService.Mediator.Product.GetProduct;

public class GetProductQuery(int id) : IRequest<ProductDto>
{
    public int Id { get; } = id;
}


public class GetProductQueryHandler(IProductRepository repository) : IRequestHandler<GetProductQuery, ProductDto>
{
    public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await repository.GetByIdAsync(request.Id);



        return new ProductDto()
        {
            Id = product.Id,
            Name = product.Name,
            Stock = product.Stock
        };


    }
}