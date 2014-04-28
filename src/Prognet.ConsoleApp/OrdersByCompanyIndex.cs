using System.Linq;
using Raven.Client.Indexes;

namespace Prognet.ConsoleApp
{
    class Orders_ByCompany : AbstractIndexCreationTask<Order, OrdersByCompany>
    {
        public Orders_ByCompany()
        {
            Map = orders =>
                from order in orders
                select new
                {
                    order.Company,
                    Count = 1,
                    Total = order.Lines.Sum(l => (decimal)l.Quantity * (decimal)l.PricePerUnit * (1M - (decimal)l.Discount))
                };

            Reduce = results =>
                from result in results
                group result by result.Company
                    into g
                    select new
                    {
                        Company = g.Key,
                        Count = g.Sum(x => x.Count),
                        Total = g.Sum(x => x.Total)
                    };
        }
    }

    internal class OrdersByCompany
    {
        public Company Company { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
    }
}
