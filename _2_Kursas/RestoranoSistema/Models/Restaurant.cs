using System.Collections.Generic;

namespace RestoranoSistema.Models;

public class Restaurant
{
    public List<Table> Tables { get; set; }


    private TableRepository _tableRepository;
    private ProductRepository _productRepository;
    private WaiterRepository _waiterRepository;

    public Restaurant()
    {
        Tables = new List<Table>();
        _tableRepository = new TableRepository();
        _productRepository = new ProductRepository();
        _waiterRepository = new WaiterRepository();
    }

    public List<Table> GetTables()
    {
        return _tableRepository.GetTables();
    }
    public List<Product> GetProducts()
    {
        return _productRepository.GetProducts();
    }
    public List<Waiter> GetWaiters()
    {
        return _waiterRepository.GetWaiters();
    }
}