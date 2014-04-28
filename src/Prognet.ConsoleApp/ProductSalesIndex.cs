using System.Linq;
using Raven.Client.Indexes;

namespace Prognet.ConsoleApp
{
    class Product_Sales : AbstractIndexCreationTask<Order, ProductSales>
    {
        public Product_Sales()
        {
            Map = orders =>
                from order in orders
                from line in order.Lines
                select new
                {
                    Product = line.Product,
                    Count = 1,
                    Total = (((decimal)line.Quantity*(decimal)line.PricePerUnit)*(1 - (decimal)line.Discount))
                };

            Reduce = results =>
                from result in results
                group result by result.Product
                into g
                select new
                {
                    Product = g.Key,
                    Count = g.Sum(x => x.Count),
                    Total = g.Sum(x => x.Total)
                };
        }
    }

    internal class ProductSales
    {
        public Product Product { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
    }
}
