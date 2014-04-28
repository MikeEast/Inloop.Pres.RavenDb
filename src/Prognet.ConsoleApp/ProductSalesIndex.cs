using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
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

    class Product_Transformer : AbstractTransformerCreationTask<ProductSales>
    {
        public Product_Transformer()
        {
            TransformResults = sales =>
                from s in sales
                select new
                {
                    Product = LoadDocument<Product>(s.Product),
                    Count = s.Count,
                    Total = s.Total
                };
        }
    }

    class ProductSales
    {
        public string Product { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
    }

    class ProductSalesView
    {
        public Product Product { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
    }


    /*
     Usage:
     * 
        var results = session.Query<ProductSales, Product_Sales>()
                        .TransformWith<Product_Transformer, ProductSalesView>()
                        .ToList();

        foreach (var productSalesView in results)
        {
            Console.WriteLine(productSalesView.AsJson());
        }
     */
}
