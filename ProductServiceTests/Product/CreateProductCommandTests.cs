using AutoFixture;
using Moq;
using Moq.AutoMock;
using ProductService.DataAccess.Dtos;
using ProductService.Mediator.Product.CreateProduct;
using ProductService.Repository.Interfaces;

namespace ProductService.Tests.Product;

public class CreateProductCommandTests
{

    private readonly AutoMocker _mocker = new();
    private readonly Fixture _fixture = new ();

    public CreateProductCommandTests()
    {
        
    }


    [Fact]
    public async Task CreateProductCommand_ValidInput_ShouldSuccess()
    {
        // Arrange
        var request = _fixture.Create<ProductDto>();

        var command = new CreateProductCommand(request);

        var handler = _mocker.CreateInstance<CreateProductCommandHandler>();

       

        // Act
        await handler.Handle(command, CancellationToken.None);

       

        _mocker.GetMock<IProductRepository>()
            .Verify(r => r.AddAsync(It.IsAny<DataAccess.Entities.Product>()), Times.Once);

        _mocker.GetMock<IProductRepository>()
            .Verify(r => r.SaveChangesAsync(), Times.Exactly(1));




    }






}
