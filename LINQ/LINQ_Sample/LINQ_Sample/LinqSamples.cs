using System;
using System.Linq;
using Task.Data;
using Task.Helpers.ResizerApp.Helpers;
using System.Collections;

namespace Task
{
    public class LinqSamples
    {
        private readonly DataSource _dataSource = new DataSource();

        public delegate string Boundaries(decimal price);

        public void Linq001(decimal amount)
        {
            var customers =
                _dataSource.Customers.Where(
                        customer => customer.Orders != null && customer.Orders.Sum(order => order.Total) > amount)
                    .Select(customer => customer.CompanyName);

            MessageHelper.InfoMessage($"Linq001 : Total turnover exceeds {amount} amount");

            DisplayData(customers);
        }

        public void Linq002()
        {
            MessageHelper.InfoMessage("Linq002. customer and Customer are from same city, Country list");

            MessageHelper.InfoMessage("Results using Join");

            var cutomerAndSupplierUsingJoin = _dataSource.Customers.Join(
                _dataSource.Suppliers,
                customer => new { customer.Country, customer.City },
                supplier => new { supplier.Country, supplier.City },
                (customer, supplier) => new { customer.CompanyName, supplier.SupplierName });

            DisplayData(cutomerAndSupplierUsingJoin);

            MessageHelper.InfoMessage("Results using Grouping");

            var cutomerAndSupplierUsingGrouping =
                _dataSource.Customers.Join(
                        _dataSource.Suppliers,
                        customer => new { customer.Country, customer.City },
                        supplier => new { supplier.Country, supplier.City },
                        (customer, supplier) =>
                                new
                                {
                                    customer.CompanyName,
                                    supplier.SupplierName,
                                    customer.Country,
                                    customer.City
                                })
                    .GroupBy(p => new { p.Country, p.City })
                    .Select(q => new { q.Key, persons = q.ToList() });


            foreach (var group in cutomerAndSupplierUsingGrouping)
            {
                Console.WriteLine();
                MessageHelper.InfoMessage(group.Key.ToString());
                Console.WriteLine();

                group.persons.ForEach(p => MessageHelper.InfoMessage($"{p.CompanyName}, {p.SupplierName}"));
            }
        }

        public void Linq003(decimal amount)
        {
            MessageHelper.InfoMessage($"Linq003. list of Cutomers who have orders that exceed the amount of {amount}");

            var customers =
                _dataSource.Customers.Where(
                        customer => customer.Orders != null && customer.Orders.Any(order => order.Total > amount))
                    .Select(customer => customer.CompanyName);

            DisplayData(customers);
        }

        public void Linq004()
        {
            MessageHelper.InfoMessage(
                $"Linq004. list of customers indicating which month of the year they became clients");

            var customers =
                _dataSource.Customers.Select(
                    customer =>
                        new
                        {
                            customer.CompanyName,
                            Month =
                                customer.Orders.Where(p => true)
                                    .OrderByDescending(p => p.OrderDate)
                                    .FirstOrDefault()?.OrderDate.Month
                        });

            DisplayData(customers);
        }

        public void Linq005()
        {
            MessageHelper.InfoMessage(
                "list of customers indicating which month of the year they became clients and orted by year, month, client turnover and customer name");

            var customers =
                _dataSource.Customers.Select(
                        customer =>
                            new
                            {
                                customer.CompanyName,
                                OrderedDate =
                                    customer.Orders.Where(p => true)
                                        .OrderByDescending(p => p.OrderDate)
                                        .FirstOrDefault()?.OrderDate,
                                Turnover = customer.Orders.Where(o => o != null).Sum(o => o.Total)
                            })
                                .Where(p => p.OrderedDate != null)
                    .OrderByDescending(p => p.OrderedDate.Value.Year)
                    .ThenByDescending(p => p.OrderedDate.Value.Month)
                    .ThenByDescending(p => p.Turnover)
                    .ThenByDescending(p => p.CompanyName);

            DisplayData(customers);
        }

        public void Linq006()
        {
            MessageHelper.InfoMessage(
                "List of customers who have a non-numeric code or are not filled in the region or the phone does not have an operator code");

            var customers = _dataSource.Customers.Where(s =>
                {
                    var defaultNumaric = 0;
                    return !int.TryParse(s.PostalCode, out defaultNumaric) || string.IsNullOrEmpty(s.Region) || !s.Phone.StartsWith("(");
                });

            customers.ToList()
                .ForEach(
                    p =>
                        MessageHelper.InfoMessage(
                            $@"CompanyName = {p.CompanyName}, PostalCode= {p.PostalCode}, Region = {p
                                .Region}, Phone = {p.Phone}"));
        }

        public void Linq007()
        {
            MessageHelper.InfoMessage(" Product boundaries: cheap: >= 0 and <= 10, average price : >10 and <= 50, expensive >50");
            //TODO: NAming should be boundary
            Boundaries Boundary = (price) =>
                {
                    if (price >= 0 && price <= 10)
                    {
                        return "cheap";
                    }
                    else if (price > 10 && price <= 50)
                    {
                        return "average price";
                    }

                    return "expensive";
                };

            var data = _dataSource.Products.GroupBy(p => Boundary(p.UnitPrice)).Select(p => new { p.Key, list = p.ToList() });

            foreach (var group in data)
            {
                Console.WriteLine();
                MessageHelper.InfoMessage(group.Key);
                Console.WriteLine();

                group.list.ForEach(p => MessageHelper.InfoMessage($"{p.ProductName}"));
            }
        }

        private static void DisplayData(IEnumerable customers)
        {
            foreach (var customer in customers)
            {
                MessageHelper.InfoMessage(customer.ToString());
            }
        }
    }
}