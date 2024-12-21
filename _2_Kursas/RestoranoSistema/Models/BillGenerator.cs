using System;

namespace RestoranoSistema.Models;

public class BillGenerator
{
    public static (Bill, Bill) GenerateChecks(Order order)
    {
        // Generate two checks: one for the restaurant and one for the customer
        var restaurantReceipt = new Bill(order);
        var customerReceipt = new Bill(order);

        // Add items to the checks
        foreach (var product in order.Products)
        {
            restaurantReceipt.AddItem(product);
            customerReceipt.AddItem(product);
        }

        return (restaurantReceipt, customerReceipt);
    }
}
