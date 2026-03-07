using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPractice
{
    class Item
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Category { get; set; }
        public Item(string name, double weight, string category)
        {
            Name = name;
            Weight = weight;
            Category = category;
        }

    }
    class Container
    {
        public string ContainerId { get; set; }
        public List<Item> Items = new List<Item>();
        public Container(string containerId, List<Item> l)
        {
            ContainerId = containerId;
            Items = l;

        }
    }
    internal class CargoBay
    {
        static void Main(string[] args)
        {
            var cargoBay = new List<List<Container>>
            {
                new List<Container>
                {
                    new Container("C001", new List<Item>{
                        new Item("Laptop",2.5,"Tech"),
                        new Item("Monitor",5.0,"Tech"),
                        new Item("Smartphone",0.5,"Tech")
                    }),
                    new Container("C104",new List<Item>
                    {
                        new Item("Sever Rack",45.0,"Tech"),
                        new Item("Cables",1.2,"Tech")
                    })
                },
                    new List<Container>
                {
                    new Container("C002", new List<Item>
                    {
                        new Item("Apple", 0.2, "Food"),
                        new Item("Banana", 0.2, "Food"),
                        new Item("Milk", 1.0, "Food")
                    }),
                    new Container("C003", new List<Item>
                    {
                        new Item("Table", 15.0, "Furniture"),
                        new Item("Chair", 7.5, "Furniture")
                    })
                },
                        // ROW 2: Fragile & Perishables (Includes an Empty Container)
                new List<Container>
                {
                    new Container("C205", new List<Item>
                    {
                        new Item("Vase", 3.0, "Decor"),
                        new Item("Mirror", 12.0, "Decor")
                    }),
                    new Container("C206", new List<Item>()) // EDGE CASE: Container with no items
                },
                    new List<Container>() // A row that exists but has no containers
                };



        }
        static List<string> findheavyContainers(List<List<Container>> cb, double tweight)
        {
            //return cb.SelectMany(x=>x??new List<Container>()).Where(container=>container.Items??new List<Item>()
            //    .Sum(item=>item.Weight)>tweight).Select(c=>c.ContainerId).ToList();
            return cb
        .SelectMany(row => row ?? new List<Container>())
        .Where(container => (container.Items ?? new List<Item>())
            .Sum(item => item.Weight) > tweight)
        .Select(container => container.ContainerId)
        .ToList();
        }
        static public Dictionary<string, int> GetItemCountsByCategory(List<List<Container>>Cargo)
        {
            return Cargo
                .SelectMany(row => row ?? new List<Container>())
                .SelectMany(container => container.Items ?? new List<Item>())
                .GroupBy(item => item.Category)
                .ToDictionary(g => g.Key, g => g.Count());
        }
        static List<Item> FlattenAndSortShipment(List<List<Container>> cb)
        {
            return cb
                .SelectMany(row => row ?? new List<Container>())
                .SelectMany(container => container.Items ?? new List<Item>())
                .GroupBy(item => item.Name)
                .Select(g => g.First())
                .OrderBy(item => item.Category)
                .ThenByDescending(item => item.Weight)
                .ToList();
        }
    }
}

