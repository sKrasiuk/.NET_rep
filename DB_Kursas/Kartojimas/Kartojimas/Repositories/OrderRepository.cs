using System;
using Kartojimas.Entities;
using Kartojimas.Entities.Db;

namespace Kartojimas.Repositories;

public class OrderRepository : GenericRepository<Order>
{
    public OrderRepository(GenericDbContext dbContext) : base(dbContext) { }
}
