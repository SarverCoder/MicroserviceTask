using OrderService.DataAccess;
using OrderService.DataAccess.Entities;
using OrderService.Repository.Interfaces;

namespace OrderService.Repository;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(OrderDbContext context) : base(context)
    {
    }
}

