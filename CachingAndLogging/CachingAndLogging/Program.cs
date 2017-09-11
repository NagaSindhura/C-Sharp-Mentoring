using System;
using System.Linq;
using System.Threading;
using CachingAndLogging.Data;
using Microsoft.Practices.ObjectBuilder2;

namespace CachingAndLogging
{
    public class Program
    {
        public static void Main()
        {
            log4net.Config.BasicConfigurator.Configure();

            DataSource dataSource = new DataSource();

            dataSource.Customers.ToList()
                .ForEach(Customer => Console.WriteLine(new { A = Customer.CustomerId.ToString() + Customer.Address }));

            dataSource.Customers.ToList()
                .ForEach(Customer => Console.WriteLine(new { A = Customer.CustomerId.ToString() + Customer.Address }));

            Thread.Sleep(3000);

            dataSource.Customers.ToList()
                .ForEach(Customer => Console.WriteLine(new { A = Customer.CustomerId.ToString() + Customer.Address }));

            dataSource.Products.ToList()
                .Take(10)
                .ForEach(Product => Console.WriteLine(new { A = Product.ProductId.ToString() + Product.ProductName }));

            dataSource.Products.ToList()
                .Take(10)
                .ForEach(Product => Console.WriteLine(new { A = Product.ProductId.ToString() + Product.ProductName }));

            Console.ReadLine();
        }
    }
}