using Logic.TestConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic._2.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Service service = new Service();
            for (int i = 0; i < 1000000; i++)
            {
                service.Add(new Product("Philips", new Random().NextDecimal()));
                service.Add(new Product("Sony", new Random().NextDecimal()));
                service.Add(new Product("Canon", new Random().NextDecimal()));
            }

            ProductData data = service.Find("Sony");

            Console.WriteLine($"Minimal Cost: {data.minCoast}, Count of such products: {data.number}");

        }
    }
}
