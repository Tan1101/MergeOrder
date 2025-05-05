using System;
using System.Collections.Generic;
using System.Linq;

public class Order
{
    public string OrderId { get; set; }
    public string Address { get; set; }
    public List<string> Products { get; set; }
}

public class MergedOrder
{
    public string Address { get; set; }
    public List<string> OrderIds { get; set; } = new List<string>();
    public List<string> Products { get; set; } = new List<string>();
}

public class Program
{
    public static void Main()
    {
        var orders = new List<Order>
        {
            new Order { OrderId = "01", Address = "Tan Minh", Products = new List<string> { "Product 1", "Product 1.1" } },
            new Order { OrderId = "02", Address = "Dich Vong", Products = new List<string> { "Product 2" } },
            new Order { OrderId = "03", Address = "Nguyen Xien", Products = new List<string> { "Product 3" } },
            new Order { OrderId = "04", Address = "Dich Vong", Products = new List<string> { "Product 4", "Product 4.1" } },
            new Order { OrderId = "05", Address = "Cau Giay", Products = new List<string> { "Product 5", "Product 5.1" } },
            new Order { OrderId = "06", Address = "Dich Vong", Products = new List<string> { "Product 6" } },
        };

        Console.WriteLine("Merge order by Dictionary:");
        var result1 = MergeOrdersByDictionary(orders);
        PrintMergedOrders(result1);

        Console.WriteLine("\nMerge order by LINQ:");
        var result2 = MergeOrdersByLinq(orders);
        PrintMergedOrders(result2);
    }



    public static List<MergedOrder> MergeOrdersByDictionary(List<Order> orders)
    {
        var dict = new Dictionary<string, MergedOrder>();

        foreach (var order in orders)
        {
            if (!dict.ContainsKey(order.Address))
            {
                dict[order.Address] = new MergedOrder { Address = order.Address };
            }

            dict[order.Address].OrderIds.Add(order.OrderId);
            dict[order.Address].Products.AddRange(order.Products);
        }

        return dict.Values.ToList();
    }

    public static List<MergedOrder> MergeOrdersByLinq(List<Order> orders)
    {
        return orders
            .GroupBy(o => o.Address)
            .Select(group => new MergedOrder
            {
                Address = group.Key,
                OrderIds = group.Select(o => o.OrderId).ToList(),
                Products = group.SelectMany(o => o.Products).ToList()
            })
            .ToList();
    }

    public static void PrintMergedOrders(List<MergedOrder> mergedOrders)
    {
        foreach (var merged in mergedOrders)
        {
            Console.WriteLine($"Address: {merged.Address}");
            Console.WriteLine($"Order IDs: {string.Join(", ", merged.OrderIds)}");
            Console.WriteLine($"Products: {string.Join(", ", merged.Products)}");
            Console.WriteLine("----------------------");
        }
    }
}