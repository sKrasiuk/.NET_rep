using System;
using System.Collections;
using System.Globalization;
using Restoranas.Models;

namespace Restoranas.Repositories;

public class MenuRepository : IEnumerable<MenuItem>
{
    public MenuRepository()
    {
        GetAllMenuItems();
    }

    private readonly string filePathFood = "Food.txt";
    private readonly string filePathDrinks = "Drinks.txt";

    private List<MenuItem> GetAllMenuItems()
    {
        var menuItems = new List<MenuItem>();

        var foodItems = GetAllFood();
        var drinkItems = GetAllDrinks();

        menuItems.AddRange(foodItems);
        menuItems.AddRange(drinkItems);

        return menuItems;
    }

    private List<Food> GetAllFood()
    {
        var lines = File.ReadAllLines(filePathFood);
        var foods = new List<Food>();

        foreach (var line in lines)
        {
            var values = line.Split(',');
            foods.Add(new Food
            {
                Name = values[0],
                Price = decimal.Parse(values[1], CultureInfo.InvariantCulture),
            });
        }
        return foods;
    }

    private List<Drink> GetAllDrinks()
    {
        var lines = File.ReadAllLines(filePathDrinks);
        var drinks = new List<Drink>();
        foreach (var line in lines)
        {
            var values = line.Split(',');
            drinks.Add(new Drink
            {
                Name = values[0],
                Price = decimal.Parse(values[1], CultureInfo.InvariantCulture),
            });
        }
        return drinks;
    }

    public IEnumerator<MenuItem> GetEnumerator()
    {
        return GetAllMenuItems().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
