using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using RestaurantSystem.Models;

namespace RestaurantSystem.Services
{
    public class MenuService
    {
        private List<MenuItem> _menuItems = new List<MenuItem>();

        public void LoadMenuItems(string foodFile, string drinksFile)
        {
            _menuItems.Clear();
            _menuItems.AddRange(LoadItemsFromFile(foodFile, MenuItemType.Food));
            _menuItems.AddRange(LoadItemsFromFile(drinksFile, MenuItemType.Drink));
        }

        private List<MenuItem> LoadItemsFromFile(string filePath, MenuItemType type)
        {
            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException($"Menu file not found: {filePath}");
            }

            var items = new List<MenuItem>();
            var lines = File.ReadAllLines(fullPath);

            foreach (var line in lines)
            {
                var parts = line.Split(',').Select(p => p.Trim()).ToArray();
                if (parts.Length != 3)
                {
                    throw new FormatException($"Invalid line format in {filePath}: {line}");
                }

                if (!int.TryParse(parts[0], out int id))
                {
                    throw new FormatException($"Invalid ID format in {filePath}: {parts[0]}");
                }

                if (!decimal.TryParse(parts[2], out decimal price))
                {
                    throw new FormatException($"Invalid price format in {filePath}: {parts[2]}");
                }

                var menuItem = new MenuItem
                {
                    Id = id,
                    Name = parts[1],
                    Price = price,
                    Type = type
                };

                items.Add(menuItem);
            }

            return items;
        }

        public List<MenuItem> GetMenuItems(MenuItemType? type = null)
        {
            return type.HasValue
                ? _menuItems.Where(m => m.Type == type.Value).ToList()
                : _menuItems;
        }
    }
}
