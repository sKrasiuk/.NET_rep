using NUnit.Framework;
using Restoranas.Models;

namespace NUnitTests;

public class OrderTests
{
    private Order _order;
    private MenuItem _sampleMenuItem;

    [SetUp]
    public void Setup()
    {
        _order = new Order();
        _sampleMenuItem = new Food
        {
            Name = "Test Item",
            Price = 10.00m
        };
    }

    [Test]
    public void TestAddItem_BasicScenario()
    {
        // Arrange
        int quantity = 2;

        // Act
        _order.AddItem(_sampleMenuItem, quantity);

        // Assert
        Assert.That(_order.Items.Count, Is.EqualTo(1));
        Assert.That(_order.Items[0].Item, Is.EqualTo(_sampleMenuItem));
        Assert.That(_order.Items[0].Quantity, Is.EqualTo(quantity));
    }

    [Test]
    public void TestAddItem_MultipleItems()
    {
        // Arrange
        var secondMenuItem = new Drink
        {
            Name = "Second Item",
            Price = 15.00m
        };

        // Act
        _order.AddItem(_sampleMenuItem, 1);
        _order.AddItem(secondMenuItem, 2);

        // Assert
        Assert.That(_order.Items.Count, Is.EqualTo(2));
        Assert.That(_order.Items[0].Item.Name, Is.EqualTo("Test Item"));
        Assert.That(_order.Items[1].Item.Name, Is.EqualTo("Second Item"));
    }

    [Test]
    public void TestAddItem_SameItemMultipleTimes()
    {
        // Act
        _order.AddItem(_sampleMenuItem, 1);
        _order.AddItem(_sampleMenuItem, 2);

        // Assert
        Assert.That(_order.Items.Count, Is.EqualTo(2));
        Assert.That(_order.Items.Sum(i => i.Quantity), Is.EqualTo(3));
    }

    [Test]
    public void TestAddItem_WithZeroQuantity()
    {
        // Act
        _order.AddItem(_sampleMenuItem, 0);

        // Assert
        Assert.That(_order.Items.Count, Is.EqualTo(1));
        Assert.That(_order.Items[0].Quantity, Is.EqualTo(0));
    }
}