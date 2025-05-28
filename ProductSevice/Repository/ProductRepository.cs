using ProductService.DataAccess;
using ProductService.DataAccess.Entities;
using ProductService.Repository.Interfaces;

namespace ProductService.Repository
{
    public class ProductRepository : Repository<Product> , IProductRepository
    {
        public ProductRepository(ProductDbContext context) : base(context)
        {
        }
    }
    
}
