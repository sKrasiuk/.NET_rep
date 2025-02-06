using System;
using Kartojimas.Entities;
using Kartojimas.Entities.Db;

namespace Kartojimas.Repositories;

public class OrderItemRepository : GenericRepository<OrderItem>
{
    public OrderItemRepository(GenericDbContext dbContext) : base(dbContext) {}
}
