using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client.Indexes;

namespace Prognet.ConsoleApp
{
    class Orders_Totals : AbstractIndexCreationTask<Order>
    {
        public Orders_Totals()
        {
            Map = orders =>
                from order in orders
                select new
                {
                    order.Employee,
                    order.Company,
                    Total = order.Lines.Sum(l => ((decimal)l.Quantity * (decimal)l.PricePerUnit) * (1 - (decimal)l.Discount))
                };
        }
    }
}
