using ProductService.DataAccess.Dtos;
using Swashbuckle.AspNetCore.Filters;

namespace ProductService.Examples;

public class CreateProductExample : IExamplesProvider<ProductDto>
{

    public ProductDto GetExamples()
    {
        return new ProductDto
        {
            Name = "Sample Product",
            Stock = 100
        };
    }

}

public class GetProductExample : IExamplesProvider<ProductDto>
{
    public ProductDto GetExamples()
    {
        return new ProductDto
        {
            Id = 1,
            Name = "Sample Product",
            Stock = 100
        };
    }
}
