using NUnit.Framework;
using Restoranas.Models;

namespace NUnitTests;

public class WaiterTests
{
    private Waiter _waiter;
    private Table _table;

    [SetUp]
    public void Setup()
    {
        _waiter = new Waiter { Id = 1, Name = "Test Waiter" };
        _table = new Table { Id = 1, Seats = 4 };
    }

    [Test]
    public void CreateOrder_ShouldAddOrderToWaitersList()
    {
        var order = _waiter.CreateOrder(_table);
        Assert.That(_waiter.Orders, Does.Contain(order));
    }

    [Test]
    public void CreateOrder_ShouldCreateNewOrderWithCorrectProperties()
    {
        // Act
        var order = _waiter.CreateOrder(_table);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(order.AssignedWaiter, Is.EqualTo(_waiter));
            Assert.That(order.AssignedTable, Is.EqualTo(_table));
            Assert.That(order.IsActive, Is.True);
            Assert.That(_waiter.Orders, Does.Contain(order));
        });
    }

    [Test]
    public void CloseOrder_ShouldSetOrderToInactive()
    {
        // Arrange
        var order = _waiter.CreateOrder(_table);

        // Act
        _waiter.CloseOrder(order);

        // Assert
        Assert.That(order.IsActive, Is.False);
    }
}
