using System;
using System.Collections.Generic;

namespace Logic.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();
            for (int i = 0; i < 1000000; i++)
            {
                list.Add(new Product("Philips", new Random().NextDecimal()));
                list.Add(new Product("Sony", new Random().NextDecimal()));
                list.Add(new Product("Canon", new Random().NextDecimal()));
            }
            
            IEnumerable<Product> result = ProductService.FindCheapest(list, "Philips");
            var count = 0;
            foreach(var item in result)
            {
                Console.WriteLine(item.ToString());
                count++;
            }

            Console.WriteLine($"There were {count} elements with the lowest price");
        }
    }
}
