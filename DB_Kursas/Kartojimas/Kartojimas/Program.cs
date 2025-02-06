using Kartojimas.Entities;
using Kartojimas.Entities.Db;
using Kartojimas.Repositories;

namespace Kartojimas;

class Program
{
    static void Main(string[] args)
    {
        var dbContext = new GenericDbContext();
        var orderRepository = new OrderRepository(dbContext);
        var orderItemRepository = new OrderItemRepository(dbContext);

        // orderRepository.Save(new Order());
        // orderRepository.Find(x => x.DateCreated == new DateTime());
    }
}
